/**
 * \file    FakeDataConnection.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Fake implementation of the wrapper for a Data connection.
 *
 * \details Intended use is to provide a simulation for when no Data
 *          connection is to be used.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2020
 */

#ifndef FAKE_DATA_CONNECTION_HPP_
#define FAKE_DATA_CONNECTION_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include "interfaces/ILogging.hpp"
#include "interfaces/IDataConnection.hpp"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Wrapper for Data connection.
 */
class FakeDataConnection final : public IDataConnection
{
public:
    /**
     * \brief   Constructor.
     * \param   logger    Logging class.
     */
    explicit FakeDataConnection(const ILogging& logger) { (void)(logger); }

    /**
     * \brief   Destructor.
     */
    virtual ~FakeDataConnection() {}

    /**
     * \brief   Connect to Server.
     * \returns Always succeeds.
     */
    bool Connect() override
    {
        mConnected = true;
        return true;
    }

    /**
     * \brief   Check if connected to Server.
     * \returns True if connected, else false. Note: simulated state.
     */
    bool IsConnected() const override { return mConnected; }

    /**
     * \brief   Disconnect from Server.
     * \returns Always succeeds.
     */
    bool Disconnect() override
    {
        mConnected = false;
        return true;
    }

    /**
     * \brief   Process data (to/from) the Server.
     */
    void Process() override {}

    /**
     * \brief   Reset internal state/data.
     */
    void Reset() override {}

    /**
     * \brief   Set handler to process received data from the Server.
     * \details Typically this is the protocol parser.
     */
    void SetHandler(const std::function<void(const uint8_t*, uint16_t)>& handler) override {}

private:
    bool mConnected = false;
};


#endif  // FAKE_WIFI_CONNECTION_HPP_
