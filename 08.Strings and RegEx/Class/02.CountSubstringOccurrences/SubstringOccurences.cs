/*
 Write a program to find how many times a given string appears in a given text as substring. 
 The text is given at the first input line. The search string is given at the second input line. The output is an integer number. 
 Please ignore the character casing. Overlapping between occurrences is allowed. Examples:
 */
using System;

class SubstringOccurences
{
    static void Main()
    {
        string text = Console.ReadLine().ToLower();
        string substring = Console.ReadLine().ToLower();
        int substrCount = 0;
        int index = text.IndexOf(substring);

        while (index != -1)
        {
            substrCount++;
            index = text.IndexOf(substring, index + 1);
        }
        Console.WriteLine(substrCount);
    }
}
