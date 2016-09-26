using System;

/* Write a program that reads a number in hexadecimal format (0x##) convert it to decimal format and prints it. */
class VariableInHexFormat
{
    static void Main()
    {
        Console.WriteLine(Convert.ToInt32(Console.ReadLine(), 16));
    }
}

