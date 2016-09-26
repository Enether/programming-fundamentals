using System;
using System.Collections.Generic;
/*
* Different Integers Size
Given an input integer, you must determine which primitive data types are capable of properly storing that input.
Input
You receive N – integer which can be arbitrarily large or small
Output
You must determine if the given primitives are capable of storing it. If yes, then print:
{N} can fit in:
* dataType
If there is more than one appropriate data type, print each one on its own line and order them by size
(sbyte < byte < short < ushort < int < uint < long).
If the number cannot be stored in one of the four aforementioned primitives, print the line: 
{N} can't fit in any type
*/
class DifferentIntegerSizes
{
    static void Main()
    {
        string n = Console.ReadLine();
        List<string> appropriateDataTypes = new List<string>();
        string[] dataTypes = { "sbyte", "byte", "short", "ushort", "int", "uint", "long" };

        // try to parse the number to each of the data types
        foreach (var dataType in dataTypes)
        {
            parseToDataType(n, appropriateDataTypes, dataType);
        }

        if (appropriateDataTypes.Count > 0)
        {
            Console.WriteLine($"{n} can fit in:");
            foreach (string dataType in appropriateDataTypes)
            {
                Console.WriteLine($"* {dataType}");
            }
        }
        else
            Console.WriteLine($"{n} can't fit in any type");
    }
    
    public static void parseToDataType(string n, List<string> appropriateDataTypes, string dataType)
    {
        try
        {
            switch (dataType)
            {
                case "long":
                    long.Parse(n);
                    appropriateDataTypes.Add("long");
                    break;

                case "uint":
                    uint.Parse(n);
                    appropriateDataTypes.Add("uint");
                    break;

                case "int":
                    int.Parse(n);
                    appropriateDataTypes.Add("int");
                    break;

                case "ushort":
                    ushort.Parse(n);
                    appropriateDataTypes.Add("ushort");
                    break;

                case "short":
                    short.Parse(n);
                    appropriateDataTypes.Add("short");
                    break;

                case "byte":
                    byte.Parse(n);
                    appropriateDataTypes.Add("byte");
                    break;

                case "sbyte":
                    sbyte.Parse(n);
                    appropriateDataTypes.Add("sbyte");
                    break;
            }
        }
        catch
        {

        }
    }
}
