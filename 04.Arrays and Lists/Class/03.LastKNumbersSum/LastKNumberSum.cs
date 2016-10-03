/*
 Enter two integers n and k. Generate and print the following sequence of n elements:

The first element is: 1

All other elements = sum of the previous k elements (if less than k are available, sum all of them)

Example: n = 9, k = 5  120 = 4 + 8 + 16 + 31 + 61
 */
using System;

class LastKNumberSum
{
    static void Main()
    {
        int numCount = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        long[] arr = new long[numCount];
        arr[0] = 1;
        for (int i = 1; i < numCount; i++)
        {
            arr[i] = GetKSum(arr, i, k);
        }

        Console.WriteLine(string.Join(" ", arr));
    }

    static long GetKSum(long[] arr, int index, int k)
    {
        long kSum = 0;

        for (int i = index-1; i >= index-k; i--)
        {
            if (i < 0)  // failsafe because we can get into negative values
                break;

            kSum += arr[i];
        }

        return kSum;
    }
}
