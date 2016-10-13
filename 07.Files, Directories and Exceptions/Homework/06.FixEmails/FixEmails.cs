/*
 You are given a sequence of strings, each on a new line, unitll you receive “stop” command.
 First string is a name of a person. On the second line you receive his email.
 Your task is to collect their names and emails, and remove emails whose domain ends with
 "us" or "uk" (case insensitive). Print:
{name} – > {email} 
 */
using System.IO;
using System.Collections.Generic;
using System.Text;

class FixEmails
{
    const string INPUT_FILE_PATH = "../../input/input.txt";
    const string OUTPUT_DIR_PATH = "../../ouput/";
    static void Main()
    {
        Directory.CreateDirectory(OUTPUT_DIR_PATH);
        string[] commands = File.ReadAllLines(INPUT_FILE_PATH);

        Dictionary<string, string> emails = new Dictionary<string, string>();

        for (int i = 0; i < commands.Length; i++)
        {
            string command = commands[i];

            if (command == "stop")
                break;
            else
            {
                // command is a name
                string name = command;
                string email = commands[i+1];
                i++;
                // if the email doesn't end in .us or .uk, add it to the dictionary
                if (!email.EndsWith("us") && !email.EndsWith("uk"))
                    emails[name] = email;
            }
        }

        StringBuilder output = new StringBuilder();
        // print the emails
        foreach (var pair in emails)
            output.AppendLine($"{pair.Key} -> {pair.Value}");

        string output_file_path = OUTPUT_DIR_PATH + "output.txt";
        File.CreateText(output_file_path).Close();

        File.WriteAllText(output_file_path, output.ToString());
    }
}