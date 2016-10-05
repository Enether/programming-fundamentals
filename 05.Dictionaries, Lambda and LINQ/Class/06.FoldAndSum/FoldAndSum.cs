/*
 Read an array of 4*k integers, fold it like shown below, and print the sum of the upper and lower rows (2*k integers):
 */
using System;
using System.Linq;

class FoldAndSum
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int k = numbers.Length / 4;

        int[] leftPart = numbers.Take(k).Reverse().ToArray();
        int[] rightPart = numbers.Skip(k * 3).Take(k).Reverse().ToArray();

        int[] middlePart = numbers.Skip(k).Take(k * 2).ToArray();
        int[] leftAndRightPart = leftPart.Concat(rightPart).ToArray();

        // sum the two arrays
        int[] summedArr = middlePart.Select((x, index) => x + leftAndRightPart[index]).ToArray();
        Console.WriteLine(string.Join(" ", summedArr));
    }
}
