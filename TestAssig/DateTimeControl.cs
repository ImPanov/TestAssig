using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssig;

public static class DateTimeControl
{
    public static DateTime GetDateTime()
    {
        DateTime time = DateTime.MinValue;
        bool IsParseTimeStart = false;
        while (time == DateTime.MinValue)
        {
            var timeString = Console.ReadLine();
            IsParseTimeStart = DateTime.TryParseExact(timeString.AsSpan(), "dd.MM.yyyy".AsSpan(), null, DateTimeStyles.None, out time);
            if (!IsParseTimeStart)
            {
                Console.WriteLine("Некорректная дата, введите заново");
            }
        }
        return time;
    }
}
