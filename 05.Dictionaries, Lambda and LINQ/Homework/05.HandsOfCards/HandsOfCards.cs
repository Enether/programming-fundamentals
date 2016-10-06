/*
 You are given a sequence of people and for every person what cards he draws from the deck. The input will be separate lines in the format:
{personName}: {PT, PT, PT,… PT}
Where P (2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A) is the power of the card and T (S, H, D, C) is the type. The input ends when a "JOKER" is drawn. The name can contain any ASCII symbol except ':'. The input will always be valid and in the format described, there is no need to check it.
A single person cannot have more than one card with the same power and type, if he draws such a card he discards it. The people are playing with multiple decks. Each card has a value that is calculated by the power multiplied by the type. Powers 2 to 10 have the same value and J to A are 11 to 14. Types are mapped to multipliers the following way (S -> 4, H-> 3, D -> 2, C -> 1).
Finally print out the total value each player has in his hand in the format:
{personName}: {value}
 */
using System;
using System.Collections.Generic;
using System.Linq;

class HandsOfCards
{
    static Dictionary<char, int> CARD_TYPE_MULTIPLIERS = new Dictionary<char, int>(){
        { 'S', 4 }, { 'H', 3 }, { 'D', 2 }, { 'C',1 } };
    static Dictionary<string, int> CARD_TYPE_POWERS = new Dictionary<string, int>()
    {
        {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10}, {"J", 11}, {"Q", 12}, {"K", 13}, {"A", 14}
    };

    static void Main()
    {
        string input = "";
        char[] separators = {' ', ',' };
        Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();

        while (true)
        {
            input = Console.ReadLine();
            if (input == "JOKER")
                break;
            // separate the name from his hand
            string[] inputInfo = input.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            string name = inputInfo[0];
            if (!players.ContainsKey(name))
                players[name] = new Dictionary<string, int>() { { "sum", 0} };

            string[] handInfo = inputInfo[1].Split(separators, StringSplitOptions.RemoveEmptyEntries);
            AddHand(handInfo, name, players);
        }

        foreach (var pair in players)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value.Values.Sum()}");
        }
    }

    static void AddHand(string[] hand, string name, Dictionary<string, Dictionary<string, int>> players)
    {
        // iterate through the cards
        for (int i = 0; i < hand.Length; i++)
        {
            string cardStr = hand[i];
            if (!players[name].ContainsKey(cardStr)) // add the card only if he doesn't have it
            {
                players[name][cardStr] = GetCardPower(cardStr);
            }
        }
    }

    static int GetCardPower(string card)
    {
        // sample card is 10C, we get the multiplier for C and parse the number, then return the result
        int multiplier = CARD_TYPE_MULTIPLIERS[card[card.Length - 1]];

        string number = "";
        for (int i = 0; i < card.Length-1; i++)
        {
            number += card[i];
        }

        return multiplier * CARD_TYPE_POWERS[number];
    }
}
