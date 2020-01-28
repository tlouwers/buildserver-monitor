 /**
 * \file ILogging.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Logging interface class.
 *
 * \details This class is intended to act as interface for the Logging class,
 *          to ease unit testing.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    01-2020
 */

#ifndef ILOGGING_HPP_
#define ILOGGING_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include "config.h"


/************************************************************************/
/* Enums                                                                */
/************************************************************************/
/**
 * \enum    LogLevel
 * \brief   Available log levels.
 */
enum class LogLevel : uint8_t
{
    OFF     = LOG_LEVEL_OFF,
    ERROR   = LOG_LEVEL_ERROR,
    WARNING = LOG_LEVEL_WARNING,
    INFO    = LOG_LEVEL_INFO,
    ALL     = LOG_LEVEL_ALL
};


/************************************************************************/
/* Interface declaration                                                */
/************************************************************************/
/**
 * \brief   ILogging interface class.
 */
class ILogging
{
public:
    virtual bool Log(LogLevel level, const char* message) = 0;
};


#endif  // ILOGGING_HPP_
