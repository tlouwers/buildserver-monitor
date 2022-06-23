using System;

//  AUTHOR: Rob Tillaart
// PURPOSE: Arduino class for CRC8;
//     URL: https://github.com/RobTillaart/CRC
//    NOTE: Ported from C++ to C#, dropped the yield() functionality

namespace BuildserverMonitor
{
    public class CRC8
    {
        #region Constants

        public const byte DEFAULT_POLYNOME = 0x07;
        public const byte DVB_S2           = 0xD5;
        public const byte AUTOSAR          = 0x2F;
        public const byte BLUETOOTH        = 0xA7;
        public const byte CCITT            = 0x07;
        public const byte DALLAS_MAXIM     = 0x31;    // oneWire
        public const byte DARC             = 0x39;
        public const byte GSM_B            = 0x49;
        public const byte SAEJ1850         = 0x1D;
        public const byte WCDMA            = 0x9B;

        #endregion

        #region Fields

        private byte _polynome;

        public byte Polynome
        {
            get { return _polynome; }
            set { _polynome = value; }
        }
        private byte _startMask;

        public byte StartXOR
        {
            get { return _startMask; }
            set { _startMask = value; }
        }
        private byte _endMask;

        public byte EndXOR
        {
            get { return _endMask; }
            set { _endMask = value; }
        }
        private byte _crc;
        private bool _reverseIn;

        public bool ReverseIn
        {
            get { return _reverseIn; }
            set { _reverseIn = value; }
        }
        private bool _reverseOut;

        public bool ReverseOut
        {
            get { return _reverseOut; }
            set { _reverseOut = value; }
        }
        private bool _started;
        private UInt32 _count;

        #endregion

        #region Public Methods

        public CRC8()
        {
            Reset();
        }

        public CRC8(byte polynome, byte XORstart, byte XORend, bool reverseIn, bool reverseOut)
        {
            _polynome   = polynome;
            _startMask  = XORstart;
            _endMask    = XORend;
            _reverseIn  = reverseIn;
            _reverseOut = reverseOut;
            _crc        = 0;
            _started    = false;
            _count      = 0;
        }

        public void Reset()
        {
            _polynome   = DEFAULT_POLYNOME;
            _startMask  = 0;
            _endMask    = 0;
            _crc        = 0;
            _reverseIn  = false;
            _reverseOut = false;
            _started    = false;
            _count      = 0;
        }

        public void Restart()
        {
            _started = true;
            _crc     = _startMask;
            _count   = 0;
        }

        public void Add(byte value)
        {
            _count++;
            Update(value);
        }

        public void Add(byte[] array, UInt16 length)
        {
            for (var i = 0; i < length; i++)
            {
                Add(array[i]);
            }
        }

        public byte GetCRC()
        {
            byte rv = _crc;
            if (_reverseOut) rv = Reverse(rv);
            rv ^= _endMask;
            return rv;
        }

        #endregion

        #region Private Methods

        private byte Reverse(byte value)
        {
            byte x = value;
            x = (byte)((byte)((byte)(x & 0xAA) >> 1) | (byte)((byte)(x & 0x55) << 1));
            x = (byte)((byte)((byte)(x & 0xCC) >> 2) | (byte)((byte)(x & 0x33) << 2));
            x =                (byte)((byte)(x >> 4) | (byte)(x << 4));
            return x;
        }

        private void Update(byte value)
        {
          if (!_started) Restart();
          if (_reverseIn) value = Reverse(value);
          _crc ^= value;
          for (byte i = 8; i > 0; i--) 
          {
              if ((_crc & (byte)(1 << 7)) > 0)
                {
                    _crc <<= 1;
                    _crc ^= _polynome;
                }
                else
                {
                _crc <<= 1;
                }
            }
        }

        #endregion
    }
}
