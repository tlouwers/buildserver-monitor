
/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include "Buzzer.hpp"


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
Buzzer::Buzzer() :
    mInitialized(false)
{ ; }

Buzzer::~Buzzer()
{
    if (IsOn()) {
        Off();
    }
}

bool Buzzer::Init()
{
    // Configure the pin as output
    pinMode(PIN_BUZZER, OUTPUT);

    mInitialized = true;
    return true;
}

bool Buzzer::IsInit() const
{
    return mInitialized;
}

bool Buzzer::On()
{
    if (mInitialized)
    {
        digitalWrite(PIN_BUZZER, HIGH);
        return true;
    }
    return false;
}

bool Buzzer::IsOn() const
{
    if (mInitialized)
    {
        return digitalRead(PIN_BUZZER);
    }
    return false;
}

bool Buzzer::Off()
{
    if (mInitialized)
    {
        digitalWrite(PIN_BUZZER, LOW);
        return true;
    }
    return false;
}

bool Buzzer::Toggle()
{
    if (mInitialized)
    {
        digitalWrite(PIN_BUZZER, !digitalRead(PIN_BUZZER));
        return true;
    }
    return false;
}
