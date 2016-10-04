/*
 Write a program that finds the longest sequence of equal elements in an array of integers.
 If several longest sequences exist, print the leftmost one
 */
using System;
using System.Linq;

class MaxSequenceOfEqualElements
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int maxCount = -1;
        int maxCountNum = -1;

        for (int i = 0; i < numbers.Length; i++)
        {
            int currentNum = numbers[i];
            int currentCount = 1;

            for (int j = i+1; j < numbers.Length; j++)
            {
                if (numbers[j] != currentNum)
                    break;
                currentCount++;
                i = j;
            }
            if(currentCount > maxCount)
            {
                maxCount = currentCount;
                maxCountNum = currentNum;
            }
        }
        
        Console.WriteLine(string.Join(" ", Enumerable.Repeat(maxCountNum, maxCount)));   
    }
}
