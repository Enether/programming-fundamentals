/*
Read a list of integers and extract all square numbers from it and print them in descending order.
A square number is an integer which is the square of any integer. For example, 1, 4, 9, 16 are square numbers.
*/
using System;
using System.Collections.Generic;
using System.Linq;

class SquareNumbers
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        List<int> squaredNumbers = numbers.Where(x => Math.Sqrt(x) == (int)Math.Sqrt(x)).ToList();
        squaredNumbers.Sort((a, b) => b.CompareTo(a));
        Console.WriteLine(string.Join(" ", squaredNumbers));
    }
}

