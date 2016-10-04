/*
Write a program that calculates and prints the n! for any n in the range [1…1000].
*/
using System;
using System.Numerics;

class Factorial
{
    static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());

        Console.WriteLine(CalculateFactorial(n));
    }

    private static BigInteger CalculateFactorial(BigInteger n)
    {
        if (n == 1)
            return 1;


        return BigInteger.Multiply(n, CalculateFactorial(n - 1));
    }
}

