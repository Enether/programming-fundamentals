/*
 Compare two char arrays lexicographically (letter by letter).
Print the them in alphabetical order, each on separate line.
 */
using System;
using System.Linq;

class CompareCharArrays
{
    static void Main()
    {
        char[] firstArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
        char[] secondArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
        bool firstArrIsFirst = false;
        bool areEqual = true;

        for (int i = 0; i < Math.Min(firstArr.Length, secondArr.Length); i++)
        {
            if (firstArr[i] == secondArr[i])
                continue;
            else
            {
                areEqual = false;
                if (firstArr[i] < secondArr[i])
                    firstArrIsFirst = true;
                break;
            }
        }

        if (areEqual)
        {
            if(firstArr.Length < secondArr.Length)
                PrintArrays(firstArr, secondArr);
            else
                PrintArrays(firstArr, secondArr, false);
        }
        else
        {
            if (firstArrIsFirst)
                PrintArrays(firstArr, secondArr);
            else
                PrintArrays(firstArr, secondArr, false);
        }
    }

    static void PrintArrays(char[] firstArr, char[] secondArr, bool reverse = true)
    {
        // reverse - bool indicating if we want to print the second array first
        if (reverse)
        {
            Console.WriteLine(string.Join("", firstArr));
            Console.WriteLine(string.Join("", secondArr));
        }
        else
        {
            Console.WriteLine(string.Join("", secondArr));
            Console.WriteLine(string.Join("", firstArr));
        }
    }
}

