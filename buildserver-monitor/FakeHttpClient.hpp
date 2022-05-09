/**
 * \file    FakeHttpClient.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Fake implementation of the wrapper for a http client.
 *
 * \details Intended use is to provide a simulation for when no http server
 *          (like Jenkins) is to be used.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2020
*/

#ifndef FAKE_HTTP_CLIENT_HPP_
#define FAKE_HTTP_CLIENT_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include "ILogging.hpp"
#include "IHttpClient.hpp"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Wrapper for a Http connection.
 */
class FakeHttpClient final : public IHttpClient
{
public:
    /**
     * \brief   Constructor.
     * \param   logger    Logging class.
     */
    explicit FakeHttpClient(const ILogging& logger) { (void)(logger); }

    /**
     * \brief   Destructor.
     */
    virtual ~FakeHttpClient() {}

    /**
     * \brief   Initialize the HTTPS connection.
     * \returns True if successful, else false. Note: simulated state.
     */
    bool Init() override
    {
        mInit = true;
        return true;
    }

    /**
     * \brief     Acquire build JSON file from given Jenkins URL.
     * \returns   True if JSON result could be acquired, else false.
     */
    bool Acquire() override { return (mInit == true) ? true : false; }

    /**
     * \brief   Parse the received Jenkins JSON file (seek the "result" - the build status of the job).
     * \returns True if the build state could be found, else false.
     */
    bool Parse() override { return (mInit == true) ? true : false; }

    /**
     * \brief   Get the buildstate from the retrieved JSON result.
     * \returns The current build state. Note: simulated state.
     */
    BuildState getBuildState() override { return BuildState::Success; }

private:
    bool mInit = false;
};


#endif  // FAKE_HTTP_CLIENT_HPP_
