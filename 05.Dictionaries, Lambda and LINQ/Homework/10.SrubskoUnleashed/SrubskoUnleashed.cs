/*
 Admit it – the СРЪБСКО is your favorite sort of music. You never miss a concert and you have become quite the geek concerning everything involved with СРЪБСКО. You can’t decide between all the singers you know who your favorite one is. One way to find out is to keep a statistics of how much money their concerts make. Write a program that does all the boring calculations for you.
On each input line you’ll be given data in format: "singer @venue ticketsPrice ticketsCount". There will be no redundant whitespaces anywhere in the input. Aggregate the data by venue and by singer. For each venue, print the singer and the total amount of money his/her concerts have made on a separate line. Venues should be kept in the same order they were entered, the singers should be sorted by how much money they have made in descending order. If two singers have made the same amount of money, keep them in the order in which they were entered. 
Keep in mind that if a line is in incorrect format, it should be skipped and its data should not be added to the output. Each of the four tokens must be separated by a space, everything else is invalid. The venue should be denoted with @ in front of it, such as @Sunny Beach
SKIP THOSE: Ceca@Belgrade125 12378, Ceca @Belgrade12312 123
The singer and town name may consist of one to three words. 
Input
The input data should be read from the console.
It consists of a variable number of lines and ends when the command “End" is received.
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
The output should be printed on the console.
Print the aggregated data for each venue and singer in the format shown below.
Format for singer lines is #{2*space}{singer}{space}->{space}{total money}
Constraints
The number of input lines will be in the range [2 … 50].
The ticket price will be an integer in the range [0 … 200].
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


class SrubskoUnleashed
{
    const string REGEX_SINGER_GROUP = "singer";
    const string REGEX_VENUE_GROUP = "venue";
    const string REGEX_TICKETPRICE_GROUP = "ticketPrice";
    const string REGEX_TICKETSCOUNT_GROUP = "ticketsCount";
    const string regexPattern = @"(?<singer>.+?) @(?<venue>.+?) (?<ticketPrice>\d+?) (?<ticketsCount>\d+)";
    // TODO: Input might have more spaces than anticipaed and we will still validate it
    static void Main()
    {
        string input = "";
        Dictionary<string, Dictionary<string, long>> venues = new Dictionary<string, Dictionary<string, long>>();
        while(true)
        {
            input = Console.ReadLine();
            if (input == "End")
                break;

            var inputInfo = ReadInput(input);
            if (inputInfo == null)
                continue;  // do not count the input if it's not valid

            string singer = inputInfo.Item1;
            string venue = inputInfo.Item2;
            int ticketPrice = inputInfo.Item3;
            long ticketsCount = inputInfo.Item4;

            if (!venues.ContainsKey(venue))
                venues[venue] = new Dictionary<string, long>();
            if (!venues[venue].ContainsKey(singer))
                venues[venue][singer] = 0L;

            long concertRevenue = ticketPrice * ticketsCount;
            venues[venue][singer] += concertRevenue;
        }

        PrintOutput(venues);
    }

    static void PrintOutput(Dictionary<string, Dictionary<string, long>> venues)
    {
        foreach (var venue in venues.Keys)
        {
            Console.WriteLine(venue);
            // order the singers and print them
            var orderedVenueSingers = venues[venue].OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var singer in orderedVenueSingers.Keys)
            {
                Console.WriteLine($"#  {singer} -> {orderedVenueSingers[singer]}");
            }
        }
    }

    static Tuple<string, string, int, long> ReadInput(string line)
    {
        /*
            Read a line of input, try to parse it using Regex and return a tuple containing all the values we get
            */
        Regex reg = new Regex(regexPattern);
        Match match = reg.Match(line);
        if (!match.Success)
            return null;

        string singer = match.Groups[REGEX_SINGER_GROUP].Value;
        string venue = match.Groups[REGEX_VENUE_GROUP].Value;
        int ticketPrice = int.Parse(match.Groups[REGEX_TICKETPRICE_GROUP].Value);
        long ticketsCount = long.Parse(match.Groups[REGEX_TICKETSCOUNT_GROUP].Value);

        return new Tuple<string, string, int, long>(singer, venue, ticketPrice, ticketsCount);
    }
}

