/*
Write a program that can calculate the area of four different geometry figures - triangle, square, rectangle and
circle.

On the first line you will get the figure type. Next you will get parameters for the chosen figure, each on a different
line:

 Triangle - side and height
 Square - side
 Rectangle - width and height
 Circle - radius

The output should be rounded to the second digit after the decimal point:
*/
using System;

class GeometryCalculator
{
    static void Main()
    {
        string figure = Console.ReadLine();

        switch(figure)
        {
            case "triangle":
                HandleTriangle();
                break;
            case "rectangle":
                HandleRectangle();
                break;
            case "circle":
                HandleCircle();
                break;
            case "square":
                HandleSquare();
                break;
        }
    }

    private static void HandleTriangle()
    {
        double side = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        Console.WriteLine($"{(side * height)/2:f2}");
    }

    private static void HandleRectangle()
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        Console.WriteLine($"{width * height:f2}");
    }

    private static void HandleCircle()
    {
        double radius = double.Parse(Console.ReadLine());

        Console.WriteLine($"{Math.Pow(radius, 2) * Math.PI:f2}");
    }

    private static void HandleSquare()
    {
        double side = double.Parse(Console.ReadLine());

        Console.WriteLine($"{side * side:f2}");
    }
}

