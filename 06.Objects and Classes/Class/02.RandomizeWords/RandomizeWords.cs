/*
 You are given a list of words in one line. Randomize their order and print each word at a separate line.
 */
using System;
using System.Collections.Generic;
using System.Linq;

class RandomizeWords
{
    static void Main()
    {
        List<string> originalSentence = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        List<string> randomizedWords = new List<string>();
        Random rnd = new Random();

        while (originalSentence.Count > 0)
        {
            int randomIndex = rnd.Next(0, originalSentence.Count);
            randomizedWords.Add(originalSentence[randomIndex]);
            originalSentence.RemoveAt(randomIndex);
        }

        Console.WriteLine(string.Join("\n", randomizedWords));
    }
}
