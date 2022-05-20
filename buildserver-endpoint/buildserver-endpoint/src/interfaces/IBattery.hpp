 /**
 * \file    IBattery.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Battery interface class.
 *
 * \details This class is intended to act as interface for the Battery class,
 *          to ease unit testing.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2022
 */

#ifndef IBATTERY_HPP_
#define IBATTERY_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include <functional>


/************************************************************************/
/* Interface declaration                                                */
/************************************************************************/
/**
 * \brief   IBattery interface class.
 */
class IBattery
{
public:
    virtual uint16_t Sample() = 0;

    virtual float CalculateVoltage(uint16_t sample) = 0;
    virtual float CalculatePercentage(float voltage) = 0;
};


#endif  // IBATTERY_HPP_
