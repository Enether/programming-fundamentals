using System;

/* Write program to enter an integer number of 
 * centuries and convert it to years, days, hours, minutes, seconds, milliseconds, microseconds, nanoseconds.*/
class CenturiesToNanoseconds
{
    static void Main()
    {
        byte centuries = byte.Parse(Console.ReadLine());
        short years = (short)(centuries * 100);
        uint days = (uint)(years * 365.242);
        uint hours = days * 24;
        uint minutes = hours * 60;
        ulong seconds = (ulong)minutes * 60;
        ulong milliseconds = (ulong)seconds * 1000;
        ulong microseconds = milliseconds * 1000;
        ulong nanoseconds = microseconds * 1000;

        Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
    }
}

