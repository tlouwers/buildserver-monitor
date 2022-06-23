using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace BuildserverMonitor
{
    public delegate void Server_ClientConnectedHandler(object sender, int clientId);
    public delegate void Server_ClientDisconnectedHandler(object sender, int clientId);

    public delegate void Server_ListeningHandler(object sender);
    public delegate void Server_ClosedHandler(object sender);
    public delegate void Server_DataReceivedHandler(object sender, byte[] data);
    public delegate void Server_ErrorHandler(object sender, string message);


    public class Server
    {
        #region Events

        public event Server_ClientConnectedHandler ClientConnected;
        public event Server_ClientDisconnectedHandler ClientDisconnected;
        public event Server_ListeningHandler Listening;
        public event Server_ClosedHandler Closed;
        public event Server_DataReceivedHandler DataReceived;
        public event Server_ErrorHandler Error;

        #endregion


        #region Fields

        private ConcurrentDictionary<int, Socket> mWorkerSocketDict = new ConcurrentDictionary<int, Socket>();
        private Int32 mClientIndex = 0;    // Ever incrementing Index as ID for the client(s) connecting to the Server
        private Socket mListenerSocket = null;
        private AsyncCallback mWorkerCallBack;

        #endregion


        #region Public Methods

        public bool Start(string server_ip, UInt16 port, bool useIpv6 = false)
        {
            if (server_ip.Length == 0) { return false; }
            if (port == 0) { return false; }

            try
            {
                // Get Host IP Address that is used to establish a connection
                // In this case, we get one IP address of localhost that is IP: 127.0.0.1
                // If a host has multiple addresses, you will get a list of addresses
                IPHostEntry host = Dns.GetHostEntry(server_ip);
                IPAddress ipAddress = null;
                foreach (var ip in host.AddressList)
                {
                    if (useIpv6 == true)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            ipAddress = ip;
                            break;
                        }
                    }
                    else
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddress = ip;
                            break;
                        }
                    }                   
                }
                if (ipAddress == null)
                {
                    throw new Exception("Server IP is not an IPv4 address");
                }
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

                // Create a Socket that will use the TCP protocol
                mListenerSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // Set LingerOption to false to be able to un-bind the socket later
                LingerOption lo = new LingerOption(false, 0);
                mListenerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, lo);
                // A Socket must be associated with an endpoint using the Bind method
                mListenerSocket.Bind(localEndPoint);
                // Specify how many requests a Socket can listen to before it gives
                // the 'Server busy' response. Per default we will listen to 10 requests at a time
                mListenerSocket.Listen(10);

                mListenerSocket.BeginAccept(new AsyncCallback(OnClientConnect), mListenerSocket);

                if (Listening != null)
                {
                    Listening(this);
                }

                return true;
            }
            catch (SocketException se)
            {
                if (Error != null)
                {
                    Error(this, se.Message);
                }
            }
            catch (Exception ex)
            {
                if (Error != null)
                {
                    Error(this, ex.Message);
                }
            }

            return false;
        }

        public void End()
        {
            foreach (var entry in mWorkerSocketDict)
            {
                Socket workerSocket = entry.Value;
                if (workerSocket != null)
                {
                    workerSocket.Close();
                    workerSocket = null;

                    if (ClientDisconnected != null)
                    {
                        ClientDisconnected(this, entry.Key);
                    }
                }
            }

            mWorkerSocketDict.Clear();

            mClientIndex = 0;

            if (mListenerSocket != null)
            {
                mListenerSocket.Close();
                mListenerSocket = null;

                if (Closed != null)
                {
                    Closed(this);
                }
            }
        }

        public bool Send(Int32 clientId, byte[] data)
        {
            if ((data != null) && (data.Length > 0))
            {
                try
                {
                    if (mWorkerSocketDict.ContainsKey(mClientIndex))
                    {
                        Socket workerSocket = null;
                        if (mWorkerSocketDict.TryGetValue(clientId, out workerSocket))
                        {
                            if (workerSocket.Connected)
                            {
                                workerSocket.Send(data);
                                return true;
                            }
                        }
                    }
                }
                catch (SocketException se)
                {
                    if (Error != null)
                    {
                        Error(this, se.Message);
                    }
                }
            }
            return false;
        }

        public int NumberOfClientsConnected
        {
            get
            {
                return mWorkerSocketDict.Count;
            }
        }

        #endregion


        #region Private Methods

        // This is the callback function, which will be invoked when a client connects
        private void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                Socket listener = (Socket)asyn.AsyncState;

                // Here we complete/end the BeginAccept() asynchronous call
                // by calling EndAccept() - which returns the reference to
                // a new Socket object
                Socket workerSocket = listener.EndAccept(asyn);

                // Now increment the client count for this client in a thread safe manner
                Interlocked.Increment(ref mClientIndex);

                // Add the client to the dictionary
                if (mWorkerSocketDict.ContainsKey(mClientIndex))
                {
                    if (Error != null)
                    {
                        Error(this, "Error: clientID already in dictionary.");
                    }
                }
                mWorkerSocketDict.TryAdd(mClientIndex, workerSocket);

                if (ClientConnected != null)
                {
                    ClientConnected(this, mClientIndex);
                }

                // Let the worker Socket do the further processing for the 
                // just connected client
                WaitForData(workerSocket, mClientIndex);

                // Since the main Socket is now free, it can go back and wait for
                // other clients who are attempting to connect
                listener.BeginAccept(new AsyncCallback(OnClientConnect), listener);
            }
            catch (ObjectDisposedException)
            {
                // Ignore: happens when disconnecting the server
            }
            catch (SocketException se)
            {
                if (Error != null)
                {
                    Error(this, se.Message);
                }
            }
            catch (Exception ex)
            {
                if (Error != null)
                {
                    Error(this, ex.Message);
                }
            }
        }

        private void WaitForData(Socket soc, Int32 clientId)
        {
            try
            {
                if (mWorkerCallBack == null)
                {
                    // Specify the call back function which is to be
                    // invoked when there is any write activity by the
                    // connected client
                    mWorkerCallBack = new AsyncCallback(OnDataReceived);
                }

                SocketPacket theSocPkt = new SocketPacket(soc, clientId);

                soc.BeginReceive(theSocPkt.Data,
                                 0,
                                 theSocPkt.Data.Length,
                                 SocketFlags.None,
                                 mWorkerCallBack,
                                 theSocPkt);
            }
            catch (SocketException se)
            {
                if (Error != null)
                {
                    Error(this, se.Message);
                }
            }
            catch (Exception ex)
            {
                if (Error != null)
                {
                    Error(this, ex.Message);
                }
            }
        }

        // This the callback function which will be invoked when the socket
        // detects any client writing of data on the stream
        private void OnDataReceived(IAsyncResult asyn)
        {
            int clientId = -1;

            try
            {
                SocketPacket socketData = (SocketPacket)asyn.AsyncState;
                clientId = socketData.ID;

                Int32 iRx = socketData.Socket.EndReceive(asyn);

                byte[] buffer = new byte[iRx];
                Array.Copy(socketData.Data, 0, buffer, 0, iRx);

                if (DataReceived != null)
                {
                    DataReceived(this, buffer);
                }

                // Continue the waiting for data on the Socket
                WaitForData(socketData.Socket, socketData.ID);
            }
            catch (ObjectDisposedException)
            {
                // Ignore: happens when disconnecting the server
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10054) // Error code for Connection reset by peer
                {
                    if (clientId != -1)
                    {
                        ClientDisconnect(clientId);
                    }
                    else
                    {
                        if (Error != null)
                        {
                            Error(this, se.Message);
                        }
                    }
                }
                else
                {
                    if (Error != null)
                    {
                        Error(this, se.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Error != null)
                {
                    Error(this, ex.Message);
                }
            }
        }

        private void ClientDisconnect(int clientId)
        {
            // Remove the reference to the worker socket of the closed client
            // so that this object will get garbage collected
            Socket workerSocket = null;
            if (mWorkerSocketDict.TryRemove(clientId, out workerSocket))
            {
                workerSocket.Close();
                workerSocket = null;

                if (ClientDisconnected != null)
                {
                    ClientDisconnected(this, clientId);
                }
            }
        }

        #endregion
    }
}
