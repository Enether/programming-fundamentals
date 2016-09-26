using System;

//  Create a program to convert a decimal number to hexadecimal and binary number and print it.

class IntegerToHexAndBinary
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        string hex = input.ToString("X");
        string binary = Convert.ToString(input, 2);
        Console.WriteLine(hex);
        Console.WriteLine(binary);
    }
}

