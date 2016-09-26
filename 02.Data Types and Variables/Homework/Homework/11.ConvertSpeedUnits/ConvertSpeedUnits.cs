using System;

/*
Create a program to ask the user for a distance (in meters) and the time taken (as three numbers: hours, minutes, seconds),
and print the speed, in meters per second, kilometers per hour and miles per hour.
Assume 1 mile = 1609 meters.

Input
On first line you receive – distance in meters
On second – hours
On third – minutes
On fourth – seconds

Output
Every number in the output should be precise up to 6 digits after the floating point
On first line – speed in meters per second (m/s)
On second line – speed in kilometers per hour (km/h) 
On third line – speed in miles per hour (mph)
*/
class ConvertSpeedUnits
{
    static void Main()
    {
        int distanceInMeters = int.Parse(Console.ReadLine());
        int hours = int.Parse(Console.ReadLine());
        int minutes = int.Parse(Console.ReadLine());
        int seconds = int.Parse(Console.ReadLine());

        // get meters per seconds m/s
        int totalSeconds = seconds + (((hours * 60) + minutes) * 60);
        float metersPerSecond = (float)distanceInMeters / totalSeconds;

        // get kilometers per hour km/h
        float distanceInKilometers = distanceInMeters / 1000f;
        float kilometersPerHour = (distanceInKilometers / totalSeconds) * 3600f;

        // get miles per hour mp/h
        float distanceInMiles = distanceInMeters / 1609.0f;
        float milesPerHour = (distanceInMiles / totalSeconds) * 3600f;

        Console.WriteLine(metersPerSecond);
        Console.WriteLine(kilometersPerHour);
        Console.WriteLine(milesPerHour);

    }
}

