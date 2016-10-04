/*
 To “rotate an array on the right” means to move its last element first: {1, 2, 3}  {3, 1, 2}.
Write a program to read an array of n integers (space separated on a single line) and an integer k, 
rotate the array right k times and sum the obtained arrays after each rotation as shown below.
 */
using System;
using System.Linq;

class RotateAndSum
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int rotateCount = int.Parse(Console.ReadLine());
        int[] summedArray = new int[arr.Length];
        for (int i = 0; i < rotateCount; i++)
        {
            RotateArray(arr);
            SumArray(summedArray, arr);
        }
        Console.WriteLine(string.Join(" ", summedArray));
    }

    static void SumArray(int[] summedArray, int[] otherArray)
    {
        /* given two arrays of equal length, add each element of otherArray to the corresponding element in summedArray*/
        for (int i = 0; i < otherArray.Length; i++)
        {
            summedArray[i] += otherArray[i];
        }
    }

    static void RotateArray(int[] arr)
    {
        int lastElement = arr[arr.Length - 1];

        for (int i = arr.Length-1; i > 0; i--)
        {
            arr[i] = arr[i-1];
        }
        arr[0] = lastElement;
    }
}

