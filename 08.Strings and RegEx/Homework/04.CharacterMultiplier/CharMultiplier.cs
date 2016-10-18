/*
 Create a method that takes two strings as arguments and returns the sum of their character codes multiplied 
 (multiply str1.charAt (0) with str2.charAt (0) and add to the total sum). 
 Then continue with the next two characters. If one of the strings is longer than the other, 
 add the remaining character codes to the total sum without multiplication
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CharMultiplier
{
    static void Main()
    {
        ulong totalSum = 0UL;
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string str1 = input[0];
        string str2 = input[1];

        for (int i = 0; i < Math.Max(str1.Length, str2.Length); i++)
        {
            if (i >= str1.Length)
            {
                totalSum += str2[i];
            }
            else if (i >= str2.Length)
            {
                totalSum += str1[i];
            }
            else
            {
                totalSum += (ulong)str1[i] * str2[i];
            }
        }

        Console.WriteLine(totalSum);
    }
}
