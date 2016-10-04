/*
 Write a program that creates an array containing all letters from the alphabet (a-z). 
 Read a lowercase word from the console and print the index of each of its letters in the letters array
 */
using System;

class IndexOfLetters
{
    static void Main()
    {
        string input = Console.ReadLine();
        for (int i = 0; i < input.Length; i++)
        {
            Console.WriteLine($"{input[i]} -> {input[i]-97}");
        }
    }
}
