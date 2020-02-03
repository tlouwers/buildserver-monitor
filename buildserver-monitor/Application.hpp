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
#include "Leds.hpp"
#include "Logging.hpp"
#include "StateMachine.hpp"
#include "WifiConnection.hpp"
#include "httpClient.hpp"


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
    Leds            mLeds;
    Logging         mLogger;
    StateMachine    mSM;
    WifiConnection  mWifi;
    httpClient      mHttp;

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

    BuildState mBuildState;
};


#endif // APPLICATION_HPP_
