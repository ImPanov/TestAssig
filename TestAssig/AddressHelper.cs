using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestAssig;

public static class AddressHelper
{
    public static string GetMaxAddress(int indexMask)
    {
        int[] addressMask = new int[] { 255, 255, 255, 255 };
        StringBuilder partAddressMask = new StringBuilder();
        for (int i = 1; i <= 32; i++)
        {
            if (i <= indexMask)
                partAddressMask.Append("1");
            else partAddressMask.Append("0");

            if (i % 8 == 0)
            {
                addressMask[i/8 - 1] -= Convert.ToInt32(partAddressMask.ToString(),2);
                partAddressMask.Clear();
            }
        }
        return string.Join(".", addressMask);
    }
}
