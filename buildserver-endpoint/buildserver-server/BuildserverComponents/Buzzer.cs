using System;
using System.Text;

namespace BuildserverMonitor
{
    public class Buzzer
    {
        public Buzzer()
        {
            TimeOn = 0;
            TimeTotal = 0;
            NrOfRepeats = 0;
        }

        public ushort TimeOn { get; set; }
        public ushort TimeTotal { get; set; }
        public ushort NrOfRepeats { get; set; }

        public byte[] ToArray()
        {
            byte[] arr = new byte[6];

            byte[] tmp = BitConverter.GetBytes(TimeOn);
            arr[0] = tmp[0];
            arr[1] = tmp[1];
            tmp = BitConverter.GetBytes(TimeTotal);
            arr[2] = tmp[0];
            arr[3] = tmp[1];
            tmp = BitConverter.GetBytes(NrOfRepeats);
            arr[4] = tmp[0];
            arr[5] = tmp[1];

            return arr;
        }

        static public Buzzer FromArray(byte[] data)
        {
            if (data.Length == 6)
            {
                Buzzer buzzer = new Buzzer();

                buzzer.TimeOn = BitConverter.ToUInt16(data, 0);
                buzzer.TimeTotal = BitConverter.ToUInt16(data, 2);
                buzzer.NrOfRepeats = BitConverter.ToUInt16(data, 4);

                return buzzer;
            }

            return null;    // Error
        }

        public void DeepCopy(Buzzer buzzer)
        {
            TimeOn = buzzer.TimeOn;
            TimeTotal = buzzer.TimeTotal;
            NrOfRepeats = buzzer.NrOfRepeats;
        }

        static public int Length
        {
            get { return 6; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

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
