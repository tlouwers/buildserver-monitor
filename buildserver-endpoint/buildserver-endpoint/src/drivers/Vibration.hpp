/**
 * \file    Vibration.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Vibration class, wrapper for pin toggle (on/off).
 *
 * \details Intended use is to provide an easy means to control an external
 *          vibration motor via a pin toggle.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2022
 */

#ifndef VIBRATION_HPP_
#define VIBRATION_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <Arduino.h>
#include "interfaces/IInitable.hpp"
#include "interfaces/ILogging.hpp"
#include "interfaces/IVibration.hpp"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Vibration motor class.
 */
class Vibration final : public IVibration, public IConfigInitable
{
public:
    /**
     * \struct  Config
     * \brief   Configuration struct for Vibration.
     */
    struct Config : public IConfig
    {
        /**
         * \brief   Constructor of the Vibration configuration struct.
         * \param   pinID   The pin to which the Vibration motor is attached.
         */
        explicit Config(uint8_t pinID) :
            mPinID(pinID)
        { }

        uint8_t mPinID;     ///< The pin to use.
    };

    explicit Vibration(ILogging& logger);
    virtual ~Vibration();

    bool Init(const IConfig& config) override;
    bool IsInit() const override;
    bool Sleep() override;

    bool On() override;
    bool IsOn() const override;
    bool Off() override;
    bool Toggle() override;

private:
    ILogging& mLogger;
    bool      mInitialized;
    uint8_t   mPin;
};


#endif  // VIBRATION_HPP_
