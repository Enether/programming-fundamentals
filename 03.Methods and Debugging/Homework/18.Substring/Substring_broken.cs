/*
The goal of this exercise is to practice debugging techniques in scenarios where a piece of code does not work
correctly. Your task is to pinpoint the bug and fix it (without rewriting the entire code). Test your fixed solution in
the judge system:


Problem Description

You are given a text and a number count. Your program should search through the text for the letter 'p' (ASCII code
112) and print 'p' along with count letters to its right.
For example, we are given the text "phahah put" and count = 3. We find a match of 'p' in the first letter so we print
it and the 3 letters to its right. The result is "phah". We continue and find another match of 'p', but there aren't 3
letters to its right, so we print only "put"

Each match should be printed on a separate line. If there are no matches of 'p' in the text, we print "no".

Input

 The first line holds the text to be processed (string).
 The second line holds the number count.

Output
For each match, print the matched substring at separate line. Print &quot;no&quot; if there are no matches.

Constraints
 The number count will be in the range [0 ... 100].
*/
using System;

public class Substring_broken
{
	public static void Main()
	{
		string text = Console.ReadLine();
		int jump = int.Parse(Console.ReadLine());

		const char SEARCHED_CHAR = 'p';
		bool hasMatch = false;

		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] == SEARCHED_CHAR)
			{
				hasMatch = true;

				if (i + jump >= text.Length)  
                    // if we go over the text's length, lower the length of the substring to the exact end of the string itself
                    // if str.Length = 7, i = 5 and jump = 3, we need to lower jump to 2 as to not go over the bounds of the string
                    jump = text.Length-1 - i;

				string matchedString = text.Substring(i, jump + 1);
				Console.WriteLine(matchedString);
				i += jump;
			}
		}

		if (!hasMatch)
		{
			Console.WriteLine("no");
		}
	}
}
