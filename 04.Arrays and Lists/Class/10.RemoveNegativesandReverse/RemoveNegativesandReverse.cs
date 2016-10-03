/*
 Read a list of integers, remove all negative numbers from it and print the remaining elements in reversed order. In
case of no elements left in the list, print “empty”.
 */
using System;
using System.Collections.Generic;
using System.Linq;

class RemoveNegativesandReverse
{
    static void Main()
    {
        List<int> positiveIntegers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where( x => x >= 0).ToList();
        positiveIntegers.Reverse();
        if (positiveIntegers.Count > 0)
            Console.WriteLine(string.Join(" ", positiveIntegers));
        else
            Console.WriteLine("empty");
    }
}
