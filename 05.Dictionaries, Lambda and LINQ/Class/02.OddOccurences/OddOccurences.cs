/*
 Write a program that extracts from a given sequence of words all elements that present in it odd number of times (case-insensitive).
Words are given in a single line, space separated.
Print the result elements in lowercase, in their order of appearance.
 */
using System;
using System.Linq;

class OddOccurences
{
    static void Main()
    {
        // one liner for fun
        Console.WriteLine(string.Join(", ", Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .GroupBy(item => item.ToString().ToLower())
            .Select(group => new  // anonymous type
            {
              Word = group.Key,
             Occurences = group.Count()
            }).Where(item => item.Occurences % 2 != 0)  // select the ones who only have odd occurences
            .Select(item => item.Word).ToList()));  // get their value only
    }
}

