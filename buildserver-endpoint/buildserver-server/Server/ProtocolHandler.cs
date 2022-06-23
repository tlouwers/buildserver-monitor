using System;
using System.Text;

namespace BuildserverMonitor
{
    public delegate void VersionResponseHandler(object sender, string version);
    public delegate void LedAmountResponseHandler(object sender, int number_of_leds);
    public delegate void LedGetResponseHandler(object sender, string led_content);


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

        public enum Version : byte
        {
            Get = 1
        };

        public enum Leds : byte
        {
            GetAmount = 1,
            Get,
            Set
        };

        #region Events

        public event VersionResponseHandler VersionResponse;
        public event LedAmountResponseHandler LedAmountResponse;
        public event LedGetResponseHandler LedGetResponse;

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

                     if (command == (byte)Command.Version) { HandleVersion(data); }
                else if (command == (byte)Command.Leds   ) { HandleLeds(data);    }
            }
        }

        #endregion


        #region Private Methods

        private void HandleVersion(byte[] data)
        {
            if (data.Length > COMMAND_LENGTH)
            {
                byte action = data[ACTION_BYTE];

                if (action == (byte)(Version.Get))
                {
                    System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                    String versionString = enc.GetString(data, CONTENT_BYTE, (data.Length - COMMAND_LENGTH - ACTION_LENGTH));

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

                if (action == (byte)(Leds.GetAmount))
                {
                    if (LedAmountResponse != null)
                    {
                        LedAmountResponse(this, data[CONTENT_BYTE]);
                    }
                }
                else if (action == (byte)(Leds.Get))
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
        
        #endregion
    }
}
