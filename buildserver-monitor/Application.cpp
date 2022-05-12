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
 * \brief   Main application file for Buildserver Monitor.
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
    mSM(mLogger),
    mWifi(mLogger),
    mHttp(mLogger),
    mBuildState(BuildState::NoState)
{ ; }

/**
 * \brief   Initialize the various peripherals, configures components and show
 *          the user the application is starting using the leds.
 * \returns True if init is successful, else false.
 */
bool Application::Init()
{
    bool result = true;

    mLogger.Log(LogLevel::INFO, versionString);

    if(!mLeds.Init()) { result = false; }
    if(!mHttp.Init()) { result = false; }

    return result;
}

/**
 * \brief   Replacement for the main loop of the application: this handles the
 *          state machine and transitions in its Process loop.
 */
void Application::Process()
{
    switch (mSM.GetState())
    {
        case State::StartUp:    HandleStartUp();    break;
        case State::Idle:       HandleIdle();       break;
        case State::Connected:  HandleConnected();  break;
        case State::Parsing:    HandleParsing();    break;
        case State::Displaying: HandleDisplaying(); break;
        case State::Sleeping:   HandleSleeping();   break;
        case State::Error:      HandleError();      break;

        default:
            mLogger.Log(LogLevel::ERROR, "Invalid state!");
            delay(ONE_SECOND);
            mLogger.Log(LogLevel::INFO, "Reset the board");
            resetFunc();
            break;
    }
}


/************************************************************************/
/* Private Methods                                                      */
/************************************************************************/
/**
 * \brief   Worker method for the StartUp state.
 */
void Application::HandleStartUp()
{
    mLogger.Log(LogLevel::INFO, "StartUp");

    mLeds.SetColor(LedColor::Off);
    mLeds.SetColor(1, LedColor::Blue);

    mSM.SetState(State::Idle);
}

/**
 * \brief   Worker method for the Idle state.
 */
void Application::HandleIdle()
{
    mLogger.Log(LogLevel::INFO, "Idle");

    if (TryConnect())
    {
        mSM.SetState(State::Connected);
    }
    else
    {
        mSM.SetState(State::Error);
    }
}

/**
 * \brief   Worker method for the Connected state.
 */
void Application::HandleConnected()
{
    mLogger.Log(LogLevel::INFO, "Connected");

    if (TryAcquiring())
    {
        mSM.SetState(State::Parsing);
    }
    else
    {
        mSM.SetState(State::Error);
    }
}

/**
 * \brief   Worker method for the Parsing state.
 */
void Application::HandleParsing()
{
    mLogger.Log(LogLevel::INFO, "Parsing");

    if (TryParsing())
    {
        mSM.SetState(State::Displaying);
    }
    else
    {
        mSM.SetState(State::Error);
    }
}

/**
 * \brief   Worker method for the Displaying state.
 */
void Application::HandleDisplaying()
{
    mLogger.Log(LogLevel::INFO, "Displaying");

    if (TryDisplaying())
    {
        mSM.SetState(State::Sleeping);
    }
    else
    {
        mSM.SetState(State::Error);
    }
}

/**
 * \brief   Worker method for the Sleeping state.
 */
void Application::HandleSleeping()
{
    mLogger.Log(LogLevel::INFO, "Sleeping");

    if (mWifi.IsConnected())
    {
        mWifi.Disconnect();
    }

    // Do not turn of the leds here: during sleep the status of the build is to be displayed.
    delay(ONE_MINUTE);

    mSM.SetState(State::Idle);
}

/**
 * \brief   Error state. Disconnects from WiFi, blinks red led then resets the board.
 */
void Application::HandleError()
{
    mLogger.Log(LogLevel::INFO, "Error");

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

/**
 * \brief   Try to connect to WiFi network (with given credentials).
 * \returns True if connection could be established, else false.
 */
bool Application::TryConnect()
{
    mLogger.Log(LogLevel::INFO, "Connecting to WiFi network...");

    bool isConnected = mWifi.IsConnected();

    if (!isConnected)
    {
        isConnected = mWifi.Connect(WIFI_CONNECTION_TIMEOUT);   // Can take some time (seconds)!
    }

    return isConnected;
}

/**
 * \brief   Try to acquire JSON data from buildserver.
 * \returns True if data could be acquired, else false.
 */
bool Application::TryAcquiring()
{
    mLogger.Log(LogLevel::INFO, "Acquiring status from Jenkins server...");

    return mHttp.Acquire();
}

/**
 * \brief   Try to parse retrieved buildserver data for the branch build status.
 * \returns True if data could be parsed, else false.
 */
bool Application::TryParsing()
{
    mBuildState = BuildState::NoState;

    mLogger.Log(LogLevel::INFO, "Parsing branch status...");
    if (mHttp.Parse())
    {
        mLogger.Log(LogLevel::INFO, "Retrieving build status...");

        mBuildState = mHttp.getBuildState();
        return true;
    }
    return false;
}

/**
 * \brief   Display build status.
 * \returns True, always.
 */
bool Application::TryDisplaying()
{
    mLogger.Log(LogLevel::INFO, "Displaying build status...");

    switch (mBuildState)
    {
        case BuildState::Success:   mLeds.SetColor(LedColor::Green);  break;
        case BuildState::Unstable:  mLeds.SetColor(LedColor::Yellow); break;
        case BuildState::Failure:   mLeds.SetColor(LedColor::Red);    break;
        case BuildState::Aborted:   mLeds.SetColor(LedColor::Blue);   break;
        case BuildState::NotBuild:  mLeds.SetColor(LedColor::Purple); break;
        case BuildState::NoState:   mLeds.SetColor(LedColor::White);  break;
        default:
            mLogger.Log(LogLevel::ERROR, "Invalid BuildState!");
            break;
    }

    // Do not turn of the leds here: during sleep the status of the build is to be displayed.

    return true;
}
