/**
 * \file FakeLeds.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Fake implementation of the Led class (wrapper around NeoPixels).
 *
 * \details Intended use is to provide a simulation for when the Leds are not
 *          connected or not used.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    01-2020
 */

#ifndef FAKE_LEDS_HPP_
#define FAKE_LEDS_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include <string>
#include "ILeds.hpp"
#include "ILogging.hpp"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   FakeLeds class.
 */
class FakeLeds final : public ILeds
{
public:
    /**
     * \brief   Constructor.
     * \param   logger    Logging class.
     */
    explicit FakeLeds(ILogging& logger) : mLogger(logger), mInitialized(false) {}
    /**
     * \brief   Destructor.
     */
    virtual ~FakeLeds() {}

    /**
     * \brief   Initialized the fake leds.
     * \returns Always true since there is no hardware.
     */
    bool Init() override { mInitialized = true; return true; }

    /**
     * \brief   Set all leds to the given color.
     * \param   color   The color to set.
     */
    void SetColor(LedColor color) override
    {
        if (mInitialized)
        {
            std::string message = "Set all leds to color [" + mLedColorTypes[static_cast<uint8_t>(color)] + "]";
            mLogger.Log(LogLevel::INFO, message.c_str());
        }
        else
        {
            mLogger.Log(LogLevel::WARNING, "Leds not initialized");
        }
    };
    /**
     * \brief   Set the given led to the given color.
     * \param   led_number  The number of the led in the strain to set.
     * \param   color       The color to set.
     */
    void SetColor(uint8_t led_number, LedColor color) override
    {
        if (mInitialized)
        {
            if (led_number > 0)
            {
                // ToDo: fix NumberToString as this yield square blocks in serial output
                char numberStr[32] = {};
                snprintf(numberStr, 32, "%d", led_number);

                std::string message = "Set led [";
                message.append(numberStr).append("] to color [").append(mLedColorTypes[static_cast<uint8_t>(color)]).append("]");
                mLogger.Log(LogLevel::INFO, message.c_str());
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

private:
    ILogging& mLogger;
    bool      mInitialized;

    // To print LedColor to serial output
    std::string mLedColorTypes[9] =
    {
        "Purple",
        "Red",
        "Orange",
        "Yellow",
        "Green",
        "LightBlue",
        "Blue",
        "White",
        "Off"
    };
};


#endif  // FAKE_LEDS_HPP_
