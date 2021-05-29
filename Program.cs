using System;
using System.Globalization;

namespace DatesAndTimesInDotNet
{
    class Program
    {
        // static void Main(string[] args)
        // {
        //     var start =DateTimeOffset.UtcNow;
        //     var end = start.AddSeconds(45);

        //     TimeSpan difference = end - start;

        //     System.Console.WriteLine(difference.TotalMilliseconds);
        // }
            
        static Calendar calendar = CultureInfo.InvariantCulture.Calendar;
        static void Main(string[] args)
        {
            var start = new DateTimeOffset(2007, 12, 31, 0, 0, 0, TimeSpan.Zero);

            var week = calendar.GetWeekOfYear(start.DateTime,
            CalendarWeekRule.FirstFourDayWeek,
            DayOfWeek.Monday
            );

            System.Console.WriteLine(week);

            var isoWeek = ISOWeek.GetWeekOfYear(start.DateTime);
            System.Console.WriteLine(isoWeek);

            var isoWeekHack = GetIso8601WeekOfYear(start.DateTime);
            System.Console.WriteLine(isoWeekHack);
        }

        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}