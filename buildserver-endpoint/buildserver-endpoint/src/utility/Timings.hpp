/**
 * \file    Timings.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Various magic numbers for timings.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    06-2020
 */

#ifndef TIMINGS_HPP_
#define TIMINGS_HPP_


/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <stdint.h>
#include <stddef.h>


/************************************************************************/
/* Configurable options                                                 */
/************************************************************************/
// Timeouts - in milliseconds
static constexpr unsigned QUARTER_SECOND =    250;
static constexpr unsigned HALF_SECOND    =    500;
static constexpr unsigned ONE_SECOND     =   1000;
static constexpr unsigned TWO_SECONDS    =   2000;
static constexpr unsigned THREE_SECONDS  =   3000;
static constexpr unsigned FOUR_SECONDS   =   4000;
static constexpr unsigned FIVE_SECONDS   =   5000;
static constexpr unsigned TEN_SECONDS    =  10000;
static constexpr unsigned TWENTY_SECONDS =  20000;
static constexpr unsigned THIRTY_SECONDS =  30000;
static constexpr unsigned SIXTY_SECONDS  =  60000;

static constexpr unsigned ONE_MINUTE     =  60000;
static constexpr unsigned TWO_MINUTES    = 120000;
static constexpr unsigned FIVE_MINUTES   = 300000;
static constexpr unsigned TEN_MINUTES    = 600000;


#endif  // TIMINGS_HPP_
