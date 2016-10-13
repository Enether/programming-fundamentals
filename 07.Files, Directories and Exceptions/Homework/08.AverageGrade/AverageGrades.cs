/*
 Define a class Student, which holds the following information about students: name, list of grades and average 
grade (calculated property, read-only). A single grade will be in range [2…6], e.g. 3.25 or 5.50.
Read a list of students and print the students that have average grade ≥ 5.00 ordered by name (ascending),
then by average grade (descending). Print the student name and the calculated average grade.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.AverageGrades
{
    class AverageGrades
    {
        const string FIRST_INPUT_PATH = "../../input/input1.txt";
        const string SECOND_INPUT_PATH = "../../input/input2.txt";
        static readonly string[] inputs = new string[] { FIRST_INPUT_PATH, SECOND_INPUT_PATH };
        const string OUTPUT_DIR_PATH = "../../output/";

        static void Main()
        {
            Directory.CreateDirectory(OUTPUT_DIR_PATH);

            for (int i = 0; i < inputs.Length; i++)
            {
                string[] input = File.ReadAllLines(inputs[i]);

                List<Student> students = ReadStudents(input);

                //  order by name and then by grades
                students = students.OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade).ToList();
                //  collect the input
                StringBuilder output = new StringBuilder();
                foreach (Student student in students.Where(x => x.AverageGrade >= 5.00))
                {
                    output.AppendLine($"{student.Name} -> {student.AverageGrade:F2}");
                }

                //  write the input
                string output_file_path = OUTPUT_DIR_PATH + "output_" + (i + 1) + ".txt";
                File.CreateText(output_file_path).Close();
                File.WriteAllText(output_file_path, output.ToString());
            }
            
        }

        static List<Student> ReadStudents(string[] input)
        {
            List<Student> students = new List<Student>();

            for (int j = 1; j < input.Length; j++)
            {
                string[] studentInfo = input[j].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = studentInfo[0];
                // the rest of the studentInfo array are the student's grades, add them into a list
                List<double> studentGrades = new List<double>();
                for (int k = 1; k < studentInfo.Length; k++)
                {
                    studentGrades.Add(double.Parse(studentInfo[k]));
                }

                students.Add(new Student(name, studentGrades));
            }

            return students;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; }
        public double AverageGrade { get; }


        public Student(string name, List<double> grades)
        {
            this.Name = name;
            this.Grades = grades;
            this.AverageGrade = grades.Sum() / grades.Count;
        }
    }
}