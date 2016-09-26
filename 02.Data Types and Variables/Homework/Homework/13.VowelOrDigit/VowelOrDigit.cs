using System;
using System.Linq;

// Create a program to check if given symbol is digit, vowel or any other symbol.

class VowelOrDigit
{
    static string[] VOWELS = { "a", "e", "i", "o", "u", "y" };
    static void Main()
    {
        string input = Console.ReadLine();

        if (IsNumeric(input))
            Console.WriteLine("digit");
        else if (VOWELS.Contains(input.ToLower()))
            Console.WriteLine("vowel");
        else
            Console.WriteLine("other");
    }

    static bool IsNumeric(string text)
    {
        // this method will return a boolean indicating if the given text is a number
        float output;
        return float.TryParse(text, out output);
    }
}
