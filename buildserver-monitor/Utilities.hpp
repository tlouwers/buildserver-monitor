/**
 * \file Utilities.hpp
 *
 * \licence "THE BEER-WARE LICENSE" (Revision 42):
 *          <terry.louwers@fourtress.nl> wrote this file. As long as you retain
 *          this notice you can do whatever you want with this stuff. If we
 *          meet some day, and you think this stuff is worth it, you can buy me
 *          a beer in return.
 *                                                                Terry Louwers
 *
 * \brief   Various small helper functions.
 *
 * \author  T. Louwers <terry.louwers@fourtress.nl>
 * \date    01-2020
 */

#ifndef UTILITIES_HPP_
#define UTILITIES_HPP_

/************************************************************************/
/* Includes                                                             */
/************************************************************************/
#include <cstdint>
#include <sstream>
#include <string>


/************************************************************************/
/* Template functions                                                   */
/************************************************************************/
/**
 * \brief   Converts a number to a string.
 * \details Work-around for the missing std::to_string() method.
 * \param   number    The number to convert.
 * \returns The number as string.
 */
template <typename T>
std::string NumberToString(T number)
{
   std::ostringstream ss;
   ss << number;
   return ss.str();
}


#endif  // UTILITIES_HPP_
