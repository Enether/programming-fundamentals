/*
 Write a program to read an array of integers and find all triples of elements a, b and c, such that a + b == c (where a

stays left from b). Print “No” if no such triples exist.
 */
using System;
using System.Linq;

class TripleSum
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        bool foundTripleSum = false;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i+1; j < arr.Length; j++)
            {
                int doubleSum = arr[i] + arr[j];  // arr[i] + each other element in the array, separately

                if (arr.Contains(doubleSum))
                {
                    // found a triple sum
                    foundTripleSum = true;
                    Console.WriteLine($"{arr[i]} + {arr[j]} == {doubleSum}");
                }
            }
        }

        if (!foundTripleSum)
            Console.WriteLine("No");
    }
}

