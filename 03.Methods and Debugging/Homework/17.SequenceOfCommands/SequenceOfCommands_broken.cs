/*
The goal of this exercise is to practice debugging techniques in scenarios where a piece of code does not work
correctly. Your task is to pinpoint the bug and fix it (without rewriting the entire code). Test your fixed solution in
the judge system:


Problem Description
You are given a program that reads a n numbers and a sequence of commands to be executed over these numbers.

Input
 The first line holds an integer n – the count of numbers.
 The second line holds n numbers – integers separated by space.
 Each of the next few lines hold commands in format: “[action] [i-th element] [value]”.
 The commands sequence end with a command “stop”.

Commands

Commands are given in format “[action] [i-th element] [value]”. Elements are indexed from 1 to n.
The action can be “multiply”, “add”, “subtract”, “rshift” or “lshift”.

 The actions “multiply”, “add” and “subtract” have parameters. The first parameter is the index of the

element that needs to be changed (in range [1...n]). The second parameter is the value with which we
manipulate the element.

 The command “lshift” moves the first element last. E.g. “lshift” over {1, 2, 3} will produce {2, 3, 1}.
 The command “rshift” moves the last element first. E.g. “rshift” over {1, 2, 3} will produce {3, 1, 2}.

Output
Print the values of the n elements after the execution of each command (except the last “stop” command).

Constraints

 The number n will be an integer in the range [1 … 15].
 Each element of the array will be an integer in the range [0 … 2 63 -1].
 The number i and the number of commands will be integers in the range [1 … 10].
 The number value will be an integer in the range [-100 … 100]. If the command is “rshift” or “lshift” there
are no parameters.
*/
using System;
using System.Linq;

public class SequenceOfCommands_broken
{
	private const char ArgumentsDelimiter = ' ';

	public static void Main()
	{
		int sizeOfArray = int.Parse(Console.ReadLine());
		long[] array = Console.ReadLine()
			.Split(ArgumentsDelimiter)
			.Select(long.Parse)
			.ToArray();

        string[] fullCommand = Console.ReadLine().Split(ArgumentsDelimiter);
		string command = fullCommand[0];
        
		while (!command.Equals("stop"))
		{
			int[] args = new int[2];

			if (command.Equals("add") ||
				command.Equals("subtract") ||
				command.Equals("multiply"))
			{
				args[0] = int.Parse(fullCommand[1]) - 1;  // the index given in the input is always one up, their 1 is equal to the array's 0
				args[1] = int.Parse(fullCommand[2]);
			}

            PerformAction(array, command, args);

            PrintArray(array);

            fullCommand = Console.ReadLine().Split(ArgumentsDelimiter);
            command = fullCommand[0];
        }
	}

	static void PerformAction(long[] arr, string action, int[] args)
	{
        long[] array = arr;  // they have the same referance
		int pos = args[0];
		int value = args[1];

		switch (action)
		{
			case "multiply":
				array[pos] *= value;
				break;
			case "add":
				array[pos] += value;
				break;
			case "subtract":
				array[pos] -= value;
				break;
			case "lshift":
				ArrayShiftLeft(array);
				break;
			case "rshift":
				ArrayShiftRight(array);
				break;
		}
	}

	private static void ArrayShiftRight(long[] array)
	{
        long lastIndexValue = array[array.Length-1];
		for (int i = array.Length - 1; i >= 1; i--)
		{
			array[i] = array[i - 1];
		}
        array[0] = lastIndexValue;
	}

	private static void ArrayShiftLeft(long[] array)
	{
        long firstIndexValue = array[0];
		for (int i = 0; i < array.Length - 1; i++)
		{
			array[i] = array[i + 1];
		}
        array[array.Length - 1] = firstIndexValue;
	}

	private static void PrintArray(long[] array)
	{
        Console.WriteLine(string.Join(" ", array));
	}
}
