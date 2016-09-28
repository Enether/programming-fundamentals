/*
 Draw at the console a filled square of size n like in the example
 input: 4
 output:
--------
-\/\/\/-
-\/\/\/-
--------
 */
using System;
using System.Linq;

class DrawAFilledSquare
{
    static void Main()
    {
        PrintSquare(int.Parse(Console.ReadLine()));
    }

    static void PrintSquare(int number)
    {
        PrintHeaderRow(number);
        for (int i = 0; i < number-2; i++)
        {
            PrintMiddleRow(number);
        }
        PrintHeaderRow(number);
    }

    static void PrintHeaderRow(int number)
    {
        Console.WriteLine(new string('-', number * 2));
    }

    static void PrintMiddleRow(int number)
    {
        Console.WriteLine('-' + string.Concat(Enumerable.Repeat("\\/", number-1)) + '-');
    }
}
