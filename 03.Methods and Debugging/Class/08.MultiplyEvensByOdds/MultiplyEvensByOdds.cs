using System;

//Create a program that reads an integer number and multiplies the sum of all its even digits by the sum of all its odd digits:

class MultiplyEvensByOdds
{
    static void Main()
    {
        char[] number = Console.ReadLine().ToCharArray();
        Console.WriteLine(getDigitsSum(number));
    }

    static int getDigitsSum(char[] number)
    {
        int oddDigitsSum = 0;
        int evenDigitsSum = 0;

        // add up the digits
        foreach (char digit in number)
        {
            if (digit != '-')  // to combat negative numbers
            {
                int digitInteger = int.Parse(digit.ToString());

                oddDigitsSum += (digitInteger % 2 != 0) ? digitInteger : 0;
                evenDigitsSum += (digitInteger % 2 == 0) ? digitInteger : 0;
            }
        }

        return oddDigitsSum * evenDigitsSum;
    }
}
