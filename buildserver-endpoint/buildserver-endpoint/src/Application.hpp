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
//#include "Battery.hpp"
//#include "Buzzer.hpp"
#if (LEDS == REAL)
    #include "drivers/Leds.hpp"
#else
    #include "drivers/FakeLeds.hpp"
#endif
#include "drivers/Timer.hpp"
#include "utility/Logging.hpp"
#include "utility/Timings.hpp"


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
    Leds               mLeds;
#else
    FakeLeds           mLeds;
#endif
    Logging            mLogger;

//    Battery mBattery;
//    Buzzer  mBuzzer;
    Timer   mTimer;

    void Tick();
};


#endif // APPLICATION_HPP_
