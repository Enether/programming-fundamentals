using System;

/*
 Find online more information about ASCII (American Standard Code for Information Interchange)
 and write a program that prints part of the ASCII table of characters at the console. 
 On the first line of input you will receive the char index you should start with
 and on the second line - the index of the last character you should print.
*/
class PrintPartOfAschiiTable
{
    static void Main()
    {
        int firstIndex = int.Parse(Console.ReadLine());
        int lastIndex = int.Parse(Console.ReadLine());
        for (int i = firstIndex; i <= lastIndex; i++)
        {
            Console.Write((char)(i) + " ");
        }
    }
}
