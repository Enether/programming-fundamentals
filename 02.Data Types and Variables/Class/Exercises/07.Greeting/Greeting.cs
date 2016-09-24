using System;

class Greeting
{
    /*
     Write a program that enters first name, last name and age and prints 
     "Hello, <first name> <last name>. You are <age> years old.". Use interpolated strings.
         */
    static void Main()
    {
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine($"Hello, {firstName} {lastName}. You are {age} years old.");
    }
}

