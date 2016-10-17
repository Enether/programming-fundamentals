/*
 Write a program that extracts from a given text all palindromes, 
 e.g. ABBA, lamal, exe and prints them on the console on a single line, separated by comma and space. 
 Use spaces, commas, dots, question marks and exclamation marks 
as word delimiters. Print only unique palindromes, sorted lexicographically.
 */
using System;
using System.Collections.Generic;
using System.Linq;

class Palindromes
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        SortedSet<string> palindromes = new SortedSet<string>();
        foreach (var word in words)
        {
            if (word == new string(word.Reverse().ToArray()))
            {
                palindromes.Add(word);
            }
        }

        Console.WriteLine(string.Join(", ", palindromes));
    }
}
