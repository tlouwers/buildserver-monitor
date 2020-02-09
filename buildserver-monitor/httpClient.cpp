/**
   \file httpClient.cpp

   \licence "THE BEER-WARE LICENSE" (Revision 42):
            <jilvin.wiegmus@fourtress.nl> wrote this file. As long as you retain
            this notice you can do whatever you want with this stuff. If we
            meet some day, and you think this stuff is worth it, you can buy me
            a beer in return.
                                                                  melip muskman

   \brief   Wrapper for a http client.

   \details Intended use is to provide an easier means to handle a http requests
            and retrieve data for a specified buildserver URL.

   \date    01-2020
*/

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <string>
#include "config.h"
#include "http_config.h"
#include "httpClient.hpp"
#include <ArduinoJson.h>


/************************************************************************/
/* Constants                                                            */
/************************************************************************/


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
   \brief   Constructor.
   \param   logger      Logging class.
*/
httpClient::httpClient(ILogging& logger) :
  mLogger(logger)
{
  mInit = false;
  mJsonString = "";
}

/**
   \brief   Destructor, disconnects (if connected).
*/
httpClient::~httpClient()
{
  delete client;
}

bool httpClient::Init()
{
  if (!mInit) {
    mLogger.Log(LogLevel::INFO, "Initializing http client");
    client = new BearSSL::WiFiClientSecure();
    if (client == NULL) {
      mLogger.Log(LogLevel::ERROR, "cannot allocate memory for https client");
      return false;
    }
    client->setFingerprint(SHA1_FINGERPRINT);
    mInit = true;
  }
  else
  {
    mLogger.Log(LogLevel::INFO, "Already initialized the http client");
  }
  return mInit;
}

bool httpClient::Acquire()
{
  if (client == NULL) {
    mLogger.Log(LogLevel::ERROR, "No http client configured!");
    return false;
  }

  if (!CheckValidHttpConfiguration(USERNAME, BASIC_AUTHENTICATION_TOKEN, JENKINS_API_URL, SHA1_FINGERPRINT))    // Note: these values are taken from the 'http_config.h' file.
  {
    return false;
  }

  std::string url = "https://" + USERNAME + ":" + BASIC_AUTHENTICATION_TOKEN + "@" + JENKINS_API_URL;
  if (https.begin(*client, url.c_str()))
  {

    // start connection and send HTTP header
    int httpCode = https.GET();
    if (httpCode > 0)
    {
      // file found at server
      if (httpCode == HTTP_CODE_OK || httpCode == HTTP_CODE_MOVED_PERMANENTLY)
      {
        mJsonString = https.getString();
        mLogger.Log(LogLevel::INFO, "http request succeeded");
      }
      else
      {
        String message = "Invalid response: " + httpCode;
        mLogger.Log(LogLevel::ERROR, message.c_str());
        return false;
      }
    }
    else
    {
      std::string message = "[HTTPS] GET... failed, error: " + std::string(https.errorToString(httpCode).c_str());
      mLogger.Log(LogLevel::ERROR, message.c_str());
      return false;
    }
    https.end();
  }
  else
  {
    std::string message = "Unable to connect with: " + JENKINS_API_URL;
    mLogger.Log(LogLevel::ERROR, message.c_str());
    return false;
  }

  Serial.println(mJsonString);
  return true;
}

bool httpClient::Parse()
{
  if (mJsonString == "") {
    return false;
  }

  StaticJsonDocument<200> doc;
  DeserializationError error = deserializeJson(doc, mJsonString);

  if (error) {
    Serial.print(F("deserializeJson() failed: "));
    Serial.println(error.c_str());
    return false;
  }

  const char* result = doc["result"];
  mResult = (char*)result;
  Serial.println(mResult);
  mJsonString = "";
  return true;
}

BuildState httpClient::getBuildState()
{
  if (strcmp(mResult, "SUCCESS") == 0) {
    return BuildState::Success;
  }
  else if (strcmp(mResult, "UNSTABLE") == 0) {
    return BuildState::Unstable;
  }
  else if (strcmp(mResult, "FAILURE") == 0) {
    return BuildState::Failure;
  }
  else if (strcmp(mResult, "ABORTED") == 0) {
    return BuildState::Aborted;
  }
  else if (strcmp(mResult, "NOT_BUILT") == 0) {
    return BuildState::NotBuild;
  }
  else {
    return BuildState::NoState;
  }
}

/************************************************************************/
/* Private Methods                                                      */
/************************************************************************/
/**
   \brief   Basic check to prevent the default or empty USERNAME, BASIC_AUTHENTICATION_TOKEN and JENKINS_API_URL.
   \param   ssid      The WiFi SSID to check.
   \param   password  The WiFi password to check.
   \returns True if ssid and password are filled and not default.
*/
bool httpClient::CheckValidHttpConfiguration(std::string username, std::string authentication_token, std::string jenkins_api_url, const uint8_t* fingerprint)
{
  if ( (username.compare("<YOUR_USRERNAME_HERE>") == 0) ||
       (username.compare("") == 0) )
  {
    mLogger.Log(LogLevel::WARNING, "Username not configured.");
    return false;
  }

  if ( (authentication_token.compare("<YOUR_AUTHENTICATION_TOKEN_HERE>") == 0) ||
       (authentication_token.compare("") == 0) )
  {
    mLogger.Log(LogLevel::WARNING, "Authentication token not configured.");
    return false;
  }

  if ( (jenkins_api_url.compare("<YOUR_JENKINS_API_URL_HERE>") == 0) ||
       (jenkins_api_url.compare("") == 0) )
  {
    mLogger.Log(LogLevel::WARNING, "Jenkins api url not configured.");
    return false;
  }

  bool result = false;
  if(FINGERPRINT_SIZE < 1) 
  {
    mLogger.Log(LogLevel::WARNING, "fingerprint size is 0.");
    return false;
  }
  for(int i = 0; i < FINGERPRINT_SIZE; i ++) 
  {
      if(fingerprint[i] != 0xFF)
      {
        result = true;
        break;
      }
  }
  if(!result)
  {
    mLogger.Log(LogLevel::WARNING, "fingerprint not configured.");
    return false;
  }
  
  return true;
}
