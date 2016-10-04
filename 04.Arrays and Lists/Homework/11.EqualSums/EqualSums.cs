/*
 Write a program that determines if there exists an element in the array such that the sum of the elements 
 on its left is equal to the sum of the elements on its right. If there are no elements to the left / right,
 their sum is considered to be 0. 
 Print the index that satisfies the required condition or “no” if there is no such index.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EqualSums
{
    class EqualSums
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int suchIndex = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                // sum left
                int leftSum = 0;
                for (int j = 0; j < i; j++)
                {
                    leftSum += nums[j];
                }


                // sum right
                int rightSum = 0;
                for (int j = i+1; j < nums.Length; j++)
                {
                    rightSum += nums[j];
                }

                if (leftSum == rightSum)
                {
                    suchIndex = i;
                    break;
                }
            }

            Console.WriteLine(suchIndex != -1 ? suchIndex.ToString() : "no");
        }
    }
}
