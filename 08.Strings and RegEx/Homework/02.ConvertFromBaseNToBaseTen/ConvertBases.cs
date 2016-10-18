/*
 Write a program that takes a base-N number and converts it to a base-10 number (0 to 1050), where 2 <= N <= 10.
The input consists of 1 line containing two numbers separated by a single space. 
The first number is the base N to which you have to convert. The second one is the base N number to be converted.
Do not use any built in converting functionality, try to write your own algorithm.

 */
using System;
using System.Numerics;


class ConvertBases
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        int base_n = int.Parse(input[0]);
        string number = input[1];
        BigInteger result = 0;

        for (int i = number.Length - 1, counter = 0; i >= 0; i--, counter++)
        {
            result += int.Parse(number[i].ToString()) * BigInteger.Pow(base_n, counter);
        }

        Console.WriteLine(result);
    }
}
