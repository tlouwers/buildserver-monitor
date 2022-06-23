 /**
 * \file    IDataConnection.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Data connection interface class.
 *
 * \details This class is intended to act as interface for the DataConnection class,
 *          to ease unit testing.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2022
 */

#ifndef IDATA_CONNECTION_HPP_
#define IDATA_CONNECTION_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include <functional>


/************************************************************************/
/* Interface declaration                                                */
/************************************************************************/
/**
 * \brief   IDataConnection interface class.
 */
class IDataConnection
{
public:
    virtual bool Connect() = 0;
    virtual bool IsConnected() const = 0;
    virtual bool Disconnect() = 0;

    virtual void Process() = 0;
    virtual void Reset() = 0;
    virtual void SetHandler(const std::function<void(const uint8_t*, uint16_t)>& handler);
};


#endif  // IDATA_CONNECTION_HPP_
