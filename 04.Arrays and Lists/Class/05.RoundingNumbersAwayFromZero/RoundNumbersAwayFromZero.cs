/*
 Write a program to read an array of real numbers (space separated values), round them to the nearest integer in
“away from 0” style and print the output as in the examples below.

Rounding in “away from zero” style means:

To round to the nearest integer, e.g. 2.9  3; -1.75  -2
In case the number is exactly in the middle of two integers (midpoint value), round it to the next integer

which is away from the 0:
 */
using System;
using System.Linq;

class RoundNumbersAwayFromZero
{
    static void Main()
    {
        foreach (double num in Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray())
        {
            Console.WriteLine($"{num} => {Math.Round(num, MidpointRounding.AwayFromZero)}");
        }
    }
}

