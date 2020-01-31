 /**
 * \file ILeds.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Leds interface class.
 *
 * \details This class is intended to act as interface for the Leds class,
 *          to ease unit testing.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    01-2020
 */

#ifndef ILEDS_HPP_
#define ILEDS_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include "config.h"


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
/* Interface declaration                                                */
/************************************************************************/
/**
 * \brief   ILeds interface class.
 */
class ILeds
{
public:
    virtual bool Init() = 0;

    virtual void SetColor(LedColor color) = 0;
    virtual void SetColor(uint8_t led_number, LedColor color) = 0;
};


#endif  // ILEDS_HPP_
