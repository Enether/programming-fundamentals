using System;
// Enter a day number [1…7] and print the day name (in English) or “Invalid Day!”. Use an array of strings.
class DayOfWeek
{
    static void Main()
    {
        string[] daysOfTheWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        int dayNumber = int.Parse(Console.ReadLine());

        if (!(dayNumber < 1 || dayNumber > 7))
        {
            Console.WriteLine(daysOfTheWeek[dayNumber - 1]);
        }
        else
            Console.WriteLine("Invalid Day!");
    }
}

