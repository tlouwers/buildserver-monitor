using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Windows.Forms;


namespace BuildserverMonitor
{
    public partial class frmMain : MetroForm
    {
        #region Fields

        private List<Int32> mClientList = new List<Int32>();
        private Server mServer = new Server();
        private bool mConnected = false;

        private Led.LedNumber mNumberOfLeds = Led.LedNumber.Invalid;
        private PacketParser mParser = new PacketParser();
        private ProtocolHandler mProtocol = new ProtocolHandler();

        #endregion


        #region UI Elements

        public frmMain()
        {
            InitializeComponent();

            mServer.ClientConnected += mServer_ClientConnected;
            mServer.ClientDisconnected += mServer_ClientDisconnected;
            mServer.Listening += mServer_Listening;
            mServer.Closed += mServer_Closed;
            mServer.DataReceived += mServer_DataReceived;
            mServer.Error += mServer_Error;

            mParser.ContentReceived += mParser_ContentReceived;

            mProtocol.VersionResponse += mProtocol_VersionResponse;
            mProtocol.LedAmountResponse += mProtocol_LedAmountResponse;
            mProtocol.LedGetResponse += mProtocol_LedGetResponse;

            cbxLedColor.SelectedIndex = 0;  // Off
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetLblNumberOfConnectedClientsValueText(System.Convert.ToString(mServer.NumberOfClientsConnected));
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            mServer.End();
        }
        
        private void btnConnection_Click(object sender, System.EventArgs e)
        {
            if (!mConnected)
            {
                if (tbxPort.Text.Length == 0)
                {
                    MessageBox.Show("Please enter a Port Number", "Server");
                    return;
                }

                UInt16 port = Convert.ToUInt16(tbxPort.Text);

                mServer.Start("localhost", port);
            }
            else
            {
                mServer.End();
            }
        }

