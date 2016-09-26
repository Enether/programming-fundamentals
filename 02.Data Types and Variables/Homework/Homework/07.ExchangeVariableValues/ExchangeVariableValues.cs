using System;

/*
 Declare two integer variables a and b and assign them with 5 and 10 and after that exchange their values
 by using some programming logic.
 Print the variable values before and after the exchange, as shown below:
*/

class ExchangeVariableValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;

        Console.WriteLine("Before:");
        Console.WriteLine("a = {0}", a);
        Console.WriteLine("b = {0}", b);

        // swap them
        int oldA = a;
        a = b;
        b = oldA;

        Console.WriteLine("After:");
        Console.WriteLine("a = {0}", a);
        Console.WriteLine("b = {0}", b);
    }
}

