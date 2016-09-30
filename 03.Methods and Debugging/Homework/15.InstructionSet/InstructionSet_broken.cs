/*
The goal of this exercise is to practice debugging techniques in scenarios where a piece of code does not work
correctly. Your task is to pinpoint the bug and fix it (without rewriting the entire code).
You can download the broken solution from here.

Problem Description
Write an instruction interpreter that executes an arbitrary number of instructions. The program should parse the
instructions, execute them and print the result. The following instruction set should be supported:


 INC &lt;operand1&gt; – increments the operand by 1
 DEC &lt;operand1&gt; – decrements the operand by 1
 ADD &lt;operand1&gt; &lt;operand2&gt; – performs addition on the two operands
 MLA &lt;operand1&gt; &lt;operand2&gt; – performs multiplication on the two operands
 END – end of input

Output
The result of each instruction should be printed on a separate line on the console.

Constraints
 The operands will be valid integers in the range [−2 147 483 648 … 2 147 483 647].
*/

using System;

class InstructionSet_broken
{
    static void Main()
    {
        string opCode = Console.ReadLine();

        while (opCode != "END")
        {
            string[] codeArgs = opCode.Split(' ');

            long result = 0;
            switch (codeArgs[0])
            {
                case "INC":
                    {
                        long operandOne = long.Parse(codeArgs[1]);
                        result = ++operandOne;
                        break;
                    }
                case "DEC":
                    {
                        long operandOne = long.Parse(codeArgs[1]);
                        result = --operandOne;
                        break;
                    }
                case "ADD":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        int operandTwo = int.Parse(codeArgs[2]);
                        result = (long)operandOne + operandTwo;
                        break;
                    }
                case "MLA":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        int operandTwo = int.Parse(codeArgs[2]);
                        result = (long)operandOne * operandTwo;
                        break;
                    }
            }

            Console.WriteLine(result);

            opCode = Console.ReadLine();
        }
    }
}