/*
 You are part of the back-end development team of the next Facebook. 
 You are given a line of usernames, between one of the following symbols: space, “/”, “\”, “(“, “)”. 
 First you have to export all valid usernames. A valid username starts with a letter and can contain only letters, digits and “_”. 
 It cannot be less than 3 or more than 25 symbols long. Your task is to sum the length of every 2 consecutive valid usernames and print on
 the console the 2 valid usernames with biggest sum of their lengths, each on a separate line. 

 Input
The input comes from the console. One line will hold all the data. It will hold usernames, divided by the symbols: space, “/”, “\”, “(“, “)”. 
The input data will always be valid and in the format described. There is no need to check it explicitly.

Output
Print at the console the 2 consecutive valid usernames with the biggest sum of their lengths each on a separate line. If there are 2 or more couples of usernames with the same sum of their lengths, print he left most.

Constraints
The input line will hold characters in the range [0 … 9999].
The usernames should start with a letter and can contain only letters, digits and “_”.
The username cannot be less than 3 or more than 25 symbols long.
Time limit: 0.5 sec. Memory limit: 16 MB.

 */
using System;
using System.Text.RegularExpressions;


class ValidUsernames
{
    static void Main()
    {
        string regexPattern = @"(?<=[ \\\/)(]|^)(?<open>[ \\\/)(]|^)*(?<username>[a-zA-Z][a-zA-Z_0-9]{2,24})(?=[ \\\/)(]|$)(?<close>[ \\\/)(]|$)*";

        Match previousMatch = null;
        // values to hold the record lengths
        int maxLength = int.MinValue;
        string maxFirstUsername = "", maxSecondUsername = "";
        foreach (Match match in Regex.Matches(Console.ReadLine(), regexPattern))
        {
            if (previousMatch == null)  // for the very first iteration
            {
                previousMatch = match;
                continue;
            }
            string firstUser = previousMatch.Groups["username"].Value;
            string secondUser = match.Groups["username"].Value;

            if (firstUser.Length + secondUser.Length > maxLength)
            {
                maxLength = firstUser.Length + secondUser.Length;
                maxFirstUsername = firstUser;
                maxSecondUsername = secondUser;
            }

            previousMatch = match;
        }

        Console.WriteLine(maxFirstUsername);
        Console.WriteLine(maxSecondUsername);
    }
}
