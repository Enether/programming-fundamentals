/*
Write a method that calculates all prime numbers in given range and returns them as list of integers:

Write a method to print a list of integers. Write a program that enters two integer numbers (each at a separate line)
and prints all primes in their range, separated by a comma.
*/
using System;
using System.Collections.Generic;

class PrimesInGivenRange
{
    static void Main()
    {
        PrintList(FindPrimesInRange(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
    }

    static List<int> FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primesInRange = new List<int>();

        for (int i = startNum; i <= endNum; i++)
        {
            if (IsPrime(i))
                primesInRange.Add(i);
        }

        return primesInRange;
    }

    static void PrintList(List<int> list)
    {
        Console.WriteLine(string.Join(", ", list));
    }

    public static bool IsPrime(int n)
    {
        if (n == 1 || n == 0)
            return false;

        bool isPrime = true;

        for (long i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        return isPrime;
    }
}

