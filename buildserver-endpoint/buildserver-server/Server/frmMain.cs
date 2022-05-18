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

        // Thread signal.  
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        private Socket mainSocket;
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

                    // Get Host IP Address that is used to establish a connection
                    // In this case, we get one IP address of localhost that is IP : 127.0.0.1
                    // If a host has multiple addresses, you will get a list of addresses
                    IPHostEntry host = Dns.GetHostEntry("localhost");
                    IPAddress ipAddress = host.AddressList[0];
                    IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

                    // Create a Socket that will use Tcp protocol
                    mainSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    // A Socket must be associated with an endpoint using the Bind method
                    mainSocket.Bind(localEndPoint);
                    // Specify how many requests a Socket can listen before it gives Server busy response.
                    // We will listen 4 requests at a time
                    mainSocket.Listen(4);

                    mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);

                    btnConnection.Text = "Running";
                    connected = true;

                    // Wait until a connection is made (a client connects) before continuing.  
                    allDone.WaitOne();
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

        // This is the call back function, which will be invoked when a client is connected
        private void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                // Here we complete/end the BeginAccept() asynchronous call
                // by calling EndAccept() - which returns the reference to
                // a new Socket object
                Socket workerSocket = mainSocket.EndAccept(asyn);

                // Signal the main thread to continue.  
                allDone.Set(); 

                MessageBox.Show("Client connected");
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed.");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void CloseSockets()
        {
            if (mainSocket != null)
            {
                mainSocket.Close();
            }
        }

        #endregion
    }
}
