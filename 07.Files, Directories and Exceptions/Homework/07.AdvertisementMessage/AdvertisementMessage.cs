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
using System.IO;
using System.Text;

class AdvertisementMessage
{
    const string INPUT_FILE_PATH = "../../input/input.txt";
    const string OUTPUT_DIR_PATH = "../../output/";

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
        Directory.CreateDirectory(OUTPUT_DIR_PATH);
        StringBuilder output = new StringBuilder();
        Random rnd = new Random();

        int n = int.Parse(File.ReadAllText(INPUT_FILE_PATH));

        for (int i = 0; i < n; i++)
        {
            string phrase = phrases[rnd.Next(0, phrases.Length)];
            string event_ = events[rnd.Next(0, events.Length)];
            string author = authors[rnd.Next(0, authors.Length)];
            string city = cities[rnd.Next(0, cities.Length)];

            output.AppendLine($"{phrase} {event_} {author} - {city}.");
        }

        string output_file_path = OUTPUT_DIR_PATH + "output.txt";
        File.CreateText(output_file_path).Close();
        File.WriteAllText(output_file_path, output.ToString());
    }
}