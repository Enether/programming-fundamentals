/*
 Refactor:
 You are given a working code that is a solution to Problem 5. Special Numbers. However, the variables are improperly named, declared before they are needed and some of them are used for multiple things. Without using your previous solution, modify the code so that it is easy to read and understand.
 Sample Code
int kolkko = int.Parse(Console.ReadLine());
int obshto = 0; int takova = 0; bool toe = false;
for (int ch = 1; ch <= kolkko; ch++)
{
    takova = ch;
    while (ch > 0)
    {
        obshto += ch % 10;
        ch = ch / 10;
    }
    toe = (obshto == 5) || (obshto == 7) || (obshto == 11);
    Console.WriteLine($"{takova} -> {toe}");
    obshto = 0;
    ch = takova;
}
 */

using System;

class RefactorSpecialNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int digitsSum = 0;
        int currentNum = 0;
        bool isSpecial = false;
        for (int i = 1; i <= number; i++)
        {
            currentNum = i;

            while (i > 0)
            {
                digitsSum += i % 10;
                i = i / 10;
            }

            isSpecial = (digitsSum == 5) || (digitsSum == 7) || (digitsSum == 11);
            Console.WriteLine($"{currentNum} -> {isSpecial}");
            digitsSum = 0;
            i = currentNum;
        }
    }
}

