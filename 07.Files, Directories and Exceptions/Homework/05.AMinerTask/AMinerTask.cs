/*
 You are given a sequence of strings, each on a new line. Every odd line on the console is representing a resource (e.g. Gold, Silver, Copper, and so on) , and every even – quantity. Your task is to collect the resources and print them each on a new line. 
Print the resources and their quantities in format:
{resource} –> {quantity}
The quantities inputs will be in the range [1 … 2 000 000 000]
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class AMinerTask
{
    const string INPUT_PATH = "../../input/input.txt";
    const string OUTPUT_PATH = "../../output/";

    static void Main()
    {
        Directory.CreateDirectory(OUTPUT_PATH);
        string[] commands = File.ReadAllLines(INPUT_PATH);

        Dictionary<string, long> resources = new Dictionary<string, long>();

        for (int i = 0; i < commands.Length; i++)
        {
            string command = commands[i];
            if (command == "stop")
                break;
            else
            {
                // command is a resource
                string resource = command;
                long quantity = long.Parse(commands[i+1]);
                i++;

                if (!resources.ContainsKey(resource))
                    resources[resource] = 0L;

                resources[resource] += quantity;
            }
        }

        string output_file_path = OUTPUT_PATH + "output.txt";
        File.CreateText(output_file_path).Close();
        StringBuilder output = new StringBuilder();  // collect the output here

        // Print the results
        foreach (var pair in resources)
            output.AppendLine($"{pair.Key} -> {pair.Value}");

        File.WriteAllText(output_file_path, output.ToString());
    }
}