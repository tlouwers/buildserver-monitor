/**
 * \file StateMachine.cpp
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

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include "config.h"
#include "StateMachine.hpp"


/************************************************************************/
/* Public Methods                                                       */
/************************************************************************/
StateMachine::StateMachine(ILogging& logger) :
    mLogger(logger),
    mState(State::StartUp)    // Initial state
{ ; }

State StateMachine::GetState() const
{
    return mState;
}

void StateMachine::StateEntry(State state)
{
    std::string message = "State entry: " + mStateTypes[static_cast<uint8_t>(state)];
    mLogger.Log(LogLevel::ALL, message.c_str());
}

void StateMachine::StateExit(State state)
{
    std::string message = "State exit: " + mStateTypes[static_cast<uint8_t>(mState)];
    mLogger.Log(LogLevel::ALL, message.c_str());
}

void StateMachine::SetState(State newState)
{
    if (mState != newState)
    {
        StateExit(mState);

        mState = newState;

        StateEntry(newState);
    }
}
