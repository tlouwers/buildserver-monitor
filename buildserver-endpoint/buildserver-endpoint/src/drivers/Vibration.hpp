
#ifndef VIBRATION_HPP_
#define VIBRATION_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <Arduino.h>
#include "config.h"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Vibration motor class.
 */
class Vibration
{
public:
    Vibration();
    virtual ~Vibration();

    bool Init();
    bool IsInit() const;

    bool On();
    bool IsOn() const;
    bool Off();
    bool Toggle();

private:
    bool mInitialized;
};


#endif  // VIBRATION_HPP_
