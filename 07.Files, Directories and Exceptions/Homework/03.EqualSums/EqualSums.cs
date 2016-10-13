/*
 Write a program that determines if there exists an element in the array such that the sum of the elements 
 on its left is equal to the sum of the elements on its right. If there are no elements to the left / right,
 their sum is considered to be 0. 
 Print the index that satisfies the required condition or “no” if there is no such index.
 */
using System;
using System.IO;
using System.Linq;


class EqualSums
{
    const string FIRST_INPUT_PATH = "../../input/input1.txt";
    const string SECOND_INPUT_PATH = "../../input/input2.txt";
    const string THIRD_INPUT_PATH = "../../input/input3.txt";
    const string FOURTH_INPUT_PATH = "../../input/input4.txt";
    const string FIFTH_INPUT_PATH = "../../input/input5.txt";
    static string[] inputs = new string[] { FIRST_INPUT_PATH, SECOND_INPUT_PATH, THIRD_INPUT_PATH, FOURTH_INPUT_PATH, FIFTH_INPUT_PATH };

    const string OUTPUT_DIR_PATH = "../../output/";
    static void Main()
    {
        Directory.CreateDirectory(OUTPUT_DIR_PATH);

        for (int i = 0; i < inputs.Length; i++)
        {
            string output_file_path = OUTPUT_DIR_PATH + "output_" + (i + 1) + ".txt";
            File.CreateText(output_file_path).Close();

            int[] nums = File.ReadAllText(inputs[i]).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int equalSumsIndex = GetEqualSumsIndex(nums);

            File.WriteAllText(output_file_path, equalSumsIndex != -1 ? equalSumsIndex.ToString() : "no");
        }
        

    }

    public static int GetEqualSumsIndex(int[] nums)
    {
        // iterates through the array and for each index tests to see 
        // if the sum of the numbers to the left of i
        // are equal to the sum of the numbers to the right of i
        int equalSumsIdx = -1;

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
            for (int j = i + 1; j < nums.Length; j++)
            {
                rightSum += nums[j];
            }

            if (leftSum == rightSum)
            {
                equalSumsIdx = i;
                break;
            }
        }

        return equalSumsIdx;
    }
}
