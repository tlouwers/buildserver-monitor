/**
 * \file httpClient.hpp
 * 
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <jilvin.wiegmus@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                melip muskman
 * 
 * \brief   Wrapper for a http client.
 * 
 * \details Intended use is to provide an easier means to handle a http requests
 *          and retrieve data for a specified buildserver URL.
 * 
 * \date    01-2020
*/

#ifndef HTTP_CLIENT_HPP_
#define HTTP_CLIENT_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include "ILogging.hpp"
#include "IHttpClient.hpp"

#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266HTTPClient.h>
#include <WiFiClientSecureBearSSL.h>


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
   \brief   Wrapper for a Http connection.
*/
class httpClient final : public IHttpClient
{
  public:
    explicit httpClient(ILogging& logger);
    virtual ~httpClient();

    bool Init() override;
    bool Acquire() override;
    bool Parse() override;
    BuildState getBuildState() override;

  private:
    ILogging& mLogger;

    HTTPClient https;
    BearSSL::WiFiClientSecure* client;

    bool mInit;
    String mJsonString;
    char* mResult;

    bool CheckValidHttpConfiguration(const std::string& username, const std::string& authentication_token, const std::string& jenkins_api_url, const uint8_t* fingerprint);
};


#endif  // HTTP_CLIENT_HPP_
