/*
Write a program that can calculate the length of the face diagonals, space diagonals, volume and surface area of a
cube (http://www.mathopenref.com/cube.html) by a given side. On the first line you will get the side of the cube.
On the second line is given the parameter (face, space, volume or area).
Output should be rounded to the second digit after the decimal point:
*/
using System;

class CubeProperties
{
    static void Main()
    {
        double cubeSide = double.Parse(Console.ReadLine());
        string property = Console.ReadLine();

        switch (property)
        {
            case "face":
                Console.WriteLine($"{GetCubeFaceDiagonal(cubeSide):f2}");
                break;
            case "space":
                Console.WriteLine($"{GetCubeSpaceDiagonal(cubeSide):f2}");
                break;
            case "volume":
                Console.WriteLine($"{GetCubeVolume(cubeSide):f2}");
                break;
            case "area":
                Console.WriteLine($"{GetCubeSurfaceArea(cubeSide):f2}");
                break;
        }
    }

    public static double GetCubeSurfaceArea(double cubeSide)
    {
        return 6 * Math.Pow(cubeSide, 2);
    }

    public static double GetCubeFaceDiagonal(double cubeSide)
    {
        return Math.Sqrt(2 * Math.Pow(cubeSide, 2));
    }

    public static double GetCubeVolume(double cubeSide)
    {
        return Math.Pow(cubeSide, 3);
    }

    public static double GetCubeSpaceDiagonal(double cubeSide)
    {
        return Math.Sqrt(3 * Math.Pow(cubeSide, 2));
    }
}

