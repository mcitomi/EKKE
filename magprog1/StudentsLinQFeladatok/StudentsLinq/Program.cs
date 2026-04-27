using StudentsLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Students
{
    

   
    class Program
    {
        static List<Student> students = new List<Student>();

        static void Generate()
        {
            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                Student s = new Student();

                s.Name = ((char)rnd.Next(65, 91)).ToString() +
                         ((char)rnd.Next(65, 91)).ToString() +
                         ((char)rnd.Next(65, 91)).ToString();

                s.Age = rnd.Next(18, 30);
                s.GPA = Math.Round(rnd.NextDouble() * 4, 2);
                s.MajorType = (Major)rnd.Next(3);
                s.YearLevel = (Year)rnd.Next(4);

                students.Add(s);
            }
        }

        static void Main(string[] args)
        {
            Generate();

            // 1. How many students are there?
            Console.WriteLine(students.Count());

            // 2. Average GPA
            var avgGPA = students.Average(x => x.GPA);
            Console.WriteLine(avgGPA);

            // 3. Highest GPA
            var maxGPA = students.Max(x => x.GPA);

            // 4. How many Computer Science students?
            int csCount = students.Where(s => s.MajorType == Major.ComputerScience).Count();


            // 5. How many students have GPA above 3.5?
            int sAbove35 = students.Where(s => s.GPA > 3.5).Count();

            // 6. Is there any student older than 25?
            bool olderThan25 = students.Any(s => s.Age > 25);


            // 7. First Mathematics student
            Student fristMathS = students.Where(s => s.MajorType == Major.Mathematics).FirstOrDefault();



            // 8. Student with highest GPA in Physics
            Student sHighestGPAinPsy = students.Where(s => s.MajorType == Major.Physics && s.GPA == students.Max(x => x.GPA)).FirstOrDefault();


            // 9. Sort by name
            students.OrderBy(s => s.Name);


            // 10. Sort by GPA descending, then by name
            students.OrderByDescending(x => x.GPA).ThenBy(x => x.Name);


            // 11. Youngest Computer Science student
            Student? youngestCS = students.Where(s => s.MajorType == Major.ComputerScience && s.Age == students.Min(x => x.Age)).FirstOrDefault();
                

            if (youngestCS != null)
                Console.WriteLine(youngestCS.Name);

            // 12. Group by major
            var groupsByMajor = students.GroupBy(x => x.MajorType);

            foreach (var g in  groupsByMajor)
            {
                Console.WriteLine(g.Key + " ; " + g.Count());
            }

            // 13. Maximum GPA by major
            var maxByMajor = students.GroupBy(x => x.MajorType).Select(g => new {Major = g.Key, MaxGPA = g.Max(x => x.GPA)});

          
            // 14. Names of students with GPA above average
            var bests = students.Where(s => s.GPA > students.Average(x => x.GPA)).ToList();

            Console.ReadKey();
        }
    }
}