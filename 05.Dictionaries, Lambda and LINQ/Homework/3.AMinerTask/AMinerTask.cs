/*
 You are given a sequence of strings, each on a new line. Every odd line on the console is representing a resource (e.g. Gold, Silver, Copper, and so on) , and every even – quantity. Your task is to collect the resources and print them each on a new line. 
Print the resources and their quantities in format:
{resource} –> {quantity}
The quantities inputs will be in the range [1 … 2 000 000 000]
 */
using System;
using System.Collections.Generic;

class AMinerTask
{
    static void Main()
    {
        Dictionary<string, long> resources = new Dictionary<string, long>();

        string command = "";
        while(true)
        {
            command = Console.ReadLine();
            if (command == "stop")
                break;
            else
            {
                // command is a recource
                string resource = command;
                long quantity = long.Parse(Console.ReadLine());

                if (!resources.ContainsKey(resource))
                    resources[resource] = 0L;

                resources[resource] += quantity;
            }
        }

        // Print the results
        foreach (var pair in resources)
            Console.WriteLine($"{pair.Key} -> {pair.Value}");
    }
}
