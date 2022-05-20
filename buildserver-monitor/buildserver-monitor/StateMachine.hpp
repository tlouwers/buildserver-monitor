/**
 * \file    StateMachine.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Simple finite state machine class.
 *
 * \details Intended use is to provide an easier means to handle various states
 *          of the application, making it easier to handle recovery paths.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    01-2020
 */

#ifndef STATEMACHINE_HPP_
#define STATEMACHINE_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include <string>
#include "ILogging.hpp"


/************************************************************************/
/* Enums                                                                */
/************************************************************************/
/**
 * \enum    State
 * \brief   Available states.
 */
enum class State : uint8_t
{
    StartUp,
    Idle,
    Connected,
    Parsing,
    Displaying,
    Sleeping,
    Error,
};


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Simple finite state machine class.
 */
class StateMachine
{
public:
    explicit StateMachine(ILogging& logger);
    virtual ~StateMachine() {};

    State GetState() const;

    void StateEntry(State state);
    void StateExit(State state);
    void SetState(State newState);

private:
    ILogging& mLogger;
    State     mState;

    // To print State to serial output
    std::string mStateTypes[7] =
    {
        "StartUp",
        "Idle",
        "Connected",
        "Parsing",
        "Displaying",
        "Sleeping",
        "Error"
    };
};


#endif // STATEMACHINE_HPP_
