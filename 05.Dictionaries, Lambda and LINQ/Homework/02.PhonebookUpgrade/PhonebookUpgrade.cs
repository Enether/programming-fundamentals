/*
 Add functionality to the phonebook from the previous task to print all contacts ordered lexicographically when receive the command “ListAll”
 */
using System;
using System.Collections.Generic;
using System.Linq;

class PhonebookUpgrade
{
    static void Main()
    {
        SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();
        string command = Console.ReadLine();

        while (true)
        {
            string[] commandInfo = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (command.StartsWith("A"))
            {
                string name = commandInfo[1];
                string number = commandInfo[2];
                phonebook[name] = number;
            }
            else if (command.StartsWith("S"))
            {
                string name = commandInfo[1];
                if (phonebook.ContainsKey(name))
                    Console.WriteLine($"{name} -> {phonebook[name]}");
                else
                    Console.WriteLine($"Contact {name} does not exist.");
            }
            else if (command == "ListAll")
            {
                foreach (var pair in phonebook)
                {
                    Console.WriteLine($"{pair.Key} -> {pair.Value}");
                }
            }
            else  // END
                break;
            command = Console.ReadLine();
        }
    }
}
