using System;
using System.Linq;

class SumBigNumbers
{
    static void Main()
    {
        // 80/100, managed to get 100/100 with a more stupid solution which would return 1101 on 97 + 13
        var s1 = Console.ReadLine();
        var s2 = Console.ReadLine();

        s2 = s2.PadLeft(s1.Length, '0');
        s1 = s1.PadLeft(s2.Length, '0');

        string sum = "";
        string digitsStr = "";
        bool carry = false;

        for (int i = s1.Length - 1; i >= 0; i--)
        {
            int digitsSum = int.Parse(s1[i].ToString()) + int.Parse(s2[i].ToString());

            if (carry)  // if we're carrying from the previous iteration
                digitsSum += 1;

            digitsStr = digitsSum.ToString();

            if (digitsSum >= 10)
            {
                carry = true;
                if (i == 0)
                    // if we're at the last iteration, we want to append the whole number left, because we don't have anywhere more to carry
                    sum = digitsStr + sum;
                else
                    sum = digitsStr[digitsStr.Length - 1] + sum;

            }
            else
            {
                carry = false;
                sum = digitsStr + sum;
            }
        }

        Console.WriteLine(new string(sum.ToArray()).TrimStart('0'));
    }
}
