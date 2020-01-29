/**
 * \file WifiConnection.cpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Wrapper for a WiFi connection.
 *
 * \details Intended use is to provide an easier means to handle a WiFi connection
 *          and retrieve data for a specified buildserver URL.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    01-2020
 */

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <string>
#include "config.h"
#include "wifi_config.h"
#include "WifiConnection.hpp"
#include <ESP8266WiFi.h>


/************************************************************************/
/* Constants                                                            */
/************************************************************************/
static constexpr uint32_t TIMEOUT_INCREMENT = 500;    // In milliseconds


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
 * \brief   Constructor.
 * \param   logger      Logging class.
 */
WifiConnection::WifiConnection(ILogging& logger) :
    mLogger(logger),
    mInitialized(false),
    mConnected(false)
{ ; }

/**
 * \brief   Destructor, disconnects (if connected).
 */
WifiConnection::~WifiConnection()
{
    if (mConnected)
    {
        Disconnect();
    }
    mInitialized = false;
}

/**
 * \brief   Connect to WiFi (as configured in config file).
 * \param   timeout_ms    The maximum time to try to connect to WiFi.
 * \returns True if connection succeeded (within timeout), else false.
 */
bool WifiConnection::Connect(uint32_t timeout_ms)
{
    if (mConnected)
    {
        std::string ipString( WiFi.localIP().toString().c_str() );
        std::string message = "WiFi connected to: [" + ipString + "]";
        mLogger.Log(LogLevel::INFO, message.c_str());
        return true;
    }

    if (timeout_ms > WIFI_CONNECTION_TIMEOUT)
    {
        timeout_ms = WIFI_CONNECTION_TIMEOUT;
        mLogger.Log(LogLevel::INFO, "Restricting maximum WiFi timeout to configured value");
    }

    bool result = false;
    if (CheckValidSSIDAndPassword())
    {
        WiFi.begin(SSID, PASSWORD);

        uint32_t waited_ms = 0;
        while (waited_ms < timeout_ms)
        {
            waited_ms += TIMEOUT_INCREMENT;

            if (WiFi.status() == WL_CONNECTED)
            {
                std::string ipString( WiFi.localIP().toString().c_str() );
                std::string message = "WiFi connected to: [" + ipString + "]";
                mLogger.Log(LogLevel::INFO, message.c_str());
                mConnected = true;
                result = true;
                break;
            }
        }
    }
    return result;
}

/**
 * \brief   Check if connected ti WiFi.
 * \result  Returns true if connected, else false.
 */
bool WifiConnection::IsConnected() const
{
    return mConnected;
}

/**
 * \brief   Disconnect (if connected);
 * \returns Always true.
 */
bool WifiConnection::Disconnect()
{
    if (mConnected)
    {
        WiFi.disconnect();
        mConnected = false;
    }
    return true;
}


/************************************************************************/
/* Private Methods                                                      */
/************************************************************************/
/**
 * \brief   Basic check to prevent the default or empty SSID and password.
 * \details These values are taken from the main config file.
 * \returns True if the SSID and password are filled and not default.
 */
bool WifiConnection::CheckValidSSIDAndPassword()
{
    std::string configured_ssid(SSID);
    std::string configured_password(PASSWORD);

    if ( (configured_ssid.compare("<YOUR_SSID_HERE>") == 0) ||
         (configured_ssid.compare("") == 0) )
    {
        mLogger.Log(LogLevel::WARNING, "WiFi SSID not configured.");
        return false;
    }

    if ( (configured_password.compare("<YOUR_PASSWD_HERE>") == 0) ||
         (configured_password.compare("") == 0) )
    {
        mLogger.Log(LogLevel::WARNING, "WiFi password not configured.");
        return false;
    }

    return true;
}
