/*
Create a method GetMax(int a, int b), that returns maximal of two numbers. Write a program that reads

three numbers from the console and prints the biggest of them. Use the GetMax(…) method you just created.
*/
using System;

class MaxMethod
{
    static void Main()
    {
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());

        Console.WriteLine(GetMax(firstNum, GetMax(secondNum, thirdNum)));
    }

    public static int GetMax(int a, int b)
    {
        return a > b ? a : b;
    }
}

