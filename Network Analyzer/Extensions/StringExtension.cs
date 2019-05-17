﻿using System;
using System.Linq;
using System.Net;
using Network_Analyzer.Models.Enums;

namespace Network_Analyzer.Extensions
{
    /// <summary>
    ///     Class string extensions
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        ///     Check string parsing language
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public static bool ValidateLanguage(this string language)
        {
            foreach (Languages languageValue in Enum.GetValues(typeof(Languages)))
            {
                if (languageValue.ToString() == language)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Check string parsing address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool ValidateAddress(this string address)
        {
            if (address.Count(c => c == '.') != 3)
            {
                return false;
            }

            return IPAddress.TryParse(address, out var parseAddress);
        }

        /// <summary>
        ///     Check strong parsing port
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool ValidatePort(this string port)
        {
            if (int.TryParse(port, out var parsePort))
            {
                if (parsePort >= 1 && parsePort <= 65535)
                {
                    return true;
                }
            }

            return false;
        }
    }
}