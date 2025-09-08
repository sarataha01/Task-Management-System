using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region q1

            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };

            var uniqueNo = numbers.Order().Distinct();
            foreach (var number in uniqueNo) 
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();
            foreach (var number in uniqueNo)
            {
                Console.WriteLine($"< Number = {number}, Multiply = {number * number} >");
            }

            #endregion

            #region Select names with length equal 3.

            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

            //query
            var namesLength =
                from n in names
                where n.Length == 3
                select n;

            Console.WriteLine();
            foreach (var name in namesLength)
            {
                Console.WriteLine(name);
            }

            //method
            var namesLength2 = names.Where(n => n.Length == 3);

            Console.WriteLine();
            foreach (var name in namesLength2)
            {
                Console.WriteLine(name);
            }

            #endregion

            #region Select names that contains “a” letter (Capital or Small )then sort them by length
            //query
            var namesLength3 =
                from n in names
                where n.ToLower().Contains("a")
                orderby n.Length
                select n;

            Console.WriteLine();
            foreach (var name in namesLength3)
            {
                Console.WriteLine(name);
            }

            //method
            var namesLength4 = names.Where(n => n.ToLower().Contains("a")).OrderBy(n => n.Length);

            Console.WriteLine();
            foreach (var name in namesLength4)
            {
                Console.WriteLine(name);
            }
            #endregion

            #region Display the first 2 names
            //query
            var topNames =
                (from n in names
                 select n).Take(2);
            Console.WriteLine();
            foreach (var name in topNames)
            {
                Console.WriteLine(name);
            }

            //method
            var topNames2 = names.Take(2);
            Console.WriteLine();
            foreach (var name in topNames2)
            {
                Console.WriteLine(name);
            }
            #endregion

            #region subject and student

            List<Student> students = new List<Student>(){
                new Student(){ Id=1, FirstName="Ali", LastName="Mohammed", Subjects=new Subject[]{ new Subject(){ Code=22,Name="EF"}, new Subject(){ Code=33,Name="UML"}}},
                new Student(){ Id=2, FirstName="Mona", LastName="Gala", Subjects=new Subject []{ new Subject(){ Code=22,Name="EF"}, new Subject (){ Code=34,Name="XML"},new Subject (){ Code=25, Name="JS"}}}, 
                new Student(){ Id=3, FirstName="Yara", LastName="Yousf", Subjects=new Subject []{ new Subject (){ Code=22,Name="EF"}, new Subject (){ Code=25,Name="JS"}}},
                new Student(){ Id=1, FirstName="Ali", LastName="Ali", Subjects=new Subject []{ new Subject (){ Code=33,Name="UML"}}},
                };

            #endregion

            #region Display Full name and number of subjects

            var nameSubject = students.Select(s => new
            {
                FullName = s.FirstName + " " + s.LastName,
                SubjectCount = s.Subjects.Length
            });

            Console.WriteLine();
            foreach (var student in nameSubject)
            {
                Console.WriteLine($"FullName: {student.FullName}, No of Subjects: {student.SubjectCount}");
            }

            #endregion

            #region Order by FirstName Descending, then LastName Ascending

            var studentName = students.OrderByDescending(s => s.FirstName).ThenBy(s => s.LastName).Select(s => new
            {
                s.FirstName,
                s.LastName
            });

            Console.WriteLine();
            foreach (var student in studentName)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
            #endregion

            #region Display each student with their subjects (using SelectMany)

            var studSub = students.SelectMany(s => s.Subjects, (student, subject) => new
                                {
                                    StudentName = student.FirstName + " " + student.LastName,
                                    SubjectName = subject.Name
                                });

            Console.WriteLine();
            foreach (var item in studSub)
            {
                Console.WriteLine($"Student Name: {item.StudentName}, Subject Name: {item.SubjectName}");
            }

            #endregion

            #region group by
            var studSub3 = students.SelectMany(s => s.Subjects, (student, subject) => new
            {
                StudentName = student.FirstName + " " + student.LastName,
                SubjectName = subject.Name
            }).GroupBy(s => s.StudentName);

            var studSub2 = students.GroupBy(s => s.FirstName + " " + s.LastName).Select(s => new
            {
                StudentName = s.Key,
                Subjects = s.SelectMany(s => s.Subjects).Select(sub => sub.Name)
            });

            Console.WriteLine();
            foreach (var group in studSub2)
            {
                Console.WriteLine(group.StudentName);
                foreach (var subject in group.Subjects)
                {
                    Console.WriteLine("   " + subject);
                }
            }

            #endregion
        }
    }
}
