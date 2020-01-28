/**
 * \file Logging.cpp
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

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <Arduino.h>
#include "config.h"
#include "Logging.hpp"


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
 * \brief   Constructor.
 * \details This assumes a 'Serial.begin(115200)' has been done in the 
 *          main 'Setup()' function of the application.
 */
Logging::Logging()
{
    // Get the configured log level from 'config.h' file --> (int) to (uint8_t) to (LogLevel)
    mConfiguredLevel = static_cast<LogLevel>(static_cast<uint8_t>(LOG_LEVEL));
}

/**
 * \brief   Log a message to the Serial output.
 * \param   level   The log level of the message.
 * \param   message The null terminated string to log as message.
 * \returns True if succesful, else false.
 */
bool Logging::Log(LogLevel level, const char* message)
{
    if (message == nullptr) { return false; }
    if (level == LogLevel::OFF) { return true; }
    if (mConfiguredLevel == LogLevel::OFF) { return true; }

    if (level <= mConfiguredLevel)
    {
        Serial.println(message);
        
        return false;
    }
    return true;    // If log level lower than configured level we silently ignore the log message.
}
