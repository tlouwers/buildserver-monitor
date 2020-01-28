#include "Application.hpp"

Application mApp;


void setup()
{
    // Setup serial connection (required for Logging class)
    Serial.begin(115200);

    if ( ! mApp.Init() )
    {
        Serial.println("Error during init");
    }
}


void loop()
{
    mApp.Process();
}
