# buildserver-monitor
Source code in C/C++ for the ESP-01 (ESP8266) which controls a buildserver monitor with multicolored leds and buzzing options.

## Intent / idea
The intent of this project is to build a cheap DIY build monitor. It is intended as a modifiable, give-away gadget, which can help developers monitor the status of a build monitor without the need of constantly checking the website of such monitor. It also acts as an eye-catcher, a fun gadget. 

By making use of a microcontroller which can handle I2C and WiFi, we can monitor/poll the build status of (for instance) Jenkins and display this status by LEDs or LCD. A buzzer or vibration motor can be used to make some noise which makes the gadget noticed more easily. By using a regular USB (micro) cable we can power the device and all peripherals. A battery and charger circuit add the option to run fully wireless for some time.

## Progress
At the moment this is a simple state machine example in which some colors of a NeoPixel strand of 8 elements are being toggled. A WiFi connection can be made, but polling of a buildsever is not done yet.

## Requirements
* An [ESP-01 (ESP8266) microcontroller](http://www.geekbuying.com/item/ESP-01-ESP8266-Wi-Fi-Transceiver-Module-with-USB-to-ESP-01-Adatper-382041.html) with WiFi, and a USB programmer for it.
* A [NeoPixel](https://www.adafruit.com/product/1612) strand of 8 leds, a [100 uF capacitor](https://sigmatechbd.com/product/100uf-25v-capacitor/) and a [resistor of 470 Ohm](https://commons.wikimedia.org/wiki/File:470_ohms_5%25_axial_resistor.jpg).
* *(more to be added later: housing, buzzer, OLED, ...)*
