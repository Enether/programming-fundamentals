/*
 Andrey is the guy who gives us food and drinks at the game bar. He likes to play billiard. 
 Since you are nice guy you want to help him play more of his favorite game.
 You decide to create a program which will help him to take orders faster and generate billing information. 

First you will receive an integer - the amount of entities with prices (separated by "-"). 
Then you will receive a list of client. For every consumer you will receive what to buy and how much.
When you receive a command: "end of clients" you should display information about every client described below.
After that say how much total money were spent while Andrey was playing billiard.

Constraints
If an entity is added more than once you should override the previous price.
If buyer tries to buy an entity that is not existing - you should ignore that line.
Buyers should be ordered by name ascending. 
All floating point digits must be rounded to 2 digits after decimal separator.
In the end of every buyer his bill should be summed.


Quantity is an integer. Price – floating point
 */
using System;
using System.Collections.Generic;
using System.Linq;


class AndreyAndBilliard
{
    static void Main()
    {
        int productsCount = int.Parse(Console.ReadLine());
        Dictionary<string, decimal> products = new Dictionary<string, decimal>();
        for (int i = 0; i < productsCount; i++)
        {
            string[] productInfo = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            string productName = productInfo[0];
            decimal productPrice = decimal.Parse(productInfo[1]);
            products[productName] = productPrice;
        }


        // dictionary of clients and a dictionary holding the client's TOTAL BILL and the count of products he's purchased i.e "Coca-Cola": 2, "Beer": 1
        SortedDictionary<string, Dictionary<string, decimal>> clients = GetClientInfo(products);

        PrintResults(clients, products);
    }
    public static SortedDictionary<string, Dictionary<string, decimal>> GetClientInfo(Dictionary<string, decimal> products)
    {
        SortedDictionary<string, Dictionary<string, decimal>> clients = new SortedDictionary<string, Dictionary<string, decimal>>();

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "end of clients")
                break;

            string[] clientInfo = command.Split(new char[] { '-', ',' /* TODO: Maybe split separately, because we can have , in the usenrame?!*/}, StringSplitOptions.RemoveEmptyEntries);
            string clientName = clientInfo[0];
            string productName = clientInfo[1];
            if (!products.ContainsKey(productName))  // skip the input if such a product is not in stock
                continue;

            if (!clients.ContainsKey(clientName))
                clients[clientName] = new Dictionary<string, decimal>();
            if (!clients[clientName].ContainsKey(productName))
                clients[clientName][productName] = 0M;
            int buyCount = int.Parse(clientInfo[2]);

            // increment the count of the certain product that this client has purchased
            clients[clientName][productName] += buyCount;
        }

        return clients;
    }

    public static void PrintResults(SortedDictionary<string, Dictionary<string, decimal>> clients, Dictionary<string, decimal> products)
    {
        // DISCLAIMER: Yes, the bills can obviously be stored and arrived at in an easier way, but I want to practice my LINQ in
        // nested dictionaries :)

        // print results
        foreach (var client in clients)
        {
            Console.WriteLine(client.Key);
            // print the client's purchases
            foreach (var productPurchase in client.Value.Keys)
            {
                Console.WriteLine($"-- {productPurchase} - {client.Value[productPurchase]}");
            }
            // print the client's bill
            Console.WriteLine($"Bill: {client.Value.Sum(x => x.Value * products[x.Key]):F2}");
        }
        // print the total bill
        Console.WriteLine($"Total bill: {clients.Sum(x => x.Value.Sum(y => y.Value * products[y.Key])):F2}");
    }
}
