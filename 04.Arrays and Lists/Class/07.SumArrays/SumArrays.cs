/*
 Write a program that reads two arrays of integers and sums them. When the arrays are not of the same size,
duplicate the smaller array a few times.
 */
using System;
using System.Linq;

class SumArrays
{
    static void Main()
    {
        int[] firstArr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[] secondArr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int maxLength = Math.Max(firstArr.Length, secondArr.Length);
        int[] summedArray = new int[maxLength];
        for (int i = 0; i < summedArray.Length; i++)
        {
            summedArray[i] = firstArr[i % firstArr.Length] + secondArr[i % secondArr.Length];
        }

        Console.WriteLine(string.Join(" ", summedArray));
    }
}

