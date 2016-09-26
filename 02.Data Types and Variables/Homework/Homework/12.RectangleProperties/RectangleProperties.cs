using System;

/*
 Create a program to calculate rectangle’s perimeter, area and diagonal by given its width and height.
*/
class RectangleProperties
{
    static void Main()
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        double diagonal = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2));
        double area = width * height;
        double perimeter = width * 2 + height * 2;
        Console.WriteLine(perimeter);
        Console.WriteLine(area);
        Console.WriteLine(diagonal);
    }
}
