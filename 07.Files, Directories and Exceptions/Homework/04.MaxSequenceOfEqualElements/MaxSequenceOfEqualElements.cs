/*
 Write a program that finds the longest sequence of equal elements in an array of integers.
 If several longest sequences exist, print the leftmost one
 */
using System;
using System.IO;
using System.Linq;

class MaxSequenceOfEqualElements
{
    const string FIRST_INPUT_PATH = "../../input/input1.txt";
    const string SECOND_INPUT_PATH = "../../input/input2.txt";
    const string THIRD_INPUT_PATH = "../../input/input3.txt";
    static string[] inputs = new string[] { FIRST_INPUT_PATH, SECOND_INPUT_PATH, THIRD_INPUT_PATH };

    const string OUTPUT_DIR_PATH = "../../output/";
    static void Main()
    {
        Directory.CreateDirectory(OUTPUT_DIR_PATH);

        for (int i = 0; i < inputs.Length; i++)
        {
            int[] numbers = File.ReadAllText(inputs[i]).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int maxCount = -1;
            int maxCountNum = -1;

            for (int j = 0; j < numbers.Length; j++)
            {
                int currentNum = numbers[j];
                int currentCount = 1;

                for (int k = j + 1; k < numbers.Length; k++)
                {
                    if (numbers[k] != currentNum)
                        break;
                    currentCount++;
                    j = k;
                }
                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    maxCountNum = currentNum;
                }
            }
            string output_file_path = OUTPUT_DIR_PATH + "output_" + (i + 1) + ".txt";
            File.CreateText(output_file_path).Close();

            File.WriteAllText(output_file_path, string.Join(" ", Enumerable.Repeat(maxCountNum, maxCount)));
        }
    }
}