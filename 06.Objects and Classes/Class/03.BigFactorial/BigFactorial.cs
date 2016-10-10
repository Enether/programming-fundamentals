/* Calculate and print n! (n factorial) for very big integer n (e.g. 1000). */
using System;
using System.Numerics;


class BigFactorial
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine(CalculateFactorial(num));
    }

    static BigInteger CalculateFactorial(int num)
    {
        if (num == 1)
            return 1;

        return num * CalculateFactorial(num - 1);
    }
}
