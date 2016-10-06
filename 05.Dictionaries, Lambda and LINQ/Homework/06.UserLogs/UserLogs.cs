/*
 Marian is a famous system administrator. The person to overcome the security of his servers has not yet been born. However, there is a new type of threat where users flood the server with messages and are hard to be detected since they change their IP address all the time. Well, Marian is a system administrator and is not so into programming. Therefore, he needs a skillful programmer to track the user logs of his servers. You are the chosen one to help him!
You are given an input in the format:

IP=(IP.Address) message=(A&sample&message) user=(username)
Your task is to parse the ip and the username from the input and for every user, you have to display every ip from which the corresponding user has sent a message and the count of the messages sent with the corresponding ip. In the output, the usernames must be sorted alphabetically while their IP addresses should be displayed in the order of their first appearance. The output should be in the following format:
username: 
IP => count, IP => count.
For example, given the following input - IP=192.23.30.40 message='Hello&derps.' user=destroyer, you have to get the username destroyer and the IP 192.23.30.40 and display it in the following format:
destroyer: 
192.23.30.40 => 1.
The username destroyer has sent a message from ip 192.23.30.40 once.
Check the examples below. They will further clarify the assignment.
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class UserLogs
{
    static string regexPattern = "IP=(?<ip>.+?) message='(?<message>.*?)' user=(?<user>.*)";
    static string REGEX_USER_GROUP = "user";
    static string REGEX_IP_GROUP = "ip";
    static string REGEX_MESSAGE_GROUP = "message";

    static void Main()
    {
        SortedDictionary<string, Dictionary<string, List<string>>> serverLogs = new SortedDictionary<string, Dictionary<string, List<string>>>();
        string inputLine = "";
        while(true)
        {
            inputLine = Console.ReadLine();
            if (inputLine == "end")
                break;

            Tuple<string, string, string> connectionInfo = ReadInputLine(inputLine);
            string ip = connectionInfo.Item1;
            string message = connectionInfo.Item2;
            string username = connectionInfo.Item3;

            if (!serverLogs.ContainsKey(username))
                serverLogs[username] = new Dictionary<string, List<string>>();
            if (!serverLogs[username].ContainsKey(ip))
                serverLogs[username][ip] = new List<string>();
            // add the message
            serverLogs[username][ip].Add(message);
        }

        foreach (var pair in serverLogs)
        {
            string userName = pair.Key;
            Dictionary<string, List<string>> ipMessageLogs = pair.Value;  // key: IP, value: list of string, the messages

            List<string> ipLogs = new List<string>();  // a list that will hold string in the format IP => (COUNT OF MESSAGES SENT FROM IP)
            foreach (var ipAndMessages in ipMessageLogs)
            {
                string ip = ipAndMessages.Key;
                int messagesCount = ipAndMessages.Value.Count;
                ipLogs.Add($"{ip} => {messagesCount}");
            }

            Console.WriteLine($"{userName}: ");
            Console.WriteLine(string.Join(", ", ipLogs) + ".");
        }
        
    }
    static Tuple<string, string, string> ReadInputLine(string inputLine)
    {
        // Uses regex to parse a line from the input and returns the IP, message and username in a tuple.
        // expected input is IP=192.23.30.40 message='Hello&derps.' user=destroyer
        Regex rex = new Regex(regexPattern);
        Match match = rex.Match(inputLine);
        string user = match.Groups[REGEX_USER_GROUP].Value;
        string ip = match.Groups[REGEX_IP_GROUP].Value;
        string message = match.Groups[REGEX_MESSAGE_GROUP].Value;

        return new Tuple<string, string, string>(ip, message, user);
    }
}

