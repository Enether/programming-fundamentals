/*
In the SoftUni office we drink lots of water (and other drinks). That’s why instead of using glasses, we use bottles.
Everyone is using different bottles, but with the same capacity. You are given an array of floating-point numbers, in which each index represents someone’s bottle.
We have some water in stock, but sometimes it is not enough to fill our bottles. That’s why we need you. Your job is to create a program that fills our bottles and tells us if there is enough water or not. If there is enough water to fill all bottles, you need to tell us how much water we have left. If there are some bottles that are not completely filled, you need to tell us how many are those bottles, and how much more water we need in order to fill them. We also need to know which members of the team need to wait for more water, and instead of using names, we will use the indexes of the bottles.
On the first line you are given the total amount of water that we have. On the second line you are given all bottles that you need to fill. There is a tricky part. If the total water is an even number, you will start filling the bottles from the beginning of the array, until you run out of water, or fill all bottles. If the number is odd, you will traverse the array from the end to the beginning, filling the bottles that way. In case you run out of water, you need to print the indexes of the empty bottles in the same order in which you are traversing the array. On the last line you will receive the maximum capacity that each bottle has.
Input
On the first line you will receive integer, which represents the total amount of water that we have.
On the second line you will receive an array, representing the bottles that you need to fill.
On the last line you will receive the capacity for each bottle of the array.

Output
If there is enough water to fill all bottles print the following lines:
“Enough water!”
“Water left: {amountOfWaterLeft}l.”
If there isn’t enough water print the following lines:
“We need more water!”
“Bottles left: {amountOfBottles}”
“With indexes: {index}, {index}, {index}”
The order of the indexes must be the same, as the order in which you are traversing the array.
“We need {amountOfWaterNeeded} more liters!”

Constraints
The total amount of water will be integer in range [0…2,147,483,647].
The items in the array will be floating-point numbers in range [0…1.7*10308].
The bottle capacity will be integer in range [0…2,147,483,647].
*/
using System;
using System.Collections.Generic;
using System.Linq;

class SoftUniWaterSupplies
{
    static void Main()
    {
        double totalWaterAmount = double.Parse(Console.ReadLine());
        List<double> waterBottles = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
        int bottleCapacity = int.Parse(Console.ReadLine());

        // a tuple containing the water left and the indexes of the bottles that need filling
        Tuple<double, List<int>> waterLeftAndBottleIndexes = null;
        if (totalWaterAmount % 2 == 0)
        {
            waterLeftAndBottleIndexes = FillBottlesForwards(waterBottles, bottleCapacity, totalWaterAmount);
        }
        else
        {
            waterLeftAndBottleIndexes = FillBottlesBackwards(waterBottles, bottleCapacity, totalWaterAmount);
        }

        double waterLeft = waterLeftAndBottleIndexes.Item1;

        if (waterLeft >= 0)
        {
            Console.WriteLine("Enough water!");
            Console.WriteLine($"Water left: {waterLeft}l.");
        }
        else
        {
            var leftBottlesIndexes = waterLeftAndBottleIndexes.Item2;
            Console.WriteLine("We need more water!");
            Console.WriteLine($"Bottles left: {leftBottlesIndexes.Count}");
            Console.WriteLine($"With indexes: {string.Join(", ", leftBottlesIndexes)}");
            Console.WriteLine($"We need {((long)bottleCapacity * waterBottles.Count) - waterBottles.Sum()} more liters!");
        }
    }

    static Tuple<double, List<int>> FillBottlesForwards(List<double> waterBottles, int bottleCapacity, double totalWaterAmount)
    {
        for (int i = 0; i < waterBottles.Count; i++)
        {
            if (waterBottles[i] < bottleCapacity)
            {
                double waterNeeded = bottleCapacity - waterBottles[i];
                if (totalWaterAmount - waterNeeded >= 0)
                {
                    // fill the bottle
                    totalWaterAmount -= waterNeeded;
                    waterBottles[i] = bottleCapacity;
                }
                else
                {
                    // we don't have enough water left
                    waterBottles[i] += totalWaterAmount;
                    totalWaterAmount = -1;
                    break;
                }
            }
        }

        if (totalWaterAmount >= 0)
            return new Tuple<double, List<int>>(totalWaterAmount, new List<int>(){ });
        else
        {
            // water was not enough, get the indexes that are not full
            List<int> bottleIndexesThatNeedFilling = new List<int>();
            for (int i = 0; i < waterBottles.Count; i++)
            {
                if (waterBottles[i] < bottleCapacity)
                    bottleIndexesThatNeedFilling.Add(i);
            }

            return new Tuple<double, List<int>>(totalWaterAmount, bottleIndexesThatNeedFilling);
        }
    }

    static Tuple<double, List<int>> FillBottlesBackwards(List<double> waterBottles, int bottleCapacity, double totalWaterAmount)
    {
        for (int i = waterBottles.Count-1; i >= 0; i--)
        {
            if (waterBottles[i] < bottleCapacity)
            {
                double waterNeeded = bottleCapacity - waterBottles[i];
                if (totalWaterAmount - waterNeeded >= 0)
                {
                    // fill the bottle
                    totalWaterAmount -= waterNeeded;
                    waterBottles[i] = bottleCapacity;
                }
                else
                {
                    // we don't have enough water left
                    waterBottles[i] += totalWaterAmount;
                    totalWaterAmount = -1;
                    break;
                }
            }
        }

        if (totalWaterAmount >= 0)
            return new Tuple<double, List<int>>(totalWaterAmount, new List<int>() { });
        else
        {
            // water was not enough, get the indexes that are not full
            List<int> bottleIndexesThatNeedFilling = new List<int>();
            for (int i = waterBottles.Count - 1; i >= 0; i--)
            {
                if (waterBottles[i] < bottleCapacity)
                    bottleIndexesThatNeedFilling.Add(i);
            }

            return new Tuple<double, List<int>>(totalWaterAmount, bottleIndexesThatNeedFilling);
        }
    }
}

