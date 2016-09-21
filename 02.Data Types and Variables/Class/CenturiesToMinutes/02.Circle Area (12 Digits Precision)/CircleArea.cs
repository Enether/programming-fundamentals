using System;

/*
 Write program to enter a radius r (real number) and print the area of the circle with 
 exactly 12 digits after the decimal point. Use data type of enough precision to hold the results.
     */
class CircleArea
{
    static void Main()
    {
        double radius = double.Parse(Console.ReadLine());
        Console.WriteLine("{0:F12}", Math.Pow(radius, 2) * Math.PI);
    }
}
