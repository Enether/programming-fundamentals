/*
 Write a program to sum all adjacent equal numbers in a list of decimal numbers, starting from left to right.

 After two numbers are summed, the obtained result could be equal to some of its neighbors and should be

summed as well (see the examples below).

 Always sum the leftmost two equal neighbors (if several couples of equal neighbors are available).
 */
using System;
using System.Collections.Generic;
using System.Linq;

class SumAdjacentEqualNumbers
{
    static void Main()
    {
        List<decimal> list = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToList();

        Console.WriteLine(string.Join(" ", SumAdjacent(list)));
    }

    static List<decimal> SumAdjacent(List<decimal> list)
    {
        // recursive method to sum all adjacent numbers that are equal and then modify the list

        for (int i = 0; i <= list.Count-2; i++)
        {
            decimal firstNum = list[i];
            decimal secondNum = list[i + 1];
            if (firstNum == secondNum)
            {
                list.Insert(i, (decimal)firstNum + secondNum);
                list.RemoveAt(i + 1);
                list.RemoveAt(i + 1);

                return SumAdjacent(list);
            }
        }

        return list;
    }
}
