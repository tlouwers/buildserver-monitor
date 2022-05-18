/**
 * \file    IHttpClient.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Http client wrapper interface class.
 *
 * \details This class is intended to act as interface for the http requests
 *          class, to ease unit testing.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2020
 */

#ifndef IHTTP_CLIENT_HPP_
#define IHTTP_CLIENT_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>


/************************************************************************/
/* Enums                                                                */
/************************************************************************/
/**
 * \enum    BuildState
 * \brief   Available build states.
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
 * \brief   IHttpClient interface class.
*/
class IHttpClient
{
public:
    virtual bool Init() = 0;
    virtual bool Acquire() = 0;
    virtual bool Parse() = 0;
    virtual BuildState getBuildState() = 0;
};


#endif  // IHTTP_CLIENT_HPP_
