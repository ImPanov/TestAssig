using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestAssig
{
    internal static class CustomAddressParser
    {
        public static int IPAddressToInt(IPAddress ipAddress)
        {
            return BitConverter.ToInt32(ipAddress.GetAddressBytes().Reverse().ToArray(), 0);
        }
    }
}
