/**
 * \file    Leds.cpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Led class (wrapper around NeoPixels).
 *
 * \details Intended use is to provide an easy means to setup and control the
 *          connected NeoPixels.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    01-2020
 */

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include "config.h"
#include "Leds.hpp"
#include "Utilities.hpp"
#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
    #include <avr/power.h>
#endif


/************************************************************************/
/* Static variables                                                     */
/************************************************************************/
static Adafruit_NeoPixel mStrip(NUMBER_OF_NEOPIXELS, PIN_NEOPIXEL_DATA, NEO_GRB + NEO_KHZ800);


 /************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
 * \brief   Constructor.
 * \param   logger    Logging class.
 */
Leds::Leds(ILogging& logger) :
    mLogger(logger),
    mInitialized(false)
{ ; }

/**
 * \brief   Destructor. Turns leds off it initialized before.
 */
Leds::~Leds()
{
    if (mInitialized)
    {
        SetColor(LedColor::Off);
    }
    mInitialized = false;
}

/**
 * \brief   Initialized the leds with color off.
 * \returns True if init successful, else false.
 */
bool Leds::Init()
{
    // These lines are specifically to support the Adafruit Trinket 5V 16 MHz.
    // Any other board, you can remove this part (but no harm leaving it):
    #if defined(__AVR_ATtiny85__) && (F_CPU == 16000000)
        clock_prescale_set(clock_div_1);
    #endif

    if (!mInitialized)
    {
        if (NUMBER_OF_NEOPIXELS > 0)
        {
            mLogger.Log(LogLevel::INFO, "All leds off");
            mStrip.begin();             // INITIALIZE NeoPixel strip object (REQUIRED)
            mStrip.setBrightness(128);  // Set the overall brightness to 50%
            mStrip.show();              // Turn OFF all pixels ASAP
            mInitialized = true;
            return true;
        }
        else
        {
            mLogger.Log(LogLevel::ERROR, "No leds configured!");
            return false;
        }
    }
    else
    {
        mLogger.Log(LogLevel::INFO, "Already initialized the leds");
        SetColor(LedColor::Off);
        return true;
    }
}

/**
 * \brief   Set all leds to the given color.
 * \param   color   The color to set.
 */
void Leds::SetColor(LedColor color)
{
    if (mInitialized)
    {
        std::string message = "Set all leds to color [" + mLedColorTypes[static_cast<uint8_t>(color)] + "]";
        mLogger.Log(LogLevel::ALL, message.c_str());

        mStrip.fill(ConvertColor(color), 0, NUMBER_OF_NEOPIXELS);
        mStrip.show();
    }
    else
    {
        mLogger.Log(LogLevel::WARNING, "Leds not initialized");
    }
}

/**
 * \brief   Set the given led to the given color.
 * \param   led_number  The number of the led in the strain to set.
 * \param   color       The color to set.
 */
void Leds::SetColor(uint8_t led_number, LedColor color)
{
    if (mInitialized)
    {
        if (led_number > 0)
        {
            std::string message = "Set led [" + NumberToString(led_number) + "] to color [" + mLedColorTypes[static_cast<uint8_t>(color)] + "]";
            mLogger.Log(LogLevel::ALL, message.c_str());

            // Number is 1 higher than the index of the led in the strand
            mStrip.setPixelColor(led_number - 1, ConvertColor(color));
            mStrip.show();
        }
        else
        {
            mLogger.Log(LogLevel::ERROR, "Invalid led number!");
        }
    }
    else
    {
        mLogger.Log(LogLevel::WARNING, "Leds not initialized");
    }
}

/**
 * \brief   Convert a LedColor to a uint32_t, which represents a compacted color struct.
 * \param   color   The color to convert.
 * \returns A uint32_t value representing the compacted color struct.
 */
uint32_t Leds::ConvertColor(LedColor color)
{
    uint32_t colorCode = 0;

    switch (color)
    {
        case LedColor::Purple:    colorCode = mStrip.Color(127,   0, 255); break;
        case LedColor::Red:       colorCode = mStrip.Color(255,   0,   0); break;
        case LedColor::Orange:    colorCode = mStrip.Color(255, 127,   0); break;
        case LedColor::Yellow:    colorCode = mStrip.Color(255, 255,   0); break;
        case LedColor::Green:     colorCode = mStrip.Color(  0, 255,   0); break;
        case LedColor::LightBlue: colorCode = mStrip.Color(  0, 255, 255); break;
        case LedColor::Blue:      colorCode = mStrip.Color(  0,   0, 255); break;
        case LedColor::White:     colorCode = mStrip.Color(255, 255, 255); break;

        case LedColor::Off:   // Fall-thru
        default:
            break;
    }

    return colorCode;
}
