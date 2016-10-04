/*
 Write a program that finds the longest increasing subsequence in an array of integers. The longest increasing subsequence is a portion of the array (subsequence) that is strongly increasing and has the longest possible length.
 If several such subsequences exist, find the left most of them
 */
using System;
using System.Linq;

class MaxSeqIncreasingElements
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int maxCount = -1;
        int maxCountStartIndex = -1;

        for (int i = 0; i < numbers.Length; i++)
        {
            int currentIndex = i;
            int currentCount = 1;

            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] <= numbers[j-1])
                    break;
                currentCount++;
                i = j;
            }
            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                maxCountStartIndex = currentIndex;
            }
        }

        for (int i = maxCountStartIndex; i < maxCountStartIndex + maxCount; i++)
        {
            Console.Write(numbers[i] + " ");
        }
    }
}

