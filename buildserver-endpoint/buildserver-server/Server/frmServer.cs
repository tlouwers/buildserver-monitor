using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace BuildserverMonitor
{
    public partial class frmMain : MetroForm
    {
        #region Fields

        private List<int> mClientList = new List<int>();
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
            mProtocol.BuzzerGetResponse += mProtocol_BuzzerGetResponse;
            mProtocol.VibrationGetResponse += mProtocol_VibrationGetResponse;

            cbxLedsColor.SelectedIndex = 0;  // Off
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

                ushort port = Convert.ToUInt16(tbxPort.Text);

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
            if (cbxLedsId.InvokeRequired)
            {
                cbxLedsId.Invoke(new Action(() => cbxLedsId.Items.Add(item)));
            }
            else
            {
                cbxLedsId.Items.Add(item);
            }
        }

        private void ClearCbxLedIdItems()
        {
            if (cbxLedsId.InvokeRequired)
            {
                cbxLedsId.Invoke(new Action(() => cbxLedsId.Items.Clear()));
            }
            else
            {
                cbxLedsId.Items.Clear();
            }
        }

        #endregion


        #region Buttons

        private void btnVersionGet_Click(object sender, EventArgs e)
        {
            byte[] content = new byte[2];

            content[0] = (byte)ProtocolHandler.Command.Version;
            content[1] = (byte)ProtocolHandler.VersionCmd.Get;

            PackageAndSendToClients(content);
        }

        private void btnLedsGetAmount_Click(object sender, EventArgs e)
        {
            byte[] content = new byte[2];

            content[0] = (byte)ProtocolHandler.Command.Leds;
            content[1] = (byte)ProtocolHandler.LedCmd.GetAmount;

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
                if (cbxLedsId.SelectedItem == null)
                {
                    MessageBox.Show("Select a led Id to get first!", "Server");
                }
                else
                {
                    byte[] content = new byte[3];

                    content[0] = (byte)ProtocolHandler.Command.Leds;
                    content[1] = (byte)ProtocolHandler.LedCmd.Get;
                    content[2] = (byte)StringToLedNumber(cbxLedsId.SelectedItem.ToString());

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
                if (!AreAllLedFieldsFilled())
                {
                    MessageBox.Show("Not all fields for Leds are filled properly!", "Server");
                }
                else
                {
                    Led.LedNumber ledNumber = StringToLedNumber(cbxLedsId.SelectedItem.ToString());

                    byte[] content = null;

                    if (ledNumber != Led.LedNumber.All && ledNumber != Led.LedNumber.Invalid)
                    {
                        content = new byte[2 + Led.Length];

                        Led led = new Led();
                        led.Id = ledNumber;
                        led.Color = StringToLedColor(cbxLedsColor.SelectedItem.ToString());
                        led.Brightness = StringToByte(tbxLedsBrightness.Text);
                        led.TimeOn = StringToUint16(tbxLedsTimeOn.Text);
                        led.TimeTotal = StringToUint16(tbxLedsTimeTotal.Text);
                        led.NrOfRepeats = StringToUint16(tbxLedsNrOfRepeats.Text);

                        byte[] ledArr = led.ToArray();

                        content[0] = (byte)ProtocolHandler.Command.Leds;
                        content[1] = (byte)ProtocolHandler.LedCmd.Set;
                        ledArr.CopyTo(content, 2);
                    }
                    else if (ledNumber == Led.LedNumber.All)
                    {
                        int numberOfLeds = LedNumberToInt(mNumberOfLeds);

                        content = new byte[2 + (numberOfLeds * Led.Length)];

                        content[0] = (byte)ProtocolHandler.Command.Leds;
                        content[1] = (byte)ProtocolHandler.LedCmd.Set;

                        for (var i = 1; i <= numberOfLeds; i++)
                        {
                            Led led = new Led();
                            led.Id = IntToLedNumber(i);
                            led.Color = StringToLedColor(cbxLedsColor.SelectedItem.ToString());
                            led.Brightness = StringToByte(tbxLedsBrightness.Text);
                            led.TimeOn = StringToUint16(tbxLedsTimeOn.Text);
                            led.TimeTotal = StringToUint16(tbxLedsTimeTotal.Text);
                            led.NrOfRepeats = StringToUint16(tbxLedsNrOfRepeats.Text);

                            byte[] ledArr = led.ToArray();

                            ledArr.CopyTo(content, 2 + ((i - 1) * 9));
                        }
                    }

                    if (content != null)
                    {
                        PackageAndSendToClients(content);
                    }

                    // Clear textboxes to prevent confusion
                    tbxLedsBrightness.Text = string.Empty;
                    tbxLedsTimeOn.Text = string.Empty;
                    tbxLedsTimeTotal.Text = string.Empty;
                    tbxLedsNrOfRepeats.Text = string.Empty;
                }
            }
        }

        private void btnBuzzerGet_Click(object sender, EventArgs e)
        {
            byte[] content = new byte[2];

            content[0] = (byte)ProtocolHandler.Command.Buzzer;
            content[1] = (byte)ProtocolHandler.BuzzerCmd.Get;

            PackageAndSendToClients(content);
        }

        private void btnBuzzerSet_Click(object sender, EventArgs e)
        {
            if (!AreAllBuzzerFieldsFilled())
            {
                MessageBox.Show("Not all fields for Buzzer are filled properly!", "Server");
            }
            else
            {
                byte[] content = new byte[2 + Buzzer.Length];

                Buzzer buzzer = new Buzzer();
                buzzer.TimeOn = StringToUint16(tbxBuzzerTimeOn.Text);
                buzzer.TimeTotal = StringToUint16(tbxBuzzerTimeTotal.Text);
                buzzer.NrOfRepeats = StringToUint16(tbxBuzzerNrOfRepeats.Text);

                byte[] buzzerArr = buzzer.ToArray();

                content[0] = (byte)ProtocolHandler.Command.Buzzer;
                content[1] = (byte)ProtocolHandler.BuzzerCmd.Set;
                buzzerArr.CopyTo(content, 2);

                if (content != null)
                {
                    PackageAndSendToClients(content);
                }

                // Clear textboxes to prevent confusion
                tbxBuzzerTimeOn.Text = string.Empty;
                tbxBuzzerTimeTotal.Text = string.Empty;
                tbxBuzzerNrOfRepeats.Text = string.Empty;
            }
        }

        private void btnVibrationGet_Click(object sender, EventArgs e)
        {
#warning ToDo - vibration button handling
        }

        private void btnVibrationSet_Click(object sender, EventArgs e)
        {
#warning ToDo - vibration button handling
        }

        #endregion


        #region Private Methods

        private void mServer_ClientConnected(object sender, int clientId)
        {
            mClientList.Add(clientId);

            SetLblNumberOfConnectedClientsValueText(Convert.ToString(mServer.NumberOfClientsConnected));

            string msg = "Client " + clientId + " connected.";
#warning Disabled popup which client connected
            //MessageBox.Show(msg, "Server");
        }

        private void mServer_ClientDisconnected(object sender, int clientId)
        {
            mClientList.Remove(clientId);

            SetLblNumberOfConnectedClientsValueText(System.Convert.ToString(mServer.NumberOfClientsConnected));
            
            string msg = "Client " + clientId + " disconnected.";
#warning Disabled popup which client disconnected
            //MessageBox.Show(msg, "Server");
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

        private void mServer_Error(object sender, string message)
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

        private ushort StringToUint16(string time_or_repeats)
        {
            ushort result = 0;
            try
            {
                result = Convert.ToUInt16(time_or_repeats);
            }
            catch (Exception)
            {
                // Silently fail: returns 0
            }
            return result;
        }

        private byte StringToByte(string brightness)
        {
            byte result = 0;
            try
            {
                result = Convert.ToByte(brightness);
            }
            catch (Exception)
            {
                // Silently fail: returns 0
            }
            return result;
        }

        private bool IsFilledAndAUint16Number(string time_or_repeats)
        {
            bool result = false;

            if ((time_or_repeats != null) && (time_or_repeats.Length > 0))
            {
                try
                {
                    Convert.ToUInt16(time_or_repeats);
                    result = true;
                }
                catch (Exception)
                {
                    // Silently fail: returns 0
                }
            }

            return result;
        }

        private bool IsFilledAndAByteNumber(string brightness)
        {
            bool result = false;

            if ((brightness != null) && (brightness.Length > 0))
            {
                try
                {
                    Convert.ToByte(brightness);
                    result = true;
                }
                catch (Exception)
                {
                    // Silently fail: returns 0
                }
            }

            return result;
        }

        private bool AreAllLedFieldsFilled()
        {
            if ((mNumberOfLeds == Led.LedNumber.Invalid) || (cbxLedsId.Text == null) || (cbxLedsId.Text.Length == 0))
            {
                return false;
            }

            if ((cbxLedsColor.Text == null) || (cbxLedsColor.Text.Length == 0))
            {
                return false;
            }

            if (!IsFilledAndAByteNumber(tbxLedsBrightness.Text))
            {
                return false;
            }

            if (!IsFilledAndAUint16Number(tbxLedsTimeOn.Text))
                {
                return false;
            }

            if (!IsFilledAndAUint16Number(tbxLedsTimeTotal.Text))
            {
                return false;
            }

            if (!IsFilledAndAUint16Number(tbxLedsNrOfRepeats.Text))
            {
                return false;
            }

            return true;
        }

        private bool AreAllBuzzerFieldsFilled()
        {
            if (!IsFilledAndAUint16Number(tbxBuzzerTimeOn.Text))
            {
                return false;
            }

            if (!IsFilledAndAUint16Number(tbxBuzzerTimeTotal.Text))
            {
                return false;
            }

            if (!IsFilledAndAUint16Number(tbxBuzzerNrOfRepeats.Text))
            {
                return false;
            }

            return true;
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
            AddLstBoxItems("Led (get): " + led_content);
        }

        private void mProtocol_BuzzerGetResponse(object sender, string buzzer_content)
        {
            AddLstBoxItems("Buzzer (get): " + buzzer_content);
        }

        private void mProtocol_VibrationGetResponse(object sender, string vibration_content)
        {
            AddLstBoxItems("Vibration (get): " + vibration_content);
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
