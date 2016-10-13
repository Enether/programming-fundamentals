/*
 Write a program that reads a text file and writes its every odd line in another file. Line numbers starts from 0. 
 */
using System.IO;
using System.Linq;

class OddLines
{
    const string INPUT_PATH = "../../input/input.txt";
    static void Main()
    {
        string[] allLines = File.ReadAllLines(INPUT_PATH);
        string[] oddLines = allLines.Where((c, i) => i % 2 != 0).ToArray();
        File.CreateText("output.txt");
        File.WriteAllLines("../../output.txt", oddLines);
    }
}
