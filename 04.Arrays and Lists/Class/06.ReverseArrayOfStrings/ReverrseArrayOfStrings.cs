/*
 Write a program to read an array of strings, reverse it and print its elements. The input consists of a sequence of
space separated strings. Print the output on a single line (space separated).
 */
using System;

class ReverrseArrayOfStrings
{
    static void Main()
    {
        string[] arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // reverse array
        for (int i = 0; i < arr.Length/2; i++)
        {
            int oppositeIndex = (arr.Length-1) - i;
            string tempValue = arr[i];
            arr[i] = arr[oppositeIndex];
            arr[oppositeIndex] = tempValue;
        }

        Console.WriteLine(string.Join(" ", arr));
    }
}

