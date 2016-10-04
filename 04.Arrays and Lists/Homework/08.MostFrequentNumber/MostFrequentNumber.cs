/*
 Write a program that finds the most frequent number in a given sequence of numbers. 
•	Numbers will be in the range [0…65535].
•	In case of multiple numbers with the same maximal frequency, print the leftmost of them.
    
 */
using System;
using System.Collections.Generic;
using System.Linq;

class MostFrequentNumber
{
    static void Main()
    {
        var i = from numbers in Console.ReadLine().Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                group numbers by numbers into grouped
                select new { Number = grouped.Key, Freq = grouped.Count() };
        Console.WriteLine(i.OrderByDescending(x => x.Freq).ToList()[0].Number);
    }
}
