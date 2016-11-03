/*
I had a number (with distinct digits) written on a sheet of paper.
My cat (Sid) ate it (she loves to eat paper)!
Now I can only remember that some digits were before or after
others. My memory is good and the order of digits I remember
are always correct.
Please help me find the smallest possible number that
corresponds to the digits order I remember.
The number was valid integer number with no leading zeroes.
There is always a possible solution.

Input
The input data should be read from the console.
On the first line there will be the number N.
On each of the next N lines there will be a string in the format “X is before Y” or “X is after Y”. X and Y
will be valid digits (‘0’ – ‘9’).
The input data will always be valid and in the format described. There is no need to check it explicitly.

Output
The output data should be printed on the console.
On the only output line write the smallest possible number that corresponds to the rules described in
the input.

Constraints
 N will be between 1 and 20.
 Allowed working time for your program: 0.05 seconds. Allowed memory: 16 MB
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BadCats
{
    static void Main()
    {
        // dictionary that holds a number and a hashset of the numbers before it
        // ex: 3: (1,2)
        Dictionary<int, HashSet<int>> numsBefore = ReadInput();
        string sequence = BuildSequence(numsBefore);
        
        Console.WriteLine(sequence);
    }
    public static string BuildSequence(Dictionary<int, HashSet<int>> numsBefore)
    {
        StringBuilder resultSB = new StringBuilder();

        // algorithm is the following:
        // 1. We start of by getting the SMALLEST number with THE LEAST (must be 0) numbers before it
        // for that we order them by their count ascending and then by their value ascending. 
        numsBefore = numsBefore.OrderBy(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        // At position 0 we should have the smallest number with 0 numbers before it
        // but we don't want to take 0, because a sequence and a valid number cannot start with 0.
        int firstNum = numsBefore.SkipWhile(x => x.Key == 0).Take(1).ToArray()[0].Key;
        numsBefore.Remove(firstNum);  // we remove the number from the dictionary because we don't need it anymore (and don't care what's before it)

        // this method removes the firstNum from the hashsets of every other number in the dict
        // because the number has been used and it's obvious that they'll be after it.
        RemoveDuplicatesInHashSets(numsBefore, firstNum);

        resultSB.Append(firstNum.ToString());  // we append it to the result

        // 2. We continue going through the dictionary, always getting a number that either has no numbers before it
        // or one that has our current number before it, prioritizing the smallest number
        var currentNum = firstNum;
        while (numsBefore.Keys.Count > 0)
        {
            // Get a valid number to put in the seq 
            currentNum = numsBefore.Where(x => x.Value.Contains(currentNum) || x.Value.Count == 0)  // where it either has the currentnum before it or no numbers before it
                                .OrderBy(x => x.Key)  // ordered by their value ascending
                                .Take(1)  // meaning the first one we take will be the smallest
                                .ToArray()[0].Key;
            numsBefore.Remove(currentNum);  // we remove the number from the dictionary because we don't need it anymore (and don't care what's before it)
            RemoveDuplicatesInHashSets(numsBefore, currentNum);  // remove said number from the hashsets of all other numbers

            resultSB.Append(currentNum);  // add it to the result
        }

        return resultSB.ToString();
    }

    public static Dictionary<int, HashSet<int>> ReadInput()
    {
        // read the input and return a dictionary that has as a key a number and as a value all the numbers that come before it
        int commandsCount = int.Parse(Console.ReadLine());
        Dictionary<int, HashSet<int>> numsBefore = new Dictionary<int, HashSet<int>>();

        // Read the commands and fill the dict
        for (int i = 0; i < commandsCount; i++)
        {
            // ex: ["1", "is" "after" "5"] OR ["1", "is" "before" "5"]
            string[] inputInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int firstNum = int.Parse(inputInfo[0]);
            int lastNum = int.Parse(inputInfo[inputInfo.Length - 1]);

            if (inputInfo.Contains("after"))
            {
                // ex: 4 is after 1 -> this means we have to save them like 1 -> 4
                // so 1 is the first number and 4 is the second
                // swap them
                var firstNumTemp = firstNum;
                firstNum = lastNum;
                lastNum = firstNumTemp;
            }

            if (!numsBefore.ContainsKey(lastNum))  // init the HashSet if it doesn't exist
                numsBefore[lastNum] = new HashSet<int>();
            if (!numsBefore.ContainsKey(firstNum)) // init the HashSet if it doesn't exist, because we know that this number is going to be in the sequence
                numsBefore[firstNum] = new HashSet<int>();

            // add that the second number has firstNum behind it
            numsBefore[lastNum].Add(firstNum);
        }

        return numsBefore;
    }

    public static void RemoveDuplicatesInHashSets(Dictionary<int, HashSet<int>> numsBefore, int currentNum)
    {
        // we create a deep copy of the dictionary to iterate over, because you cannot change a collection while for-eaching over it
        var newDict = DeepCopyDict(numsBefore);
        foreach (var pair in newDict)
        {
            if (pair.Value.Contains(currentNum))
                numsBefore[pair.Key].Remove(currentNum);  // we remove the number from the hashset of the respective key
        }
            
    }

    public static Dictionary<int, HashSet<int>> DeepCopyDict(Dictionary<int, HashSet<int>> originalDictionary)
    {
        /* Create a deep copy of a dictionary */
        var newDict = new Dictionary<int, HashSet<int>>();

        foreach (var pair in originalDictionary)
        {
            // we create a deep copy of each hashset. I'm actually not sure if this is needed, but it doesn't hurt eh
            newDict[pair.Key] = DeepCopyHashSet(pair.Value);
        }

        return newDict;
    }

    public static HashSet<int> DeepCopyHashSet(HashSet<int> originalHashSet)
    {
        /* Create a deep copy of a HashSet */
        var deepCopyHashSet = new HashSet<int>();

        foreach (var element in originalHashSet)
        {
            deepCopyHashSet.Add(element);
        }

        return deepCopyHashSet;
    }
}
