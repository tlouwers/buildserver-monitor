 /**
 * \file    Commands.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   All possible commands for the buildserver-endpoint.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    06-2022
 */

#ifndef COMMANDS_HPP_
#define COMMANDS_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <stdint.h>
#include <stddef.h>


/************************************************************************/
/* Enums                                                                */
/************************************************************************/
/**
 * \enum    Command
 * \brief   Available protocol commands.
 */
enum class Command : uint8_t
{
    Version,
    Leds,
    Buzzer,
    Vibration,
    OLED,
    Battery
};

/**
 * \enum    Version
 * \brief   Available Version commands.
 */
enum class Version : uint8_t
{
    Get
};


#endif  // COMMANDS_HPP_
