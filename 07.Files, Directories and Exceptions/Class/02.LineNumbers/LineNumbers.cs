/*
 Write a program that reads a text file 
 and inserts line numbers in front of each of its lines. The result should be written to another text file. 
 */
using System;
using System.IO;

class LineNumbers
{
    const string INPUT_PATH = "../../input/input.txt";

    static void Main()
    {
        string[] text = File.ReadAllLines(INPUT_PATH);
        File.CreateText("output.txt");

        for (int i = 0; i < text.Length; i++)
        {
            File.AppendAllText("../../output.txt", $"{i + 1}. {text[i]}{Environment.NewLine}");
        }

        Console.WriteLine("Done! :)");
    }
}
