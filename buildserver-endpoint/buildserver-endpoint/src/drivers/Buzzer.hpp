/**
 * \file    Buzzer.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Buzzer class, wrapper for pin toggle (on/off).
 *
 * \details Intended use is to provide an easy means to control an external
 *          buzzer via a pin toggle.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    05-2022
 */

#ifndef BUZZER_HPP_
#define BUZZER_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <Arduino.h>
#include "interfaces/IInitable.hpp"
#include "interfaces/ILogging.hpp"
#include "interfaces/IBuzzer.hpp"


/************************************************************************/
/* Class declaration                                                    */
/************************************************************************/
/**
 * \brief   Buzzer class.
 */
class Buzzer final : public IBuzzer, public IConfigInitable
{
public:
    /**
     * \struct  Config
     * \brief   Configuration struct for Buzzer.
     */
    struct Config : public IConfig
    {
        /**
         * \brief   Constructor of the Buzzer configuration struct.
         * \param   pinID   The pin to which the Buzzer is attached.
         */
        Config(uint8_t pinID) :
            mPinID(pinID)
        { }

        uint8_t mPinID;     ///< The pin to use.
    };

    explicit Buzzer(ILogging& logger);
    virtual ~Buzzer();

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


#endif  // BUZZER_HPP_
