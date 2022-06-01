/**
 * \file    DataConnection.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Data connection handling, used to send/receive data via the WiFi
 *          network. Consider this to be a Client connecting to a Host (Server).
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2022
 */

#ifndef DATA_CONNECTION_HPP_
#define DATA_CONNECTION_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include "interfaces/ILogging.hpp"
#include "interfaces/IDataConnection.hpp"
#include <ESP8266WiFi.h>


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Data connection handling, used to send/receive data via the WiFi
 *          network.
 */
class DataConnection final : public IDataConnection
{
public:
    explicit DataConnection(ILogging& logger);
    virtual ~DataConnection();

    bool Connect() override;
    bool IsConnected() const override;
    bool Disconnect() override;

    void Process() override;
    void Reset() override;
    void SetHandler(const std::function<void(const uint8_t* data, uint16_t length)>& handler);

private:
    ILogging&  mLogger;
    bool       mInitialized;
    bool       mConnected;
    WiFiClient mClient;
    uint8_t    mBuffer[DATA_CONNECTION_BUFFER_SIZE] = {};
    std::function<void(const uint8_t*, uint16_t)> mHandler;


    bool CheckValidHostAddressAndPort(const char* host_address, const char* host_port);
    bool ConnectionAttempt();
    void LogServerString();
};


#endif  // DATA_CONNECTION_HPP_
