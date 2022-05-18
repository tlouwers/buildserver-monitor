
// Select a Timer Clock
#define USING_TIM_DIV1      true    // for shortest and most accurate timer
#define USING_TIM_DIV16     false   // for medium time and medium accurate timer
#define USING_TIM_DIV256    false   // for longest timer but least accurate. Default

#ifndef TIMER_HPP_
#define TIMER_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <functional>
#include "ESP8266TimerInterrupt.h"


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
class Timer
{
public:
    Timer();
    virtual ~Timer();

    bool Init();
    bool IsInit() const;

    bool Start(const std::function<void()>& handler);
    bool IsStarted() const;
    bool Stop();

private:
    ESP8266Timer mTimer;
    TimerStruct& mTimerStruct;
    bool         mInitialized;
    bool         mStarted;
};


#endif  // TIMER_HPP_
