 /**
 * \file    IVibration.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Vibration interface class.
 *
 * \details This class is intended to act as interface for the Vibration class,
 *          to ease unit testing.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2022
 */

#ifndef IVIBRATION_HPP_
#define IVIBRATION_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>


/************************************************************************/
/* Interface declaration                                                */
/************************************************************************/
/**
 * \brief   IVibration interface class.
 */
class IVibration
{
public:
    virtual bool On() = 0;
    virtual bool IsOn() const = 0;
    virtual bool Off() = 0;
    virtual bool Toggle() = 0;
};


#endif  // IVIBRATION_HPP_
