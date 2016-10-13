/*
 Write a program that creates an array containing all letters from the alphabet (a-z). 
 Read a lowercase word from the console and print the index of each of its letters in the letters array
 */
using System;
using System.IO;
using System.Text;

class IndexOfLetters
{
    const string FIRST_INPUT_PATH = "../../input/input1.txt";
    const string SECOND_INPUT_PATH = "../../input/input2.txt";
    static string[] inputs = new string[] { FIRST_INPUT_PATH, SECOND_INPUT_PATH };

    const string OUTPUT_PATH = "../../output/";
    static void Main()
    {
        Directory.CreateDirectory(OUTPUT_PATH);

        for (int i = 0; i < inputs.Length; i++)
        {
            StringBuilder output = new StringBuilder();  // here we will store the output for each input

            string input = File.ReadAllText(inputs[i]);
            string output_file_path = OUTPUT_PATH + "output" + (i + 1) + ".txt";
            File.CreateText(output_file_path).Close();

            for (int j = 0; j < input.Length; j++)
            {
                output.AppendLine($"{input[j]} -> {input[j] - 97}");
            }

            File.WriteAllText(output_file_path, output.ToString());
        }
    }
}