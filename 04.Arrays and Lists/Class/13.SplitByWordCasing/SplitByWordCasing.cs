/*
 Read a text, split it into words and distribute them into 3 lists.

Lower-case words like “programming”, “at” and “databases” – consist of lowercase letters only.
Upper-case words like “PHP”, “JS” and “SQL” – consist of uppercase letters only.
Mixed-case words like “C#”, “SoftUni” and “Java” – all others.

Use the following separators between the words: , ; : . ! ( ) " ' \ / [ ] space

Print the 3 lists as shown in the example below.
 */
using System;
using System.Collections.Generic;

class SplitByWordCasing
{
    static void Main()
    {
        string[] inputArr = Console.ReadLine().Split(new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '/', '[', ']', ' ', '\\' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> lowerCaseWords = new List<string>();
        List<string> mixedCaseWords = new List<string>();
        List<string> upperCaseWords = new List<string>();
        
        for (int i = 0; i < inputArr.Length; i++)
        {
            string word = inputArr[i];

            switch (GetWordCase(word))
            {
                case "mixed":
                    mixedCaseWords.Add(word);
                    break;
                case "upper":
                    upperCaseWords.Add(word);
                    break;
                case "lower":
                    lowerCaseWords.Add(word);
                    break;
            }
        }

        Console.WriteLine($"Lower-case: {string.Join(", ", lowerCaseWords)}");
        Console.WriteLine($"Mixed-case: {string.Join(", ", mixedCaseWords)}");
        Console.WriteLine($"Upper-case: {string.Join(", ", upperCaseWords)}");
    }

    static string GetWordCase(string word)
    {
        bool isMixed = false;
        bool isUpper = false;
        bool isLower = false;

        for (int i = 0; i < word.Length; i++)
        {
            if (char.IsUpper(word[i]))
                isUpper = true;
            else if (char.IsLower(word[i]))
                isLower = true;
            else
                isMixed = true;
        }

        if (isMixed || (isUpper == true && isLower == true))
            return "mixed";
        else if (isUpper)
            return "upper";
        else
            return "lower";
    }
}

