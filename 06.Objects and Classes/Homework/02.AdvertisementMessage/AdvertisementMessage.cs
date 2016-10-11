/*
 Write a program that generate random fake advertisement message to extol some product. The messages must consist of 4 parts: laudatory phrase + event + author + city. Use the following predefined parts:
Phrases – {“Excellent product.”, “Such a great product.”, “I always use that product.”,
“Best product of its category.”, “Exceptional product.”, “I can’t live without this product.”}
Events – {“Now I feel good.”, “I have succeeded with this product.”, 
“Makes miracles. I am happy of the results!”, “I cannot believe but now I feel awesome.”, 
”Try it yourself, I am very satisfied.”, “I feel great!”}
Author – {“Diana”, “Petya”, “Stella”, “Elena”, “Katya”, “Iva”, “Annie”, “Eva”}
Cities – {“Burgas”, “Sofia”, “Plovdiv”, “Varna”, “Ruse”}
The format of the output message is: {phrase} {event} {author} – {city}.
 */
using System;

class AdvertisementMessage
{
    static readonly string[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.",
"Best product of its category.", "Exceptional product.", "I can’t live without this product."};

    static readonly string[] events = new string[]
    {
        "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
        "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
    };

    static readonly string[] authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
    static readonly string[] cities = new string[] { "Burgas", "Sofia", "Plovdid", "Varna", "Ruse" };
    static void Main()
    {
        Random rnd = new Random();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string phrase = phrases[rnd.Next(0, phrases.Length)];
            string event_ = events[rnd.Next(0, events.Length)];
            string author = authors[rnd.Next(0, authors.Length)];
            string city = cities[rnd.Next(0, cities.Length)];

            Console.WriteLine($"{phrase} {event_} {author} - {city}.");
        }
    }
}
