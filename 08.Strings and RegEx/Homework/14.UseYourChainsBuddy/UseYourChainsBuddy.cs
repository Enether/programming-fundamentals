using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _14.UseYourChainsBuddy
{
    class UseYourChainsBuddy
    {
        static void Main()
        {
            string input = Console.ReadLine();
            StringBuilder output = new StringBuilder();

            foreach (Match match in Regex.Matches(input, @"(<p>(?<value>.+?)<\/p>)"))
            {
                StringBuilder decryptedText = new StringBuilder();
                string value = match.Groups["value"].Value;
                // replace all characters which are not small letters and numbers with a space " "
                value = Regex.Replace(value, @"[^a-z0-9]", " ");

                foreach (char character in value)
                {
                    char modifiedChar = character;
                    if (character >= 'a' && character <= 'm')
                    {
                        modifiedChar = Convert.ToChar(character + 13);
                    }
                    else if (character >= 'n' && character <= 'z')
                    {
                        modifiedChar = Convert.ToChar(character - 13);
                    }

                    decryptedText.Append(modifiedChar.ToString());
                }

                // replace multiple whitespaces with one only
                string decryptedStr = Regex.Replace(decryptedText.ToString(), @"\s+", " ");
                output.Append(decryptedStr);
            }

            Console.WriteLine(output.ToString());
        }
    }
}

