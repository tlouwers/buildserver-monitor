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
#include <array>
#include <cstdint>
#include <functional>
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

    void Reset();

    void Parse(const uint8_t* data, uint16_t length);

private:
    ILogging& mLogger;
    std::array<uint8_t, PARSER_BUFFER_SIZE> mBuffer;
};


#endif  // PACKET_PARSER_HPP_