        private void SetLblNumberOfConnectedClientsValueText(string txt)
        {
            if (lblNumberOfConnectedClientsValue.InvokeRequired)
            {
                lblNumberOfConnectedClientsValue.Invoke(new Action(() => lblNumberOfConnectedClientsValue.Text = txt));
            }
            else
            {
                lblNumberOfConnectedClientsValue.Text = txt;
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

        private void AddCbxLedIdItem(string item)
        {
            if (cbxLedId.InvokeRequired)
            {
                cbxLedId.Invoke(new Action(() => cbxLedId.Items.Add(item)));
            }
            else
            {
                cbxLedId.Items.Add(item);
            }
        }

        private void ClearCbxLedIdItems()
        {
            if (cbxLedId.InvokeRequired)
            {
                cbxLedId.Invoke(new Action(() => cbxLedId.Items.Clear()));
            }
            else
            {
                cbxLedId.Items.Clear();
            }
        }

        #endregion


        #region Buttons

        private void btnVersionGet_Click(object sender, EventArgs e)
        {
            byte[] content = new byte[2];

            content[0] = (byte)ProtocolHandler.Command.Version;
            content[1] = (byte)ProtocolHandler.Version.Get;

            PackageAndSendToClients(content);
        }

        private void btnLedsGetAmount_Click(object sender, EventArgs e)
        {
            byte[] content = new byte[2];

            content[0] = (byte)ProtocolHandler.Command.Leds;
            content[1] = (byte)ProtocolHandler.Leds.GetAmount;

            PackageAndSendToClients(content);
        }

        private void btnLedsGet_Click(object sender, EventArgs e)
        {
            if (mNumberOfLeds == Led.LedNumber.Invalid)
            {
                MessageBox.Show("Request the number of leds first!", "Server");
            }
            else
            {
                if (cbxLedId.SelectedItem == null)
                {
                    MessageBox.Show("Select a led Id to get first!", "Server");
                }
                else
                {
                    byte[] content = new byte[3];

                    content[0] = (byte)ProtocolHandler.Command.Leds;
                    content[1] = (byte)ProtocolHandler.Leds.Get;
                    content[2] = (byte)StringToLedNumber(cbxLedId.SelectedItem.ToString());

                    PackageAndSendToClients(content);
                }
            }
        }

        private void btnLedsSet_Click(object sender, EventArgs e)
        {
            if (mNumberOfLeds == Led.LedNumber.Invalid)
            {
                MessageBox.Show("Request the number of leds first!", "Server");
            }
            else
            {
                Led.LedNumber ledNumber = StringToLedNumber(cbxLedId.SelectedItem.ToString());

                byte[] content = null;

                if (ledNumber != Led.LedNumber.All && ledNumber != Led.LedNumber.Invalid)
                {
                    content = new byte[2 + Led.Length];

                    Led led = new Led();
                    led.Id = ledNumber;
                    led.Color = StringToLedColor(cbxLedColor.SelectedItem.ToString());

                    byte[] ledArr = led.ToArray();

                    content[0] = (byte)ProtocolHandler.Command.Leds;
                    content[1] = (byte)ProtocolHandler.Leds.Set;
                    ledArr.CopyTo(content, 2);
                }
                else if (ledNumber == Led.LedNumber.All)
                {
                    int numberOfLeds = LedNumberToInt(mNumberOfLeds);

                    content = new byte[2 + (numberOfLeds * Led.Length)];

                    content[0] = (byte)ProtocolHandler.Command.Leds;
                    content[1] = (byte)ProtocolHandler.Leds.Set;

                    for (var i = 1; i <= numberOfLeds; i++)
                    {
                        Led led = new Led();
                        led.Id = IntToLedNumber(i);
                        led.Color = StringToLedColor(cbxLedColor.SelectedItem.ToString());

                        byte[] ledArr = led.ToArray();

                        ledArr.CopyTo(content, 2 + ((i - 1) * 9));
                    }
                }

                if (content != null)
                {
                    PackageAndSendToClients(content);
                }
            }
        }

        #endregion


        #region Private Methods

        private void mServer_ClientConnected(object sender, int clientId)
        {
            mClientList.Add(clientId);

            SetLblNumberOfConnectedClientsValueText(System.Convert.ToString(mServer.NumberOfClientsConnected));

            string msg = "Client " + clientId + " connected.";
            MessageBox.Show(msg, "Server");
        }

        private void mServer_ClientDisconnected(object sender, int clientId)
        {
            mClientList.Remove(clientId);

            SetLblNumberOfConnectedClientsValueText(System.Convert.ToString(mServer.NumberOfClientsConnected));
            
            string msg = "Client " + clientId + " disconnected.";
            MessageBox.Show(msg, "Server");
        }

        private void mServer_Listening(object sender)
        {
            SetBtnConnectionText("Disconnect");
            mConnected = true;
        }

        private void mServer_Closed(object sender)
        {
            mClientList.Clear();

            SetLblNumberOfConnectedClientsValueText(System.Convert.ToString(mServer.NumberOfClientsConnected));

            SetBtnConnectionText("Connect");
            mConnected = false;

            ClearLstBoxItems();
        }

        private void mServer_DataReceived(object sender, byte[] data)
        {
            if ((data != null) && (data.Length > 0))
            {
                mParser.ParsePacket(data);
            }
        }

        private void mServer_Error(object sender, String message)
        {
            if (message.Length > 0)
            {
                MessageBox.Show(message, "Server");
            }
        }

        private void mParser_ContentReceived(object sender, byte[] content)
        {
            mProtocol.ParseCommand(content);
        }

        private Led.LedNumber StringToLedNumber(string ledNumberString)
        {
                 if (ledNumberString == "1"  ) { return Led.LedNumber.One;     }
            else if (ledNumberString == "2"  ) { return Led.LedNumber.Two;     }
            else if (ledNumberString == "3"  ) { return Led.LedNumber.Three;   }
            else if (ledNumberString == "4"  ) { return Led.LedNumber.Four;    }
            else if (ledNumberString == "All") { return Led.LedNumber.All;     }
            else                               { return Led.LedNumber.Invalid; }
        }

        private string LedNumberToString(int ledNumber)
        {
                 if (ledNumber == 1) { return "1"; }
            else if (ledNumber == 2) { return "2"; }
            else if (ledNumber == 3) { return "3"; }
            else if (ledNumber == 4) { return "4"; }
            else                     { return "0"; }  // Invalid. Case 'All' not handled: special
        }

        private Led.LedNumber IntToLedNumber(int ledNumber)
        {
                 if (ledNumber == 0) { return Led.LedNumber.Invalid; }
            else if (ledNumber == 1) { return Led.LedNumber.One;     }
            else if (ledNumber == 2) { return Led.LedNumber.Two;     }
            else if (ledNumber == 3) { return Led.LedNumber.Three;   }
            else if (ledNumber == 4) { return Led.LedNumber.Four;    }
            else                     { return Led.LedNumber.All;     }
        }

        private int LedNumberToInt(Led.LedNumber ledNumber)
        {                 
                 if (ledNumber == Led.LedNumber.One    ) { return 1; }
            else if (ledNumber == Led.LedNumber.Two    ) { return 2; }
            else if (ledNumber == Led.LedNumber.Three  ) { return 3; }
            else if (ledNumber == Led.LedNumber.Four   ) { return 4; }
            else                                         { return 0; }  // Invalid. Case 'All' not handled: special
        }

        private Led.LedColor StringToLedColor(string ledColorString)
        {
                 if (ledColorString == "Purple"   ) { return Led.LedColor.Purple;    }
            else if (ledColorString == "Red"      ) { return Led.LedColor.Red;       }
            else if (ledColorString == "Orange"   ) { return Led.LedColor.Orange;    }
            else if (ledColorString == "Yellow"   ) { return Led.LedColor.Yellow;    }
            else if (ledColorString == "Green"    ) { return Led.LedColor.Green;     }
            else if (ledColorString == "LightBlue") { return Led.LedColor.LightBlue; }
            else if (ledColorString == "Blue"     ) { return Led.LedColor.Blue;      }
            else if (ledColorString == "White"    ) { return Led.LedColor.White;     }
            else                                    { return Led.LedColor.Off;       }
        }

        #endregion


        #region Protocol Handling

        private void mProtocol_VersionResponse(object sender, string version)
        {
            AddLstBoxItems(version);
        }

        private void mProtocol_LedAmountResponse(object sender, int number_of_leds)
        {
            mNumberOfLeds = IntToLedNumber(number_of_leds);

            // Fill combobox with available options
            if (number_of_leds > 0)
            {
                ClearCbxLedIdItems();
                AddCbxLedIdItem("All");
                for (var i = 1; i <= number_of_leds; i++)
                {
                    AddCbxLedIdItem(LedNumberToString(i));
                }
            }

            AddLstBoxItems("Number of leds: " + number_of_leds);
        }

        private void mProtocol_LedGetResponse(object sender, string led_content)
        {
            AddLstBoxItems(led_content);
        }

        private void PackageAndSendToClients(byte[] content)
        {
            byte[] packet = mParser.CreatePacket(content);

            foreach (var clientId in mClientList)
            {
                mServer.Send(clientId, packet);
            }
        }

        #endregion
    }
}
