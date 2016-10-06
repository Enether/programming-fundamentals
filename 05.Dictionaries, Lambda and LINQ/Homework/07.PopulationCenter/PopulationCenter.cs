/*
 So many people! It’s hard to count them all. But that’s your job as a statistician. You get raw data for a given city and you need to aggregate it. 
On each input line you’ll be given data in format: "city|country|population". There will be no redundant whitespaces anywhere in the input. Aggregate the data by country and by city and print it on the console. For each country, print its total population and on separate lines the data for each of its cities. Countries should be ordered by their total population in descending order and within each country, the cities should be ordered by the same criterion. If two countries/cities have the same population, keep them in the order in which they were entered. Check out the examples; follow the output format strictly!
Input
The input data should be read from the console.
It consists of a variable number of lines and ends when the command "report" is received.
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
The output should be printed on the console.
Print the aggregated data for each country and city in the format shown below.
Constraints
The name of the city, country and the population count will be separated from each other by a pipe ('|').
The number of input lines will be in the range [2 … 50].
A city-country pair will not be repeated.
The population count of each city will be an integer in the range [0 … 2 000 000 000].
Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.
 */
using System;
using System.Collections.Generic;
using System.Linq;

class PopulationCenter
{
    static void Main()
    {
        var populationCounter = ReadInputIntoDictionary();

        // ORDER BY DESCENDNG CITY SIZE
        var orderedByCity = new Dictionary<string, Dictionary<string, long>>(); 
        foreach (var country in populationCounter.Keys)
        {
            orderedByCity[country] = populationCounter[country].OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        // ORDER BY COUNTRY SIZE
        var orderedByCountry = orderedByCity.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, x => x.Value);

        PrintOutput(orderedByCountry); // Print Output   
    }

    private static void PrintOutput(Dictionary<string, Dictionary<string, long>> populationCounter)
    {
        foreach (var country in populationCounter.Keys)
        {
            Console.WriteLine($"{country} (total population: {populationCounter[country].Sum(x => x.Value)})");
            foreach (var city in populationCounter[country].Keys)
            {
                Console.WriteLine($"=>{city}: {populationCounter[country][city]}");
            }
        }
    }

    private static Dictionary<string, Dictionary<string, long>> ReadInputIntoDictionary()
    {
        var populationCounter = new Dictionary<string, Dictionary<string, long>>();
        string input = "";
        while (true)
        {
            input = Console.ReadLine();
            if (input == "report")
                break;

            string[] inputInfo = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string city = inputInfo[0];
            string country = inputInfo[1];
            long population = long.Parse(inputInfo[2]);

            if (!populationCounter.ContainsKey(country))
                populationCounter[country] = new Dictionary<string, long>();
            if (!populationCounter[country].ContainsKey(city))
                populationCounter[country][city] = 0L;

            populationCounter[country][city] += population;
        }

        return populationCounter;
    }
}
