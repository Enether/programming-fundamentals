using System;
using System.Linq;
/*
 Create a method for printing triangles as shown below:

    input: 4
    output: 1
1 2
1 2 3 
1 2 3 4
1 2 3
1 2
1
     */
class PrintingTriangle
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        PrintTriangle(number);
    }

    static void PrintTriangle(int number)
    {
        // print top half, from 1 to number-1
        for (int i = 1; i < number; i++)
        {
            PrintLine(i);
        }

        // print bottom half, from num to 1
        for (int i = number; i > 0; i--)
        {
            PrintLine(i);
        }
    }

    static void PrintLine(int max)
    {
        Console.WriteLine(string.Join(" ", Enumerable.Range(1, max).ToArray()));
    }
}

