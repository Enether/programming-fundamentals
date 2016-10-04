/*
Write a program that reads sequence of numbers, reverses their digits, and prints their sum.

ex: 123 234 12 => 321 + 432 + 21 = 774
*/
using System;
using System.Linq;

class SumReversedNumbers
{
    static void Main()
    {
        Console.WriteLine(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(ReverseOneLiner).Sum());
    }
    public static int ReverseOneLiner(int num)
    {
        for (int result = 0; /*no max, can loop forever, but won't*/;
                result = result * 10 + num % 10, num /= 10)
            if (num == 0)
                return result;
    }
}

