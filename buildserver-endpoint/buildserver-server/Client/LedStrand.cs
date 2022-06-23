using System;
using System.Text;

namespace BuildserverMonitor
{
    public delegate void LedColorHandler(object sender, Led.LedNumber number, Led.LedColor color);

    public class LedStrand
    {
        #region Events

        public event LedColorHandler LedColor;

        #endregion


        #region Constants

        private const int NUMBER_OF_NEOPIXELS = 4;              // 254 is the max
        private Led[] mLeds = new Led[NUMBER_OF_NEOPIXELS];

        #endregion


        #region Public methods

        public LedStrand()
        {
            for (var i = 0; i < NumberOfLeds; i++)
            {
                mLeds[i] = new Led();
                mLeds[i].Id = (Led.LedNumber)Enum.Parse(typeof(Led.LedNumber), (i + 1).ToString());
            }
        }

        static public int NumberOfLeds
        {
            get
            {
                return NUMBER_OF_NEOPIXELS;
            }
        }

        public Led Get(byte led_nr)
        {
            Led led = null;    // Invalid one: check the Id --> must be > 0

            if ((led_nr > 0) && (led_nr <= NUMBER_OF_NEOPIXELS))
            {
                return mLeds[led_nr - 1];
            }

            return led;
        }

        public bool Set(Led led)
        {
            byte led_nr = Convert.ToByte(led.Id);

            if ((led_nr > 0) && (led_nr <= NUMBER_OF_NEOPIXELS))
            {
                mLeds[led_nr - 1] = led;

                if (LedColor != null)
                {
                    LedColor(this, led.Id, led.Color);
                }

                return true;
            }

            return false;
        }

        #endregion
    }
}
