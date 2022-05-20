/**
 * \file    Battery.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Battery class (specific for the Wemos Lolin D1 mino Pro board).
 *
 * \details Intended use is to provide an easy means to measure the battery.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2022
 */

#ifndef BATTERY_HPP_
#define BATTERY_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <stdint.h>
#include "interfaces/IBattery.hpp"
#include "interfaces/ILogging.hpp"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
class Battery final : public IBattery
{
public:
    explicit Battery(ILogging& logger);
    virtual ~Battery() {};

    uint16_t Sample() override;

    float CalculateVoltage(uint16_t sample) override;
    float CalculatePercentage(float voltage) override;

private:
    ILogging& mLogger;
};


#endif // BATTERY_HPP_
