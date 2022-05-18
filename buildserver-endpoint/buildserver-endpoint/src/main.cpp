/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <Arduino.h>
#include "Application.hpp"

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
    }
}

/**
 * \brief   Loop (hook): the main application loop.
 */
void loop()
{
    mApp.Process();
}
