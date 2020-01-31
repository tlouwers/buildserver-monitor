/**
 * \file Application.cpp
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
    mState(BuildState::NoState)
{ 
  ; 
}

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

    delay(1000);

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
    mLogger.Log(LogLevel::INFO, "Handling StartUp");

    mLeds.SetColor(1, LedColor::Green);
    delay(1000);
    mLeds.SetColor(LedColor::Off);

    mSM.SetState(State::Idle);
}

/**
 * \brief   Worker method for the Idle state.
 */
void Application::HandleIdle()
{
    mLogger.Log(LogLevel::INFO, "Handling Idle");

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
    mLogger.Log(LogLevel::INFO, "Handling Connected");

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
    mLogger.Log(LogLevel::INFO, "Handling Parsing");

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
    mLogger.Log(LogLevel::INFO, "Handling Displaying");

    if (TryDisplaying())
    {
        if (mWifi.IsConnected())
        {
            mWifi.Disconnect();
        }
      
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
    mLogger.Log(LogLevel::INFO, "Handling Sleeping");

    mLeds.SetColor(1, LedColor::Yellow);
    delay(5000);
    mLeds.SetColor(LedColor::Off);

    mSM.SetState(State::Idle);
}

/**
 * \brief   Worker method for the Error state.
 */
void Application::HandleError()
{
    mLogger.Log(LogLevel::INFO, "Handling Error");

    mLeds.SetColor(LedColor::Red);
    delay(1000);
    mLeds.SetColor(LedColor::Off);

    // Discuss: move to Sleeping state first? This would turn off WiFi/Leds/...
    delay(4000);

    mSM.SetState(State::Idle);
}

/**
 * \brief   Dummy method to mimic an attempt to connect to the WiFi network.
 * \returns True, always.
 */
bool Application::TryConnect()
{
    mLogger.Log(LogLevel::INFO, "Trying to connect...");

    mLeds.SetColor(2, LedColor::Purple);

    bool isConnected = mWifi.IsConnected();
    
    if (!isConnected)
    {
        isConnected = mWifi.Connect(WIFI_CONNECTION_TIMEOUT);   // Can take some time (seconds)!
    }

    mLeds.SetColor(LedColor::Off);
    
    return isConnected;
}

/**
 * \brief   Dummy method to mimic an attempt to acquire data from buildserver.
 * \returns True, always.
 */
bool Application::TryAcquiring()
{
    mLogger.Log(LogLevel::INFO, "Trying to acquire...");

    mLeds.SetColor(3, LedColor::Blue);
    delay(1000);

    bool result = mHttp.Acquire();
    Serial.println("hello there");
    
    mLeds.SetColor(LedColor::Off);

    return result;
}

/**
 * \brief   Dummy method to mimic an attempt to parse buildserver data and retrieve a build status.
 * \returns True, always.
 */
bool Application::TryParsing()
{
    mLogger.Log(LogLevel::INFO, "Trying to parse...");

    mLeds.SetColor(4, LedColor::Red);
    delay(1000);

    bool result = mHttp.Parse();
    if (!result) { return false; }

    mState = mHttp.getBuildState();
    Serial.println(int(mState));
    
    mLeds.SetColor(LedColor::Off);

    return result;
}

/**
 * \brief   Dummy method to mimic display of the found build status.
 * \returns True, always.
 */
bool Application::TryDisplaying()
{
    mLogger.Log(LogLevel::INFO, "Trying to display...");

    switch (mState)
    {
        case BuildState::Success:   mLeds.SetColor(LedColor::Green); break;
        case BuildState::Unstable:  mLeds.SetColor(LedColor::Yellow); break;
        case BuildState::Failure:   mLeds.SetColor(LedColor::Red); break;
        case BuildState::Aborted:   mLeds.SetColor(LedColor::Blue); break;
        case BuildState::NotBuild:  mLeds.SetColor(LedColor::Purple); break;
        case BuildState::NoState:   mLeds.SetColor(LedColor::White); break;
        default:   
            break;
    }
    delay(1000);
    mLeds.SetColor(LedColor::Off);

    mState = BuildState::NoState;

    return true;
}
