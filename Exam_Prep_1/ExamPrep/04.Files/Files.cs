/*
 You are given number of files with their full file paths and file sizes. You need to print all file names with a given extension that are present in a given root directory sorted by their file size in descending order. If two files have same size, order them by alphabetical order. 
If a file name (file name + extension) appears more than once in a given root, save only its latest value. If a file name appears in more than one root, they are treated as different files.
If there aren't any files that correspond to the query, print "No".

Input / Constrains
•	On the first line of input you will get N the number of files to be read from the console
•	On the next N lines, you receive the actual files in the format "root\folder\filename.extension;filesize"
•	There may be more than one folder e.g. files can be deeply nested
•	On the last line you receive a query string in format "{extension} in {root}". You need to print all files with the given extension that are in present in the given root

Output
•	You need to print all files sorted by their size in descending order. 
•	If two files have the same size, order them by alphabetical order. 
•	Files should be printed in the given format "filename.extension - filesize KB" 
•	If there aren't any movies that correspond to the query, print "No".

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Files
{
    const string pattern = @"(?<root>[^\\]+)\\(.*\\)*(?<file>[^;]+\.(?<extension>[a-zA-Z0-9]+));(?<size>\d+)";
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        // ex: Key: D:, Value: Key: exe Value: 51205 (KB)
        Dictionary<string, Dictionary<string, Dictionary<string, ulong>>> files = new Dictionary<string, Dictionary<string, Dictionary<string, ulong>>>();
        for (int i = 0; i < count; i++)
        {
            Match match = Regex.Match(Console.ReadLine(), pattern);
            if (!match.Success)
                continue;
            string root = match.Groups["root"].Value;
            string fileName = match.Groups["file"].Value;
            string extension = match.Groups["extension"].Value;
            ulong size = ulong.Parse(match.Groups["size"].Value);

            if (!files.ContainsKey(root))
                files[root] = new Dictionary<string, Dictionary<string, ulong>>();
            if (!files[root].ContainsKey(extension))
                files[root][extension] = new Dictionary<string, ulong>();

            files[root][extension][fileName] = size;
        }

        string[] query = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string searchedExtension = query[0];
        string searchedRoot = query[2];

        if (files.ContainsKey(searchedRoot) && files[searchedRoot].ContainsKey(searchedExtension))
        {
            var orderedFiles = files[searchedRoot][searchedExtension].OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var pair in orderedFiles)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} KB");
            }
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
