using System;
using System.Text;

namespace BuildserverMonitor
{
    public delegate void VersionResponseHandler(object sender, string version);
    public delegate void LedAmountResponseHandler(object sender, int number_of_leds);
    public delegate void LedGetResponseHandler(object sender, string led_content);
    public delegate void BuzzerGetResponseHandler(object sender, string buzzer_content);
    public delegate void VibrationGetResponseHandler(object sender, string vibration_content);


    public class ProtocolHandler
    {
        public enum Command : byte
        {
            Version = 1,
            Leds,
            Buzzer,
            Vibration,
            OLED,
            Battery
        };

        public enum VersionCmd : byte
        {
            Get = 1
        };

        public enum LedCmd : byte
        {
            GetAmount = 1,
            Get,
            Set
        };

        public enum BuzzerCmd : byte
        {
            Get = 1,
            Set
        };

        public enum VibrationCmd : byte
        {
            Get = 1,
            Set
        };

        #region Events

        public event VersionResponseHandler VersionResponse;
        public event LedAmountResponseHandler LedAmountResponse;
        public event LedGetResponseHandler LedGetResponse;
        public event BuzzerGetResponseHandler BuzzerGetResponse;
        public event VibrationGetResponseHandler VibrationGetResponse;

        #endregion


        #region Constants

        private const byte COMMAND_LENGTH = 1;    // Used as: length
        private const byte ACTION_LENGTH  = 1;    // Used as: length
        private const byte COMMAND_BYTE   = 0;    // Used as: array index
        private const byte ACTION_BYTE    = 1;    // Used as: array index
        private const byte CONTENT_BYTE   = 2;    // Used as: array index

        #endregion


        #region Public Methods

        public void ParseCommand(byte[] data)
        {
            if ((data != null) && (data.Length > 0))
            {
                byte command = data[COMMAND_BYTE];

                     if (command == (byte)Command.Version  ) { HandleVersion(data); }
                else if (command == (byte)Command.Leds     ) { HandleLeds(data);    }
                else if (command == (byte)Command.Buzzer   ) { HandleBuzzer(data);  }
                else if (command == (byte)Command.Vibration) { HandleVibration(data); }
            }
        }

        #endregion


        #region Private Methods

        private void HandleVersion(byte[] data)
        {
            if (data.Length > COMMAND_LENGTH)
            {
                byte action = data[ACTION_BYTE];

                if (action == (byte)(VersionCmd.Get))
                {
                    System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                    string versionString = enc.GetString(data, CONTENT_BYTE, (data.Length - COMMAND_LENGTH - ACTION_LENGTH));

                    if (VersionResponse != null)
                    {
                        VersionResponse(this, versionString);
                    }
                }
            }
        }

        private void HandleLeds(byte[] data)
        {
            if (data.Length > COMMAND_LENGTH)
            {
                byte action = data[ACTION_BYTE];

                if (action == (byte)(LedCmd.GetAmount))
                {
                    if (LedAmountResponse != null)
                    {
                        LedAmountResponse(this, data[CONTENT_BYTE]);
                    }
                }
                else if (action == (byte)(LedCmd.Get))
                {
                    byte ledId = data[CONTENT_BYTE];
                    byte length = (byte)(data.Length - COMMAND_LENGTH - ACTION_LENGTH);
                    StringBuilder sb = new StringBuilder();

                    byte[] led_content = new byte[Led.Length];

                    if (length == Led.Length)
                    {
                        Array.Copy(data, CONTENT_BYTE, led_content, 0, led_content.Length);
                        Led newLed = Led.FromArray(led_content);
                        if (newLed != null)
                        {
                            sb.Append(newLed.ToString());
                        }
                    }
                    else if (length > Led.Length)     // All
                    {
                        int numberOfLeds = length / Led.Length;

                        for (var i = 0; i < numberOfLeds; i++)
                        {
                            Array.Copy(data, CONTENT_BYTE + (i * Led.Length), led_content, 0, led_content.Length);
                            Led newLed = Led.FromArray(led_content);
                            if (newLed != null)
                            {
                                sb.Append(newLed.ToString());

                                if (i != numberOfLeds)
                                {
                                    sb.Append(" --- ");
                                }
                            }
                        }
                    }
                                      
                    if (LedGetResponse != null)
                    {
                        LedGetResponse(this, sb.ToString());
                    }
                }
            }
        }

        private void HandleBuzzer(byte[] data)
        {
            if (data.Length > COMMAND_LENGTH)
            {
                byte action = data[ACTION_BYTE];

                if (action == (byte)(BuzzerCmd.Get))
                {
                    byte length = (byte)(data.Length - COMMAND_LENGTH - ACTION_LENGTH);
                    byte[] buzzer_content = new byte[Buzzer.Length];

                    if (length == Buzzer.Length)
                    {
                        Array.Copy(data, CONTENT_BYTE, buzzer_content, 0, buzzer_content.Length);
                        Buzzer newBuzzer = Buzzer.FromArray(buzzer_content);
                        if (newBuzzer != null)
                        {
                            if (BuzzerGetResponse != null)
                            {
                                BuzzerGetResponse(this, newBuzzer.ToString());
                            }
                        }
                    }                    
                }
            }
        }

        private void HandleVibration(byte[] data)
        {
            if (data.Length > COMMAND_LENGTH)
            {
                byte action = data[ACTION_BYTE];

                if (action == (byte)(VibrationCmd.Get))
                {
                    byte length = (byte)(data.Length - COMMAND_LENGTH - ACTION_LENGTH);
                    byte[] vibration_content = new byte[Vibration.Length];

                    if (length == Vibration.Length)
                    {
                        Array.Copy(data, CONTENT_BYTE, vibration_content, 0, vibration_content.Length);
                        Vibration newVibration = Vibration.FromArray(vibration_content);
                        if (newVibration != null)
                        {
                            if (VibrationGetResponse != null)
                            {
                                VibrationGetResponse(this, newVibration.ToString());
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
