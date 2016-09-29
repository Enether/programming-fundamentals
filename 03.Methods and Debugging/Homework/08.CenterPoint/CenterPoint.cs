/*
You are given the coordinates of two podoubles on a Cartesian coordinate system - X1, Y1, X2 and Y2. Create a method
that prdoubles the podouble that is closest to the center of the coordinate system (0, 0) in the format (X, Y). If the podoubles are
on a same distance from the center, prdouble only the first one.
*/
using System;

class CenterPoint
{
    static void Main()
    {
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());

        PrintClosestCoordinates(x1, y1, x2, y2);
    }

    public static void PrintClosestCoordinates(double x1, double y1, double x2, double y2)
    {
        // the one with the minimum sum will be the closer print
        double firstCoordinatesSum = Math.Abs(x1) + Math.Abs(y1);
        double secondCoordinatesSum = Math.Abs(x2) + Math.Abs(y2);

        double xToPrint, yToPrint = 0;

        if (firstCoordinatesSum <= secondCoordinatesSum)
        {
            xToPrint = x1;
            yToPrint = y1;
        }
        else
        {
            xToPrint = x2;
            yToPrint = y2;
        }

        Console.WriteLine($"({xToPrint}, {yToPrint})");
    }
}

