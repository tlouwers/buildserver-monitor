using MetroFramework.Forms;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;


namespace BuildserverMonitor
{
    public partial class frmMain : MetroForm
    {
        public delegate void UpdateLBXMessagesCallback(String text);
        public AsyncCallback pfnWorkerCallBack;

        #region Fields

        private Socket clientSocket;
        private bool connected = false;

        #endregion

        #region UI Elements

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }
        
        private void btnConnection_Click(object sender, System.EventArgs e)
        {
            if (!connected)
            {
                try
                {
                    if (tbxPort.Text == "")
                    {
                        MessageBox.Show("Please enter a Port Number", "Client");
                        return;
                    }

                    Int32 port = Convert.ToInt32(tbxPort.Text);

                    // Establish the remote endpoint for the socket.  
                    IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");  
                    IPAddress ipAddress = ipHostInfo.AddressList[0];  
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, port); 

                    // Create a TCP/IP socket.  
                    clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp); 

                    // Connect to the remote endpoint.  
                    clientSocket.BeginConnect( remoteEP, new AsyncCallback(ConnectCallback), null);

                    SetBtnConnectionText("Disconnect");
                    connected = true;
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message, "Client");
                }
            }
            else
            {
                CloseConnection();

                SetBtnConnectionText("Connect");
                connected = false;
            }
        }

        private void btnSendToServer_Click(object sender, EventArgs e)
        {
            if (tbxSendToServer.Text.Length > 0)
            {
                try
                {
                    if ((clientSocket != null) && (clientSocket.Connected))
                    {
                        byte[] messageBuf = System.Text.Encoding.UTF8.GetBytes(tbxSendToServer.Text);

                        clientSocket.Send(messageBuf);
                        tbxSendToServer.Clear();
                    }
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message, "Client");
                }
            }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void ConnectCallback(IAsyncResult asyn)
        {
            try
            {
                // Complete the connection.  
                clientSocket.EndConnect(asyn);

                SetBtnConnectionText("Disconnect");
                connected = true;

                WaitForData();  // Wait for data asynchronously

                StringBuilder sb = new StringBuilder("Connected to server: ");
                sb.Append(clientSocket.RemoteEndPoint.ToString());
                MessageBox.Show(sb.ToString(), "Client");
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10061) // Error code for: Server refused connection (maybe not started)
                {
                    String msg = "Server unavailable.";
                    MessageBox.Show(msg, "Client");

                    CloseConnection();

                    connected = false;
                    SetBtnConnectionText("Connect");
                }
                else
                {
                    MessageBox.Show(se.Message, "Client");
                }
            }
        }

        public void WaitForData()
        {
            try
            {
                if (pfnWorkerCallBack == null)
                {
                    pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
                }

                SocketPacket theSocPkt = new SocketPacket(clientSocket, 0);

                // Start listening to the data asynchronously
                clientSocket.BeginReceive(theSocPkt.Data,
                                          0,
                                          theSocPkt.Data.Length,
                                          SocketFlags.None,
                                          pfnWorkerCallBack,
                                          theSocPkt);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message, "Client");
            }
        }

        public void OnDataReceived(IAsyncResult asyn)
        {
            SocketPacket theSocPkt = (SocketPacket)asyn.AsyncState;

            try
            {
                Int32 iRx = theSocPkt.Socket.EndReceive(asyn);
                System.Text.Decoder decoder = System.Text.Encoding.UTF8.GetDecoder();

                byte[] buffer = new byte[iRx];
                Array.Copy(theSocPkt.Data, 0, buffer, 0, iRx);

                System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                String szData = enc.GetString(buffer, 0, buffer.Length);

                AppendToLBXMessages(szData);

                WaitForData();
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10054) // Error code for: Connection reset by peer
                {
                    String msg = "Server disconnected.";
                    MessageBox.Show(msg, "Client");

                    CloseConnection();

                    connected = false;
                    SetBtnConnectionText("Connect");
                }
                else
                {
                    MessageBox.Show(se.Message, "Client");
                }
            }
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
                lbxMessages.BeginInvoke(new UpdateLBXMessagesCallback(OnUpdateLBXMessages), pList);
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
            lbxMessages.Items.Add(msg);
        }

        private void SetBtnConnectionText(string txt)
        {
            if (btnConnection.InvokeRequired)
                btnConnection.Invoke(new Action(() => btnConnection.Text = txt));
            else
                btnConnection.Text = txt;
        }

        private void CloseConnection()
        {
            if (clientSocket != null)
            {
                clientSocket.Close();
                clientSocket = null;
            }
        }

        #endregion
    }
}
