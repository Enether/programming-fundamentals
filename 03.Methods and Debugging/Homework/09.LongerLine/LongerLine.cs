/*
You are given the coordinates of four points in the 2D plane. The first and the second pair of points form two
different lines. Print the longer line in format &quot;(X1, Y1)(X2, Y2)&quot; starting with the point that is closer to the center of
the coordinate system (0, 0) (You can reuse the method that you wrote for the previous problem). If the lines are of
equal length, print only the first one.
*/
using System;

class LongerLine
{
    static void Main()
    {
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());
        double x3 = double.Parse(Console.ReadLine());
        double y3 = double.Parse(Console.ReadLine());
        double x4 = double.Parse(Console.ReadLine());
        double y4 = double.Parse(Console.ReadLine());

        double distanceOne = ((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        double distanceTwo = ((x3 - x4) * (x3 - x4) + (y3 - y4) * (y3 - y4));

        if (distanceOne >= distanceTwo)
            PrintLongestLine(x1, y1, x2, y2);
        else
            PrintLongestLine(x3, y3, x4, y4);
    }

    public static void PrintLongestLine(double x1, double y1, double x2, double y2)
    {
        // the one with the minimum sum will be the first coordinate to be printed
        double firstCoordinatesSum = Math.Abs(x1) + Math.Abs(y1);
        double secondCoordinatesSum = Math.Abs(x2) + Math.Abs(y2);

        if (firstCoordinatesSum <= secondCoordinatesSum)
            Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
        else
            Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
    }

}

