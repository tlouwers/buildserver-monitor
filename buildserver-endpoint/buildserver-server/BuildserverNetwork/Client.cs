using System;
using System.Net;
using System.Net.Sockets;

namespace BuildserverMonitor
{
    public delegate void Client_ConnectedHandler(object sender, string server_ip);
    public delegate void Client_DisconnectedHandler(object sender);
    public delegate void Client_DataReceivedHandler(object sender, byte[] data);
    public delegate void Client_ErrorHandler(object sender, string message);


    public class Client
    {
        #region Events

        public event Client_ConnectedHandler Connected;
        public event Client_DisconnectedHandler Disconnected;
        public event Client_DataReceivedHandler DataReceived;
        public event Client_ErrorHandler Error;

        #endregion


        #region Fields

        private Socket mClientSocket = null;
        private AsyncCallback mWorkerCallBack;

        #endregion


        #region Public Methods

        public bool Connect(string server_ip, UInt16 port, bool useIpv6 = false)
        {
            if (server_ip.Length == 0) { return false; }
            if (port == 0) { return false; }

            try
            {
                // Establish the remote endpoint for the socket.  
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
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.  
                mClientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                mClientSocket.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), null);

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

        public void Disconnect()
        {
            if (mClientSocket != null)
            {
                mClientSocket.Close();
                mClientSocket = null;

                if (Disconnected != null)
                {
                    Disconnected(this);
                }
            }
        }

        public bool Send(byte[] data)
        {
            if ((data != null) && (data.Length > 0))
            {
                try
                {
                    if (mClientSocket.Connected)
                    {
                        mClientSocket.Send(data);
                        return true;
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

        #endregion


        #region Private Methods

        private void ConnectCallback(IAsyncResult asyn)
        {
            try
            {
                // Complete the connection.
                mClientSocket.EndConnect(asyn);

                if (Connected != null)
                {
                    Connected(this, mClientSocket.RemoteEndPoint.ToString());
                }

                WaitForData();  // Wait for data asynchronously
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10061) // Error code for: Server refused connection (maybe not started)
                {
                    if (Error != null)
                    {
                        Error(this, "Server unavailable.");
                    }

                    Disconnect();
                }
                else
                {
                    if (Error != null)
                    {
                        Error(this, se.Message);
                    }
                }
            }
        }

        private void WaitForData()
        {
            try
            {
                if (mWorkerCallBack == null)
                {
                    mWorkerCallBack = new AsyncCallback(OnDataReceived);
                }

                SocketPacket theSocPkt = new SocketPacket(mClientSocket, 0);

                // Start listening to the data asynchronously
                mClientSocket.BeginReceive(theSocPkt.Data,
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
        }

        private void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket theSocPkt = (SocketPacket)asyn.AsyncState;

                Int32 iRx = theSocPkt.Socket.EndReceive(asyn);

                byte[] buffer = new byte[iRx];
                Array.Copy(theSocPkt.Data, 0, buffer, 0, iRx);

                if (DataReceived != null)
                {
                    DataReceived(this, buffer);
                }

                WaitForData();
            }
            catch (ObjectDisposedException)
            {
                // Ignore: this happens when closing the connection from Client side.
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10054) // Error code for: Connection reset by peer
                {
                    if (Error != null)
                    {
                        Error(this, "Server disconnected.");
                    }

                    Disconnect();
                }
                else
                {
                    if (Error != null)
                    {
                        Error(this, se.Message);
                    }
                }
            }
        }

        #endregion
    }
}
