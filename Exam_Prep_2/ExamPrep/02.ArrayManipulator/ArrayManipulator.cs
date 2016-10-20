/*
Trifon has finally become a junior developer and has received his first task. It’s about manipulating an array of integers. He is not quite happy about it, since he hates manipulating arrays. They are going to pay him a lot of money, though, and he is willing to give somebody half of it if to help him do his job. You, on the other hand, love arrays (and money) so you decide to try your luck.
The array may be manipulated by one of the following commands
•	exchange {index} – splits the array after the given index, and exchanges the places of the two resulting sub-arrays. E.g. [1, 2, 3, 4, 5] -> exchange 2 -> result: [4, 5, 1, 2, 3]
o	If the index is outside the boundaries of the array, print “Invalid index”
•	max even/odd– returns the INDEX of the max even/odd element -> [1, 4, 8, 2, 3] -> max odd -> print 4
•	min even/odd – returns the INDEX of the min even/odd element -> [1, 4, 8, 2, 3] -> min even > print 3
o	If there are two or more equal min/max elements, return the index of the rightmost one
o	If a min/max even/odd element cannot be found, print “No matches”
•	first {count} even/odd– returns the first {count} elements -> [1, 8, 2, 3] -> first 2 even -> print [8, 2]
•	last {count} even/odd – returns the last {count} elements -> [1, 8, 2, 3] -> last 2 odd -> print [1, 3]
o	If the count is greater than the array length, print “Invalid count”
o	If there are not enough elements to satisfy the count, print as many as you can. If there are zero even/odd elements, print an empty array “[]”
•	end – stop taking input and print the final state of the array

Input
•	The input data should be read from the console.
•	On the first line, the initial array is received as a line of integers, separated by a single space
•	On the next lines, until the command “end” is received, you will receive the array manipulation commands
•	The input data will always be valid and in the format described. There is no need to check it explicitly.

Output
•	The output should be printed on the console.
•	On a separate line, print the output of the corresponding command
•	On the last line, print the final array in square brackets with its elements separated by a comma and a space 
•	See the examples below to get a better understanding of your task

Constraints
•	The number of input lines will be in the range [2 … 50].
•	The array elements will be integers in the range [0 … 1000].
•	The number of elements will be in the range [1 .. 50]
•	The split index will be an integer in the range [-231 … 231 – 1]
•	first/last count will be an integer in the range [1 … 231 – 1]
•	There will not be redundant whitespace anywhere in the input
•	Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.

 */
using System;
using System.Collections.Generic;
using System.Linq;

class ArrayModifier
{
    static void Main()
    {
        List<long> arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end")
                break;

            string[] splitInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = splitInput[0];

            int count = 0;  // will hold the count for the commands that require it
            string evenOrOdd = "";  // will hold information if the user wants even or odd numbers
            List<long> elements = new List<long>();  // will hold only the odd/even elements, depending on the command
            switch (command)
            {
                case "exchange":
                    int exchangeIndex = int.Parse(splitInput[1]);

                    if (exchangeIndex >= arr.Count || exchangeIndex < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    arr = HandleExchangeCommand(arr, exchangeIndex);
                    break;
                case "max":
                    evenOrOdd = splitInput[1];

                    if (evenOrOdd == "even")
                        elements = GetEvenElements(arr);
                    else
                        elements = GetOddElements(arr);

                    if (elements.Count() == 0)
                    {
                        Console.WriteLine("No matches");
                        continue;
                    }

                    Console.WriteLine(arr.LastIndexOf(elements.Max()));
                    break;
                case "min":
                    evenOrOdd = splitInput[1];

                    if (evenOrOdd == "even")
                        elements = GetEvenElements(arr);
                    else
                        elements = GetOddElements(arr);

                    if (elements.Count == 0)
                    {
                        Console.WriteLine("No matches");
                        continue;
                    }

                    Console.WriteLine(arr.LastIndexOf(elements.Min()));
                    break;
                case "first":
                    count = int.Parse(splitInput[1]);

                    if (count > arr.Count || count <= 0)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    evenOrOdd = splitInput[2];

                    if (evenOrOdd == "even")
                        elements = GetEvenElements(arr);
                    else
                        elements = GetOddElements(arr);

                    Console.WriteLine("[" + string.Join(", ", elements.Take(count)) + "]");
                    break;
                case "last":
                    count = int.Parse(splitInput[1]);

                    if (count > arr.Count || count <= 0)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    evenOrOdd = splitInput[2];

                    if (evenOrOdd == "even")
                        elements = GetEvenElements(arr);
                    else
                        elements = GetOddElements(arr);

                    elements.Reverse();  // we get the last elements by reversing the array and getting the first elements of the now reversed array
                    // because they want us to print the elements as they were ordered originally, we need to reverse the order of the last elements again
                    Console.WriteLine("[" + string.Join(", ", elements.Take(count).Reverse()) + "]");
                    break;
            }
        }
        Console.WriteLine($"[{string.Join(", ", arr)}]");

    }

    static List<long> GetOddElements(List<long> list)
    {
        return list.Select(x => x).Where(x => x % 2 != 0).ToList();
    }

    static List<long> GetEvenElements(List<long> list)
    {
        return list.Select(x => x).Where(x => x % 2 == 0).ToList();
    }

    static List<long> HandleExchangeCommand(List<long> list, int index)
    {
        List<long> firstPart = list.GetRange(0, index+1);
        List<long> secondPart = list.GetRange(index+1, list.Count - (index+1));
        return secondPart.Concat(firstPart).ToList();
    }
}