/*
 Read an array of 4*k integers, fold it like shown below, 
 and print the sum of the upper and lower two rows (each holding 2 * k integers):
 */
using System;
using System.Collections.Generic;
using System.Linq;

class FoldAndSum
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int k = arr.Length / 4;
        // break the array into three pieces
        int[] leftPart = new int[k];
        Array.Copy(arr, 0, leftPart, 0, k);

        int[] middlePart = new int[k * 2];
        Array.Copy(arr, k, middlePart, 0, k * 2);

        int[] rightPart = new int[k];
        Array.Copy(arr, k * 3, rightPart, 0, k);

        // flip the arrays
        Array.Reverse(leftPart);
        Array.Reverse(rightPart);

        // combine those arrays
        int[] leftAndRight = new int[k * 2];
        Array.Copy(leftPart, leftAndRight, leftPart.Length);
        Array.Copy(rightPart, 0, leftAndRight, leftPart.Length, rightPart.Length);

        // sum the combined array with the middlepart
        for (int i = 0; i < middlePart.Length; i++)
        {
            middlePart[i] += leftAndRight[i];
        }

        Console.WriteLine(string.Join(" ", middlePart));
    }
}
