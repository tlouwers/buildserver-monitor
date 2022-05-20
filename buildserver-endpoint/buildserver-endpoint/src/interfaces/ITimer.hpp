 /**
 * \file    ITimer.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Timer interface class.
 *
 * \details This class is intended to act as interface for the Timer class,
 *          to ease unit testing.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2022
 */

#ifndef ITIMER_HPP_
#define ITIMER_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include <functional>


/************************************************************************/
/* Interface declaration                                                */
/************************************************************************/
/**
 * \brief   ITimer interface class.
 */
class ITimer
{
public:
    virtual bool Start(const std::function<void()>& handler) = 0;
    virtual bool IsStarted() const = 0;
    virtual bool Stop() = 0;
};


#endif  // ITIMER_HPP_
