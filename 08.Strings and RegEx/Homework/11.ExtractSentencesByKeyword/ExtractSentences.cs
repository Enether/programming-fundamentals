/*
 Write a program that extracts from a text all sentences that contain a particular word (case-sensitive).
Assume that the sentences are separated from each other by the character "." or "!" or "?".
The words are separated one from another by a non-letter character.
Notе that appearance as substring is different than appearance as word.
The sentence “I am a fan of Motorhead” does not contain the word “to”. It contains the substring “to” which is not what we need.
Print the result sentence text without the separators between the sentences ("." or "!" or "?")
 */
using System;
using System.Text.RegularExpressions;

class ExtractSentences
{
    static void Main()
    {
        string keyword = Console.ReadLine();
        string regexPattern = @"((?<=[.!?]|^)(([^\w.?!]|^)+\w*[^\w.?!]*)*[^\w\.\?!]+(" + keyword + @")[^\w\.\?!]+([^\w.?!]*\w*[^\w.!?]*)*)(?:[.!?]+)";
        string text = Console.ReadLine();

        foreach (Match match in Regex.Matches(text, regexPattern))
        {
            Console.WriteLine(match.Groups[1].Value);
        }
    }
}
