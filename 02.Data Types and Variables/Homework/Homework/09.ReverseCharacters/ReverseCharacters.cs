using System;

/*
 Write a program to ask the user for 3 letters and print them in reversed order
*/
class ReverseCharacters
{
    static void Main()
    {
        char firstLetter = char.Parse(Console.ReadLine());
        char secondLetter = char.Parse(Console.ReadLine());
        char thirdLetter = char.Parse(Console.ReadLine());

        string reversedString = thirdLetter.ToString() + secondLetter + firstLetter;
        Console.WriteLine(reversedString);
    }
}
