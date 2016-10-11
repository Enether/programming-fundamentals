/*
 Write a program that reads two dates in format dd-MM-yyyy and prints the number of working days between these two dates inclusive. Non-working days are:
All days that are Saturday or Sunday.
All days that are official holidays in Bulgaria:
New Year Eve (1 Jan)
Liberation Day (3 March)
Worker’s day (1 May)
Saint George’s Day (6 May)
Saints Cyril and Methodius Day (24 May)
Unification Day (6 Sept)
Independence Day (22 Sept)
National Awakening Day (1 Nov)
Christmas (24, 25 and 26 Dec)
All days not mentioned above are working and should count.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class CountWorkingDays
{
    static DateTime[] holidays = new DateTime[]
    {
        new DateTime(2000, 1, 1),
        new DateTime(2000, 3, 3),
        new DateTime(2000, 5, 1),
        new DateTime(2000, 5, 6),
        new DateTime(2000, 5, 24),
        new DateTime(2000, 9, 6),
        new DateTime(2000, 9, 22),
        new DateTime(2000, 11, 1),
        new DateTime(2000, 12, 24),
        new DateTime(2000, 12, 25),
        new DateTime(2000, 12, 26)
    };
    static void Main()
    {
        // read dates
        DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", CultureInfo.InvariantCulture);
        DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", CultureInfo.InvariantCulture);
        int workingDays = 0;

        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            DateTime compareDate = new DateTime(2000, date.Month, date.Day);  // convert the date to the year 2000 to check if it's contained in the holidays array

            if (!((dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday) || holidays.Contains(compareDate)))
                workingDays++;
        }

        Console.WriteLine(workingDays);
    }
}
