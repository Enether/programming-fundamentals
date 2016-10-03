/*
 Write a program to read an array of integers, reverse it and print its elements. The input consists of a number n

(the number of elements) + n integers, each as a separate line. Print the output on a single line (space separated).
 */
using System;

class ReverseArray
{
    static void Main()
    {
        int integersCount = int.Parse(Console.ReadLine());
        int[] arr = new int[integersCount];
        // read the array
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        for (int i = arr.Length-1; i >= 0; i--)
        {
            Console.Write("{0} ", arr[i]);
        }
    }
}
