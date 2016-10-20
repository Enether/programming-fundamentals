using System;
/*
 You will be given information about results of football matches. Create a standings table by points. For win the team gets 3 points, for loss – 0 and for draw – 1. Also find the top 3 teams with most scored goals in descending order. If two or more teams are with same goals scored or same points order them by name in ascending order.
The name of each team is encrypted. You must decrypt it before proceeding with calculating statistics. You will be given some string key and the team name will be placed between that key in reversed order.
For example: the key: “???”;
String to decrypt: “kfle???airagluB???gertIt%%” -> “airagluB” -> “Bulgaria”
Also you should ignore the letter casing in the team names. For example:
buLgariA = BulGAria = bulGARIA = BULGARIA

Input / Constrains
•	On the first line of input you will get the key that will be used for decryption
•	On the next lines until you receive “final” you will get lines in format:
{encrypted teamA} {encrypted teamB} {teamA score}:{teamB score}
•	Team scores will be integer numbers in the range [0...231]

     */
using System.Collections.Generic;
using System.Linq;

class FootballStandings
{
    static void Main(string[] args)
    {
        Dictionary<string, ulong> teamPoints = new Dictionary<string, ulong>();
        Dictionary<string, ulong> teamGoals = new Dictionary<string, ulong>();

        string key = Console.ReadLine();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "final")
                break;

            string[] splitInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // 0-{FIRST TEAM} 1-{SECOND TEAM} 2-{RESULT}
            string firstTeam = DecryptTeam(splitInput[0], key);
            string secondTeam = DecryptTeam(splitInput[1], key);

            string[] splitResult = splitInput[2].Split(':');
            ulong firstTeamGoals = ulong.Parse(splitResult[0]);
            ulong secondTeamGoals = ulong.Parse(splitResult[1]);

            // Check if the countries exist in our dictionary, if not, enter them

            // Points Dicionary
            if (!teamPoints.ContainsKey(firstTeam))
                teamPoints[firstTeam] = 0UL;
            if (!teamPoints.ContainsKey(secondTeam))
                teamPoints[secondTeam] = 0UL;
            // Goals Dictionary
            if (!teamGoals.ContainsKey(firstTeam))
                teamGoals[firstTeam] = 0UL;
            if (!teamGoals.ContainsKey(secondTeam))
                teamGoals[secondTeam] = 0UL;


            // add the statistics from the match
            if (firstTeamGoals == secondTeamGoals)
            {
                teamPoints[firstTeam] += 1UL;
                teamPoints[secondTeam] += 1UL;
            }
            else if (firstTeamGoals > secondTeamGoals)
            {
                // first team wins, 3 points to them
                teamPoints[firstTeam] += 3UL;
            }
            else if (secondTeamGoals > firstTeamGoals)
            {
                // second team wins, 3 points to them
                teamPoints[secondTeam] += 3UL;
            }

            //   add the goals of each team to their record
            teamGoals[firstTeam] += firstTeamGoals;
            teamGoals[secondTeam] += secondTeamGoals;
        }

        Console.WriteLine("League standings:");
        int leaguePosition = 1;
        foreach (var pair in teamPoints.OrderByDescending(points => points.Value).ThenBy(name => name.Key).ToDictionary(name => name.Key, points => points.Value))
        {
            Console.WriteLine($"{leaguePosition}. {pair.Key} {pair.Value}");
            leaguePosition += 1;
        }

        Console.WriteLine("Top 3 scored goals:");
        foreach (var pair in teamGoals.OrderByDescending(goals => goals.Value).ThenBy(name => name.Key).ToDictionary(name => name.Key, goals => goals.Value).Take(3))
        {
            Console.WriteLine($"- {pair.Key} -> {pair.Value}");
        }
    }

    static string DecryptTeam(string encryptedTeam, string key)
    {
        int firstKeyIndex = encryptedTeam.IndexOf(key);
        int lastKeyIndex = encryptedTeam.LastIndexOf(key);

        int messageStartIndex = firstKeyIndex + key.Length;
        return new string(encryptedTeam.Substring(messageStartIndex, lastKeyIndex - messageStartIndex).Reverse().ToArray()).ToUpper();
    }
}
