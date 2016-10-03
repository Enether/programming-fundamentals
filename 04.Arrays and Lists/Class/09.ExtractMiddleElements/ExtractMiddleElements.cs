/*
 Write a method to extract the middle 1, 2 or 3 elements from array of n integers and print them.

 n = 1 -> 1 element

 even n -> 2 elements

 odd n -> 3 elements

Create a program that reads an array of integers (space separated values) and prints the middle elements in the

format shown in the examples.
 */
using System;
using System.Linq;

class ExtractMiddleElements
{
    static void Main()
    {
        int[] inputArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int n = inputArr.Length;

        if (n == 1)
            Console.WriteLine($"{{ {inputArr[0]} }}");
        else if (n % 2 == 0)
        {
            // even, print 2 numbers
            int firstNumIndex = inputArr.Length / 2 - 1;
            int secondNumIndex = firstNumIndex + 1;
            Console.WriteLine($"{{ {inputArr[firstNumIndex]}, {inputArr[secondNumIndex]} }}");
        }
        else
        {
            // odd, print 3 numbers
            int firstNumIndex = inputArr.Length / 2 - 1;
            int secondNumindex = firstNumIndex + 1;
            int thirdNumIndex = secondNumindex + 1;
            Console.WriteLine($"{{ {inputArr[firstNumIndex]}, {inputArr[secondNumindex]}, {inputArr[thirdNumIndex]} }}");
        }
    }
}

