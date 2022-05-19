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
        public delegate void UpdateLBLNrClientsCallback(String text);

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

                    // Establish the remote endpoint for the socket.  
                    IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");  
                    IPAddress ipAddress = ipHostInfo.AddressList[0];  
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, port); 

                    // Create a TCP/IP socket.  
                    clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp); 

                    // Connect to the remote endpoint.  
                    clientSocket.BeginConnect( remoteEP, new AsyncCallback(ConnectCallback), null);  

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
                btnConnection.Text = "Connect";
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

                MessageBox.Show("Connected to server: {0}", clientSocket.RemoteEndPoint.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        } 

        private void CloseSockets()
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
