/*
 Read a text, extract its words, find all short words (less than 5 characters) and print them alphabetically, in lowercase.
Use the following separators: . , : ; ( ) [ ] " ' \ / ! ? (space).
Use case-insensitive matching.
Remove duplicated words.
 */
using System;
using System.Linq;

class ShortWordsSorted
{
    static void Main()
    {
        char[] separators = { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };
        string[] words = Console.ReadLine().ToLower()  // convert the whole input to lowercase
                        .Split(separators, StringSplitOptions.RemoveEmptyEntries)  // split by the separators
                        .Distinct()  // remove duplicate words
                        .Where(word => word.Length < 5)  // get the words that are shorter than 5
                        .OrderBy(x => x)  // order them alphabetically
                        .ToArray();
        Console.WriteLine(string.Join(", ", words));
    }
}
