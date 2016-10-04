/*
Read a list of integers in range [0…1000] and print them in ascending order along with their number of occurrences
*/
using System;
using System.Collections.Generic;
using System.Linq;

class CountNumbers
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        var groups = numbers.GroupBy(item => item)
            .Select(group =>
                    new  // anonymous type
                    {
                        Number = group.Key,
                        Occurences = group.Count()
                    }).OrderBy(group => group.Number);  // order by the number

        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Number} -> {group.Occurences}");
        }
    }
}

