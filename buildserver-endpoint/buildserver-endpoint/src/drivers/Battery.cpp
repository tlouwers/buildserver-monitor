
/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <Arduino.h>
#include "Battery.hpp"


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
uint16_t Battery::Sample()
{
    uint16_t sample = 0;

    sample = analogRead(A0);

    Serial.print("Battery (raw): ");
    Serial.println(sample);

    return sample;
}

//  V = Count * (Vmax_adc / ADCbits) * Vbat
float Battery::CalculateVoltage(uint16_t sample)
{
    constexpr float FACTOR = 0.0042609582f;

    return sample * FACTOR;
}

float Battery::CalculatePercentage(float voltage)
{
    constexpr float BATT_LOW  = 3.4f;
    constexpr float BATT_HIGH = 4.15f;

    if (voltage <= BATT_LOW)  { return 0.0; }
    if (voltage >= BATT_HIGH) { return 100.0; }

    return ( (voltage - BATT_LOW) / (BATT_HIGH - BATT_LOW) ) * 100;
}
