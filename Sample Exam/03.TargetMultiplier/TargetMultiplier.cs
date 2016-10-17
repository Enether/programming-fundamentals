/*
 Write a program which reads from the console dimensions of a matrix and matrix elements values. Get a targeted cell and multiply its value with the sum of all neighboring cells. The neighboring cells must change their values too. Each one should be the product of its initial value and the initial value of the targeted cell. Then print on the console updated matrix. 
Input
The input data should be read from the console:
•	The first line holds the number of rows – R and columns – C, separated by space.
•	The next R lines hold the matrix values. Each line holds C integers, separated by space.
•	The last line holds the position (targeted row and targeted col) of the targeted cell, separated by space
The input data will always be valid and in the format described. There is no need to check it explicitly

Output
The output should be printed on the console. The elements of each row should be separated by space.


Constraints
•	The dimensions of the matrix (R and C) will be a positive integer numbers in the range [3...20].
•	The values of the cells will be an integer numbers in range [-16,300... 16,300].
•	The targeted row will be an integer number in the range [1...R-2].
•	The targeted column will be an integer number in the range [1...C-2].

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TargetMultiplier
{
    static void Main()
    {
        long[,] matrix = BuildMatrix();
        string[] targetDimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int targetRow = int.Parse(targetDimensions[0]);
        int targetCol = int.Parse(targetDimensions[1]);

        matrix = ModifyMatrix(matrix, targetRow, targetCol);

        PrintMatrix(matrix);
    }

    static long[,] ModifyMatrix(long[,] matrix, int targetRow, int targetCol)
    {
        /* this method gets the sum of all of the neighbours
         * modifies all of them, multiplying the neighbour with the target
           and then multiplies the target with the sum of the neighbours   */
        long neighboursSum = 0;
        for (int row = targetRow - 1; row <= targetRow + 1; row++)
        {
            for (int col = targetCol - 1; col <= targetCol + 1; col++)
            {
                if (row != targetRow || col != targetCol)
                {
                    neighboursSum += matrix[row, col];
                    matrix[row, col] *= matrix[targetRow, targetCol];
                }
            }
        }
        matrix[targetRow, targetCol] *= neighboursSum;

        return matrix;
    }

    static long[,] BuildMatrix()
    {
        /* read the input and build the matrix */
        string[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        long[,] matrix = new long[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            long[] inputRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            // parse each number from the row to the matrix
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = inputRow[col];
            }
        }

        return matrix;
    }

    static void PrintMatrix(long[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}
