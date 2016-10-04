/*
 Read two arrays of words and find the length of the largest common end (left or right).
 */
using System;

class LargestCommonEnd
{
    static void Main()
    {
        string[] firstArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] secondArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // first words
        int leftEqual = 0;
        for (int i = 0; i < Math.Min(firstArr.Length, secondArr.Length); i++)
        {
            if (firstArr[i] != secondArr[i])
                break;
            leftEqual++;
        }

        // second words            
        int rightEqual = 0;
        int firstArrIndex = firstArr.Length - 1;
        int secondArrIndex = secondArr.Length - 1;
        for (; firstArrIndex >= 0 && secondArrIndex >= 0; firstArrIndex--, secondArrIndex--)
        {
            if (firstArr[firstArrIndex] != secondArr[secondArrIndex])
                break;
            rightEqual++;
        }
        
        Console.WriteLine(Math.Max(rightEqual, leftEqual));
    }
}
