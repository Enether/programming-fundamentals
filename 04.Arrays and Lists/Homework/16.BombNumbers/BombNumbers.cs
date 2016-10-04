/*
Write a program that reads sequence of numbers and special bomb number with a certain power.
Your task is to detonate every occurrence of the special bomb number and according to its power his neighbors from left and right. 
Detonations are performed from left to right and all detonated numbers disappear. 
Finally print the sum of the remaining elements in the sequence.
*/
using System;
using System.Collections.Generic;
using System.Linq;

class BombNumbers
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        List<int> bombNumberAndPower = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        int bombNumber = bombNumberAndPower[0];
        int power = bombNumberAndPower[1];

        for (int i = 0; i < numbers.Count(); i++)
        {
            if (numbers[i] == bombNumber)
            {
                // DETONATE !!!
                // start from the back and delete power(nums behind bombnum) +  1(bombNum) + power(nums after bombnum) numbers.
                // ex: BombNumber = 1, power = 1 => [4, 5, 1, 3] We want to remove 5, 1 and 3
                int totalDetonations = power + 1 + power;
                int startIndex = -1;
                int detonationsToSkip = 0;

                if (i - power >= 0)
                    startIndex = i - power;
                else
                {
                    startIndex = 0;
                    detonationsToSkip = Math.Abs(i - power);// ex: 0-3 = -3, because we're at the start index, the 3 detonations before the bombNum shouldn't be done
                }

                // detonate and remove the numbers from left to right
                for (int j = 0; j < totalDetonations - detonationsToSkip; j++)
                {
                    if(numbers.Count > startIndex)
                        numbers.RemoveAt(startIndex);
                }

                i = -1;  // after a detonation, the list has been manipulated and we want to start from 0 again, because a new number can be at our current index
            }
        }
        Console.WriteLine(string.Join(" ", numbers.Sum()));

    }
}

