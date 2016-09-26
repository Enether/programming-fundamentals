using System;
/*
 Create a new C# project and create a program that assigns floating point values to variables.
 Be sure that each value is stored in the correct variable type (try to find the most suitable variable type in order to save memory).
 Finally, you need to print all variables to the console.
*/

class PracticeFloatingPointNumbers
{
    static void Main()
    {
        decimal pi = 3.141592653589793238M;
        double onePointSix = 1.60217657;
        decimal sevenPointEight = 7.8184261974584555216535342341M;

        Console.WriteLine(pi);
        Console.WriteLine(onePointSix);
        Console.WriteLine(sevenPointEight);
    }
}

