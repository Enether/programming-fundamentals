using System;

/*
 Write a program to read an integer n and print all triples of the first n small Latin letters, ordered alphabetically:
     */

class TriplesOfLetters
{
    private const int LOWER_A_ASCII_POS = 97;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[] ch = FillCharArray(3);
        GetTriples(ch, 0, n);
    }

    private static void GetTriples(char[] ch, int pos, int max)
    {
        /* recursive function to get all possible permutations without repetitions */
        if (pos == ch.Length)
        {
            Console.WriteLine(ch);
            return;
        }
        for (int i = 0; i < max; i++)
        {
            ch[pos] = (char)(LOWER_A_ASCII_POS + i);
            GetTriples(ch, pos + 1, max);
        }
    }

    private static char[] FillCharArray(int length)
    {
        char[] chrArray = new char[length];

        for (int i = 0; i < length; i++)
        {
            chrArray[i] = 'a';
        }

        return chrArray;
    }
}

