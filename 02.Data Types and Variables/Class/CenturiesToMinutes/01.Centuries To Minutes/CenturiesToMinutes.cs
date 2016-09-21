using System;

/*
 Write program to enter an integer number of centuries and convert it to years, days, hours and minutes.
     */
class CenturiesToMinutes
{
    const double DAYS_IN_YEAR = 365.2422;

    static void Main()
    {
        byte centuries = byte.Parse(Console.ReadLine());
        ushort year = (ushort)(centuries * 100);
        uint days = (uint)(year * DAYS_IN_YEAR);
        uint hours = days * 24;
        ulong minutes = hours * 60;

        Console.WriteLine($"{centuries} centuries = {year} years = {days} days = {hours} hours = {minutes} minutes");
    }
}

