/*
 Read a list of real numbers and print them in ascending order along with their number of occurrences.
 */
using System;
using System.Linq;

class CountRealNumbers
{
    static void Main()
    {
        var groupedNumbers = Console.ReadLine().Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).GroupBy(item => item)
            .Select(group =>
                    new  // anonymous type
                    {
                        Number = group.Key,
                        Occurences = group.Count()
                    }).OrderBy(group => group.Number);  // order by the number

        foreach (var numberGroup in groupedNumbers)
        {
            Console.WriteLine($"{numberGroup.Number} -> {numberGroup.Occurences} ");
        }

    }
}
