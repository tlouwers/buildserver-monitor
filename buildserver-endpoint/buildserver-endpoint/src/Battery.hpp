
#ifndef BATTERY_HPP_
#define BATTERY_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <stdint.h>


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
class Battery
{
public:
    Battery() {};
    virtual ~Battery() {};

    uint16_t Sample();

    float CalculateVoltage(uint16_t sample);
    float CalculatePercentage(float voltage);
};


#endif // BATTERY_HPP_
