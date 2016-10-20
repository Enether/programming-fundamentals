/*
 Cubic is a veteran soldier from The Great Cubic Army. He has even participated in the Spherical Invasion as a Sergeant First Class. As a veteran, Cubic has some personal security issues – he communicates only trough text messages and sends them in a specific encrypted way, which you must decrypt in order to understand what he is saying.
You will begin receiving lines of input, which will consist of random ASCII characters – Cubic’s encrypted lines. After each line you will receive a number – the length of the message he sent. Cubic might send false messages, in an act to confuse his “enemies”. You must capture only the messages that follow a certain format. 
According to that format the valid messages:
•	Consist of m characters, where m is the integer entered after each encrypted line.  
•	Has only digits before itself in the encrypted line
•	Consists only of English alphabet letters
•	Has no English alphabet letters after itself in the encrypted line
Any message that does not follow the, specified above, rules, is invalid, and you must ignore it.
After you find all valid messages, you need to find their verification code. Every message has its own verification code, which Cubic gives in order to verify the message. Take all the digits before the message and all the digits after the message and consider them as indexes. If they are valid existing indexes in the message, form a string with those indexes taking characters from the message. If an index is nonexistent, put a space there. The string you form up is the verification code for the current message. 

Input
•	The input will always come in the form of 2 lines, except when it is the line terminating the input sequence.
•	The first input line will contain random ASCII characters, and the second – a number.
•	When the line “Over!” is entered, the input sequence ends. 

Output
•	The output is simple. You must print all the valid messages you’ve found, each on a new line, and their verification codes, if they have such.
•	The format of output is “{message} == {verificationCode}”.

Constraints
•	The input lines can consist of ANY ASCII character.
•	There will be NO such cases as an encrypted message without a number before it.
•	The number will be a valid integer in the range [0, 100].
•	Allowed time/memory: 100ms/16MB

 */
using System;
using System.Text.RegularExpressions;

class CubicMessages
{
    static void Main()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Over!")
                break;
            int length = int.Parse(Console.ReadLine());

            var splitMessage = SplitMessage(input); // tuple containing Digits, the Message and the Rest. Null if the message is not valid

            if (splitMessage == null)
                continue;  // message is not valid, skip it

            string digits = splitMessage.Item1;
            string message = splitMessage.Item2;
            if (length != message.Length)
            {
                // ignore the message if the length is not correct
                continue;
            }
            string rest = splitMessage.Item3;
            string allDigits = digits + GetDigitsInRest(rest);

            // iterate over all the digits and try to get the char at the index of each digit from the message. if the index is invalid, add space ' '
            string modifiedMessage = "";
            for (int i = 0; i < allDigits.Length; i++)
            {
                int index = int.Parse(allDigits[i].ToString());
                if (index >= message.Length)
                    modifiedMessage += ' ';  // invalid index
                else
                    modifiedMessage += message[index];
            }

            Console.WriteLine($"{message} == {modifiedMessage}");
        }
    }

    static Tuple<string, string, string> SplitMessage(string command)
    {
        /*
            Splits the given message, the constraints are the following:
            {digits}{message}{rest}
            digits must contain only numbers
            message should contain only ENGLISH letters
            rest can contain anything EXCEPT ENGLISH letters

        So what we do is:
        Read the digits
        Read the message until we find a symbol that's not an english letter
        Read the rest, where if we find an english letter in the REST, we return Null
            */

        // get the digits before the message
        string digits = "";
        int count = 0;
        while (count < command.Length)
        {
            char currentChar = command[count];
            if (!char.IsDigit(currentChar))
                break;
            digits += currentChar;
            count++;
        }

        // read the message
        string message = "";
        while (count < command.Length)
        {
            char currentChar = command[count];
            if (currentChar < 65 || (currentChar > 90 && currentChar < 97) || currentChar > 122)
                break;  // if it's not an english letter
            message += currentChar;
            count++;
        }

        // read the rest
        string rest = "";
        while (count < command.Length)
        {
            char currentChar = command[count];
            if (!(currentChar < 65 || (currentChar > 90 && currentChar < 97) || currentChar > 122))
                return null;  // if it's an english letter, directly return Null because the message is invalid
            rest += currentChar;
            count++;
        }

        return new Tuple<string, string, string>(digits, message, rest);
    }

    static string GetDigitsInRest(string rest)
    {
        string digits = "";

        foreach (Match rest_match in Regex.Matches(rest, @"\d"))
        {
            digits += rest_match.Value;
        }

        return digits;
    }
}
