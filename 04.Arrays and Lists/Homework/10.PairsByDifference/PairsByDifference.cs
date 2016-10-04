// Write a program that count the number of pairs in given array which difference is equal to given number.
using System;
using System.Linq;

class PairsByDifference
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int difference = int.Parse(Console.ReadLine());
        int pairs = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i; j < numbers.Length; j++)
            {
                if (Math.Abs(numbers[i] - numbers[j]) == difference)
                    pairs++;
            }
        }

        Console.WriteLine(pairs);
    }
}

