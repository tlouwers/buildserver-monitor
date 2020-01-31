/**
   \file httpClient.hpp

   \licence "THE BEER-WARE LICENSE" (Revision 42):
            <jilvin.wiegmus@fourtress.nl> wrote this file. As long as you retain
            this notice you can do whatever you want with this stuff. If we
            meet some day, and you think this stuff is worth it, you can buy me
            a beer in return.
                                                                  melip muskman

   \brief   Wrapper for a http client.

   \details Intended use is to hold the environment specific parts of the Http
            configuration, things that need to be altered for a given buildserver
            environment.

   \date    01-2020
*/

#ifndef HTTP_CLIENT_HPP_
#define HTTP_CLIENT_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include "ILogging.hpp"

#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266HTTPClient.h>
#include <WiFiClientSecureBearSSL.h>

/************************************************************************/
/* Enums                                                                */
/************************************************************************/
/**
 * \enum    BuildStatus
 * \brief   Available led colors.
 */
enum class BuildState : uint8_t
{
    Success,
    Unstable,
    Failure,
    Aborted,
    NotBuild,
    NoState
};

/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
   \brief   Wrapper for a WiFi connection.
*/
class httpClient
{
  public:
    explicit httpClient(ILogging& logger);
    virtual ~httpClient();

    bool Init();
    bool Acquire();
    bool Parse();
    BuildState getBuildState();

  private:
    ILogging& mLogger;

    HTTPClient https;
    BearSSL::WiFiClientSecure* client;

    bool mInit;
    String mJsonString;
    char* mResult;
};


#endif  // HTTP_CLIENT_HPP_
