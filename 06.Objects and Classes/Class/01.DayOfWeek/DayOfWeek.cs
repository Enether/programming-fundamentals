/* You are given a date in format day-month-year. Calculate and print the day of week in English. */
using System;
using System.Globalization;

class DayOfWeek
{
    static void Main()
    {
        Console.WriteLine(DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", CultureInfo.InvariantCulture).DayOfWeek);
    }
}
