 /**
 * \file IWifiConnection.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   WiFi connection interface class.
 *
 * \details This class is intended to act as interface for the WifiConnection class,
 *          to ease unit testing.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2020
 */

#ifndef IWIFI_CONNECTION_HPP_
#define IWIFI_CONNECTION_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>


/************************************************************************/
/* Interface declaration                                                */
/************************************************************************/
/**
 * \class   IWifiConnection interface class.
 */
class IWifiConnection
{
public:
    virtual bool Connect(uint32_t timeout_ms) = 0;
    virtual bool IsConnected() const = 0;
    virtual bool Disconnect() = 0;
};


#endif  // IWIFI_CONNECTION_HPP_
