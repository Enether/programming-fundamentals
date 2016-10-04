/*
The goal of this exercise is to practice debugging techniques in scenarios where a piece of code does not work
correctly. Your task is to pinpoint the bug and fix it (without rewriting the entire code). Test your fixed solution in
the judge system:

Problem Description
A program is designed to take some sequences of numbers from the console, to process them as described below
and print each obtained sequence.

Input

 On the first line of input you are given a count N – the number of sequences.
 On each of the next N lines you will receive some numbers surrounded by whitespaces.

Processing Logic
You need to check each number, if it’s positive – print it on the console; if it’s negative, add to its value the value of
the next number and only print the result if it’s not negative. You only perform the addition once, e.g. if you have
the sequence: -3, 1, 3, the algorithm is as follows:


 -3 is negative => add to it the next number (1) => -3 + 1 = -2 still negative => do not print anything (and don’t
keep adding numbers, you stop here).

 The next number we consider is 3 which is positive => print it.

If no numbers can be obtained in this manner for the given sequence, print “(empty)”.
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class BePositive_broken
{
	public static void Main()
	{
		int countSequences = int.Parse(Console.ReadLine());

		for (int i = 0; i < countSequences; i++)
		{
            // read the input and convert it into an int array
			int[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
			var numbers = new List<int>();

			for (int j = 0; j < input.Length; j++)
			{
				int currentNum = input[j];

				if (currentNum >= 0)
				{
                    numbers.Add(currentNum);
				}
				else
				{
                    if(j + 1 < input.Length)
                    {
                        // it's a negative number, so we add it to the next number
                        currentNum += input[j + 1];
                        j++; // increment once so we skip the number we just added [j+1]
                    }

					if (currentNum >= 0)
					{
                        numbers.Add(currentNum);
					}
				}
			}

            if(numbers.Count > 0)
                Console.WriteLine(string.Join(" ", numbers));
            else
                Console.WriteLine("(empty)");
		}
	}
}