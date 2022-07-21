using System;
using System.Collections.Generic;
using System.Text;

namespace BuildserverMonitor
{
    public delegate void ResponseHandler(object sender, byte[] content);

    public delegate void VersionResponseHandler(object sender, string version);
    public delegate void LedAmountResponseHandler(object sender, int number_of_leds);
    public delegate void LedGetResponseHandler(object sender, string led_content);
    public delegate void LedSetResponseHandler(object sender, string led_content);
    public delegate void BuzzerGetResponseHandler(object sender, string buzzer_content);
    public delegate void BuzzerSetResponseHandler(object sender, string buzzer_content);
    public delegate void VibrationGetResponseHandler(object sender, string vibration_content);
    public delegate void VibrationSetResponseHandler(object sender, string vibration_content);

    // For UI purpose only
    public delegate void LedColorHandlerUI(object sender, Led.LedNumber number, Led.LedColor color);

    public class ProtocolHandler
    {
        enum Command : byte
        {
            Version = 1,
            Leds,
            Buzzer,
            Vibration,
            OLED,
            Battery
        };

        enum VersionCmd : byte
        {
            Get = 1
        };

        enum LedCmd : byte
        {
            GetAmount = 1,
            Get,
            Set
        };

        enum BuzzerCmd : byte
        {
            Get = 1,
            Set
        };

        enum VibrationCmd : byte
        {
            Get = 1,
            Set
        };



        #region Events

        public event ResponseHandler Response;

        public event VersionResponseHandler VersionResponse;
        public event LedAmountResponseHandler LedAmountResponse;
        public event LedGetResponseHandler LedGetResponse;
        public event LedSetResponseHandler LedSetResponse;
        public event BuzzerGetResponseHandler BuzzerGetResponse;
        public event BuzzerSetResponseHandler BuzzerSetResponse;
        public event VibrationGetResponseHandler VibrationGetResponse;
        public event VibrationSetResponseHandler VibrationSetResponse;

        // For UI purpose only
        public event LedColorHandlerUI LedColor;

        #endregion


        #region Constants

        private readonly string VERSION_STRING = "Buildserver Client v0.2";

        private const byte COMMAND_LENGTH = 1;    // Used as: length
        private const byte ACTION_LENGTH  = 1;    // Used as: length
        private const byte COMMAND_BYTE   = 0;    // Used as: array index
        private const byte ACTION_BYTE    = 1;    // Used as: array index
        private const byte CONTENT_BYTE   = 2;    // Used as: array index

        #endregion


        #region Fields

        private LedStrand mLedStrand = new LedStrand();
        private Buzzer mBuzzer = new Buzzer();
        private Vibration mVibration = new Vibration();

        #endregion


        #region Public Methods

        public ProtocolHandler()
        {
            mLedStrand.LedColor += mLedStrand_LedColor;
        }

        public void ParseCommand(byte[] data)
        {
            if ((data != null) && (data.Length > 0))
            {
                byte command = data[COMMAND_BYTE];

                     if (command == (byte)Command.Version  ) { HandleVersion(data);   }
                else if (command == (byte)Command.Leds     ) { HandleLeds(data);      }
                else if (command == (byte)Command.Buzzer   ) { HandleBuzzer(data);    }
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
                    byte[] versionAsArray = Encoding.ASCII.GetBytes(VERSION_STRING);

                    byte[] content = new byte[versionAsArray.Length + COMMAND_LENGTH + ACTION_LENGTH];
                    content[COMMAND_BYTE] = (byte)(Command.Version);
                    content[ACTION_BYTE] = (byte)(VersionCmd.Get);
                    versionAsArray.CopyTo(content, CONTENT_BYTE);

                    if (Response != null)
                    {
                        Response(this, content);
                    }

                    if (VersionResponse != null)
                    {
                        VersionResponse(this, VERSION_STRING);
                    }
                }
            }
        }

