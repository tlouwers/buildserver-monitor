
/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include "Timer.hpp"


/************************************************************************/
/* Static variables                                                     */
/************************************************************************/
static TimerStruct timerStruct {};


static void IRAM_ATTR TimerHandler()
{
    if (timerStruct.callback)
    {
        timerStruct.callback();
    }
}



/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
Timer::Timer() :
    mTimerStruct(timerStruct),
    mInitialized(false),
    mStarted(false)
{ ; }

Timer::~Timer()
{
    if (IsStarted()) {
        Stop();
    }
}

bool Timer::Init()
{
    // Interval is fixed to 50 ms
    constexpr uint32_t MILLISECONDS = 1000;

    if (mTimer.attachInterruptInterval(50 * MILLISECONDS, TimerHandler))
    {
        mTimer.stopTimer();
        mInitialized = true;
        return true;
    }
    return false;
}

bool Timer::IsInit() const
{
    return mInitialized;
}

bool Timer::Start(const std::function<void()>& handler)
{
    if (mInitialized)
    {
        mTimerStruct.callback = handler;
        mTimer.enableTimer();
        mStarted = true;
        return true;
    }
    return false;
}

bool Timer::IsStarted() const
{
    if (mInitialized)
    {
        return mStarted;
    }
    return false;
}

bool Timer::Stop()
{
    if (mInitialized && mStarted)
    {
        mTimer.stopTimer();
        mStarted = false;
        return true;
    }
    return false;
}
