/**
 * \file http_config.h
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <jilvin.wiegmus@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                melip muskman
 *
 * \brief   Http configuration file for the Buildserver Monitor.
 *
 * \details Intended use is to hold the environment specific parts of the Http
 *          configuration, things that need to be altered for a given buildserver
 *          environment.
 *
 * \date    01-2020
 */

#ifndef BUILDSERVER_MONITOR_HTTP_CONFIG_H_
#define BUILDSERVER_MONITOR_HTTP_CONFIG_H_

#ifdef __cplusplus
extern "C" {
#endif

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <stdint.h>
#include <stddef.h>

// Network
static std::string    USERNAME = "your username";     // The jenkins username.
static std::string    BASIC_AUTHENTICATION_TOKEN = "your token";   // The basic authentication token needed for https requests.
static std::string    JENKINS_API_URL = "your api link";   // The jenkins api url needed to request the json data from.
static const uint8_t  SHA1_FINGERPRINT[20] = {}; // Fingerprint for jenkins URL, expires on DATE, needs to be updated well before this date

#ifdef __cplusplus
}
#endif

#endif // BUILDSERVER_MONITOR_HTTP_CONFIG_H_
