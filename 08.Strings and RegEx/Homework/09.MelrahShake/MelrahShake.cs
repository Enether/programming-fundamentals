using System;

class MelrahShake
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = Console.ReadLine();

        while(input.IndexOf(pattern) != -1)
        {
            int firstOccurence = input.IndexOf(pattern);
            int lastOccurence = input.LastIndexOf(pattern);

            if (firstOccurence == lastOccurence || pattern == null)
                break;

            input = input.Remove(firstOccurence, pattern.Length);
            // update the last occurence
            lastOccurence = input.LastIndexOf(pattern);
            input = input.Remove(lastOccurence, pattern.Length);

            Console.WriteLine("Shaked it.");

            // update the pattern
            int patternPos = pattern.Length / 2;
            if (pattern.Length <= 1) // we're removing the pattern altogether
                pattern = null;
            else
                pattern = pattern.Remove(pattern.Length / 2, 1);
        }

        Console.WriteLine("No shake.");
        Console.WriteLine(input);
    }
}
