/*
 Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file text.txt. Matching should be case-insensitive.
The result should be written to another text file. Sort the words by frequency in descending order.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class WordCount
{
    const string WORDS_PATH = "../../input/words.txt";  // file with words we'll be searching for
    const string INPUT_PATH = "../../input/input.txt"; // file with the text
    static void Main()
    {
        string[] wordsToFind = File.ReadAllText(WORDS_PATH).ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] inputText = File.ReadAllText(INPUT_PATH).ToLower().Split(new char[] { ' ', '\r', '\n', '-', '.', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> wordsCount = new Dictionary<string, int>();

        // save the count
        foreach (var word in wordsToFind)
        {
            wordsCount[word] = inputText.Count(x => x == word);
        }
        
        StringBuilder output = new StringBuilder();
        // sort the dictionary and iterate through it
        foreach (var key in wordsCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value).Keys)
        {
            output.AppendLine($"{key} - {wordsCount[key]}");
        }

        File.CreateText("output.txt");
        File.WriteAllText("../../output.txt", output.ToString());
    }
}
