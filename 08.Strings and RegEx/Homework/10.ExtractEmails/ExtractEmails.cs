using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        string pattern = @"(?:\s|^)(?<user>[0-9a-zA-Z][0-9a-zA-Z.\-_]*[0-9a-zA-Z])@(?<host>[a-zA-Z][a-zA-Z\-]*[a-zA-Z])(\.[a-zA-Z][a-zA-Z\-]*[a-zA-Z])+";
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(input, pattern);
        foreach (var match in matches)
        {
            Console.WriteLine(match);
        }
    }
}

