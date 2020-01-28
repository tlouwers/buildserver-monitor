/**
 * \file Leds.hpp
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

#ifndef LEDS_HPP_
#define LEDS_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include <string>
#include "ILogging.hpp"


/************************************************************************/
/* Enums                                                                */
/************************************************************************/
/**
 * \enum    LedColor
 * \brief   Available led colors.
 */
enum class LedColor : uint8_t
{
    Purple,
    Red,
    Orange,
    Yellow,
    Green,
    LightBlue,
    Blue,
    White,
    Off
};


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Leds class.
 */
class Leds
{
public:
    explicit Leds(ILogging& logger);
    virtual ~Leds();

    bool Init();

    void SetColor(LedColor color);
    void SetColor(uint8_t led_number, LedColor color);

private:
    ILogging& mLogger;
    bool      mInitialized;

    uint32_t ConvertColor(LedColor color);

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


#endif  // LEDS_HPP_
