using System;
/*
Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.
Note that we cannot directly compare two floating-point numbers a and b by a==b because of the
nature of the floating-point arithmetic.
Therefore, we assume two numbers are equal if they are more closely to each other than some fixed constant eps. 
*/
class ComparingFloats
{
    static void Main()
    {
        double precisionEps = 0.000001;
        double numberA = double.Parse(Console.ReadLine());
        double numberB = double.Parse(Console.ReadLine());

        if (Math.Abs(numberA-numberB) < precisionEps)
            Console.WriteLine("True");
        else
            Console.WriteLine("False");
    }
}
