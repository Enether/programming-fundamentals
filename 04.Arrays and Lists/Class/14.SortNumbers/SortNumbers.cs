//Read a list of decimal numbers and sort them in increasing order. Print the output as shown in the examples below.
using System;
using System.Collections.Generic;
using System.Linq;

class SortNumbers
{
    static void Main()
    {
        List<decimal> input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToList();
        input.Sort();
        Console.WriteLine(string.Join(" <= ", input));
    }
}

