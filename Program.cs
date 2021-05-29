using System;

namespace DatesAndTimesInDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var start =DateTimeOffset.UtcNow;
            var end = start.AddSeconds(45);

            TimeSpan difference = end - start;

            System.Console.WriteLine(difference.TotalMilliseconds);
        }
    }
}