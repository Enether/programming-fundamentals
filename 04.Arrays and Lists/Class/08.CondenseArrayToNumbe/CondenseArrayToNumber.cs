/*
 Write a program to read an array of integers and condense them by summing adjacent couples of elements until a
single integer is obtained. For example, if we have 3 elements {2, 10, 3}, we sum the first two and the second two
elements and obtain {2+10, 10+3} = {12, 13}, then we sum again all adjacent elements and obtain {12+13} = {25}.
 */
using System;
using System.Linq;

class CondenseArrayToNumber
{
    static void Main()
    {
        Console.WriteLine(string.Join(" ", SumArray(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())));
    }

    static int[] SumArray(int[] arr)
    {
        // function uses recursion to sum the elements of an array until we reach an array with 1 element in it
        if (arr.Length == 1)
            return arr;

        int[] newArr = new int[arr.Length - 1];

        for (int i = 0; i < arr.Length-1; i++)
        {
            newArr[i] = arr[i] + arr[i+1];
        }

        return SumArray(newArr);
    }
}

