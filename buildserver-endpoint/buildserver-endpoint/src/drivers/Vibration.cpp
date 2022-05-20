/**
 * \file    Vibration.cpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Vibration class, wrapper for pin toggle (on/off).
 *
 * \details Intended use is to provide an easy means to control an external
 *          vibration motor via a pin toggle.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2022
 */

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <string>
#include "Vibration.hpp"


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
 * \brief   Constructor.
 * \param   logger    Logging class.
 */
Vibration::Vibration(ILogging& logger) :
    mLogger(logger),
    mInitialized(false),
    mPin(0xFF)
{ ; }

/**
 * \brief   Destructor. Turns Vibration off if initialized before.
 */
Vibration::~Vibration()
{
    digitalWrite(mPin, LOW);
    mInitialized = false;
}

/**
 * \brief   Initialize the Vibration with the pin given via the config.
 * \returns True if init successful, else false.
 */
bool Vibration::Init(const IConfig& config)
{
    const Config& cfg = reinterpret_cast<const Config&>(config);

    mPin = cfg.mPinID;

    std::string message = "Vibration at pin " + std::to_string(mPin);
    mLogger.Log(LogLevel::INFO, message.c_str());

    // Configure the pin as output
    pinMode(mPin, OUTPUT);

    mInitialized = true;
    return true;
}

/**
 * \brief   Indicate if Vibration is initialized.
 * \returns True if Vibration is initialized, else false.
 */
bool Vibration::IsInit() const
{
    return mInitialized;
}

/**
 * \brief   Puts the Vibration module in sleep mode.
 * \returns True if Vibration module could be put in sleep mode, else false.
 */
bool Vibration::Sleep()
{
    if (IsOn()) {
        Off();
        mInitialized = false;
        return true;
    }
    return false;
}

/**
 * \brief   Turns the Vibration On.
 * \returns True if successful, else false.
 */
bool Vibration::On()
{
    if (mInitialized)
    {
        digitalWrite(mPin, HIGH);
        mLogger.Log(LogLevel::INFO, "Vibration ON");
        return true;
    }
    return false;
}

/**
 * \brief   Indicate if Vibration is On or not.
 * \returns True if Vibration is On, else false.
 */
bool Vibration::IsOn() const
{
    if (mInitialized)
    {
        const bool result = digitalRead(mPin);
        mLogger.Log(LogLevel::INFO, ((result) ? "Vibration ON" : "Vibration OFF"));
        return result;
    }
    return false;
}

/**
 * \brief   Turns the Vibration Off.
 * \returns True if successful, else false.
 */
bool Vibration::Off()
{
    if (mInitialized)
    {
        digitalWrite(mPin, LOW);
        mLogger.Log(LogLevel::INFO, "Vibration OFF");
        return true;
    }
    return false;
}

/**
 * \brief   Toggles the Vibration pin.
 * \returns True if successful, else false.
 */
bool Vibration::Toggle()
{
    if (mInitialized)
    {
        const bool result = !digitalRead(mPin);     // Note: result already toggled to the state it should become
        digitalWrite(mPin, result);
        mLogger.Log(LogLevel::INFO, ((result) ? "Vibration ON" : "Vibration OFF"));
        return true;
    }
    return false;
}
