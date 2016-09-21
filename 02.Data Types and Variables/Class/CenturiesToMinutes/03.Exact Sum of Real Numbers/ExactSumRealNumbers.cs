using System;

/*
 Write program to enter n numbers and calculate and print their exact sum (without rounding).
     */
class ExactSumRealNumbers
{
    static void Main()
    {
        int numbersCount = int.Parse(Console.ReadLine());
        decimal sum = 0.0M;

        for (int i = 0; i < numbersCount; i++)
        {
            sum += decimal.Parse(Console.ReadLine());
        }

        Console.WriteLine(sum);
    }
}

