/*
 Write a program that finds the most frequent number in a given sequence of numbers. 
•	Numbers will be in the range [0…65535].
•	In case of multiple numbers with the same maximal frequency, print the leftmost of them.
    
 */
using System;
using System.IO;
using System.Linq;

class MostFrequentNumber
{
    const string FIRST_INPUT_PATH = "../../input/input1.txt";
    const string SECOND_INPUT_PATH = "../../input/input2.txt";
    const string THIRD_INPUT_PATH = "../../input/input3.txt";
    const string OUTPUT_DIR = "../../output/";
    static string[] inputs = new string[] { FIRST_INPUT_PATH, SECOND_INPUT_PATH, THIRD_INPUT_PATH };
    static void Main()
    {
        Directory.CreateDirectory(OUTPUT_DIR);

        for (int i = 0; i < inputs.Length; i++)
        {
            var groupedByFreqNums = from numbers in File.ReadAllText(inputs[i]).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    group numbers by numbers into grouped
                    select new { Number = grouped.Key, Freq = grouped.Count() };

            string outputFilePath = OUTPUT_DIR + "output" + (i + 1) + ".txt";
            File.CreateText(outputFilePath).Close();
            File.WriteAllText(outputFilePath, groupedByFreqNums.OrderByDescending(x => x.Freq).ToList()[0].Number.ToString());
        }
        
    }
}