/**
 * \file    ProtocolHandler.cpp
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

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <string>
#include "ProtocolHandler.hpp"
#include "utility/Utilities.hpp"


/************************************************************************/
/* Constants                                                            */
/************************************************************************/
static constexpr uint8_t COMMAND_LENGTH = 1;    // Used as: length
static constexpr uint8_t COMMAND_BYTE   = 0;    // Used as: array index
static constexpr uint8_t ACTION_BYTE    = 1;    // Used as: array index


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
 * \brief   Constructor.
 * \param   logger      Logging class.
 */
ProtocolHandler::ProtocolHandler(ILogging& logger) :
    mLogger(logger)
{ ; }

/**
 * \brief   Parse a Command packet and route it to an appropriate handler.
 */
void ProtocolHandler::ParseCommand(const uint8_t* data, uint16_t length)
{
    if (data == nullptr) { mLogger.Log(LogLevel::ERROR, "Data is nullptr"); return; }
    if (length == 0)     { mLogger.Log(LogLevel::ERROR, "Data length was 0, skipped"); return; }

    const uint8_t command = data[COMMAND_BYTE];

    std::string message = "Received command: [" + NumberToString(command) + "]";
    mLogger.Log(LogLevel::INFO, message.c_str());

         if (command == static_cast<uint8_t>(Command::Version)  ) { HandleVersion  (data, length); }
    else if (command == static_cast<uint8_t>(Command::Leds)     ) { HandleLeds     (data, length); }
    else if (command == static_cast<uint8_t>(Command::Buzzer)   ) { HandleBuzzer   (data, length); }
    else if (command == static_cast<uint8_t>(Command::Vibration)) { HandleVibration(data, length); }
    else if (command == static_cast<uint8_t>(Command::OLED)     ) { HandleOLED     (data, length); }
    else if (command == static_cast<uint8_t>(Command::Battery)  ) { HandleBattery  (data, length); }
    else
    {
        mLogger.Log(LogLevel::WARNING, "Command not understood, discarded");
    }
}

/**
 * \brief   Method to connect a callback method to handle a Version Get command.
 * \param   handler     The callback method to connect.
 */
void ProtocolHandler::SetVersionGetHandler(const std::function<void(const std::string& versionString)>& handler)
{
    mVersionGetHandler = handler;
}

/************************************************************************/
/* Private Methods                                                      */
/************************************************************************/
void ProtocolHandler::HandleVersion(const uint8_t* data, uint16_t length)
{
    if (data == nullptr) { mLogger.Log(LogLevel::ERROR, "Data is nullptr"); return; }
    if (length == 0)     { mLogger.Log(LogLevel::ERROR, "Data length was 0, skipped"); return; }

    mLogger.Log(LogLevel::INFO, "Handling Version command");

    if (length > COMMAND_LENGTH)
    {
        if (data[ACTION_BYTE] == static_cast<uint8_t>(Version::Get))
        {
            std::string versionString(VERSION_STRING);
            std::string message("Version Get - " + versionString);
            mLogger.Log(LogLevel::INFO, message.c_str());

#warning ToDo: NO - should call a method which creates a Command + Data again and move this to the PacketParser to have it sent back to the Server.
            if (mVersionGetHandler) { mVersionGetHandler(versionString); }
        }
    }
    else
    {
        mLogger.Log(LogLevel::WARNING, "Version command could not be retrieved, skipped");
    }
}

void ProtocolHandler::HandleLeds(const uint8_t* data, uint16_t length)
{
    // ToDo
    mLogger.Log(LogLevel::INFO, "Handling Leds command");
}

void ProtocolHandler::HandleBuzzer(const uint8_t* data, uint16_t length)
{
    // ToDo
    mLogger.Log(LogLevel::INFO, "Handling Buzzer command");
}

void ProtocolHandler::HandleVibration(const uint8_t* data, uint16_t length)
{
    // ToDo
    mLogger.Log(LogLevel::INFO, "Handling Vibration command");
}

void ProtocolHandler::HandleOLED(const uint8_t* data, uint16_t length)
{
    // ToDo
    mLogger.Log(LogLevel::INFO, "Handling OLED command");
}

void ProtocolHandler::HandleBattery(const uint8_t* data, uint16_t length)
{
    // ToDo
    mLogger.Log(LogLevel::INFO, "Handling Battery command");
}
