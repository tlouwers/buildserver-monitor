using System;
using System.Text;

namespace BuildserverMonitor
{
    public class Led
    {
        public enum LedNumber : byte
        {
            Invalid = 0,
            One,
            Two,
            Three,
            Four,
            All
        }

        public enum LedColor : byte
        {
            Off = 0,
            Purple,
            Red,
            Orange,
            Yellow,
            Green,
            LightBlue,
            Blue,
            White,
        }

        public Led()
        {
            Id = LedNumber.Invalid;
            Color = LedColor.Off;
            Brightness = 0;
            TimeOn = 0;
            TimeTotal = 0;
            NrOfRepeats = 0;
        }

        public LedNumber Id { get; set; }
        public LedColor Color { get; set; }
        public byte Brightness { get; set; }
        public UInt16 TimeOn { get; set; }
        public UInt16 TimeTotal { get; set; }
        public UInt16 NrOfRepeats { get; set; }

        public byte[] ToArray()
        {
            byte[] arr = new byte[9];

            arr[0] = Convert.ToByte(Id);
            arr[1] = Convert.ToByte(Color);
            arr[2] = Brightness;
            byte[] tmp = BitConverter.GetBytes(TimeOn);
            arr[3] = tmp[0];
            arr[4] = tmp[1];
            tmp = BitConverter.GetBytes(TimeTotal);
            arr[5] = tmp[0];
            arr[6] = tmp[1];
            tmp = BitConverter.GetBytes(NrOfRepeats);
            arr[7] = tmp[0];
            arr[8] = tmp[1];

            return arr;
        }

        static public Led FromArray(byte[] data)
        {
            if (data.Length == 9)
            {
                Led led = new Led();

                led.Id = (LedNumber)Enum.Parse(typeof(LedNumber), data[0].ToString());
                led.Color = (LedColor)Enum.Parse(typeof(LedColor), data[1].ToString());
                led.Brightness = data[2];
                led.TimeOn = BitConverter.ToUInt16(data, 3);
                led.TimeTotal = BitConverter.ToUInt16(data, 5);
                led.NrOfRepeats = BitConverter.ToUInt16(data, 7);

                return led;
            }

            return null;    // Error
        }

        static public int Length
        {
            get { return 9; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Id: ");
            sb.Append(Convert.ToByte(Id));
            sb.Append(", ");
            sb.Append("Color: ");
            sb.Append(Color.ToString());
            sb.Append(", ");
            sb.Append("Brightness: ");
            sb.Append(Brightness);
            sb.Append(", ");
            sb.Append("TimeOn: ");
            sb.Append(TimeOn);
            sb.Append(", ");
            sb.Append("TimeTotal: ");
            sb.Append(TimeTotal);
            sb.Append(", ");
            sb.Append("NrOfRepeats: ");
            sb.Append(NrOfRepeats);

            return sb.ToString();
        }
    }
}
