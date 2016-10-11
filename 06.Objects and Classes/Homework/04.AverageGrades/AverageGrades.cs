/*
 Define a class Student, which holds the following information about students: name, list of grades and average 
grade (calculated property, read-only). A single grade will be in range [2…6], e.g. 3.25 or 5.50.
Read a list of students and print the students that have average grade ≥ 5.00 ordered by name (ascending),
then by average grade (descending). Print the student name and the calculated average grade.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AverageGrades
{
    class AverageGrades
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = studentInfo[0];
                // the rest of the studentInfo array are the student's grades, add them into a list
                List<double> studentGrades = new List<double>();
                for (int j = 1; j < studentInfo.Length; j++)
                {
                    studentGrades.Add(double.Parse(studentInfo[j]));
                }

                students.Add(new Student(name, studentGrades));
            }

            // order by name and then by grades
            students = students.OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade).ToList();
            foreach (Student student in students.Where(x => x.AverageGrade >= 5.00))
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade:F2}");
            }
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
