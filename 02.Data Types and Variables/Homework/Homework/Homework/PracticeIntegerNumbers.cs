/*
 Create a new C# project and create a program that assigns integer values to variables.
 Be sure that each value is stored in the correct variable type (try to find the most suitable variable type in order to save memory).
 Finally, you need to print all variables to the console.
 */

class PracticeIntegerNumbers
{
    static void Main()
    {
        sbyte negativeOneHundred = -100;
        byte oneHundredTwentyEight = 128;
        short negativeThreeThousand = -3540;
        ushort sixtyFourThousand = 64876;
        uint intMaxPlusOne = 2147483648;
        int minusOneTrillion = -1141583228;
        long bigNumber = -1223372036854775808;

        System.Console.WriteLine(negativeOneHundred);
        System.Console.WriteLine(oneHundredTwentyEight);
        System.Console.WriteLine(negativeThreeThousand);
        System.Console.WriteLine(sixtyFourThousand);
        System.Console.WriteLine(intMaxPlusOne);
        System.Console.WriteLine(minusOneTrillion);
        System.Console.WriteLine(bigNumber);
    }
}

