// Create a program that counts the trailing zeroes of the factorial of a given number.
using System;
using System.Numerics;

class FactorialTrailingZeroes
{
    static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        BigInteger nFactorial = CalculateFactorial(n);

        Console.WriteLine(CountTrailingZeroes(nFactorial));
    }

    private static int CountTrailingZeroes(BigInteger n)
    {
        int zeroesCount = 0;

        while (n > 0)
        {
            if (n % 10 == 0)
                zeroesCount++;
            else
                break;

            n = BigInteger.Divide(n, 10);
        }

        return zeroesCount;
    }

    private static BigInteger CalculateFactorial(BigInteger n)
    {
        if (n == 1)
            return 1;


        return BigInteger.Multiply(n, CalculateFactorial(n - 1));
    }
}
