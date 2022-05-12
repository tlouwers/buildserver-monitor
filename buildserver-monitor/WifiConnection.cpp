/**
 * \file    WifiConnection.cpp
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
static constexpr uint32_t TIMEOUT_INCREMENT = 250;    // In milliseconds


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
    if (CheckValidSSIDAndPassword(WIFI_SSID, WIFI_PASSWORD))    // Note: these values are taken from the 'wifi_config.h' file.
    {
        for (uint8_t i = 0; i < WIFI_NUMBER_OF_RETRIES; i++)
        {
            if (ConnectionAttempt(timeout_ms))
            {
                std::string ipString( WiFi.localIP().toString().c_str() );
                std::string message = "WiFi connected to: [" + ipString + "]";
                mLogger.Log(LogLevel::INFO, message.c_str());
                mConnected = true;
                result = true;
                break;
            }
            else
            {
                mLogger.Log(LogLevel::INFO, "Attempt failed, retry...");
                delay(TIMEOUT_INCREMENT);
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
    WiFi.disconnect();
    mConnected = false;

    return true;
}


/************************************************************************/
/* Private Methods                                                      */
/************************************************************************/
/**
 * \brief   Basic check to prevent the default or empty SSID and password.
 * \param   ssid      The WiFi SSID to check.
 * \param   password  The WiFi password to check.
 * \returns True if ssid and password are filled and not default.
 */
bool WifiConnection::CheckValidSSIDAndPassword(const char* ssid, const char* password)
{
    if (ssid == NULL)
    {
        mLogger.Log(LogLevel::ERROR, "Empty pointer for ssid");
        return false;
    }
    if (password == NULL)
    {
        mLogger.Log(LogLevel::ERROR, "Empty pointer for password");
        return false;
    }

    std::string configured_ssid(ssid);
    std::string configured_password(password);

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

/**
 * \brief   Try to connect to WiFi, stop attempt after given timeout.
 * \param   timeout_ms    The maximum time to try to connect to WiFi.
 * \returns True if connected to WiFi, else false.
 */
bool WifiConnection::ConnectionAttempt(uint32_t timeout_ms)
{
    WiFi.mode(WIFI_STA);
    wifi_set_sleep_type(LIGHT_SLEEP_T);
    WiFi.begin(WIFI_SSID, WIFI_PASSWORD);

    if (!WiFi.isConnected())
    {
        WiFi.reconnect();
        WiFi.waitForConnectResult(timeout_ms);
    }

    // Check status: on failure cleanup first
    if (WiFi.isConnected())
    {
        return true;    // Happy case...
    }
    else
    {
        WiFi.disconnect();
        return false;
    }
}
