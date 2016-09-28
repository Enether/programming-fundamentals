using System;
/*
 You are given two values of the same type as input. The values can be of type int, 
 char of string. Create a method GetMax() that returns the greater of the two values:
     */

class GreaterOfTwoValues
{
    static void Main()
    {
        string type = Console.ReadLine();
        string firstValue = Console.ReadLine();
        string secondValue = Console.ReadLine();

        switch (type)
        {
            case "int":
                Console.WriteLine(GetMax(int.Parse(firstValue), int.Parse(secondValue));
                break;
            case "string":
                Console.WriteLine(GetMax(firstValue, secondValue));
                break;
            case "char":
                Console.WriteLine(GetMax(firstValue, secondValue));
                break;
        }
    }
}

