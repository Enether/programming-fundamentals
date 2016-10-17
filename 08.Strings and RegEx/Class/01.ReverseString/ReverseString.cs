// Write a program that reads a string from the console, reverses it and prints the result back at the console.
using System;
using System.Linq;

class ReverseString
{
    static void Main()
    {
        Console.WriteLine(new string(Console.ReadLine().Reverse().ToArray()));
    }
}
