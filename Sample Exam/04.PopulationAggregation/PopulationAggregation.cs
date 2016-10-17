/*
 Write a program that receives as input information about country, city and its population and prints an aggregated statistic. There are 2 types of input lines
•	{Country}\{city}\{population}
•	{city}\{Country}\{population}
The country name always starts with a capital letter and the city name always starts with a lowercase letter. The country name and the city name are both polluted with prohibited symbols (@, #, $, & and digits from 0 to 9). Your task is to clear all prohibited symbols and print aggregated data about the all the countries ordered alphabetically in format:
{Country} -> {number of cities}
And top 3 cities with biggest population ordered in descending order by population in format:
{city} -> {population}
In case of repeating towns, count the last seen population for each town (ignore the others).
Count all towns in each country. In case of repeating towns for certain country, count the duplicated towns.

Input
•	The input data should be read from the console.
•	It consists of a variable number of lines and ends when the command "stop" is received.
•	The input data will always be valid and in the format described. There is no need to check it explicitly.

Output
•	The output should be printed on the console.
•	Print the aggregated data for each country and city in the described format.

Constraints
•	The name of the city, country and the population will be separated from each other by a back slash ('\').
•	The number of input lines will be in the range [2 … 50].
•	The population count of each city will be an integer in the range [0 … 263 − 1].
•	Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class PopulationAggregation
{
    const string countryRegexPattern = @"(?<country>[A-Z][a-z0-9@#$&]+)\\(?<city>[a-z][a-z0-9@#$&]+)\\(?<population>\d+)";
    const string cityRegexPattern = @"(?<city>[a-z][a-zA-Z0-9@#$&]+)\\(?<country>[A-Z][a-zA-Z0-9@#$&]+)\\(?<population>\d+)";
    const string DUPLICATED_CITIES_KEY = "duplicatedCitiesCount";
    static void Main()
    {
        var populationDict = FillDictionary();

        // print results
        foreach (string country in populationDict.Keys)
        {
            //                               |Total cities for the country                                                          | 
            //                               | ( - 1 so as to not count the entry that holds the duplicated cities count            |
            Console.WriteLine($"{country} -> {populationDict[country].Keys.Count - 1 + populationDict[country][DUPLICATED_CITIES_KEY]}");
        }

        var topThreeCities = populationDict
                                    .SelectMany(dict => dict.Value)
                                    .Where(x => x.Key != DUPLICATED_CITIES_KEY)
                                    .ToDictionary(pair => pair.Key, pair => pair.Value)
                                    .OrderByDescending(x => x.Value)
                                    .Take(3)
                                    .ToDictionary(pair => pair.Key, pair => pair.Value);

        foreach (var city in topThreeCities)
        {
            Console.WriteLine($"{city.Key} -> {city.Value}");
        }
    }

    static SortedDictionary<string, Dictionary<string, long>> FillDictionary()
    {
        /*
         Fill the dictionary as expecting, while keeping an additional key-pair value for each country containing the count of
         cities that have been overwritten (duplicated).
         */
        SortedDictionary<string, Dictionary<string, long>> populationDict = new SortedDictionary<string, Dictionary<string, long>>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "stop")
                break;

            string city = "";
            string country = "";
            long population = 0;

            if (Regex.IsMatch(input, countryRegexPattern))
            {
                // Country/city/pop
                Match match = Regex.Match(input, countryRegexPattern);
                country = Regex.Replace(match.Groups["country"].ToString(), @"[0-9@#$&]", "");
                city = Regex.Replace(match.Groups["city"].ToString(), @"[0-9@#$&]", "");
                population = long.Parse(match.Groups["population"].ToString());
            }
            else if (Regex.IsMatch(input, cityRegexPattern))
            {
                // city/country/pop
                Match match = Regex.Match(input, cityRegexPattern);
                country = Regex.Replace(match.Groups["country"].ToString(), @"[0-9@#$&]", "");
                city = Regex.Replace(match.Groups["city"].ToString(), @"[0-9@#$&]", "");
                population = long.Parse(match.Groups["population"].ToString());
            }

            if (!populationDict.ContainsKey(country))
            {
                populationDict[country] = new Dictionary<string, long>();
                populationDict[country][DUPLICATED_CITIES_KEY] = 0;
            }

            if (populationDict[country].ContainsKey(city))
                populationDict[country][DUPLICATED_CITIES_KEY] += 1;

            populationDict[country][city] = population;
        }

        return populationDict;
    }
}
