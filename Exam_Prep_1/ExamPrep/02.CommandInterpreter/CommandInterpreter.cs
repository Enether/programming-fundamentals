using System;
using System.Linq;


class CommandInterpreter
{
    const string INVALID_INPUT = "Invalid input parameters.";
    static void Main(string[] args)
    {
        string[] collection = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        // commands
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "end")
                break;

            string[] commandInfo = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int start = -1;
            int count = -1;
            switch (commandInfo[0])
            {
                case "reverse":
                    start = int.Parse(commandInfo[2]);

                    count = int.Parse(commandInfo[4]);
                    if (start < 0 || start >= collection.Length)
                    {
                        Console.WriteLine(INVALID_INPUT);
                        continue;
                    }
                    ReversePortionOfArr(collection, start, count);
                    break;
                case "sort":
                    start = int.Parse(commandInfo[2]);
                    count = int.Parse(commandInfo[4]);
                    if (start < 0 || start >= collection.Length)
                    {
                        Console.WriteLine(INVALID_INPUT);
                        continue;
                    }
                    SortPortionOfArr(collection, start, count);
                    break;
                case "rollLeft":
                    count = int.Parse(commandInfo[1]);
                    if (count < 0)
                    {
                        Console.WriteLine(INVALID_INPUT);
                    }
                    else
                    {
                        RollLeft(collection, count);
                    }
                    break;
                case "rollRight":
                    count = int.Parse(commandInfo[1]);
                    if (count < 0)
                    {
                        Console.WriteLine(INVALID_INPUT);
                    }
                    else
                    {
                        RollRight(collection, count);
                    }
                    break;
            }

        }

        Console.WriteLine($"[{string.Join(", ", collection)}]");
    }

    static void ReversePortionOfArr(string[] arr, int start, int count)
    {
        string[] originalArr = new string[arr.Length];
        Array.Copy(arr, originalArr, arr.Length);

        try
        {
            // split array into two parts and reverse the one between
            var firstPart = new string[start];
            Array.Copy(arr, 0, firstPart, 0, start);

            var midPart = new string[count];
            Array.Copy(arr, start, midPart, 0, count);
            Array.Reverse(midPart);

            var lastPart = new string[arr.Length - (start + count)];
            Array.Copy(arr, start + count, lastPart, 0, arr.Length - (start + count));

            Array.Copy(firstPart, 0, arr, 0, firstPart.Length);
            Array.Copy(midPart, 0, arr, firstPart.Length, midPart.Length);
            Array.Copy(lastPart, 0, arr, firstPart.Length + midPart.Length, lastPart.Length);
        }
        catch
        {
            //Array.Copy(originalArr, arr, arr.Length);
            Console.WriteLine(INVALID_INPUT);
        }
    }
    static void SortPortionOfArr(string[] arr, int start, int count)
    {
        string[] originalArr = new string[arr.Length];
        Array.Copy(arr, originalArr, arr.Length);
        try
        {
            // split array into two parts and reverse the one between
            var firstPart = new string[start];
            Array.Copy(arr, 0, firstPart, 0, start);

            var midPart = new string[count];
            Array.Copy(arr, start, midPart, 0, count);
            Array.Sort(midPart);

            var lastPart = new string[arr.Length - (start + count)];
            Array.Copy(arr, start + count, lastPart, 0, arr.Length - (start + count));

            Array.Copy(firstPart, 0, arr, 0, firstPart.Length);
            Array.Copy(midPart, 0, arr, firstPart.Length, midPart.Length);
            Array.Copy(lastPart, 0, arr, firstPart.Length + midPart.Length, lastPart.Length);
        }
        catch
        {
            // Array.Copy(originalArr, arr, arr.Length);
            Console.WriteLine(INVALID_INPUT);
        }
    }

    static void RollLeft(string[] arr, int count)
    {
        count = count % arr.Length;

        for (int i = 0; i < count; i++)
        {
            // roll once
            string firstEl = arr[0];
            for (int j = 1; j < arr.Length; j++)
            {
                arr[j - 1] = arr[j];
            }
            arr[arr.Length - 1] = firstEl;
        }
    }

    static void RollRight(string[] arr, int count)
    {
        count = count % arr.Length;
        for (int i = 0; i < count; i++)
        {
            // roll once
            string lastEl = arr[arr.Length - 1];
            for (int j = arr.Length - 1; j >= 1; j--)
            {
                arr[j] = arr[j - 1];
            }
            arr[0] = lastEl;
        }
    }
}
