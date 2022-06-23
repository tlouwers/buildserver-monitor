/**
 * \file    PacketParser.cpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Packet parser, concatenates incoming data into packets, provides
 *          validation and creates events on received messages.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2022
 */

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstring>
#include "PacketParser.hpp"


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
 * \brief   Constructor.
 * \param   logger      Logging class.
 */
PacketParser::PacketParser(ILogging& logger) :
    mLogger(logger)
{
    Reset();

    mCrc.setPolynome(0x07);     // CRC8-CCITT
}

/**
 * \brief   Destructor.
 */
PacketParser::~PacketParser()
{
    Reset();
}

/**
 * \brief   Store received data (not looking at the contents).
 * \param   data    Buffer with received data from Server.
 * \param   length  The number of bytes in the buffer.
 */
void PacketParser::StoreData(const uint8_t* data, uint16_t length)
{
    mLogger.Log(LogLevel::INFO, "Storing data...");

    if (data != nullptr)
    {
        for (auto i = 0; i < length; i++)
        {
            mBuffer.push(data[i]);
        }
    }
}

/**
 * \brief   Resets the internal buffers.
 */
void PacketParser::Reset()
{
    mBuffer.clear();
}

/**
 * \brief   Iterates over the entire buffer until a packet is found.
 *          This packet is extracted and pushed to the handler method.
 *          Will clear the internal buffer upto the found packet (if any).
 */
void PacketParser::Process()
{
    while (!mBuffer.isEmpty())
    {
        // Get length byte
        const uint8_t length = mBuffer.first();

        // Check there is enough data for a possible packet
        if (length > 3)
        {
            if (mBuffer.size() >= length)
            {
                // Extract specified length as possible packet
                uint8_t content[length - 2] = {};               // Command + data
                for (uint8_t i = 0; i < (length - 2); i++)
                {
                    content[i] = mBuffer[i];
                }

                // Check CRC
                mCrc.reset();
                mCrc.add(content, (length - 2));
                uint8_t checksum = mCrc.getCRC();
                uint8_t checksumInPacket = mBuffer[length - 1];

                if (checksum == checksumInPacket)
                {
                    // If correct then get packet from buffer
                    for (uint8_t i = 0; i < length; i++)
                    {
                        mBuffer.pop();
                    }

                    if (mHandler)
                    {
                        mHandler(content, length - 2);
                    }
                }
                else
                {
                    // CRC does not match
                    mBuffer.pop();
                }
            }
            else
            {
                // Not enough data in buffer to be a packet
                mBuffer.pop();
            }
        }
        else
        {
            // length not enough to be a complete packet
            mBuffer.pop();
        }
    }
}

/**
 * \brief   Method to connect a callback method to handle a complete packet.
 * \param   handler     The callback method to connect.
 */
void PacketParser::SetHandler(const std::function<void(const uint8_t*, uint16_t)>& handler)
{
    mHandler = handler;
}
