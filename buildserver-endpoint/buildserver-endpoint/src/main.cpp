/**
 * \file    main.cpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Main entry point for Buildserver Endpoint application.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \version 1.0
 * \date    01-2020
 */

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include "Application.hpp"


/** Main application */
Application mApp;


/**
 * \brief   Setup (hook) from Arduino framework. Configures the serial
 *          connection for logging.
 */
void setup()
{
    // Setup serial connection (required for Logging class)
    Serial.begin(115200);

    if ( ! mApp.Init() )
    {
        Serial.println("Error during init");
        mApp.Error();
    }
}

/**
 * \brief   Loop (hook): the main application loop.
 */
void loop()
{
    mApp.Process();
}
