
/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include "Vibration.hpp"


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
Vibration::Vibration() :
    mInitialized(false)
{ ; }

Vibration::~Vibration()
{
    if (IsOn()) {
        Off();
    }
}

bool Vibration::Init()
{
    // Configure the pin as output
    pinMode(PIN_VIBRATION, OUTPUT);

    mInitialized = true;
    return true;
}

bool Vibration::IsInit() const
{
    return mInitialized;
}

bool Vibration::On()
{
    if (mInitialized)
    {
        digitalWrite(PIN_VIBRATION, HIGH);
        return true;
    }
    return false;
}

bool Vibration::IsOn() const
{
    if (mInitialized)
    {
        return digitalRead(PIN_VIBRATION);
    }
    return false;
}

bool Vibration::Off()
{
    if (mInitialized)
    {
        digitalWrite(PIN_VIBRATION, LOW);
        return true;
    }
    return false;
}

bool Vibration::Toggle()
{
    if (mInitialized)
    {
        digitalWrite(PIN_VIBRATION, !digitalRead(PIN_VIBRATION));
        return true;
    }
    return false;
}
