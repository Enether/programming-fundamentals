/*
 Write a program to append several lists of numbers.

 Lists are separated by ‘|’.

 Values are separated by spaces (‘ ’, one or several)

 Order the lists from the last to the first, and their values from left to right.
 */
using System;
using System.Collections.Generic;
using System.Linq;

class AppendLists
{
    static void Main()
    {
        // each element in the array below is an input string that will be converted into an array of itself
        var arrays = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

        List<int> appendedLists = new List<int>();
        for (int i = arrays.Length - 1; i >= 0; i--)
        {
            appendedLists.AddRange(string.Join("", arrays[i]).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
        }

        Console.WriteLine(string.Join(" ", appendedLists));
    }
}
