/*
* Logs Aggregator
You are given a sequence of access logs in format <IP> <user> <duration>. For example:
192.168.0.11 peter 33
10.10.17.33 alex 12
10.10.17.35 peter 30
10.10.17.34 peter 120
10.10.17.34 peter 120
212.50.118.81 alex 46
212.50.118.81 alex 4
Write a program to aggregate the logs data and print for each user the total duration of his sessions and a list of unique IP addresses in format "<user>: <duration> [<IP1>, <IP2>, …]". Order the users alphabetically. Order the IPs alphabetically. In our example, the output should be the following:
alex: 62 [10.10.17.33, 212.50.118.81]
peter: 303 [10.10.17.34, 10.10.17.35, 192.168.0.11]
 */
using System;
using System.Collections.Generic;
using System.Linq;

class LogsAggregator
{
    public const int INPUT_IP_INDEX = 0;
    public const int INPUT_USERNAME_INDEX = 1;
    public const int INPUT_DURATION_INDEX = 2;

    static void Main()
    {
        int inputCount = int.Parse(Console.ReadLine());

        // key: name, value: list of the IPs the user has used
        SortedDictionary<string, List<string>> accessLogs = new SortedDictionary<string, List<string>>();
        // key: name, value: sum of user's durations
        Dictionary<string, int> userDurations = new Dictionary<string, int>();

        for (int i = 0; i < inputCount; i++)
        {
            string[] inputInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string ip = inputInfo[INPUT_IP_INDEX];
            string username = inputInfo[INPUT_USERNAME_INDEX];
            int duration = int.Parse(inputInfo[INPUT_DURATION_INDEX]);

            if (!accessLogs.ContainsKey(username))
            {
                accessLogs[username] = new List<string>();  // list of IPs
                userDurations[username] = 0;
            }

            accessLogs[username].Add(ip);
            userDurations[username] += duration;
        }

        // Sort the IPs alphabetically
        var accessLogsKeys = accessLogs.Keys.ToList();
        foreach (var username in accessLogsKeys)
        {
            accessLogs[username] = accessLogs[username].Distinct().OrderBy(x => x).ToList();
        }

        // Print output
        foreach (var username in accessLogs.Keys)
        {
            Console.WriteLine($"{username}: {userDurations[username]} [{string.Join(", ", accessLogs[username])}]");
        }
    }
}
