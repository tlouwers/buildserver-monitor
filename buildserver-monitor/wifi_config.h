/**
 * \file wifi_config.h
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   WiFi configuration file for the Buildserver Monitor.
 *
 * \details Intended use is to hold the environment specific parts of the WiFi
 *          configuration, things that need to be altered for a given buildserver
 *          environment.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    01-2020
 */

#ifndef BUILDSERVER_MONITOR_WIFI_CONFIG_H_
#define BUILDSERVER_MONITOR_WIFI_CONFIG_H_

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
// Timeouts
static const uint32_t WIFI_CONNECTION_TIMEOUT = 15000;        // In milliseconds.

// Retries
static const uint8_t  WIFI_NUMBER_OF_RETRIES  = 2;            // Connection retry attempts if initial connection attempt fails.

// Network
static const char*    WIFI_SSID     = "<YOUR_SSID_HERE>";     // The SSID of the WiFi network to connect to.
static const char*    WIFI_PASSWORD = "<YOUR_PASSWD_HERE>";   // The password of the WiFi network to connect to.


#ifdef __cplusplus
}
#endif

#endif  // BUILDSERVER_MONITOR_WIFI_CONFIG_H_
