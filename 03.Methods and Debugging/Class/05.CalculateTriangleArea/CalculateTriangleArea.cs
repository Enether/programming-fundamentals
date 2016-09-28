using System;
// Create a method that calculates and returns the area of a triangle by given base and height:
    
class CalculateTriangleArea
{
    static void Main()
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        Console.WriteLine(GetTriangleArea(width, height));
    }

    static double GetTriangleArea(double width, double height)
    {
        return (width*height)/2;
    }
}
