/**
 * \file    Timer.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Timer class (wrapper around Hardware timer).
 *
 * \details Intended use is to provide an easy means to get a callback on hardware
 *          timer tick.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2022
 */

/************************************************************************/
/* Defines                                                              */
/************************************************************************/
// Required for the 'ESP8266TimerInterrupt' module: select a timer divider.
#define USING_TIM_DIV1      true    // for shortest and most accurate timer
#define USING_TIM_DIV16     false   // for medium time and medium accurate timer
#define USING_TIM_DIV256    false   // for longest timer but least accurate. Default


#ifndef TIMER_HPP_
#define TIMER_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include "ESP8266TimerInterrupt.h"
#include "interfaces/IInitable.hpp"
#include "interfaces/ILogging.hpp"
#include "interfaces/ITimer.hpp"


/************************************************************************/
/* Structures                                                           */
/************************************************************************/
/**
 * \struct  TimerStruct
 * \brief   Data structure to contain callback for Timer instance.
 */
struct TimerStruct {
    std::function<void()> callback = nullptr;  ///< Callback to call when Timer ISR occurs.
};


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Timer class. Wrapper for ESP8266 ISR based timer.
 */
class Timer final : public ITimer, public IConfigInitable
{
public:
    /**
     * \struct  Config
     * \brief   Configuration struct for Timer.
     */
    struct Config : public IConfig
    {
        /**
         * \brief   Constructor of the Timer configuration struct.
         * \param   milliseconds    Tick interval in milliseconds.
         */
        Config(uint32_t milliseconds) :
            mMilliseconds(milliseconds)
        { }

        uint32_t mMilliseconds;     ///< The tick interval in milliseconds.
    };

    explicit Timer(ILogging& logger);
    virtual ~Timer();

    bool Init(const IConfig& config) override;
    bool IsInit() const override;
    bool Sleep() override;

    bool Start(const std::function<void()>& handler) override;
    bool IsStarted() const override;
    bool Stop() override;

private:
    ESP8266Timer mTimer;
    TimerStruct& mTimerStruct;
    ILogging&    mLogger;
    bool         mInitialized;
    bool         mStarted;
};


#endif  // TIMER_HPP_
