/**
 * \file    PacketParser.hpp
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

#ifndef PACKET_PARSER_HPP_
#define PACKET_PARSER_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include <functional>
#include <CircularBuffer.h>
#include <CRC8.h>
#include "config.h"
#include "interfaces/ILogging.hpp"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Packer parser for incoming data from WiFi network.
 */
class PacketParser final
{
public:
    explicit PacketParser(ILogging& logger);
    virtual ~PacketParser();

    void StoreData(const uint8_t* data, uint16_t length);
    void Reset();

    void Process();

    void SetHandler(const std::function<void(const uint8_t* data, uint16_t length)>& handler);

private:
    ILogging& mLogger;
    CircularBuffer<uint8_t, PARSER_BUFFER_SIZE> mBuffer;
    CRC8 mCrc;
    std::function<void(const uint8_t*, uint16_t)> mHandler;
};


#endif  // PACKET_PARSER_HPP_
