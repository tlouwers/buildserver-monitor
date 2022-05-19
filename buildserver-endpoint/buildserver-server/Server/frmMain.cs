using MetroFramework.Forms;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace BuildserverMonitor
{
    public partial class frmMain : MetroForm
    {
        public delegate void UpdateLBXMessagesCallback(String text);
        public delegate void UpdateLBLNrClientsCallback(String text);
        public AsyncCallback pfnWorkerCallBack;

        #region Fields

        private ArrayList workerSocketList = ArrayList.Synchronized(new System.Collections.ArrayList());
        private int clientCount = 0;
        private bool connected = false;

        #endregion

        #region UI Elements

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateLBLNrClientsConnected(System.Convert.ToString(0));
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseSockets();
        }
        
        private void btnConnection_Click(object sender, System.EventArgs e)
        {
            if (!connected)
            {
                try
                {
                    if (tbxPort.Text == "")
                    {
                        MessageBox.Show("Please enter a Port Number");
                        return;
                    }

                    Int32 port = Convert.ToInt32(tbxPort.Text);

                    // Get Host IP Address that is used to establish a connection
                    // In this case, we get one IP address of localhost that is IP: 127.0.0.1
                    // If a host has multiple addresses, you will get a list of addresses
                    IPHostEntry host = Dns.GetHostEntry("localhost");
                    IPAddress ipAddress = host.AddressList[0];
                    IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

                    // Create a Socket that will use the TCP protocol
                    Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    // A Socket must be associated with an endpoint using the Bind method
                    listener.Bind(localEndPoint);
                    // Specify how many requests a Socket can listen to before it gives
                    // the 'Server busy' response. Per default we will listen to 2 requests at a time
                    listener.Listen(2);

                    listener.BeginAccept(new AsyncCallback(OnClientConnect), listener);

                    btnConnection.Text = "Disconnect";
                    connected = true;
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message);
                }
            }
            else
            {
                CloseSockets();

                connected = false;
                btnConnection.Text = "Disconnected";

                // Cannot call .Bind() again: just restart the application
                btnConnection.Enabled = false;
            }
        }

        private void UpdateLBLNrClientsConnected(String msg)
        {
            if (lblNumberOfConnectedClientsValue.InvokeRequired)
            {
                lblNumberOfConnectedClientsValue.BeginInvoke(new UpdateLBLNrClientsCallback(OnUpdateLBLNrClients), msg);
            }
            else
            {
                OnUpdateLBLNrClients(msg);
            }
        }

        // This OnUpdateLBLNrClients will be run back on the UI thread
        // (using System.EventHandler signature so we don't need to
        // define a new delegate type here)
        private void OnUpdateLBLNrClients(String msg)
        {
            lblNumberOfConnectedClientsValue.Text = msg;
        }

        // This method could be called by either the main thread or any of the
        // worker threads
        private void AppendToLBXMessages(String msg)
        {
            // Check to see if this method is called from a thread 
            // other than the one created the control
            if (InvokeRequired)
            {
                // We cannot update the GUI on this thread.
                // All GUI controls are to be updated by the main (GUI) thread.
                // Hence we will use the invoke method on the control which will
                // be called when the Main thread is free
                // Do UI update on UI thread
                object[] pList = { msg };
                tbxMessages.BeginInvoke(new UpdateLBXMessagesCallback(OnUpdateLBXMessages), pList);
            }
            else
            {
                // This is the main thread which created this control, hence update it
                // directly 
                OnUpdateLBXMessages(msg);
            }
        }

        // This OnUpdateLBXMessages will be run back on the UI thread
        // (using System.EventHandler signature so we don't need to
        // define a new delegate type here)
        private void OnUpdateLBXMessages(String msg)
        {
            if (msg.Length > 0)
            {
                StringBuilder sb = new StringBuilder(tbxMessages.Text);
                sb.AppendLine(System.Environment.NewLine);
                sb.AppendLine(msg);
                tbxMessages.Text = sb.ToString();
            }
        }

        #endregion

        #region Public Methods

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

                // Add the workerSocket reference to our ArrayList
                workerSocketList.Add(workerSocket);

                // Now increment the client count for this client 
                // in a thread safe manner
                Interlocked.Increment(ref clientCount);
                UpdateLBLNrClientsConnected(System.Convert.ToString(clientCount));

                // Let the worker Socket do the further processing for the 
                // just connected client
                WaitForData(workerSocket, clientCount);

                // Since the main Socket is now free, it can go back and wait for
                // other clients who are attempting to connect
                listener.BeginAccept(new AsyncCallback(OnClientConnect), listener);
            }
            catch (ObjectDisposedException ode)
            {
                MessageBox.Show(ode.Message, "Socket closed");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        // Start waiting for data from the client
        private void WaitForData(Socket soc, Int32 clientNumber)
        {
            try
            {
                if (pfnWorkerCallBack == null)
                {
                    // Specify the call back function which is to be
                    // invoked when there is any write activity by the
                    // connected client
                    pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
                }

                SocketPacket theSocPkt = new SocketPacket(soc, clientNumber);

                soc.BeginReceive(theSocPkt.Data,
                                 0,
                                 theSocPkt.Data.Length,
                                 SocketFlags.None,
                                 pfnWorkerCallBack,
                                 theSocPkt);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        // This the callback function which will be invoked when the socket
        // detects any client writing of data on the stream
        private void OnDataReceived(IAsyncResult asyn)
        {
            SocketPacket socketData = (SocketPacket)asyn.AsyncState;

            try
            {
                if (socketData.Socket.Connected == false)
                {
                    ClientDisconnected(socketData.ID);
                }
                else
                {
                    // Complete the BeginReceive() asynchronous call by EndReceive() method
                    // which will return the number of characters written to the stream
                    // by the client
                    Int32 iRx = socketData.Socket.EndReceive(asyn);
                    byte[] buff = new byte[iRx + 1];

                    Array.Copy(socketData.Data, 0, buff, 0, iRx);

                    System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                    String szData = enc.GetString(buff);

                    if (szData == "\0")
                    {
                        ClientDisconnected(socketData.ID);
                    }
                    else
                    {
                        AppendToLBXMessages(szData);

                        // Continue the waiting for data on the Socket
                        WaitForData(socketData.Socket, socketData.ID);
                    }
                }
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10054) // Error code for Connection reset by peer
                {
                    ClientDisconnected(socketData.ID);
                }
                else
                {
                    MessageBox.Show(se.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClientDisconnected(int clientID)
        {
            String msg = "Client " + clientID + " Disconnected.";
            MessageBox.Show(msg);

            // Remove the reference to the worker socket of the closed client
            // so that this object will get garbage collected
            workerSocketList[clientID - 1] = null;
            Interlocked.Decrement(ref clientCount);
            UpdateLBLNrClientsConnected(System.Convert.ToString(clientCount));
        }

        private void CloseSockets()
        {
            Socket workerSocket = null;
            for (int i = 0; i < workerSocketList.Count; i++)
            {
                workerSocket = (Socket)workerSocketList[i];
                if (workerSocket != null)
                {
                    workerSocket.Close();
                    workerSocket = null;
                }
            }

            clientCount = 0;
            UpdateLBLNrClientsConnected(System.Convert.ToString(clientCount));
        }

        #endregion
    }
}
