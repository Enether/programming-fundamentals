using System;

//Create a method that calculates and returns the value of a number raised to a given power:
class MathPower
{
    static void Main()
    {
        double number = double.Parse(Console.ReadLine());
        double power = double.Parse(Console.ReadLine());
        Console.WriteLine(RaiseToPower(number, power));
    }

    static double RaiseToPower(double number, double power)
    {
        return Math.Pow(number, power);
    }
}