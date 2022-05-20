/**
 * \file    Buzzer.cpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Buzzer class, wrapper for pin toggle (on/off).
 *
 * \details Intended use is to provide an easy means to control an external
 *          buzzer via a pin toggle.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2022
 */

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <string>
#include "Buzzer.hpp"


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
 * \brief   Constructor.
 * \param   logger    Logging class.
 */
Buzzer::Buzzer(ILogging& logger) :
    mLogger(logger),
    mInitialized(false),
    mPin(0xFF)
{ ; }

/**
 * \brief   Destructor. Turns Buzzer off if initialized before.
 */
Buzzer::~Buzzer()
{
    Sleep();
}

/**
 * \brief   Initialize the Buzzer with the pin given via the config.
 * \returns True if init successful, else false.
 */
bool Buzzer::Init(const IConfig& config)
{
    const Config& cfg = reinterpret_cast<const Config&>(config);

    mPin = cfg.mPinID;

    std::string message = "Buzzer at pin " + std::to_string(mPin);
    mLogger.Log(LogLevel::INFO, message.c_str());

    // Configure the pin as output
    pinMode(mPin, OUTPUT);

    mInitialized = true;
    return true;
}

/**
 * \brief   Indicate if Buzzer is initialized.
 * \returns True if Buzzer is initialized, else false.
 */
bool Buzzer::IsInit() const
{
    return mInitialized;
}

/**
 * \brief   Puts the Buzzer module in sleep mode.
 * \returns True if Buzzer module could be put in sleep mode, else false.
 */
bool Buzzer::Sleep()
{
    if (IsOn()) {
        Off();
        mInitialized = false;
        return true;
    }
    return false;
}

/**
 * \brief   Turns the Buzzer On.
 * \returns True if successful, else false.
 */
bool Buzzer::On()
{
    if (mInitialized)
    {
        digitalWrite(mPin, HIGH);
        mLogger.Log(LogLevel::INFO, "Buzzer ON");
        return true;
    }
    return false;
}

/**
 * \brief   Indicate if Buzzer is On or not.
 * \returns True if Buzzer is On, else false.
 */
bool Buzzer::IsOn() const
{
    if (mInitialized)
    {
        const bool result = digitalRead(mPin);
        mLogger.Log(LogLevel::INFO, ((result) ? "Buzzer ON" : "Buzzer OFF"));
        return result;
    }
    return false;
}

/**
 * \brief   Turns the Buzzer Off.
 * \returns True if successful, else false.
 */
bool Buzzer::Off()
{
    if (mInitialized)
    {
        digitalWrite(mPin, LOW);
        mLogger.Log(LogLevel::INFO, "Buzzer OFF");
        return true;
    }
    return false;
}

/**
 * \brief   Toggles the Buzzer pin.
 * \returns True if successful, else false.
 */
bool Buzzer::Toggle()
{
    if (mInitialized)
    {
        const bool result = !digitalRead(mPin);     // Note: result already toggled to the state it should become
        digitalWrite(mPin, result);
        mLogger.Log(LogLevel::INFO, ((result) ? "Buzzer ON" : "Buzzer OFF"));
        return true;
    }
    return false;
}
