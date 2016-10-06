/*
 You are given a sequence of strings, each on a new line, unitll you receive “stop” command.
 First string is a name of a person. On the second line you receive his email.
 Your task is to collect their names and emails, and remove emails whose domain ends with
 "us" or "uk" (case insensitive). Print:
{name} – > {email} 
 */
using System;
using System.Collections.Generic;

class FixEmails
{
    static void Main()
    {
        Dictionary<string, string> emails = new Dictionary<string, string>();
        string command = "";

        while (true)
        {
            command = Console.ReadLine();

            if (command == "stop")
                break;
            else
            {
                // command is a name
                string name = command;
                string email = Console.ReadLine();
                // if the email doesn't end in .us or .uk, add it to the dictionary
                if(!email.EndsWith("us") && !email.EndsWith("uk"))
                    emails[name] = email;
            }
        }

        // print the emails
        foreach (var pair in emails)
            Console.WriteLine($"{pair.Key} -> {pair.Value}");
    }
}
