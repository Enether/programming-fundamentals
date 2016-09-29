/*
Write a method that receives a name as parameter and prints on the console. “Hello, <name>!”
*/
using System;

class HelloName
{
    static void Main()
    {
        SayHello(Console.ReadLine());
    }

    static void SayHello(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }
}
