/**
 * \file    FakeWifiConnection.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Fake implementation of the wrapper for a WiFi connection.
 *
 * \details Intended use is to provide a simulation for when no WiFi
 *          connection is to be used.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2020
 */

#ifndef FAKE_WIFI_CONNECTION_HPP_
#define FAKE_WIFI_CONNECTION_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include "ILogging.hpp"
#include "IWifiConnection.hpp"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Wrapper for WiFi connection.
 */
class FakeWifiConnection final : public IWifiConnection
{
public:
    /**
     * \brief   Constructor.
     * \param   logger    Logging class.
     */
    explicit FakeWifiConnection(const ILogging& logger) { (void)(logger); }

    /**
     * \brief   Destructor.
     */
    virtual ~FakeWifiConnection() {}

    /**
     * \brief   Connect to WiFi network.
     * \returns Always succeeds since there is no hardware.
     */
    bool Connect(uint32_t timeout_ms) override
    {
        (void)(timeout_ms);
        mConnected = true;
        return true;
    }

    /**
     * \brief   Check if connected via WiFi.
     * \returns True if connected, else false. Note: simulated state.
     */
    bool IsConnected() const override { return mConnected; }

    /**
     * \brief   Disconnect from WiFi network.
     * \returns Always succeeds since there is no hardware.
     */
    bool Disconnect() override
    {
        mConnected = false;
        return true;
    }

private:
    bool mConnected = false;
};


#endif  // FAKE_WIFI_CONNECTION_HPP_
