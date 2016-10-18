/*
 Write a method that takes as input two strings, and returns Boolean if they are exchangeable or not.
 Exchangeable are words where the characters in the first string can be replaced to get the second string. 
 Example: "egg" and "add" are exchangeable,
 but "aabbccbb" and "nnooppzz" are not. (First 'b' corresponds to 'o', but then it also corresponds to 'z'). 
 The two words may not have the same length, if such is the case they are exchangeable only if the longer one doesn't 
 have more types of characters then the shorter one ("Clint" and "Eastwaat" are exchangeable because 'a' and 't' are
 already mapped as 'l' and 'n',
 but "Clint" and "Eastwood" aren't exchangeable because 'o' and 'd' are not contained in "Clint").
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MagicExchangeableWords
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string firstStr = input[0];
        string secondStr = input[1];
        if (AreExchangeable(firstStr, secondStr))
            Console.WriteLine("true");
        else
            Console.WriteLine("false");
    }

    static bool AreExchangeable(string firstStr, string secondStr)
    {
        /*
         Hold key value pairs for each string in separate dictionaries andcheck them
         */
        Dictionary<char, char> firstCharCorrelations = new Dictionary<char, char>();
        Dictionary<char, char> secondCharCorrelations = new Dictionary<char, char>();
        for (int i = 0; i < Math.Max(firstStr.Length, secondStr.Length); i++)
        {
            if (i >= firstStr.Length)
            {
                // we only check to see if correlations have been made with the characters
                char secondStrChar = secondStr[i];
                if (!secondCharCorrelations.ContainsKey(secondStrChar))
                    return false;
            }
            else if (i >= secondStr.Length)
            {
                // we only check to see if correlations have been made with the 
                char firstStrChar = firstStr[i];
                if (!firstCharCorrelations.ContainsKey(firstStrChar))
                    return false;
            }
            else
            {
                char firstStrChar = firstStr[i];
                char secondStrChar = secondStr[i];

                // create only the first found correlations
                if (!firstCharCorrelations.ContainsKey(firstStrChar))
                {
                    firstCharCorrelations[firstStrChar] = secondStrChar;
                }
                if (!secondCharCorrelations.ContainsKey(secondStrChar))
                {
                    secondCharCorrelations[secondStrChar] = firstStrChar;
                }

                // check if they still correlate with the character's we're currently on
                if (firstCharCorrelations[firstStrChar] != secondStrChar)
                    return false;
                if (secondCharCorrelations[secondStrChar] != firstStrChar)
                    return false;
            }     
        }

        return true;
    }
}