/*
Write a method that prints the digits of a given decimal number in a reversed order.
*/
using System;

class NumbersInReversedOrder
{
    static void Main()
    {
        decimal number = decimal.Parse(Console.ReadLine());
        PrintStringReverse(number.ToString());
    }

    public static void PrintStringReverse(string str)
    {
        // prints the string in reverse
        for (int i = str.Length-1; i >= 0; i--)
        {
            Console.Write(str[i]);
        }
    }
}

