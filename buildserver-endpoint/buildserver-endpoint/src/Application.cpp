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
    mLeds(mLogger),
    mTimer(mLogger)
{ ; }

bool Application::Init()
{
    bool result = true;

    mLogger.Log(LogLevel::INFO, versionString);

    if (!mLeds.Init()) { result = false; }
    if (!mTimer.Init(Timer::Config(50))) { result = false; }

    result = mTimer.Start( [this]() { this->Tick(); } );

    return result;
}

void Application::Process()
{
    // uint16_t raw_adc = mBattery.Sample();

    // float voltage = mBattery.CalculateVoltage(raw_adc);
    // Serial.print("Voltage = ");
    // Serial.println(voltage);

    // float percentage = mBattery.CalculatePercentage(voltage);
    // Serial.print("Percentage = ");
    // Serial.println(percentage);

    // mBuzzer.Toggle();

    Serial.println("Idling...");
    delay(2000);
}

static uint8_t count = 0;
void Application::Tick()
{
    if ( ((++count) % 10) == 0)
    {
        count = 0;
        Serial.println("Tick");

//        bool on = mBuzzer.IsOn();
//        if (on) { mBuzzer.Off(); }
//        else    { mBuzzer.On();  }
    }
}
