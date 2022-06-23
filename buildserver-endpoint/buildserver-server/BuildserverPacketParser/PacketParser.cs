using System;

namespace BuildserverMonitor
{
    public delegate void ContentHandler(object sender, byte[] content);
    
    
    public class PacketParser
    {
        #region Events

        public event ContentHandler ContentReceived;

        #endregion


        #region Constants

        private const byte LENGTH_OFFSET         = 0;     // Used as: array index 
        private const byte COMMAND_OFFSET        = 1;     // Used as: array index
        private const byte MINIMAL_PACKET_LENGTH = 3;     // Length + Command + CRC
        private const byte LENGTH_AND_CRC_BYTE   = 2;     // Length + CRC

        #endregion


        #region Fields

        private CRC8 mCrcRecieve = new CRC8();
        private CRC8 mCrcSend = new CRC8();

        #endregion


        #region Public Methods

        public PacketParser()
        {
            mCrcRecieve.Polynome = CRC8.CCITT;
            mCrcSend.Polynome = CRC8.CCITT;
        }

        public byte[] CreatePacket(byte[] content)
        {
            byte[] packet = null;

            if ((content != null) && (content.Length > 0))
            {
                int packetLength = content.Length + LENGTH_AND_CRC_BYTE;

                if (packetLength <= Byte.MaxValue)
                {
                    packet = new byte[content.Length + LENGTH_AND_CRC_BYTE];

                    mCrcSend.Reset();
                    mCrcSend.Add(content, (UInt16)content.Length);

                    // Fill packet with data: Length, Content (Command + Data), CRC
                    packet[0] = (byte)packet.Length;
                    content.CopyTo(packet, 1);
                    packet[packet.Length - 1] = mCrcSend.GetCRC();
                }                
            }

            return packet;
        }

        public void ParsePacket(byte[] data)
        {
            // Check there is enough data for a possible packet
            if (data.Length > MINIMAL_PACKET_LENGTH)
            {
                byte length = data[LENGTH_OFFSET];

                // Extract specified length as possible packet
                byte[] content = new byte[length - LENGTH_AND_CRC_BYTE];     // (leaves only Command + data)
                for (var i = 0; i < (length - LENGTH_AND_CRC_BYTE); i++)
                {
                    content[i] = data[i + COMMAND_OFFSET];
                }

                // Check CRC
                mCrcRecieve.Reset();
                mCrcRecieve.Add(content, (UInt16)(length - LENGTH_AND_CRC_BYTE));
                byte checksum = mCrcRecieve.GetCRC();
                byte checksumInPacket = data[length - 1];

                if (checksum == checksumInPacket)
                {
                    // Pass Command + data to handler
                    if (ContentReceived != null)
                    {
                        ContentReceived(this, content);
                    }
                }
            }
        }

        #endregion
    }
}
