/**
 * \file    ProtocolHandler.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Protocol handler. Intended to provide callbacks for received
 *          commands from the Server.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    06-2022
 */

#ifndef PROTOCOL_HANDLER_HPP_
#define PROTOCOL_HANDLER_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include <functional>
#include "config.h"
#include "interfaces/ILogging.hpp"
#include "interfaces/IProtocolHandler.hpp"
#include "utility/Commands.hpp"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Protocol handler to provide callbacks for received commands.
 */
class ProtocolHandler final : public IProtocolHandler
{
public:
    explicit ProtocolHandler(ILogging& logger);
    virtual ~ProtocolHandler() {};

    void ParseCommand(const uint8_t* data, uint16_t length) override;

    void SetVersionGetHandler(const std::function<void(const std::string& versionString)>& handler);

private:
    ILogging& mLogger;

    std::function<void(const std::string& )> mVersionGetHandler;

    void HandleVersion(const uint8_t* data, uint16_t length);
    void HandleLeds(const uint8_t* data, uint16_t length);
    void HandleBuzzer(const uint8_t* data, uint16_t length);
    void HandleVibration(const uint8_t* data, uint16_t length);
    void HandleOLED(const uint8_t* data, uint16_t length);
    void HandleBattery(const uint8_t* data, uint16_t length);
};


#endif  // PROTOCOL_HANDLER_HPP_
