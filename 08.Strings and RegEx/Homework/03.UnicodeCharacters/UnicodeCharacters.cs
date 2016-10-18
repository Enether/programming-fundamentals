// Write a program that converts a string to a sequence of Unicode character literals.
using System;
using System.Linq;

class UnicodeCharacters
{
    static void Main()
    {
        Console.WriteLine(string.Join("", Console.ReadLine().Select(x => "\\u" + ((int)x).ToString("X").PadLeft(4, '0'))));
    }
}
