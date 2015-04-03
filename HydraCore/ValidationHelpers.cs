﻿using System;
using System.Diagnostics.Contracts;
using System.Net;
using System.Text.RegularExpressions;

namespace HydraCore
{
    public static class ValidationHelpers
    {
        private static readonly Regex DomainRegex = new Regex(@"^([a-z](\-?[a-z0-9]+)*\.)+[a-z](\-?[a-z0-9]+)*$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static bool IsValidDomainName(this string domain)
        {
            Contract.Requires<ArgumentNullException>(domain != null);
            return DomainRegex.IsMatch(domain);
        }

        public static bool IsValidAddressLiteral(this string address)
        {
            Contract.Requires<ArgumentNullException>(address != null);
            IPAddress ip;
            if (address.StartsWith("IPv6:"))
            {
                address = address.Substring(5);

                if (!IPAddress.TryParse(address, out ip)) return false;

                return ip.GetAddressBytes().Length > 4;
            }

            if (!IPAddress.TryParse(address, out ip)) return false;

            return ip.GetAddressBytes().Length == 4;
        }

        public static bool IsValidDomain(this string domain)
        {
            Contract.Requires<ArgumentNullException>(domain != null);
            if (IsValidDomainName(domain)) return true;

            if (domain.StartsWith("[") && domain.EndsWith("]"))
            {
                return IsValidAddressLiteral(domain.Substring(1, domain.Length - 2));
            }

            return false;
        }
    }
}