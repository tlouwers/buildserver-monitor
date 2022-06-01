/**
 * \file    DataConnection.cpp
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

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstring>
#include <string>
#include "connection_config.h"
#include "DataConnection.hpp"
#include "utility/Timings.hpp"
#include "utility/Utilities.hpp"


/************************************************************************/
/* Constants                                                            */
/************************************************************************/
static constexpr uint32_t TIMEOUT_INCREMENT = QUARTER_SECOND;    // In milliseconds


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
 * \brief   Constructor.
 * \param   logger      Logging class.
 */
DataConnection::DataConnection(ILogging& logger) :
    mLogger(logger),
    mInitialized(false),
    mConnected(false),
    mHandler(nullptr)
{ ; }

/**
 * \brief   Destructor, disconnects (if connected).
 */
DataConnection::~DataConnection()
{
    if (mClient.connected())
    {
        mClient.stop();
    }

    mConnected   = false;
    mInitialized = false;
}

/**
 * \brief   Connect to Server (as configured in config file).
 * \returns True if connection succeeded, else false.
 */
bool DataConnection::Connect()
{
    Reset();

    if (mConnected)
    {
        LogServerString();
        return true;
    }

    bool result = false;
    if (CheckValidHostAddressAndPort(HOST_ADDRESS, HOST_PORT))  // Note: these values are taken from the 'connection_config.h' file.
    {
        for (uint8_t i = 0; i < DATA_NUMBER_OF_RETRIES; i++)
        {
            if (ConnectionAttempt())
            {
                LogServerString();
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
 * \brief   Check if connected to Server.
 * \result  Returns true if connected, else false.
 */
bool DataConnection::IsConnected() const
{
    return mConnected;
}

/**
 * \brief   Disconnect (if connected).
 * \returns Always true.
 */
bool DataConnection::Disconnect()
{
    if (mClient.connected())
    {
        mClient.stop();
    }
    mConnected = false;

    return true;
}

/**
 * \brief   Checks if data is received and pushes this to the handler method
 *          (if configured).
 */
void DataConnection::Process()
{
    if (mConnected)
    {
        std::size_t length = mClient.available();
        if (length > 0)
        {
            // Clear buffer first
            memset(mBuffer, 0, DATA_CONNECTION_BUFFER_SIZE);

            // Clip if more data is available than out buffer can hold
            if (length > DATA_CONNECTION_BUFFER_SIZE)
            {
                length = DATA_CONNECTION_BUFFER_SIZE;
            }

            // Read received data (from stream)
            const std::size_t actual = mClient.readBytes(mBuffer, length);
            if (actual > 0)
            {
                if (mHandler)
                {
                    // Pass data to handler
                    mHandler(mBuffer, actual);
                }
            }
        }
    }
}

/**
 * \brief   Resets the internal buffers.
 */
void DataConnection::Reset()
{
    mClient.flush();

    memset(mBuffer, 0, DATA_CONNECTION_BUFFER_SIZE);
}

/**
 * \brief   Method to connect a callback method to handle received data from
 *          the Server.
 * \param   handler     The callback method to connect.
 */
void DataConnection::SetHandler(const std::function<void(const uint8_t*, uint16_t)>& handler)
{
    mHandler = handler;
}


/************************************************************************/
/* Private Methods                                                      */
/************************************************************************/
/**
 * \brief   Basic check to prevent the default or empty Host address and port.
 * \param   host_address    The Host address to check.
 * \param   host_port       The Host port to check.
 * \returns True if host_address and host_port are filled and not default.
 */
bool DataConnection::CheckValidHostAddressAndPort(const char* host_address, const char* host_port)
{
    if (host_address == NULL)
    {
        mLogger.Log(LogLevel::ERROR, "Empty pointer for host_address");
        return false;
    }
    if (host_port == NULL)
    {
        mLogger.Log(LogLevel::ERROR, "Empty pointer for host_port");
        return false;
    }

    std::string configured_host_address(host_address);
    std::string configured_host_port(host_port);

    if ( (configured_host_address.compare("<YOUR_HOST_ADDRESS_HERE>") == 0) ||
         (configured_host_address.compare("") == 0) )
    {
        mLogger.Log(LogLevel::WARNING, "Host address not configured.");
        return false;
    }
    IPAddress host;
    if (!host.fromString(host_address))
    {
        mLogger.Log(LogLevel::WARNING, "Host address not a valid IP address.");
        return false;
    }

    if ( (configured_host_port.compare("<YOUR_HOST_PORT_HERE>") == 0) ||
         (configured_host_port.compare("") == 0) )
    {
        mLogger.Log(LogLevel::WARNING, "Host port not configured.");
        return false;
    }

    int port = std::stoi(configured_host_port);
    if ((port < 0) ||
        (port > UINT16_MAX) )
    {
        mLogger.Log(LogLevel::WARNING, "Host port not in valid range.");
    }

    return true;
}

/**
 * \brief   Try to connect to Server, stop attempt after given timeout.
 * \details An internal timeout of 5 seconds is used.
 * \returns True if connected to Server, else false.
 */
bool DataConnection::ConnectionAttempt()
{
    // Converting to these variables to have a specific connect() call.
    //IPAddress host;
    IPAddress host(172, 16, 15, 37);
    if (!host.fromString(HOST_ADDRESS))
    {
        return false;
    }

    const uint16_t port = std::stoi(HOST_PORT);

    mLogger.Log(LogLevel::INFO, "--- ConnectionAttempt");
    if (!mClient.connected())
    {
        std::string hostAddressString( host.toString().c_str() );
        std::string hostPortString( NumberToString(port) );
        std::string message = "Trying to connect to Server: [" + hostAddressString + ":" + hostPortString + "]";
        mLogger.Log(LogLevel::INFO, message.c_str());

        // Note: internal timeout of 5 seconds
        return mClient.connect(host, port);
    }
    return false;
}

/**
 * \brief   Helper method to print the host address and port where this client is connected to.
 * \details Use only when there is a connection (else data cannot be retrieved).
 */
void DataConnection::LogServerString()
{
    std::string hostAddressString( mClient.remoteIP().toString().c_str() );
    std::string hostPortString( NumberToString(mClient.remotePort()) );
    std::string message = "Connected to Server: [" + hostAddressString + ":" + hostPortString + "]";
    mLogger.Log(LogLevel::INFO, message.c_str());
}
