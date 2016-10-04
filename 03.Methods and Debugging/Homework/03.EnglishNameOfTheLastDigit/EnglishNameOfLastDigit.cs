/*
Write a method that returns the English name of the last digit of a given number. Write a program that reads an

integer and prints the returned value from this method.
*/
using System;

class EnglishNameOfLastDigit
{
    static void Main()
    {
        Console.WriteLine(GetLastDigitName(long.Parse(Console.ReadLine())));
    }

    public static string GetLastDigitName(long n)
    {
        int lastDigit = int.Parse(n.ToString()[n.ToString().Length-1].ToString());
        switch (lastDigit)
        {
            case 9:
                return "nine";
            case 8:
                return "eight";
            case 7:
                return "seven";
            case 6:
                return "six";
            case 5:
                return "five";
            case 4:
                return "four";
            case 3:
                return "three";
            case 2:
                return "two";
            case 1:
                return "one";
            case 0:
                return "zero";          
        }

        return "Invalid Number!";
    }
}

