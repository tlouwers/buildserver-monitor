using System;

namespace BuildserverMonitor
{
    public enum bsmCommand : byte
    {
        BatterySOC = 0,
        BatteryCharging,
        LedsAmount,
        LedsColorAndBrightness,
        BuzzerOn,
        BuzzerOff,
        VibrationOn,
        VibrationOff,
        OLEDTextLine1,
        OLEDTextLine2,
        OLEDScroll,
        OLEDOff,
        MCUVersion,
        Invalid,
    };


    public class bsmProtocol
    {
        private String mVersion = "Buildserver-monitor API v0.1";
        
        private byte mLength = 0;
        private bsmCommand mCommand = bsmCommand.Invalid;
        private byte[] mPayload = new byte[245];
        private UInt16 mCRC16 = 0;



        public String Version
        {
            get { return this.mVersion; }
        }

        public byte Length
        {
            get { return this.mLength; }
            set { this.mLength = Length; }
        }

        public bsmCommand Command
        {
            get { return this.mCommand; }
            set { this.mCommand = Command; }
        }

        public byte[] Payload
        {
            get { return this.mPayload; }
            set { this.mPayload = Payload; }
        }

        public UInt16 CRC16
        {
            get { return this.mCRC16; }
            set { this.mCRC16 = CRC16; }
        }



        public byte[] ToPacket()
        {
            // Dummy
            return new byte[] { 0x01, 0x02, 0x03, 0x04 };
        }
    }
}
