using MetroFramework.Forms;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;


namespace BuildserverMonitor
{
    public partial class frmMain : MetroForm
    {
        #region Fields

        private Client mClient = new Client();
        private bool mConnected = false;

        
        private PacketParser mParser = new PacketParser();
        private ProtocolHandler mProtocol = new ProtocolHandler();

        #endregion


        #region UI Elements

        public frmMain()
        {
            InitializeComponent();

            mClient.Connected += client_Connected;
            mClient.Disconnected += client_Disconnected;
            mClient.DataReceived += client_DataReceived;
            mClient.Error += client_Error;

            mParser.ContentReceived += mParser_ContentReceived;
            mProtocol.Response += mProtocol_Response;

            mProtocol.VersionResponse += mProtocol_VersionResponse;
            mProtocol.LedAmountResponse += mProtocol_LedAmountResponse;
            mProtocol.LedGetResponse += mProtocol_LedGetResponse;
            mProtocol.LedSetResponse += mProtocol_LedSetResponse;

            // Led UI events
            mProtocol.LedColor += mProtocol_LedColor;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            mClient.Disconnect();
        }
        
        private void btnConnection_Click(object sender, System.EventArgs e)
        {
            if (!mConnected)
            {
                if (tbxAddress.Text.Length == 0)
                {
                    MessageBox.Show("Please enter a Server address", "Client");
                    return;
                }

                if (tbxPort.Text.Length == 0)
                {
                    MessageBox.Show("Please enter a Port Number", "Client");
                    return;
                }

                UInt16 port = Convert.ToUInt16(tbxPort.Text);

                mClient.Connect(tbxAddress.Text, port);
            }
            else
            {
                mClient.Disconnect();
            }
        }

        private void btnSendToServer_Click(object sender, EventArgs e)
        {
            if (tbxSendToServer.Text.Length > 0)
            {
                byte[] messageBuf = System.Text.Encoding.UTF8.GetBytes(tbxSendToServer.Text);

                mClient.Send(messageBuf);
            }
        }

        private void SetBtnConnectionText(string txt)
        {
            if (btnConnection.InvokeRequired)
            {
                btnConnection.Invoke(new Action(() => btnConnection.Text = txt));
            }
            else
            {
                btnConnection.Text = txt;
            }
        }

        private void AddLstBoxItems(string txt)
        {
            if (lstBox.InvokeRequired)
            {
                lstBox.Invoke(new Action(() => lstBox.Items.Add(txt)));
            }
            else
            {
                lstBox.Items.Add(txt);
            }
        }

        private void ClearLstBoxItems()
        {
            if (lstBox.InvokeRequired)
            {
                lstBox.Invoke(new Action(() => lstBox.Items.Clear()));
            }
            else
            {
                lstBox.Items.Clear();
            }
        }

        private void SetLed(Bulb.LedBulb led, Led.LedColor color)
        {
            if (led.InvokeRequired)
            {
                led.Invoke(new Action(() => { led.Color = GetLedColor(color); led.On = (color == Led.LedColor.Off) ? false : true; } ));
            }
            else
            {
                led.Color = GetLedColor(color);
                led.On = (color == Led.LedColor.Off) ? false : true;
            }
        }

        private void ClearLeds()
        {
            SetLed(ledBulb1, Led.LedColor.Off);
            SetLed(ledBulb2, Led.LedColor.Off);
            SetLed(ledBulb3, Led.LedColor.Off);
            SetLed(ledBulb4, Led.LedColor.Off);
        }

        #endregion


        #region Private Methods

        private void client_Connected(object sender, string server_ip)
        {
            SetBtnConnectionText("Disconnect");
            mConnected = true;

            string msg = "Connected to server: " + server_ip;
            MessageBox.Show(msg, "Client");
        }

        private void client_Disconnected(object sender)
        {
            SetBtnConnectionText("Connect");
            mConnected = false;

            ClearLstBoxItems();
            ClearLeds();
        }

        private void client_DataReceived(object sender, byte[] data)
        {
            if ((data != null) && (data.Length > 0))
            {
                mParser.ParsePacket(data);
            }
        }

        private void client_Error(object sender, string message)
        {
            if (message.Length > 0)
            {
                MessageBox.Show(message, "Client");
            }
        }

        private void mParser_ContentReceived(object sender, byte[] content)
        {
            mProtocol.ParseCommand(content);
        }

        private void mProtocol_Response(object sender, byte[] content)
        {
            if ((content != null) && (content.Length > 0))
            {
                mClient.Send(mParser.CreatePacket(content));
            }            
        }

        private void mProtocol_VersionResponse(object sender, string version)
        {
            AddLstBoxItems(version);
        }

        private void mProtocol_LedAmountResponse(object sender, int number_of_leds)
        {
            AddLstBoxItems("Number of leds: " + number_of_leds);
        }

        private void mProtocol_LedGetResponse(object sender, string led_content)
        {
            AddLstBoxItems("Led (get): " + led_content);
        }

        private void mProtocol_LedSetResponse(object sender, string led_content)
        {
            AddLstBoxItems("Led (set): " + led_content);
        }

        #region LedStrand Events

        private void mProtocol_LedColor(object sender, Led.LedNumber number, Led.LedColor color)
        {
            switch (number)
            {
                case Led.LedNumber.One:
                    SetLed(ledBulb1, color);
                    break;
                case Led.LedNumber.Two:
                    SetLed(ledBulb2, color);
                    break;
                case Led.LedNumber.Three:
                    SetLed(ledBulb3, color);
                    break;
                case Led.LedNumber.Four:
                    SetLed(ledBulb4, color);
                    break;
                case Led.LedNumber.All:
                    SetLed(ledBulb1, color);
                    SetLed(ledBulb2, color);
                    SetLed(ledBulb3, color);
                    SetLed(ledBulb4, color);
                    break;
                default: break; // Ignore
            };
        }

        #endregion

        private System.Drawing.Color GetLedColor(Led.LedColor color)
        {
            System.Drawing.Color result = System.Drawing.Color.Black;

            switch (color)
            {
                case Led.LedColor.Off:
                    result = System.Drawing.Color.Black;
                    break;
                case Led.LedColor.Purple:
                    result = System.Drawing.Color.Purple;
                    break;
                case Led.LedColor.Red:
                    result = System.Drawing.Color.Red;
                    break;
                case Led.LedColor.Orange:
                    result = System.Drawing.Color.Orange;
                    break;
                case Led.LedColor.Yellow:
                    result = System.Drawing.Color.Yellow;
                    break;
                case Led.LedColor.Green:
                    result = System.Drawing.Color.Green;
                    break;
                case Led.LedColor.LightBlue:
                    result = System.Drawing.Color.LightBlue;
                    break;
                case Led.LedColor.Blue:
                    result = System.Drawing.Color.Blue;
                    break;
                case Led.LedColor.White:
                    result = System.Drawing.Color.White;
                    break;
                default: break;
            };

            return result;
        }

        #endregion
    }
}
