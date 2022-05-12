/**
 * \file    HttpClient.cpp
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

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <string>
#include "config.h"
#include "http_config.h"
#include "HttpClient.hpp"
#include <ArduinoJson.h>


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
/**
 * \brief   Constructor.
 * \param   logger  Logging class.
 */
HttpClient::HttpClient(ILogging& logger) :
    mLogger(logger),
    client(NULL),
    mInit(false),
    mJsonString(""),
    mResult("")
{ ; }

/**
 * \brief   Destructor, deletes the client (if needed).
 */
HttpClient::~HttpClient()
{
    if (client != NULL) {
        delete client;
        client = NULL;
    }
}

/**
 * \brief   Initialize the HTTPS connection.
 * \returns True if successful, else false.
 */
bool HttpClient::Init()
{
    if (!mInit)
    {
        mLogger.Log(LogLevel::INFO, "Initializing http client");
        client = new BearSSL::WiFiClientSecure();
        if (client == NULL)
        {
            mLogger.Log(LogLevel::ERROR, "Cannot allocate memory for http client");
            return false;
        }

        if (client->setFingerprint(SHA1_FINGERPRINT))
        {
            mInit = true;
        }
        else
        {
            mLogger.Log(LogLevel::ERROR, "Cannot set SHA1 fingerprint for http client");
            return false;
        }
    }
    else
    {
        mLogger.Log(LogLevel::INFO, "Already initialized the http client");
    }
    return mInit;
}

/**
 * \brief     Acquire build JSON file from given Jenkins URL.
 * \returns   True if JSON result could be acquired, else false.
 */
bool HttpClient::Acquire()
{
    mJsonString = "";

    if (client == NULL)
    {
        mLogger.Log(LogLevel::ERROR, "No http client configured!");
        return false;
    }

    // Note: these values are taken from the 'http_config.h' file.
    if (!CheckValidHttpConfiguration(USERNAME, BASIC_AUTHENTICATION_TOKEN, JENKINS_API_URL, SHA1_FINGERPRINT))
    {
        return false;
    }

    bool result = false;

    // Set authorization data: the user/pass to login with Jenkins
    https.setAuthorization(USERNAME.c_str(), BASIC_AUTHENTICATION_TOKEN.c_str());

    // Connect to the server (Jenkins) and check with SHA1 if server is who it claims it is
    mLogger.Log(LogLevel::ALL, JENKINS_API_URL.c_str());
    if (https.begin(*client, JENKINS_API_URL.c_str()))
    {
        // Login to Jenkins with credentials and retrieve JSON data
        int httpCode = https.GET();
        if (httpCode > 0)
        {
            // File found at server - put retrieved data into string to parse later
            if (httpCode == HTTP_CODE_OK || httpCode == HTTP_CODE_MOVED_PERMANENTLY)
            {
                mLogger.Log(LogLevel::INFO, "Http request succeeded, JSON retrieved");
                mJsonString = https.getString();
                result = true;
            }
            else if (httpCode == HTTP_CODE_UNAUTHORIZED)
            {
                mLogger.Log(LogLevel::ERROR, "User not authorized to access URL");
            }
            else
            {
                String message = "Invalid response: " + https.errorToString(httpCode);
                mLogger.Log(LogLevel::ERROR, message.c_str());
            }
        }
        else
        {
            String message = "[HTTPS] GET... failed, error: " + https.errorToString(httpCode);
            mLogger.Log(LogLevel::ERROR, message.c_str());
        }
        https.end();
    }
    else
    {
        std::string message = "Unable to connect with: " + JENKINS_API_URL;
        mLogger.Log(LogLevel::ERROR, message.c_str());
    }

    return result;
}

/**
 * \brief   Parse the received Jenkins JSON file (seek the "result" - the build status of the job).
 * \returns True if the build state could be found, else false.
 */
bool HttpClient::Parse()
{
    if (mJsonString == "") { return false; }

    StaticJsonDocument<3000> doc;   // Keep the number low
    DeserializationError error = deserializeJson(doc, mJsonString);

    if (error) {
        String errorStr(error.c_str());
        String message = "DeserializeJson() failed: " + errorStr;
        mLogger.Log(LogLevel::INFO, message.c_str());
        return false;
    }

    // Parse 'result' and copy it to mResult
    const char* result = doc["result"];
    mResult = result;

    String message = "Parsed JSON result: " + mResult;
    mLogger.Log(LogLevel::INFO, message.c_str());
    mJsonString = "";
    return true;
}

/**
 * \brief   Get the buildstate from the retrieved JSON result.
 * \returns The current build state.
 */
BuildState HttpClient::getBuildState()
{
         if (mResult.compareTo("SUCCESS"  ) == 0) { return BuildState::Success;  }
    else if (mResult.compareTo("UNSTABLE" ) == 0) { return BuildState::Unstable; }
    else if (mResult.compareTo("FAILURE"  ) == 0) { return BuildState::Failure;  }
    else if (mResult.compareTo("ABORTED"  ) == 0) { return BuildState::Aborted;  }
    else if (mResult.compareTo("NOT_BUILT") == 0) { return BuildState::NotBuild; }
    else                                          { return BuildState::NoState;  }
}


/************************************************************************/
/* Private Methods                                                      */
/************************************************************************/
/**
 * \brief   Basic check to prevent the default or empty USERNAME, BASIC_AUTHENTICATION_TOKEN and JENKINS_API_URL.
 * \param   username              The Jenkins username to check.
 * \param   authentication_token  The authentication token to check.
 * \param   jenkins_api_url       The Jenkins URL to check.
 * \param   fingerprint           The fingerprint array to check.
 * \returns True if ssid and password are filled and not default.
 */
bool HttpClient::CheckValidHttpConfiguration(const std::string& username, const std::string& authentication_token, const std::string& jenkins_api_url, const uint8_t* fingerprint)
{
    if ( (username.compare("<YOUR_USERNAME_HERE>") == 0) ||
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
    if (FINGERPRINT_SIZE < 1)
    {
        mLogger.Log(LogLevel::WARNING, "Fingerprint size is 0.");
        return false;
    }
    if (fingerprint != NULL)
    {
        for (auto i = 0; i < FINGERPRINT_SIZE; i++)
        {
            if (fingerprint[i] != 0xFF)
            {
                result = true;
                break;
            }
        }
    }
    if (!result)
    {
        mLogger.Log(LogLevel::WARNING, "Fingerprint not configured.");
        return false;
    }

    return true;
}
