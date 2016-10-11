/*
 You are mentor of a group. You have done your job well and now you have to generate a report about your group's activity.
 You will be given usernames and dates ("dd/MM/yyyy"), dates (if any) are separated with comma, until you receive command "end of dates". 
 After that you will receive user and some comment (separated with dash). You can add comment for every user who is in your group 
 (if not ignore the line). Adding comment/date to same user more than once should append to that user the comment/date. 
 Upon receiving command "end of comments" you should generate report in format:
{user} -
Comments:
- {firstComment} …
Dates attended:
-- {firstDate}
-- {secondDate}
Users should be printed ordered by name (ascending). For every user dates should be sorted again in ascending order.
Input will be valid for in the format described - you should not check it explicitly!
 */
using System;
using System.Collections.Generic;

class MentorGroup
{
    // I really should start doing these exercises with CLASSES

    static void Main()
    {
        // ex: Key: Nakov, Value: Dictionary {Key: comments, Value: List ("He's a raging alcoholic", "But also really funny")}
        SortedDictionary<string, Dictionary<string, List<string>>> students = new SortedDictionary<string, Dictionary<string, List<string>>>();

        // read dates
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "end of dates")
                break;

            string[] dateInfo = command.Split(new char[] { ' ', ',' /*maybe separate splits*/}, StringSplitOptions.RemoveEmptyEntries);
            string studentName = dateInfo[0];
            // everything onwards in dateInfo is a date
            // read the dates
            List<string> dates = new List<string>();
            for (int i = 1; i < dateInfo.Length; i++)
            {
                dates.Add(dateInfo[i]);
            }

            if (!students.ContainsKey(studentName))
            {
                students[studentName] = new Dictionary<string, List<string>>() { { "dates", new List<string>() }, { "comments", new List<string>() } };
            }
            students[studentName]["dates"].AddRange(dates); // add the dates
        }

        // read comments
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "end of comments")
                break;

            string[] commentInfo = command.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            string studentName = commentInfo[0];

            if (!students.ContainsKey(studentName))
                continue;  // skip line if we don't have the student registered
            string comment = commentInfo[1];


            // add the comment
            students[studentName]["comments"].Add(comment);
        }

        // print results
        foreach (var student in students)
        {
            Console.WriteLine(student.Key);

            // print comments
            Console.WriteLine("Comments:");
            foreach (var comment in student.Value["comments"])
            {
                Console.WriteLine($"- {comment}");
            }

            // print dates sorted
            student.Value["dates"].Sort();
            Console.WriteLine("Dates attended:");
            foreach (var date in student.Value["dates"])
            {
                Console.WriteLine($"-- {date}");
            }
        }
    }
}
