/*
Alex is having hard time ordering coffee recently, because the new members of the team drink too much coffee. You need to help her. At the beginning of the input, you will receive the keywords for the week. Those keywords are delimiters, that Alex will use for the rest of the input. Alex will tell you what coffee, everyone drinks. She should also tell you the quantity for each coffee type, but she might forget, so you will have to assume that there in none left.
After you receive all of the information you need, you must check how much coffee you have, and if there in none left from certain type, you must tell Alex, to order more. Then you must monitor how much coffee each member of the team drinks. If a coffee type ends, you must tell Alex to order more. After the end of the week, you need to print reports. The first report should print how much coffee is left. It should be in the following format: 
“coffeeType count”
This report must be sorted by the count for each coffee type in descending order.
The second report should tell us which team members have some coffee left, and what is the type of the coffee. The report must be sorted by coffee type lexicographically. If there are team members that drink the same type of coffee, their names must be sorted lexicographically in descending order.

Input
On the first line you are given the two delimiters separated by (space).
On the next lines, until you receive “end of info” you are given one of the following lines:
“PersonName[firstDelimiter]CoffeeType”
“CoffeeType[secondDelimiter]Quantity”
On the next lines, until you receive “end of week” you will receive how much coffee everyone drinks in the following format:
“PersonName count”

Output
When you run out of a coffee type you must print:
“Out of {coffeeType}”
After you receive the command “end of week” you must print the following reports:
“Coffee Left:”
“{coffeeType} {quantity}” – All coffee types that have more than 0 quantity, sorted in descending order by quantity
“For:”
“{personName} {coffeeType}” – For each of the coffeeTypes from the previous report, print the team members drinking each type of coffee. This report must be sorted in lexicographical order  
for each coffee type. If there is more than 1 team member drinking the same coffeeType, order them alphabetically in descending order.

Constraints
The two delimiters will always be different strings
The Coffee Quantity will be valid integer in the range [0...231]
*/
using System;
using System.Collections.Generic;
using System.Linq;

class SoftUniCoffeeSupplies
{
    static void Main(string[] args)
    {
        string[] delimiters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string personCoffeePreferenceDelimiter = delimiters[0];
        string coffeeAmountDelimiter = delimiters[1];
        Dictionary<string, string> personCoffeePreference = new Dictionary<string, string>(); // dictionary holding the name of the person and the type of coffee he likes
        Dictionary<string, int> coffeeInStock = new Dictionary<string, int>(); // dictionary holding the type of the coffee and amount we have left
        /*
        On the next lines, until you receive “end of info” you are given one of the following lines:
        “PersonName[firstDelimiter]CoffeeType”
        “CoffeeType[secondDelimiter]Quantity”   
        */
        while (true)
        {
            string info = Console.ReadLine();
            if (info == "end of info")
                break;

            string[] personPreference = info.Split(new string[] { personCoffeePreferenceDelimiter }, StringSplitOptions.RemoveEmptyEntries);
            string[] coffeeQuantity = info.Split(new string[] { coffeeAmountDelimiter }, StringSplitOptions.RemoveEmptyEntries);

            if (personPreference.Length > 1)
            {
                string personName = personPreference[0];
                string coffeeType = personPreference[1];

                personCoffeePreference[personName] = coffeeType;

                if (!coffeeInStock.ContainsKey(coffeeType))
                    coffeeInStock[coffeeType] = 0;
            }
            else
            {
                string coffee = coffeeQuantity[0];
                int quantity = int.Parse(coffeeQuantity[1]);

                if (!coffeeInStock.ContainsKey(coffee))
                    coffeeInStock[coffee] = 0;
                coffeeInStock[coffee] += quantity;
            }
        }

        // print coffees that we do not have in stock right out th ebat
        var outOfCoffee = coffeeInStock.Where(x => x.Value <= 0).Select(x => x.Key).ToList();
        foreach (var item in outOfCoffee)
        {
            Console.WriteLine($"Out of {item}");
        }

        // start taking orders
        while (true)
        {
            string info = Console.ReadLine();
            if (info == "end of week")
                break;

            string[] personOrder = info.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string personName = personOrder[0];
            int coffeeOrdered = int.Parse(personOrder[1]);
            string coffeeType = personCoffeePreference[personName];

            if (!coffeeInStock.ContainsKey(coffeeType))
                coffeeInStock[coffeeType] = 0;

            // decrease the stock because coffee has been bought
            coffeeInStock[coffeeType] -= coffeeOrdered;

            if (coffeeInStock[coffeeType] <= 0)
                Console.WriteLine($"Out of {coffeeType}");
        }

        Console.WriteLine("Coffee Left:");
        var coffeeLeft = coffeeInStock.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        foreach (var coffeePair in coffeeLeft)
        {
            Console.WriteLine($"{coffeePair.Key} {coffeePair.Value}");
        }

        Console.WriteLine("For:");
        var peopleWhoHaveCoffeeLeft = personCoffeePreference.Where(x => coffeeLeft.Keys.Contains(x.Value)).Select(x => x).ToDictionary(x => x.Key, x => x.Value);
        peopleWhoHaveCoffeeLeft = peopleWhoHaveCoffeeLeft.OrderBy(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
        foreach (var personWhoHasCoffee in peopleWhoHaveCoffeeLeft)
        {
            Console.WriteLine($"{personWhoHasCoffee.Key} {personWhoHasCoffee.Value}");
        }
    }
}

