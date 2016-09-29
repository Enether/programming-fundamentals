// Write a Boolean method IsPrime(n) that checks whetehr a given integer number n is prime.
using System;

class PrimeChecker
{
    static void Main()
    {
        Console.WriteLine(IsPrime(long.Parse(Console.ReadLine())));
    }

    static bool IsPrime(long n)
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

