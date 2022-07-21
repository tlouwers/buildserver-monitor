 /**
 * \file    IProtocolHandler.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Protocol handler interface class.
 *
 * \details This class is intended to act as interface for the ProtocolHandler
 *          class, to ease unit testing.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    06-2022
 */

#ifndef IPROTOCOL_HANDLER_HPP_
#define IPROTOCOL_HANDLER_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>


/************************************************************************/
/* Interface declaration                                                */
/************************************************************************/
/**
 * \brief   IProtocolHandler interface class.
 */
class IProtocolHandler
{
public:
    virtual void ParseCommand(const uint8_t* data, uint16_t length) = 0;
};


#endif  // IPROTOCOL_HANDLER_HPP_
