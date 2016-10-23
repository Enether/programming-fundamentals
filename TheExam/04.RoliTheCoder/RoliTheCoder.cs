/*
Roli is really busy with the recently started JS Core and DB Fundamentals modules at SoftUni. She is used to going out with friends on a various events. However, when the times comes, you need to tell her to start coding.
Roli is the organizer of those events, so she needs to keep track of the unique participants for each event. She saves the events by 'ID', which is the unique code for each event. For each ID, she keeps the event name and the participants for it.
She receives request in the following format:
•	{id} #{eventName} @{participant1} @{participant2} … @{participantN}
If she is given event in an invalid format (such as without a hashtag), she ignores that line of input. If she is given ID that already exists she needs to check if the eventName is the same. If it is, she adds the participants from the request to the other registered participants. If the event id exists but the name doesn’t, it is invalid and you need to ignore it.
After you receive "Time for Code", you need to print the results. All events must be sorted by participant count in descending order and then by alphabetical order. For each event, the participants must be sorted in alphabetical order.

Input / Constrains
•	Unil you receive “Time for Code” you will get lines of input in which everything is separated by one or more blank spaces
•	Until you receive "Time for Code", you will be receiving events in the following format:
o	{id} #{eventName} @{participant1} @{participant2} … @{participantN}

Output
•	All events must be sorted in descending order by participant count and then by alphabetical order. For each event you need to print:
o	{eventName} – {participantCount}
•	On the next lines you need to print all participants. All participants for an event must be sorted alphabetically.

 */
using System;
using System.Collections.Generic;
using System.Linq;

// 100/100!
class RoliTheCoder
{
    static void Main()
    {
        Dictionary<string, HashSet<string>> eventAndParticipants = new Dictionary<string, HashSet<string>>();
        Dictionary<int, string> eventIDs = new Dictionary<int, string>();  // holds associations for events and their IDs

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Time for Code")
                break;

            string[] inputParams = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int id = int.Parse(inputParams[0]);
            string eventName = inputParams[1];

            if (eventName[0] != '#')  // skip the input line if the event name doesn't start with #
                continue;
            else
                eventName = eventName.Substring(1);  // the event is valid, so we remove the hashtag in it's name (ex: #BeerJS => BeerJS)

            if (eventIDs.ContainsKey(id))
            {
                if (eventIDs[id] != eventName)  // check if the given id is associated with the event
                {
                    continue;  // eventName is invalid for the ID
                }

                // else, we continue on to adding the participants
            }
            else
            {
                // add the id and event
                eventIDs[id] = eventName;
                eventAndParticipants[eventName] = new HashSet<string>();
            }

            // get the participants and add them to the event
            string[] participants = inputParams.Skip(2).ToArray();
            foreach (var participant in participants)
            {
                eventAndParticipants[eventName].Add(participant);
            }
        }

        // order the dictionary
        var orderedEvents = eventAndParticipants
            .OrderByDescending(x => x.Value.Count)  // count of participants
            .ThenBy(x => x.Key) // event name
            .ToDictionary(x => x.Key, y => y.Value);

        PrintResults(orderedEvents);
            
    }
    static void PrintResults(Dictionary<string, HashSet<string>> orderedEvents)
    {
        foreach (var eventPair in orderedEvents)
        {
            string eventName = eventPair.Key;
            var eventParticipants = eventPair.Value.OrderBy(name => name);  // order the participants by their name alphabetically

            Console.WriteLine($"{eventName} - {eventParticipants.Count()}");
            // print the event's participants
            foreach (var participant in eventParticipants)
            {
                Console.WriteLine(participant);
            }
        }
    }
}
