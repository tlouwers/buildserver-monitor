/**
 * \file    Application.cpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Main application file for Buildserver Endpoint.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    01-2020
 */

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <Arduino.h>
#include "wifi_config.h"
#include "Application.hpp"


/************************************************************************/
/* Reset function declaration                                           */
/************************************************************************/
// https://www.instructables.com/id/two-ways-to-reset-arduino-in-software/
#ifndef DOXYGEN_SHOULD_SKIP_THIS
void(* resetFunc) (void) = 0;
#endif


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
 * \brief   Constructor.
 */
Application::Application() :
    // Get the configured log level from 'config.h' file --> (int) to (uint8_t) to (LogLevel)
    mLogger(static_cast<LogLevel>(static_cast<uint8_t>(LOG_LEVEL))),
    mBattery(mLogger),
    mBuzzer(mLogger),
    mLeds(mLogger),
    mTimer(mLogger),
    mVibration(mLogger)
{ ; }

bool Application::Init()
{
    bool result = true;

    mLogger.Log(LogLevel::INFO, versionString);

    result &= mBuzzer.Init(Buzzer::Config(PIN_BUZZER));
    result &= mVibration.Init(Vibration::Config(PIN_VIBRATION));
    result &= mLeds.Init();
    result &= mTimer.Init(Timer::Config(50));

    result &= mTimer.Start( [this]() { this->Tick(); } );

    return result;
}

void Application::Process()
{
    uint16_t raw_adc = mBattery.Sample();
    float voltage = mBattery.CalculateVoltage(raw_adc);
    float percentage = mBattery.CalculatePercentage(voltage);

    mBuzzer.Toggle();
    mVibration.Toggle();

    Serial.println("Idling...");
    delay(2000);
}

void Application::Error()
{
    mLogger.Log(LogLevel::ERROR, "Error");

//    if (mWifi.IsConnected())
//    {
//        mWifi.Disconnect();
//    }

    // Blink red leds to indicate error
    for (auto i = 0; i < 10; i++) {
        mLeds.SetColor(LedColor::Red);
        delay(HALF_SECOND);
        mLeds.SetColor(LedColor::Off);
        delay(HALF_SECOND);
    }

    mLogger.Log(LogLevel::INFO, "Reset the board");
    resetFunc();
}

static uint8_t count = 0;
void Application::Tick()
{
    if ( ((++count) % 10) == 0)
    {
        count = 0;
        Serial.println("Tick");
    }
}
