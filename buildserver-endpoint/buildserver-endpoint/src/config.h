/**
 * \file    config.h
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   General configuration file for the Buildserver Monitor.
 *
 * \details Intended use is to list the various options and settings as configurable
 *          items for the Buildserver Monitor.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    01-2020
 */

#ifndef BUILDSERVER_MONITOR_CONFIG_H_
#define BUILDSERVER_MONITOR_CONFIG_H_

#ifdef __cplusplus
extern "C" {
#endif

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <stdint.h>
#include <stddef.h>


/************************************************************************/
/* Configurable options                                                 */
/************************************************************************/
// Version
static const char versionString[] = "Buildserver Monitor v0.1";

// Available log levels
#define LOG_LEVEL_OFF      1
#define LOG_LEVEL_ERROR    2
#define LOG_LEVEL_WARNING  3
#define LOG_LEVEL_INFO     4
#define LOG_LEVEL_ALL      5

#define LOG_LEVEL    LOG_LEVEL_INFO


// Leds (NeoPixels)
#define PIN_NEOPIXEL_DATA     2       // GPIO_2, pin on the ESP8266 used as data line for the NeoPixels.
#define NUMBER_OF_NEOPIXELS   4       // Must match the connected number of NeoPixels in the strand.

#define PIN_BUZZER            12      // GPIO_12, pin on the ESP8266 used as On/Off for the buzzer.
#define PIN_VIBRATION         13      // GPIO_13, pin on the ESP8266 used as On/Off for the vibration motor.


#define REAL        1
#define SIMULATED   2

// Simulation
#define LEDS  REAL
#define WIFI  REAL
#define HTTP  REAL


#ifdef __cplusplus
}
#endif

#endif  // BUILDSERVER_MONITOR_CONFIG_H_
