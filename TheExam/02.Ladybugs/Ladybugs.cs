/*
 You are given a field size and the indexes of ladybugs inside the field. After that on every new line until the "end" command is given, a ladybug changes its position either to its left or to its right by a given fly length. 
A command to a ladybug looks like this: "0 right 1". This means that the little insect placed on index 0 should fly one index to its right. If the ladybug lands on a fellow ladybug, it continues to fly in the same direction by the same fly length. If the ladybug flies out of the field, it is gone.
For example, imagine you are given a field with size 3 and ladybugs on indexes 0 and 1. If the ladybug on index 0 needs to fly to its right by the length of 1 (0 right 1) it will attempt to land on index 1 but as there is another ladybug there it will continue further to the right by additional length of 1, landing on index 2. After that, if the same ladybug needs to fly to its right by the length of 1 (2 right 1), it will land somewhere outside of the field, so it flies away:
 
If you are given ladybug index that does not have ladybug there, nothing happens. If you are given ladybug index that is outside the field, nothing happens. 
Your job is to create the program, simulating the ladybugs flying around doing nothing. At the end, print all cells in the field separated by blank spaces. For each cell that has a ladybug on it print '1' and for each empty cells print '0'. For the example above, the output should be '0 1 0'. 

Input
•	On the first line you will receive an integer - the size of the field
•	On the second line you will receive the initial indexes of all ladybugs separated by a blank space. The given indexes may or may not be inside the field range
•	On the next lines, until you get the "end" command you will receive commands in the format: "{ladybug index} {direction} {fly length}"

Output
•	Print the all cells within the field in format: "{cell} {cell} … {cell}"
o	If a cell has ladybug in it, print '1'
o	If a cell is empty, print '0' 

Constrains
•	The size of the field will be in the range [0 … 1000]
•	The ladybug indexes will be in the range [-2,147,483,647 … 2,147,483,647]
•	The number of commands will be in the range [0 … 100] 
•	The fly length will be in the range [-2,147,483,647 … 2,147,483,647]

 */
using System;
using System.Linq;

// 100/100 !
class SecondProblem
{
    static void Main()
    {
        int len = int.Parse(Console.ReadLine());  // length of the array
        int[] ladybugs = new int[len];  // array holding the ladybugs

        // array with the indexes of each ladybug
        int[] ladybugsPositions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        foreach (var ladybugIndex in ladybugsPositions)
        {
            // validate add the ladybug
            if (ladybugIndex >= 0 && ladybugIndex < ladybugs.Length)
                ladybugs[ladybugIndex] = 1;
        }

        // take commands
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "end")
                break;

            string[] commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int ladybugIndex = int.Parse(commandArgs[0]);  // the index of the ladybug we want to move
            string direction = commandArgs[1];  // "left" or "right"
            int step = int.Parse(commandArgs[2]);

            // validate the ladybug index and see if there even is a ladybug at the given index
            if (ladybugIndex >= ladybugs.Length || ladybugIndex < 0 || ladybugs[ladybugIndex] != 1)
                continue;

            Fly(ladybugs, ladybugIndex, step, true ? direction == "right" : false);
        }

        Console.WriteLine(string.Join(" ", ladybugs));
    }
    static void Fly(int[] ladybugs, int startIndex, int step, bool right)
    {
        /*
            Given an array with ladybugs in it and a startIndex with a ladybug on it, start moving the ladybug in the
            direction appropriate to the boolean right. If it's true, move it to the right of the array, else to the left.
            Move it until it either finds an index that's empty and can stay there or until it goes out of bounds
            */
        if (step == 0) 
            return;  // do not move the ladybug
        if (!right) // we want to move left
            step = -step;  // invert the step so that we move backwards. (ex: 1 would become -1 and we would go backwards)

        // starts flying
        ladybugs[startIndex] = 0;
        long newIndex = startIndex;

        while (true)
        {
            newIndex += step;

            if (newIndex < 0 || newIndex >= ladybugs.Length)
                break;  // flies out

            if (ladybugs[newIndex] != 1)
            {
                // found an index
                ladybugs[newIndex] = 1;
                break;
            }  // else continue modifying the index until we find a proper one
        }
    }
}