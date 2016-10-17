/*
 Write a program that replaces in a HTML document given as string all the tags 
 <a href=…>…</a> with corresponding tags [URL href=…>…[/URL]. 
 Read an input, until you receive “end” command. Print the result on the console. 
 */
using System;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceATags
{
    const string regPattern = @"(?<openA><a\s*)(?<link>.+)(?<closeLink>>)(?<rest>\s*.*\s*)(?<closingA><\/a>)";
    static void Main()
    {
        string input = ReadInput();
        Regex rex = new Regex(regPattern);
        string replacement = @"[URL $2]$4[/URL]";
        Console.WriteLine(Regex.Replace(input, regPattern, replacement));
    }

    static string ReadInput()
    {
        StringBuilder input = new StringBuilder();

        while (true)
        {
            string inputLine = Console.ReadLine();

            if (inputLine == "end")
                break;
            input.AppendLine(inputLine);
        }

        return input.ToString();
    }
}
