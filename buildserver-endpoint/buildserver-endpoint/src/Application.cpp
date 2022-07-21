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
#include "connection_config.h"
#include "Application.hpp"
#include "utility/Timings.hpp"


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
    mData(mLogger),
    mLeds(mLogger),
    mPacketParser(mLogger),
    mProtocol(mLogger),
    mTimer(mLogger),
    mVibration(mLogger),
    mWifi(mLogger)
{ ; }

/**
 * \brief   Initialize the various peripherals, configures components, connects
 *          to server and show the user the application is starting using the
 *          leds.
 * \returns True if init is successful, else false.
 */
bool Application::Init()
{
    bool result = true;

    mLogger.Log(LogLevel::INFO, VERSION_STRING);

    result &= mBuzzer.Init(Buzzer::Config(PIN_BUZZER));
    result &= mVibration.Init(Vibration::Config(PIN_VIBRATION));
    result &= mLeds.Init();
    result &= mTimer.Init(Timer::Config(FIFTY_MILLISECONDS));

#warning ToDo: handler for wifi received complete packet? Parse chunk?
    mData.SetHandler( [this](const uint8_t* data, uint16_t length) { mPacketParser.StoreData(data, length); } );
    mPacketParser.SetHandler( [this](const uint8_t* data, uint16_t length) { mProtocol.ParseCommand(data, length); } );

    result &= TryConnect();

    result &= mTimer.Start( [this]() { this->Tick(); } );

    return result;
}

/**
 * \brief   Replacement for the main loop of the application: this handles the
 *          data send/receive via the Process loop.
 */
void Application::Process()
{
    uint16_t raw_adc = mBattery.Sample();
    float voltage = mBattery.CalculateVoltage(raw_adc);
    float percentage = mBattery.CalculatePercentage(voltage);

    mBuzzer.Toggle();
    mVibration.Toggle();

    mData.Process();
    mPacketParser.Process();

    Serial.println("Idling...");
    delay(2000);

    mLeds.SetColor(LedColor::Off);
}

/**
 * \brief   Error state. Disconnects from Server and WiFi, blinks red leds then
 *          resets the board.
 */
void Application::Error()
{
    mLogger.Log(LogLevel::ERROR, "Error");

    if (mWifi.IsConnected())
    {
        mWifi.Disconnect();
    }

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


/************************************************************************/
/* Private Methods                                                      */
/************************************************************************/
/**
 * \brief   Try to connect to the WiFi network, if this succeeds then try to
 *          connect to the Server.
 * \returns True if both connections succeed, else false.
 */
bool Application::TryConnect()
{
    mLeds.SetColor(1, LedColor::Blue);

    bool wifiConnected = mWifi.IsConnected();
    if (!wifiConnected)
    {
        wifiConnected = mWifi.Connect(WIFI_CONNECTION_TIMEOUT);   // Can take some time (seconds)!
    }

    bool dataConnected = false;
    if (wifiConnected)
    {
        mLeds.SetColor(2, LedColor::Blue);
        dataConnected = mData.Connect();
    }

    if (dataConnected)
    {
        mLeds.SetColor(LedColor::Green);
    }

    return dataConnected;
}

/**
 * \brief   Callback (dummy) for timer tick to show HW timer is working.
 */
static uint8_t count = 0;
void Application::Tick()
{
    if ( ((++count) % 10) == 0)
    {
        count = 0;
        Serial.println("Tick");
    }
}
