/*
 Mighty battle is coming. In the stormy nether realms, demons are fighting against each other for supremacy in a duel from which only one will survive. 
Your job, however is not so exciting. You are assigned to sign in all the participants in the nether realm's mighty battle's demon book, which of course is sorted alphabetically. 
A demon's name contains his health and his damage. 
The sum of the asci codes of all characters (excluding numbers (0-9), arithmetic symbols ('+', '-', '*', '/') and delimiter dot ('.')) gives a demon's total health. 
The sum of all numbers in his name forms his base damage. Note that you should consider the plus '+' and minus '-' signs (e.g. +10 is 10 and -10 is -10). 
However, there are some symbols ('*' and '/') that can further alter the base damage by multiplying or dividing it by 2 
(e.g. in the name "m15* /c-5.0", the base damage is 15 + (-5.0) = 10 and then you need to multiply it by 2 (e.g. 10 * 2 = 20)
and then divide it by 2 (e.g. 20 / 2 = 10)). 
So, multiplication and division are applied only after all numbers are included in the calculation and in the order they appear in the name.
You will get all demons on a single line, separated by commas and zero or more blank spaces.
Sort them in alphabetical order and print their names along their health and damage.

Input
The input will be read from the console.The input consists of a single line containing all demon names
separated by commas and zero or more spaces in the format: "{demon name}, {demon name}, … {demon name}"

Output
Print all demons sorted by their name in ascending order, each on a separate line in the format:
•	"{demon name} - {health points} health, {damage points} damage"

Constraints
•	A demon's name will contain at least one character
•	A demon's name cannot contain blank spaces ' ' or commas ','
•	A floating point number will always have digits before and after its decimal separator
•	Number in a demon's name is considered everything that is a valid integer or floating point number (with dot '.' used as separator). For example, all these are valid numbers: '4', '+4', '-4', '3.5', '+3.5', '-3.5' 

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// 100/100!
namespace _03.ThirdProblem
{
    class NetherRealms
    {
        static void Main()
        {
            string[] demonNames = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // List of Demons, sorted by their name alphabetically
            List<Demon> orderedDemons = GetDemons(demonNames).OrderBy(demon => demon.Name).ToList();

            // print demons
            PrintDemons(orderedDemons);
        }

        static void PrintDemons(List<Demon> demons)
        {
            foreach (Demon demon in demons)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }

        static List<Demon> GetDemons(string[] demonNames)
        {
            List<Demon> demons = new List<Demon>();

            foreach (var demonName in demonNames)
            {
                int demonHealth = ExtractDemonHealth(demonName);
                decimal demonDamage = ExtractDemonDamage(demonName);

                List<char> arithmeticSymbols = ExtractArithmeticSymbols(demonName);

                // modify damage by looping through the mul/div symbols
                foreach (var symbol in arithmeticSymbols)
                {
                    if (symbol == '*')
                        demonDamage *= 2;  // multiply the damage
                    else  // == '/'
                        if (demonDamage != 0)
                        demonDamage /= 2;  //  divide by two
                }

                demons.Add(new Demon(demonName, demonHealth, demonDamage));
            }

            return demons;
        }

        static int ExtractDemonHealth(string demonName)
        {
            // sum of all the character's ascii values  (excluding numbers, +, -, *, and /)
            string demonHealthPattern = @"[^0-9\+\-\*\/\.]";
            int demonHealth = 0;

            foreach (Match healthChar in Regex.Matches(demonName, demonHealthPattern))
            {
                demonHealth += char.Parse(healthChar.Value);
            }

            return demonHealth;
        }

        static decimal ExtractDemonDamage(string demonName)
        {
            // sum of all the numbers in a demon's name
            decimal demonDamage = 0M;

            foreach (Match number in Regex.Matches(demonName, @"(-|\+|)\d+\.?\d*"))
            {
                demonDamage += decimal.Parse(number.Value);
            }

            return demonDamage;
        }

        static List<char> ExtractArithmeticSymbols(string demonName)
        {
            // Extract all the * and / symbols from the name. The order in which we store them matters because they are
            // going to be used to do their respective operations
            List<char> arithmeticSymbols = new List<char>();

            foreach (Match specialSymbol in Regex.Matches(demonName, @"(\*|\/)"))
            {
                arithmeticSymbols.Add(char.Parse(specialSymbol.Value));
            }

            return arithmeticSymbols;
        }
    }

    class Demon
    {
        public string Name;
        public int Health;
        public decimal Damage;

        public Demon(string name, int health, decimal damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }
    }
}

