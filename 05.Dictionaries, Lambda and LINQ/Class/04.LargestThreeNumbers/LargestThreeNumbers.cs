// Read a list of real numbers and print largest 3 of them. If less than 3 numbers exit, print all of them
using System;
using System.Linq;

class LargestThreeNumbers
{
    static void Main()
    {
        Console.WriteLine(string.Join(" ", Console.ReadLine()
                                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(double.Parse)
                                            .OrderByDescending(x=>x)
                                            .Take(3)));
    }
}
