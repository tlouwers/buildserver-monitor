/**
 * \file    UI_Manager.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   UI Manager. Handles various UI elements (buzzer, OLED, etc).
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    06-2022
 */

#ifndef UI_MANAGER_HPP_
#define UI_MANAGER_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include "config.h"
#include "interfaces/ILogging.hpp"
#include "utility/Commands.hpp"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   UI Manager class.
 */
class UI_Manager final
{
public:
    explicit UI_Manager(ILogging& logger);
    virtual ~UI_Manager() {};



private:
    ILogging&  mLogger;
};


#endif // UI_MANAGER_HPP_
