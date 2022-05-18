
#ifndef BUZZER_HPP_
#define BUZZER_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <Arduino.h>
#include "config.h"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Buzzer class.
 */
class Buzzer
{
public:
    Buzzer();
    virtual ~Buzzer();

    bool Init();
    bool IsInit() const;

    bool On();
    bool IsOn() const;
    bool Off();
    bool Toggle();

private:
    bool mInitialized;
};


#endif  // BUZZER_HPP_
