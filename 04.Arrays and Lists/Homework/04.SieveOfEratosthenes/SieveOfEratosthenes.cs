/*
 Write a program to find all prime numbers in range [1…n]. Implement the algorithm called “Sieve of Eratosthenes”: https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes. Steps in the “Sieve of Eratosthenes” algorithm:
Assign primes[0…n] = true
Assign primes[0] = primes[1] = false
Find the smallest p, which holds primes[p] = true
Print p (it is prime)
Assign primes[2*p] = primes[3*p] = primes[4*p] = … = false
Repeat for the next smallest p < n
 */
using System;
using System.Collections.Generic;
using System.Linq;

class SieveOfEratosthenes
{
    static void Main()
    {
        bool[] primes = new bool[int.Parse(Console.ReadLine()) + 1].Select(x => x = true).ToArray();
        List<int> primesList = new List<int>();
        primes[0] = false;
        primes[1] = false;

        for (int i = 1; i < primes.Length; i++)
        {
            if (primes[i])
            {
                primesList.Add(i);
                // assign 2*i, 3*i ... etc as false
                for (int j = 2; j * i < primes.Length; j++)
                {
                    primes[i * j] = false;
                }
            }
        }

        Console.WriteLine(string.Join(" ", primesList));
    }
}
