/**
 * \file WifiConnection.hpp
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
 
#ifndef WIFI_CONNECTION_HPP_
#define WIFI_CONNECTION_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include "ILogging.hpp"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Wrapper for a WiFi connection.
 */
class WifiConnection
{
public:
    explicit WifiConnection(ILogging& logger);
    virtual ~WifiConnection();

    bool Connect(uint32_t timeout_ms);
    bool IsConnected() const;
    bool Disconnect();
    
private:
    ILogging& mLogger;
    bool      mInitialized;
    bool      mConnected;

    bool CheckValidSSIDAndPassword(const char* ssid, const char* password);
    bool ConnectionAttempt(uint32_t timeout_ms);
};


#endif  // WIFI_CONNECTION_HPP_
