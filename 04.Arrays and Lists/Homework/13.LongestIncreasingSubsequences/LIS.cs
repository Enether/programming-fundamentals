using System;
using System.Collections.Generic;
using System.Linq;

class LIS
{
    static void Main()
    {
        int[] nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Console.WriteLine(string.Join(" ", FindLongestIncreasingSubsequence(nums)));
    }

    static int[] FindLongestIncreasingSubsequence(int[] sequence)
    {
        int[] len = new int[sequence.Length];
        int[] prev = new int[sequence.Length];

        for (int i = 0; i < sequence.Length; i++)
        {
            len[i] = 1;
            prev[i] = -1;
            for (int j = 0; j < i; j++)
            {
                if (sequence[i] > sequence[j])
                {
                    if (len[i] <= len[j])
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                }
            }
        }

        // reconstruct
        int recIndex = Array.IndexOf(len, len.Max());
        List<int> lis = new List<int>(len.Max()) {
            sequence[recIndex] };

        while (true)
        {
            recIndex = prev[recIndex];
            if (recIndex == -1)
                break;
            lis.Add(sequence[recIndex]);
        }
        lis.Reverse();

        return lis.ToArray();
    }
}
