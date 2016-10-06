/*
 You’ve beaten all the content and the last thing left to accomplish is own a legendary item. However, it’s a tedious process and requires quite a bit of farming. Anyway, you are not too pretentious – any legendary will do. The possible items are:
Shadowmourne – requires 250 Shards;
Valanyr – requires 250 Fragments;
Dragonwrath – requires 250 Motes;
Shards, Fragments and Motes are the key materials, all else is junk. You will be given lines of input, such as 
Then, print the remaining shards, fragments, motes, ordered by quantity in descending order, each on a new line.
Finally, print the collected junk items, in alphabetical order.
 */
using System;
using System.Collections.Generic;
using System.Linq;

class LegendaryFarming
{
    public static readonly string[] KEY_MATERIALS = { "motes", "shards", "fragments" };
    public static readonly Dictionary<string, string> MATERIAL_LEGENDARY_OUTPUT = new Dictionary<string, string>()
    { { "shards", "Shadowmourne" }, { "fragments", "Valanyr" }, { "motes", "Dragonwrath" } };

    static void Main()
    {
        bool end = false;
        Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
        Dictionary<string, int> junk = new Dictionary<string, int>();

        while(!end)  // loop until we collect the necessary materials
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < input.Length-1; i+=2)
            {
                // input array is like ["3", "motes", "4", "shards"], meaning we iterate through 2 at once, because they're a pair
                int amount = int.Parse(input[i]);
                string material = input[i + 1].ToLower();

                if(KEY_MATERIALS.Contains(material))
                {
                    // material is valuable
                    if (!keyMaterials.ContainsKey(material))
                        keyMaterials[material] = 0;
                    keyMaterials[material] += amount;
                    // Check if it's over 250
                    if (keyMaterials[material] >= 250)
                    {
                        // we've collected enough for a legendary
                        keyMaterials[material] -= 250;
                        PrintOutput(keyMaterials, junk, material);
                        end = true;
                        break;
                    }
                }
                else
                {
                    // material is junk
                    if (!junk.ContainsKey(material))
                        junk[material] = 0;
                    junk[material] += amount;
                }
            }
        }
    }
    public static void PrintOutput(Dictionary<string, int> keyMaterials, Dictionary<string, int> junk, string material)
    {
        // Print which legendary we've obtained
        Console.WriteLine($"{MATERIAL_LEGENDARY_OUTPUT[material]} obtained!");

        // check if we're missing a key material
        foreach (var mat in MATERIAL_LEGENDARY_OUTPUT.Keys)
        {
            if (!keyMaterials.ContainsKey(mat))
                keyMaterials[mat] = 0;
        }

        // Order key materials in descending order and print them
        var descendingMaterials = keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        foreach (var pair in descendingMaterials)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        // Order junk alphabetically and print them
        var alphabeticallyOrderedJunk = junk.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        foreach (var pair in alphabeticallyOrderedJunk)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}
