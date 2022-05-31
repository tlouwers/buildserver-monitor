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
 * \brief   Packet parser, concatinates incoming data into packets, provides
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
}

/**
 * \brief   Destructor, disconnects (if connected).
 */
PacketParser::~PacketParser()
{
    Reset();
}

/**
 * \brief   Resets the internal buffers.
 */
void PacketParser::Reset()
{
    mBuffer.fill(0);
}

/**
 * \brief   Parser method which tries to concatenate data and create packets.
 * \param   data    Buffer with received data from Server.
 * \param   length  The number of bytes in the buffer.
 */
void PacketParser::Parse(const uint8_t* data, uint16_t length)
{
    if (data != nullptr)
    {
#warning ToDo...
//        size_t length = sizeof(data);

    }
}
