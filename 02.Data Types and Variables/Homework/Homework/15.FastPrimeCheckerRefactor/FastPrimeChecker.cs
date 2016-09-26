using System;
/*             
Fast Prime Checker - Refactor
You are given a program that checks if numbers in a given range [2...N] are prime. For each number is printed "{number} is prime -> {True or False}". The code however, is not very well written. Your job is to modify it in a way that is easy to read and understand.
Code
Sample Code
int ___Do___ = int.Parse(Console.ReadLine());
for (int DAVIDIM = 0; DAVIDIM <= ___Do___; DAVIDIM++)
{
    bool TowaLIE = true;
    for (int delio = 2; delio <= Math.Sqrt(DAVIDIM); delio++)
    {
        if (DAVIDIM % delio == 0)
        {
            TowaLIE = false;
            break;
        }
    }
    Console.WriteLine($"{DAVIDIM} is prime -> {TowaLIE}");
} 
*/


class FastPrimeChecker
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int number = 1; number <= n; number++)
        {
            bool isPrime = true;

            for (int secondNum = 2; secondNum <= Math.Sqrt(number); secondNum++)
            {
                if (number % secondNum == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            Console.WriteLine($"{number} -> {isPrime}");
        }
    }
}
