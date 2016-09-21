using System;
using System.Linq;

/*
 A number is special when its sum of digits is 5, 7 or 11.
Write a program to read an integer n and for all numbers in the range 1…n to print the number and if it is special or not (True / False).
     */
class SpecialNumbers
{
    public static readonly int[] SPECIAL_NUMBERS = { 5, 7, 11 };
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        for (int i = 1; i <= number; i++)
        {
            bool isSpecial = IsSpecial(i);
            Console.WriteLine($"{i} -> {isSpecial}");
        }
    }

    private static bool IsSpecial(int number)
    {
        return SPECIAL_NUMBERS.Contains(SumNumberDigits(number));
    }

    private static int SumNumberDigits(int number)
    {
        int sum = 0;
        char[] numberDigits = number.ToString().ToCharArray();

        for (int i = 0; i < numberDigits.Length; i++)
        {
            sum += int.Parse(numberDigits[i].ToString());
        }

        return sum;
    }
}