        private void HandleLeds(byte[] data)
        {
            if (data.Length > COMMAND_LENGTH)
            {
                byte action = data[ACTION_BYTE];

                #region Leds.GetAmount

                if (action == (byte)(LedCmd.GetAmount))
                {
                    byte[] content = new byte[1 + COMMAND_LENGTH + ACTION_LENGTH];
                    content[COMMAND_BYTE] = (byte)(Command.Leds);
                    content[ACTION_BYTE] = (byte)(LedCmd.GetAmount);
                    content[CONTENT_BYTE] = (byte)LedStrand.NumberOfLeds;

                    if (Response != null)
                    {
                        Response(this, content);
                    }

                    if (LedAmountResponse != null)
                    {
                        LedAmountResponse(this, LedStrand.NumberOfLeds);
                    }
                }

                #endregion

                #region Leds.Get

                else if (action == (byte)(LedCmd.Get))
                {
                    byte ledId = data[CONTENT_BYTE];
                    byte[] led_content = new byte[0];
                    StringBuilder sb = new StringBuilder();

                    if ((ledId > 0) && (ledId <= LedStrand.NumberOfLeds))
                    {
                        Led led = mLedStrand.Get(ledId);
                        if (led != null)
                        {
                            led_content = mLedStrand.Get(ledId).ToArray();
                            sb.Append(mLedStrand.Get(ledId).ToString());
                        }
                    }
                    else if (ledId == (LedStrand.NumberOfLeds + 1))     // All
                    {
                        List<byte> list = new List<byte>();
                        for (var i = 0; i < LedStrand.NumberOfLeds; i++)
                        {
                            Led led = mLedStrand.Get((byte)(i + 1));
                            if (led != null)
                            {
                                list.AddRange(led.ToArray());
                                sb.Append(led.ToString());

                                if (i != LedStrand.NumberOfLeds)
                                {
                                    sb.Append(" --- ");
                                }
                            }
                        }
                        led_content = list.ToArray();
                    }

                    byte[] content = new byte[led_content.Length + COMMAND_LENGTH + ACTION_LENGTH];
                    content[COMMAND_BYTE] = (byte)(Command.Leds);
                    content[ACTION_BYTE] = (byte)(LedCmd.Get);
                    led_content.CopyTo(content, CONTENT_BYTE);

                    if (Response != null)
                    {
                        Response(this, content);
                    }

                    if (LedGetResponse != null)
                    {
                        LedGetResponse(this, sb.ToString());
                    }
                }

                #endregion

                #region Leds.Set

                else if (action == (byte)(LedCmd.Set))
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
                            if (mLedStrand.Set(newLed))
                            {
                                sb.Append(newLed.ToString());
                            }
                        }
                    }
                    else if (length == (Led.Length * LedStrand.NumberOfLeds))     // All
                    {
                        for (var i = 0; i < LedStrand.NumberOfLeds; i++)
                        {
                            Array.Copy(data, CONTENT_BYTE + (i * Led.Length), led_content, 0, led_content.Length);
                            Led newLed = Led.FromArray(led_content);
                            if (newLed != null)
                            {
                                if (mLedStrand.Set(newLed))
                                {
                                    sb.Append(newLed.ToString());

                                    if (i != LedStrand.NumberOfLeds)
                                    {
                                        sb.Append(" --- ");
                                    }
                                }
                            }
                        }
                    }

                    if (LedSetResponse != null)
                    {
                        LedSetResponse(this, sb.ToString());
                    }
                }

                #endregion
            }
        }

        private void HandleBuzzer(byte[] data)
        {
            if (data.Length > COMMAND_LENGTH)
            {
                byte action = data[ACTION_BYTE];

                #region Buzzer.Get

                if (action == (byte)(BuzzerCmd.Get))
                {
                    byte[] buzzer_content = mBuzzer.ToArray();

                    byte[] content = new byte[buzzer_content.Length + COMMAND_LENGTH + ACTION_LENGTH];
                    content[COMMAND_BYTE] = (byte)(Command.Buzzer);
                    content[ACTION_BYTE] = (byte)(BuzzerCmd.Get);
                    buzzer_content.CopyTo(content, CONTENT_BYTE);

                    if (Response != null)
                    {
                        Response(this, content);
                    }

                    if (BuzzerGetResponse != null)
                    {
                        BuzzerGetResponse(this, mBuzzer.ToString());
                    }
                }

                #endregion
                #region Buzzer.Set

                else if (action == (byte)(BuzzerCmd.Set))
                {
                    byte length = (byte)(data.Length - COMMAND_LENGTH - ACTION_LENGTH);
                    byte[] buzzer_content = new byte[Buzzer.Length];

                    if (length == Buzzer.Length)
                    {
                        Array.Copy(data, CONTENT_BYTE, buzzer_content, 0, buzzer_content.Length);
                        Buzzer newBuzzer = Buzzer.FromArray(buzzer_content);
                        if (newBuzzer != null)
                        {
                            mBuzzer.DeepCopy(newBuzzer);

                            if (BuzzerSetResponse != null)
                            {
                                BuzzerSetResponse(this, mBuzzer.ToString());
                            }
                        }
                    }
                }

                #endregion
            }
        }

        private void HandleVibration(byte[] data)
        {
            if (data.Length > COMMAND_LENGTH)
            {
                byte action = data[ACTION_BYTE];

                #region Vibration.Get

                if (action == (byte)(VibrationCmd.Get))
                {
                    byte[] vibration_content = mVibration.ToArray();

                    byte[] content = new byte[vibration_content.Length + COMMAND_LENGTH + ACTION_LENGTH];
                    content[COMMAND_BYTE] = (byte)(Command.Vibration);
                    content[ACTION_BYTE] = (byte)(VibrationCmd.Get);
                    vibration_content.CopyTo(content, CONTENT_BYTE);

                    if (Response != null)
                    {
                        Response(this, content);
                    }

                    if (VibrationGetResponse != null)
                    {
                        VibrationGetResponse(this, mBuzzer.ToString());
                    }
                }

                #endregion
                #region Vibration.Set

                else if (action == (byte)(VibrationCmd.Set))
                {
                    byte length = (byte)(data.Length - COMMAND_LENGTH - ACTION_LENGTH);
                    byte[] vibration_content = new byte[Vibration.Length];

                    if (length == Vibration.Length)
                    {
                        Array.Copy(data, CONTENT_BYTE, vibration_content, 0, vibration_content.Length);
                        Vibration newVibration = Vibration.FromArray(vibration_content);
                        if (newVibration != null)
                        {
                            mVibration.DeepCopy(newVibration);

                            if (VibrationSetResponse != null)
                            {
                                VibrationSetResponse(this, mVibration.ToString());
                            }
                        }
                    }
                }

                #endregion
            }
        }

        #region LedStrand Events

        private void mLedStrand_LedColor(object sender, Led.LedNumber number, Led.LedColor color)
        {
            // Forward the event
            if (LedColor != null)
            {
                LedColor(this, number, color);
            }
        }

        #endregion

        #endregion
    }
}
