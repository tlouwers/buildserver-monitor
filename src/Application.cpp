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
#include "Application.hpp"


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
 * \brief   Constructor.
 */
Application::Application() :
    mLeds(mLogger),
    mSM(mLogger)
{
    ;
}

bool Application::Init()
{
    bool result = false;
  
    mLogger.Log(LogLevel::INFO, versionString);

    result = mLeds.Init();

    delay(1000);

    return result;
}

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
/* Public Methods                                                       */
/************************************************************************/
void Application::HandleStartUp()
{
    mLogger.Log(LogLevel::INFO, "Handling StartUp");

    mLeds.SetColor(1, LedColor::Green);
    delay(1000);
    mLeds.SetColor(LedColor::Off);

    mSM.SetState(State::Idle);
}

void Application::HandleIdle()
{
    mLogger.Log(LogLevel::INFO, "Handling Idle");

    if (TryConnect())
    {
        mSM.SetState(State::Connected);
    }
    // Else: remain Idle
}

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

void Application::HandleDisplaying()
{
    mLogger.Log(LogLevel::INFO, "Handling Displaying");

    if (TryDisplaying())
    {
        mSM.SetState(State::Sleeping);
    }
    else
    {
        mSM.SetState(State::Error);
    }
}

void Application::HandleSleeping()
{
    mLogger.Log(LogLevel::INFO, "Handling Sleeping");

    mLeds.SetColor(1, LedColor::Yellow);
    delay(5000);
    mLeds.SetColor(LedColor::Off);

    mSM.SetState(State::Idle);
}

void Application::HandleError()
{
    mLogger.Log(LogLevel::INFO, "Handling Error");

    mLeds.SetColor(LedColor::Red);
    delay(1000);
    mLeds.SetColor(LedColor::Off);

    mSM.SetState(State::Idle);
}

bool Application::TryConnect()
{
    mLogger.Log(LogLevel::INFO, "Trying to connect...");

    mLeds.SetColor(2, LedColor::Purple);
    delay(1000);
    mLeds.SetColor(LedColor::Off);

    return true;
}

bool Application::TryAcquiring()
{
    mLogger.Log(LogLevel::INFO, "Trying to acquire...");

    mLeds.SetColor(3, LedColor::Blue);
    delay(1000);
    mLeds.SetColor(LedColor::Off);

    return true;
}

bool Application::TryParsing()
{
    mLogger.Log(LogLevel::INFO, "Trying to parse...");

    mLeds.SetColor(4, LedColor::Red);
    delay(1000);
    mLeds.SetColor(LedColor::Off);

    return true;
}

bool Application::TryDisplaying()
{
    mLogger.Log(LogLevel::INFO, "Trying to display...");

    for (uint8_t i = 0; i < 5; i++)
    {
        mLeds.SetColor(LedColor::White);
        delay(150);
        mLeds.SetColor(LedColor::Green);
        delay(150);
        mLeds.SetColor(LedColor::Blue);
        delay(150);
        mLeds.SetColor(LedColor::Purple);
        delay(150);
        mLeds.SetColor(LedColor::Red);
        delay(150);
        mLeds.SetColor(LedColor::Orange);
        delay(150);
        mLeds.SetColor(LedColor::Yellow);
        delay(150);
    }
    mLeds.SetColor(LedColor::Off);

    return true;
}
