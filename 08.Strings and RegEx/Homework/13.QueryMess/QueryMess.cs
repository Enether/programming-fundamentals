/*

*Query Mess
This problem is originally from the JavaScript Basics Exam (22 November 2014). You may check your solution here.
Ivancho participates in a team project with colleagues at SoftUni.  They have to develop an application, but something mysterious happened – at the last moment all team members… disappeared!  And guess what? He is left alone to finish the project.  All that is left to do is to parse the input data and store it in a special way, but Ivancho has no idea how to do that! Can you help him?

Input
The input comes from the console on a variable number of lines and ends when the keyword "END" is received.  
For each row of the input, the query string contains pairs field=value. Within each pair, the field name and value are separated by an equals sign, '='. The series of pairs are separated by an ampersand, '&'. The question mark is used as a separator and is not part of the query string. A URL query string may contain another URL as value. The input data will always be valid and in the format described. There is no need to check it explicitly.

Output
For each input line, print on the console a line containing the processed string as follows:  key=[value]nextkey=[another  value] … etc. 
Multiple whitespace characters should be reduced to one inside value/key names, but there shouldn’t be any whitespaces before/after extracted keys and values. If a key already exists, the value is added with comma and space after other values of the existing key in the current string.  See the examples below.  

Constraints
SPACE is encoded as '+' or "%20". Letters (A-Z and a-z), numbers (0-9), the characters '*', '-', '.', '_' and other non-special symbols are left as-is.
Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class QueryMess
{
    static void Main()
    {
        string regexPattern = @"(?:\?|^|&)(?!ht)(?<key>([^=&])+)=(?<value>([^=&])+)";

        while (true)
        {
            // read the query
            string input = Console.ReadLine();

            if (input == "END")
                break;
            // store the queries parameters in a dictionary
            Dictionary<string, List<string>> keyValues = new Dictionary<string, List<string>>();

            foreach (Match match in Regex.Matches(input, regexPattern))
            {
                string key = match.Groups["key"].Value;
                string value = match.Groups["value"].Value;

                // fix spaces, first by replacing the placeholders "+" and "%20" with spaces, and then reducing each space streak to one. 
                // Also removing whitespaces before/after the key/value
                key = Regex.Replace(Regex.Replace(key, @"(%20|\+)", " "), @"\s+", " ").Trim();
                value = Regex.Replace(Regex.Replace(value, @"(%20|\+)", " "), @"\s+", " ").Trim();

                if (!keyValues.ContainsKey(key))
                    keyValues[key] = new List<string>();
                keyValues[key].Add(value);
            }

            foreach (var pair in keyValues)
            {
                Console.Write($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
            }
            Console.WriteLine();
        }
    }
}
