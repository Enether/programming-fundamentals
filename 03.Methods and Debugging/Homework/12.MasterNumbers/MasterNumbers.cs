/*
A master number is an integer that holds the following properties:

 Is symmetric (palindrome), e.g. 5, 77, 282, 14341, 9553559.
 Its sum of digits is divisible by 7, e.g. 77, 313, 464, 5225, 37173.
 Holds at least one even digit, e.g. 232, 707, 6886, 87578.

Write a program to print all master numbers in the range [1…n].
*/
using System;
using System.Linq;

class MasterNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        SumOfDigits(553);
        // all master numbers in the range 1-n
        for (int i = 1; i <= number; i++)
        {
            if (IsPalindrome(i) && SumOfDigits(i) % 7 == 0 && ContainsEvenDigit(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    private static bool IsPalindrome(int num)
    {
        int n = num;
        int reversedNum = 0;
        int dig;

        while (num > 0)
        {
            dig = n % 10;
            reversedNum = reversedNum * 10 + dig;
            n = n / 10;
        }

        return num == reversedNum;
    }

    private static int SumOfDigits(int num)
    {
        int sum = 0;

        while(num != 0)
        {
            sum += num % 10;
            num /= 10;
        }

        return sum;
    }

    private static bool ContainsEvenDigit(int num)
    {
        string numStr = num.ToString();

        for (int i = 0; i < numStr.Length; i++)
        {
            if (int.Parse(numStr[i].ToString()) % 2 == 0)
                return true;
        }

        return false;
    }
}
