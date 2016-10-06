using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DragonArmy
{
    const int DRAGON_TYPE_INDEX = 0;
    const int DRAGON_NAME_INDEX = 1;
    const int DRAGON_DAMAGE_INDEX = 2;
    const int DRAGON_HEALTH_INDEX = 3;
    const int DRAGON_ARMOR_INDEX = 4;

    const int DEFAULT_HEALTH = 250;
    const int DEFAULT_DAMAGE = 45;
    const int DEFAULT_ARMOR = 10;
     
    static void Main()
    {
        Dictionary<string, Dictionary<string, Dictionary<string, int>>> dragons = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();

        int linesCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < linesCount; i++)
        {
            var dragonInfo = ReadInputLine(Console.ReadLine());
            string dragonType = dragonInfo.Item1;
            string dragonName = dragonInfo.Item2;
            int dragonDamage = dragonInfo.Item3;
            int dragonHealth = dragonInfo.Item4;
            int dragonArmor = dragonInfo.Item5;

            if (!dragons.ContainsKey(dragonType))
                dragons[dragonType] = new Dictionary<string, Dictionary<string, int>>();
            if (!dragons[dragonType].ContainsKey(dragonName))
                dragons[dragonType][dragonName] = new Dictionary<string, int>();

            dragons[dragonType][dragonName] = new Dictionary<string, int>() { { "damage", dragonDamage }, { "health", dragonHealth }, { "armor", dragonArmor } };
        }

        PrintOutput(dragons);
    }
    static void PrintOutput(Dictionary<string, Dictionary<string, Dictionary<string, int>>> dragons)
    {
        foreach (var dragonType in dragons.Keys)
        {
            double averageDamage = dragons[dragonType].Select(x => x.Value["damage"]).Average();
            double averageHealth = dragons[dragonType].Select(x => x.Value["health"]).Average();
            double averageArmor = dragons[dragonType].Select(x => x.Value["armor"]).Average();

            var alphabeticallySortedDragons = dragons[dragonType].OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{dragonType}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");
            foreach (var pair in alphabeticallySortedDragons)
            {
                string dragonName = pair.Key;
                int dragonDamage = pair.Value["damage"];
                int dragonHealth = pair.Value["health"];
                int dragonArmor = pair.Value["armor"];

                Console.WriteLine($"-{dragonName} -> damage: {dragonDamage}, health: {dragonHealth}, armor: {dragonArmor}");
            }
        }
    }
    
    static Tuple<string, string, int, int, int> ReadInputLine(string line)
    {
        string[] lineInfo = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string dragonType = lineInfo[DRAGON_TYPE_INDEX];
        string dragonName = lineInfo[DRAGON_NAME_INDEX];
        int dragonDamage = lineInfo[DRAGON_DAMAGE_INDEX] != null ? int.Parse(lineInfo[DRAGON_DAMAGE_INDEX]) : DEFAULT_DAMAGE;
        int dragonHealth = lineInfo[DRAGON_HEALTH_INDEX] != null ? int.Parse(lineInfo[DRAGON_HEALTH_INDEX]) : DEFAULT_HEALTH;
        int dragonArmor = lineInfo[DRAGON_ARMOR_INDEX] != null ? int.Parse(lineInfo[DRAGON_ARMOR_INDEX]) : DEFAULT_ARMOR;

        return new Tuple<string, string, int, int, int>(dragonType, dragonName, dragonDamage, dragonHealth, dragonArmor);
    }
}

