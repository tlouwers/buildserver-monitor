/**
 * \file    UI_Manager.cpp
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

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include "UI_Manager.hpp"


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
 * \brief   Constructor.
 * \param   logger      Logging class.
 */
UI_Manager::UI_Manager(ILogging& logger) :
    mLogger(logger)
{ ; }
