using System;
/*Create a method that prints the sign of an integer number n.*/

class SignOfIntegerNumber
{
    static void Main()
    {
        PrintSign(int.Parse(Console.ReadLine()));
    }

    static void PrintSign(int number)
    {
        string sign = "";

        if (number > 0)
            sign = "positive";
        else if (number < 0)
            sign = "negative";
        else
            sign = "zero";

        Console.WriteLine($"The number {number} is {sign}.");
    }
}
