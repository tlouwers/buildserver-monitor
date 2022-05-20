/**
 * \file    Timer.cpp
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
/* Includes                                                             */
/************************************************************************/
#include <string>
#include "Timer.hpp"
#include "utility/Utilities.hpp"


/************************************************************************/
/* Static variables                                                     */
/************************************************************************/
static TimerStruct timerStruct {};


/************************************************************************/
/* Static functions                                                     */
/************************************************************************/
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
/**
 * \brief   Constructor.
 * \param   logger    Logging class.
 */
Timer::Timer(ILogging& logger) :
    mTimerStruct(timerStruct),
    mLogger(logger),
    mInitialized(false),
    mStarted(false)
{ ; }

/**
 * \brief   Destructor. Turns timer off if initialized before.
 */
Timer::~Timer()
{
    Sleep();
}

/**
 * \brief   Initialize the (hardware) Timer with the given interval in milliseconds.
 * \returns True if init successful, else false.
 */
bool Timer::Init(const IConfig& config)
{
    constexpr uint32_t MICRO_TO_MILLISECOND = 1000;

    const Config& cfg = reinterpret_cast<const Config&>(config);

    if (mTimer.attachInterruptInterval(cfg.mMilliseconds * MICRO_TO_MILLISECOND, TimerHandler))
    {
        mTimer.stopTimer();
        mInitialized = true;
        std::string message = "Timer initialized with " + NumberToString(cfg.mMilliseconds) + " millisecond tick";
        mLogger.Log(LogLevel::INFO, message.c_str());
        return true;
    }
    mLogger.Log(LogLevel::ERROR, "Timer initialization failed!");
    return false;
}

/**
 * \brief   Indicate if Timer is initialized.
 * \returns True if Timer is initialized, else false.
 */
bool Timer::IsInit() const
{
    return mInitialized;
}

/**
 * \brief   Puts the Timer module in sleep mode.
 * \returns True if Timer module could be put in sleep mode, else false.
 */
bool Timer::Sleep()
{
    if (IsStarted()) {
        return Stop();
    }
    return true;
}

/**
 * \brief   Start the Timer.
 * \param   handler     Callback to call when Timer tick occurs.
 * \returns True if Timer could be started, else false.
 */
bool Timer::Start(const std::function<void()>& handler)
{
    if (mInitialized)
    {
        mTimerStruct.callback = handler;
        mTimer.enableTimer();
        mStarted = true;
        mLogger.Log(LogLevel::INFO, "Timer started");
        return true;
    }
    return false;
}

/**
 * \brief   Indicate if Timer is started.
 * \returns True if Timer is started, else false.
 */
bool Timer::IsStarted() const
{
    if (mInitialized)
    {
        return mStarted;
    }
    return false;
}

/**
 * \brief   Stop the Timer.
 * \returns True if Timer could be stopped, else false.
 */
bool Timer::Stop()
{
    if (mInitialized && mStarted)
    {
        mTimer.stopTimer();
        mStarted = false;
        mLogger.Log(LogLevel::INFO, "Timer stopped");
        return true;
    }
    return false;
}
