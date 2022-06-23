/**
 * \file    Battery.cpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Battery class (specific for the Wemos Lolin D1 mini Pro board).
 *
 * \details Intended use is to provide an easy means to measure the battery.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2022
 */

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <Arduino.h>
#include <string>
#include "Battery.hpp"
#include "utility/Utilities.hpp"


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
 * \brief   Constructor.
 * \param   logger    Logging class.
 */
Battery::Battery(ILogging& logger) :
    mLogger(logger)
{ ; }

/**
 * \brief   Take a sample of the battery voltage.
 * \returns 10-bit ADC count of the measured battery voltage.
 */
uint16_t Battery::Sample()
{
    uint16_t sample = analogRead(A0);

    std::string message = "Measured battery sample of " + NumberToString(sample) + " ADC counts";
    mLogger.Log(LogLevel::INFO, message.c_str());

    return sample;
}

/**
 * \brief   Calculate the voltage based upon a given sample value.
 * \param   sample  The measured sample in ADC counts.
 * \returns The sample value in Volts.
 */
float Battery::CalculateVoltage(uint16_t sample)
{
    // V = Count * (Vmax_adc / ADCbits) * Vbat
    constexpr float FACTOR = 0.0042609582f;

    float result = sample * FACTOR;
    std::string message = "Battery at " + NumberToString(result) + "V";
    mLogger.Log(LogLevel::INFO, message.c_str());

    return result;
}

/**
 * \brief   Calculate the percentage based upon a given voltage.
 * \param   voltage     The voltage to convert.
 * \returns The battery voltage as percentage full.
 */
float Battery::CalculatePercentage(float voltage)
{
    // The low and high limits indicating 0% and 100% full
    constexpr float BATT_LOW  = 3.4f;
    constexpr float BATT_HIGH = 4.15f;

    // Clip results (if needed)
    if (voltage <= BATT_LOW)
    {
        mLogger.Log(LogLevel::INFO, "Battery clips 0%");
        return 0.0;
    }
    if (voltage >= BATT_HIGH)
    {
        mLogger.Log(LogLevel::INFO, "Battery clips, 100%");
        return 100.0;
    }

    float result = ( (voltage - BATT_LOW) / (BATT_HIGH - BATT_LOW) ) * 100;
    std::string message = "Battery at " + NumberToString(result) + "%";
    mLogger.Log(LogLevel::INFO, message.c_str());
    return result;
}
