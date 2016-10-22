/*
You are matrix operator chief, but you are tired of doing your job manually. You want to write a program, that will automate the process. The information you are processing comes from your boss, and he wants to see daily reports for the job.
You are given a table of integers. For that table you will need to execute some commands.
The commands are the following: remove, swap and insert. All commands come with 2 additional parameters. 
The remove command – type and position.
The type can be one of the following – positive / negative / odd / even. That means that you will need to remove said elements from the given row / col.
The position will be in the following format: {row / col index}.
The swap command – the 2 rows that you need to swap.
The insert command – row and number that you need to insert at the beginning of the given row.
The input stops once you receive the “end” command, and then you need to print the table after all operations.

Input
On the first line you will receive integer r – rows.
On the next r lines, you will receive the elements for each row.
On the next lines, you will receive commands in the following format:
remove {type} {position}
swap {firstRow} {secondRow}
insert {row} {element}
The input stops when you receive the command “end”.

Output
The output should consist of the matrix after all commands have been executed.

Constraints
The rows of the table will be in range [1…30].
The columns of each row will be in range [0…30].
The elements of the table will be integers in the range [-2,147,483,648…2,147,483,647].
The commands will always be valid and in the given format.
*/
using System;
using System.Collections.Generic;
using System.Linq;

class MatrixOperator
{
    static void Main(string[] args)
    {
        int matrixRows = int.Parse(Console.ReadLine());
        int[][] matrix = new int[matrixRows][];
        for (int i = 0; i < matrixRows; i++)
        {
            int[] row = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            matrix[i] = row;
        }

        // handle commands
        while (true)
        {
            string input = Console.ReadLine();

            if (input == "end")
                break;

            string[] commandInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch(commandInfo[0])
            {
                case "remove":
                    string removeType = commandInfo[1];
                    string rowOrCol = commandInfo[2]; // string indicating where to remove ex: "col" will remove every element from the given column
                    int rowOrColIndex = int.Parse(commandInfo[3]);
                    HandleRemoveCommand(removeType, rowOrCol, rowOrColIndex, matrix);
                    break;
                case "swap":
                    // swap two rows
                    int firstRowIdx = int.Parse(commandInfo[1]);
                    int secondRowIdx = int.Parse(commandInfo[2]);

                    // swap
                    int[] firstRow = matrix[firstRowIdx];
                    matrix[firstRowIdx] = matrix[secondRowIdx];
                    matrix[secondRowIdx] = firstRow;
                    break;
                case "insert":
                    // insert number at the beggining of row
                    int rowIndex = int.Parse(commandInfo[1]);
                    int elementToInsert = int.Parse(commandInfo[2]);
                    List<int> tempList = matrix[rowIndex].ToList();
                    tempList.Insert(0, elementToInsert);
                    matrix[rowIndex] = tempList.ToArray();
                    break;
            }
        }
        PrintMatrix(matrix);
    }

    static void HandleRemoveCommand(string removeType, string rowOrCol, int index, int[][] matrix)
    {
        if (rowOrCol == "row")
        {
            // remove from row
            int[] updatedRow = null;
            switch (removeType)
            {
                case "even":
                    // get only odd elements
                    updatedRow = matrix[index].Where(x => x % 2 != 0).Select(x => x).ToArray();
                    break;
                case "odd":
                    // get only even elements
                    updatedRow = matrix[index].Where(x => x % 2 == 0).Select(x => x).ToArray();
                    break;
                case "positive":
                    // get only negative elements
                    updatedRow = matrix[index].Where(x => x < 0).Select(x => x).ToArray();
                    break;
                case "negative":
                    // get only positive elements
                    updatedRow = matrix[index].Where(x => x >= 0).Select(x => x).ToArray();
                    break;
            }

            matrix[index] = updatedRow;
        }
        else
        {
            // through cols
            for (int row = 0; row < matrix.Length; row++)
            {
                if (matrix[row].Length > index)  // if there is a col at the desired position in the current row
                {
                    List<int> tempList = matrix[row].ToList();

                    if (removeType == "even" && tempList[index] % 2 == 0)
                        tempList.RemoveAt(index);
                    else if (removeType == "odd" && tempList[index] % 2 != 0)
                        tempList.RemoveAt(index);
                    else if (removeType == "positive" && tempList[index] >= 0)
                        tempList.RemoveAt(index);
                    else if (removeType == "negative" && tempList[index] < 0)
                        tempList.RemoveAt(index);

                    matrix[row] = tempList.ToArray();
                }
            }
        }

    }

    static void PrintMatrix(int[][] matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}

