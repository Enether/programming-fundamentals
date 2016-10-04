/*
 Write a program that reads an array of integers from the console and set of commands and executes them over the array. The commands are as follows:
add <index> <element> – adds element at the specified index (elements right from this position inclusively are shifted to the right).
addMany <index> <element 1> <element 2> … <element n> – adds a set of elements at the specified index.
contains <element> – prints the index of the first occurrence of the specified element (if exists) in the array or -1 if the element is not found.
remove <index> – removes the element at the specified index.
shift <positions> – shifts every element of the array the number of positions to the left (with rotation).
For example, [1, 2, 3, 4, 5] -> shift 2 -> [3, 4, 5, 1, 2]
sumPairs – sums the elements in the array by pairs (first + second, third + fourth, …).
For example, [1, 2, 4, 5, 6, 7, 8] -> [3, 9, 13, 8].
print – stop receiving more commands and print the last state of the array.
 */
using System;
using System.Collections.Generic;
using System.Linq;

class ArrayManipulator
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        string command = Console.ReadLine();

        while(command != "print")
        {
            string[] cmdInfo = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            command = cmdInfo[0];

            switch(command)
            {
                case "add":
                    int index = int.Parse(cmdInfo[1]);
                    int element = int.Parse(cmdInfo[2]);
                    numbers.Insert(index, element);
                    break;
                case "contains":
                    Console.WriteLine(numbers.IndexOf(int.Parse(cmdInfo[1])));
                    break;
                case "remove":
                    numbers.RemoveAt(int.Parse(cmdInfo[1]));
                    break;
                case "shift":
                    int numberOfShifts = int.Parse(cmdInfo[1]);
                    ShiftList(numbers, numberOfShifts);
                    break;
                case "sumPairs":
                    SumPairs(numbers);
                    break;
                case "addMany":
                    int addIndex = int.Parse(cmdInfo[1]);
                    List<int> numbersToAdd = new List<int>();
                    for (int i = 2; i < cmdInfo.Length; i++)
                    {
                        numbersToAdd.Add(int.Parse(cmdInfo[i]));
                    }
                    AddMany(numbers, addIndex, numbersToAdd);
                    break;
            }
            command = Console.ReadLine();
        }
        Console.WriteLine($"[{string.Join(", ", numbers)}]");
    }
    static void ShiftList(List<int> arr, int shiftCount)
    {
        for (int _ = 0; _ < shiftCount; _++)
        {
            int firstElement = arr[0];

            for (int i = 0; i < arr.Count-1; i++)
            {
                arr[i] = arr[i + 1];
            }

            arr[arr.Count-1] = firstElement;
        }
    }

    static void SumPairs(List<int> arr)
    {
        for (int i = 0; i < arr.Count-1; i++)
        {
            arr[i] += arr[i + 1];
            arr.RemoveAt(i + 1);
        }
    }

    static void AddMany(List<int> arr, int index, List<int> many)
    {
        arr.InsertRange(index, many);
    }
}
