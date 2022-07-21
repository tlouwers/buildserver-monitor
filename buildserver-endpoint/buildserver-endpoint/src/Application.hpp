/**
 * \file    Application.hpp
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

#ifndef APPLICATION_HPP_
#define APPLICATION_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include "config.h"
#include "drivers/Battery.hpp"
#include "drivers/Buzzer.hpp"
#if (DATA == REAL)
    #include "connection/DataConnection.hpp"
#else
    #include "connection/FakeDataConnection.hpp"
#endif
#if (LEDS == REAL)
    #include "drivers/Leds.hpp"
#else
    #include "drivers/FakeLeds.hpp"
#endif
#include "connection/PacketParser.hpp"
#include "connection/ProtocolHandler.hpp"
#include "drivers/Timer.hpp"
#include "drivers/Vibration.hpp"
#if (WIFI == REAL)
    #include "connection/WifiConnection.hpp"
#else
    #include "connection/FakeWifiConnection.hpp"
#endif
#include "utility/Logging.hpp"


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
    void Error();

private:
    Logging            mLogger;
    Battery            mBattery;
    Buzzer             mBuzzer;
#if (DATA == REAL)
    DataConnection     mData;
#else
    FakeDataConnection mData;
#endif
#if (LEDS == REAL)
    Leds               mLeds;
#else
    FakeLeds           mLeds;
#endif
    PacketParser       mPacketParser;
    ProtocolHandler    mProtocol;
    Timer              mTimer;
    Vibration          mVibration;
#if (WIFI == REAL)
    WifiConnection     mWifi;
#else
    FakeWifiConnection mWifi;
#endif

    bool TryConnect();
    void Tick();
};


#endif // APPLICATION_HPP_
