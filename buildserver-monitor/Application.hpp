/**
 * \file Application.hpp
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

#ifndef APPLICATION_HPP_
#define APPLICATION_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include "config.h"
#if (LEDS == REAL)
    #include "Leds.hpp"
#else
    #include "FakeLeds.hpp"
#endif
#include "FakeLeds.hpp"
#include "Logging.hpp"
#include "StateMachine.hpp"
#include "WifiConnection.hpp"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Main application class.
 */
class Application
{
public:
    Application();
    virtual ~Application() {};

    bool Init();
    void Process();

private:
#if (LEDS == REAL)
    Leds            mLeds;
#else
    FakeLeds        mLeds;
#endif
    Logging         mLogger;
    StateMachine    mSM;
    WifiConnection  mWifi;

    // State handlers
    void HandleStartUp();
    void HandleIdle();
    void HandleConnected();
    void HandleParsing();
    void HandleDisplaying();
    void HandleSleeping();
    void HandleError();

    // Action methods
    bool TryConnect();
    bool TryAcquiring();
    bool TryParsing();
    bool TryDisplaying();
};


#endif // APPLICATION_HPP_
