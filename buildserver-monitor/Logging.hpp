/**
 * \file Logging.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Logging class (wrapper around Serial class).
 *
 * \details Intended use is to provide a consistent logging mechanism based upon 
 *          the Serial for logging messages in various levels of detail.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    01-2020
 */

#ifndef LOGGING_HPP_
#define LOGGING_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include "ILogging.hpp"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Logging class.
 */
class Logging final : public ILogging
{
public:
    Logging();
    virtual ~Logging() {};

    bool Log(LogLevel level, const char* message) override;

private:
    LogLevel mConfiguredLevel;
};


#endif  // LOGGING_HPP_
