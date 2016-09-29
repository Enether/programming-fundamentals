// Define a method Fib(n) that calculates the n th Fibonacci number. Examples:
using System;

class FibonacciNumbers
{
    static int[] fibonaccis;  // use an array to store past calculations in order to not recalculate fibonaccis that have been calculated already
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        fibonaccis = new int[n+1];

        Console.WriteLine(Fib(n));
    }
    
    public static int Fib(int n)
    {
        if (n == 0 || n == 1)
            return 1;


        if (fibonaccis[n] != 0)
            return fibonaccis[n];
        else
        {
            fibonaccis[n] = Fib(n - 1) + Fib(n - 2);
            return fibonaccis[n];
        }
    }
}
