/*
 Refactor this
 Sample Code
double dul, sh, V = 0;
Console.Write("Length: ");
dul = double.Parse(Console.ReadLine());
Console.Write("Width: ");
sh = double.Parse(Console.ReadLine());
Console.Write("Heigth: ");
V = double.Parse(Console.ReadLine());
V = (dul + sh + V) / 3;
Console.WriteLine("Pyramid Volume: {0:F2}", V);
 */

using System;

class RefactorVolumeofPyramid
{
    static void Main()
    {
        Console.Write("Length: ");
        double length = double.Parse(Console.ReadLine());

        Console.Write("Width: ");
        double width = double.Parse(Console.ReadLine());

        Console.Write("Height: ");
        double heigth = double.Parse(Console.ReadLine());

        double volume = ((length * width) * heigth) / 3;
        Console.WriteLine("Pyramid Volume: {0:F2}", volume);
    }
}
