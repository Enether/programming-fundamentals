/*
 Write a program that receives some info from the console about people and their phone numbers. Each entry should have just one name and one number (both of them strings). 
On each line you will receive some of the following commands:
A {name} {phone} – adds entry to the phonebook. In case of trying to add a name that is already in the phonebook you should change the existing phone number with the new one provided.
S {name} – searches for a contact by given name and prints it in format "{name} -> {number}". In case the contact isn't found, print "Contact {name} does not exist.".
END – stop receiving more commands.
 */
using System;
using System.Collections.Generic;

class Phonebook
{
    static void Main()
    {
        Dictionary<string, string> phonebook = new Dictionary<string, string>();
        string command = Console.ReadLine();

        while(true)
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
                if(phonebook.ContainsKey(name))
                    Console.WriteLine($"{name} -> {phonebook[name]}");
                else
                    Console.WriteLine($"Contact {name} does not exist.");
            }
            else  // END
                break;
            command = Console.ReadLine();
        }
        
    }
}
