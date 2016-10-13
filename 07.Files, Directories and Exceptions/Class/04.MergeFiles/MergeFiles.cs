/*
 Write a program that reads the contents of two text files and merges them together into a third one.
 */
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04.MergeFiles
{
    class MergeFiles
    {
        const string FILE_ONE_PATH = "../../input/FileOne.txt";
        const string FILE_TWO_PATH = "../../input/FileTwo.txt";

        static void Main()
        {
            List<string> newFileLines = File.ReadAllLines(FILE_ONE_PATH).ToList();

            newFileLines.AddRange(File.ReadAllLines(FILE_TWO_PATH));
            newFileLines.Sort();

            File.Create("output.txt");
            File.WriteAllLines("../../output.txt", newFileLines);
        }
    }
}
