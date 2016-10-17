/*
 You are given an array with integers. Write a program to modify the array elements after processing a sequence of commands “swap”, “multiply” or “decrease”. The commands are as follows:
•	“swap {index1} {index2}” takes two elements and swaps them.
•	“multiply {index1} {index2}” takes element at the 1st index and multiplies it with the element at 2nd index. Save the product at the 1st index.
•	“decrease” decreases all elements in the array with 1.

Input
On the first input line you will be given the initial array values separated by a single space.
On the next lines you will receive commands until you receive the command “end”. The commands are as follow: 
•	“swap {index1} {index2}”
•	“multiply {index1} {index2}”
•	“decrease”

Output
The output should be printed on the console and consist element of the modified array – separated by “, “ (comma and single space).
Constraints
•	Commands will be: “swap”, “multiply”, “decrease” and “end”.
•	Elements of the array will be integer numbers in the range [-231...231].
•	Count of the array elements will be in the range [2...100].
•	Indexes will be always in the range of the array.

 */
using System;
using System.Collections.Generic;
using System.Linq;


class ArrayModifier
{
    static void Main()
    {
        List<long> arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        // handle commands
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "end")
                break;

            if (command.Contains("swap"))
            {
                HandleSwapCommand(command, arr);
            }
            else if (command.Contains("multiply"))
            {
                HandleMultiplyCommand(command, arr);
            }
            else if (command.Contains("decrease"))
            {
                arr = arr.Select(x => x - 1).ToList();
            }
            else
            {
                throw new Exception();
            }

        }

        Console.WriteLine(string.Join(", ", arr));
    }

    private static void HandleMultiplyCommand(string command, List<long> arr)
    {
        string[] commandInfo = command.Split();
        int firstIndex = int.Parse(commandInfo[1]);
        int secondIndex = int.Parse(commandInfo[2]);

        arr[firstIndex] *= arr[secondIndex];
    }

    static void HandleSwapCommand(string command, List<long> list)
    {
        string[] commandInfo = command.Split();
        int firstIndex = int.Parse(commandInfo[1]);
        int secondIndex = int.Parse(commandInfo[2]);

        long oldValue = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = oldValue;
    }
}
