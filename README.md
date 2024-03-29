# buildserver-monitor
Source code in C/C++ for the Wemos Lolin D1 mini Pro (ESP8266EX) which controls a buildserver monitor with multicolored leds.

## Intent / idea
The intent of this project is to build a cheap DIY build monitor. It is intended as a modifiable, give-away gadget, which can help developers monitor the status of a build monitor without the need of constantly checking the website of such monitor. It also acts as an eye-catcher, a fun gadget.

By making use of a microcontroller which can handle I2C and WiFi, we can monitor/poll the build status of (for instance) Jenkins and display this status by LEDs or LCD. A buzzer or vibration motor can be used to make some noise which makes the gadget noticed more easily. By using a regular USB (micro) cable we can power the device and all peripherals. A battery and charger circuit add the option to run fully wireless for some time.

## Progress
At the moment this is a simple state machine example in which some colors of a NeoPixel strand of 4 elements are being toggled. The user is expected to provide credentials for the WiFi network and for the Jenkins buildserver - both can be set in configuration files. The device polls the status of the buildserver each minute and show the status by the leds. A light sleepmode is implemented to last longer on a battery charge.

## Requirements
* An [Wemos Lolin D1 mino Pro (ESP8266EX) microcontroller](https://www.wemos.cc/en/latest/d1/d1_mini_pro.html) with WiFi and USB charger.
* A [NeoPixel](https://www.adafruit.com/product/1612) strand of 4 leds, a [100 uF capacitor](https://sigmatechbd.com/product/100uf-25v-capacitor/) and a [resistor of 470 Ohm](https://commons.wikimedia.org/wiki/File:470_ohms_5%25_axial_resistor.jpg).

# buildserver-endpoint
Source code in C/C++ for the Wemos Lolin D1 mini Pro (ESP8266EX) which controls a buildserver endpoint with multicolored leds, a buzzer, a vibration motor and OLED display.
While the buildserver-monitor is a simple device working autonomously (polling a Jenkins buildserver for a status), the buildserver-endpoint is a client which will need a server to control the device. The server application will communicate via an API with the endpoint to (for example): turn on the leds, display text on the OLED screen, etc.

## Intent / idea
The intent of the endpoint is to add more features (in hardware) and move control to a server application. This makes the endpoint a unit which can be controlled via WiFi with a bunch of attention drawing items (buzzer, leds, vibration motor and OLED screen).

## Progress
Development of the endpoint is just started, a reference server (in C#) will be provided.

## Requirements
* An [Wemos Lolin D1 mino Pro (ESP8266EX) microcontroller](https://www.wemos.cc/en/latest/d1/d1_mini_pro.html) with WiFi and USB charger.
* A [NeoPixel](https://www.adafruit.com/product/1612) strand of 4 leds, a [100 uF capacitor](https://sigmatechbd.com/product/100uf-25v-capacitor/) and a [resistor of 470 Ohm](https://commons.wikimedia.org/wiki/File:470_ohms_5%25_axial_resistor.jpg).
* An active [buzzer](https://www.tinytronics.nl/shop/nl/audio/speakers/buzzers/actieve-buzzer-module-5v).
* A [vibration motor](https://www.tinytronics.nl/shop/nl/mechanica-en-actuatoren/motoren/vibratiemotoren/tril-vibratie-dc-motor-module-3.7-5.3v).
* An I2C [OLED display](https://www.tinytronics.nl/shop/nl/displays/oled/0.91-inch-oled-display-128*32-pixels-wit-i2c).
