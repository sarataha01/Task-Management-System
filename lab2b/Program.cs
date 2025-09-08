using System.Collections;

namespace lab2b
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Name={Name}, Age={Age}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<string> names = new List<string> { "Ali", "Omar", "Aya", "Sara", "Ahmed", "Ali" };

            List<Student> students = new List<Student>
            {
                new Student{ Id=1, Name="Ali", Age=20 },
                new Student{ Id=2, Name="Sara", Age=22 },
                new Student{ Id=3, Name="Omar", Age=19 },
                new Student{ Id=4, Name="Aya", Age=21 },
                new Student{ Id=5, Name="Ali", Age=20 }
            };


            #region filtering

            var evenNo = numbers.Where(n => n % 2 == 0);
            foreach (var num in evenNo)
            {
                Console.WriteLine(num);
            }

            var studAge = students.Where(s => s.Age > 20);
            Console.WriteLine();
            foreach (var stud in studAge)
            {
                Console.WriteLine($"Name: {stud.Name} Age: {stud.Age}");
            }

            #endregion

            #region projection

            var studNames = students.Select(s => s.Name);
            Console.WriteLine();
            foreach(var stud in studNames)
            {
                Console.WriteLine(stud);
            }

            string[] sentences = { "I love C#", "LINQ is powerful" };
            var text = sentences.SelectMany(s => s.Split(' '));
            Console.WriteLine();
            foreach ( var t in text)
            {
                Console.WriteLine(t);
            }
            #endregion

            #region sorting

            var studAge2 = students.OrderBy(s => s.Age);
            Console.WriteLine();
            foreach ( var stud in studAge2)
            {
                Console.WriteLine($"Name: {stud.Name} Age: {stud.Age}");
            }

            var studAgeName = students.OrderBy(s => s.Age).ThenBy(s => s.Name);
            Console.WriteLine();
            foreach( var stud in studAgeName)
            {
                Console.WriteLine($"Name: {stud.Name} Age: {stud.Age}");
            }

            var numReverse = numbers.AsEnumerable().Reverse();
            Console.WriteLine();
            foreach(var num in numReverse)
            {
                Console.WriteLine(num);
            }
            #endregion

            #region partitioning

            var num1 = numbers.Take(5);
            Console.WriteLine();
            foreach (var num in num1)
            {
                Console.WriteLine(num);
            }

            var num2 = numbers.Skip(3);
            Console.WriteLine();
            foreach (var num in num2)
            {
                Console.WriteLine(num);
            }

            var num3 = numbers.TakeWhile(n => n < 6);
            Console.WriteLine();
            foreach (var num in num3)
            {
                Console.WriteLine(num);
            }

            var num4= numbers.SkipWhile(n => n < 6);
            Console.WriteLine();
            foreach (var num in num4)
            {
                Console.WriteLine(num);
            }

            #endregion

            #region element operator

            var num5 = numbers.First();
            Console.WriteLine();
            Console.WriteLine(num5);
            
            var stud1 = students.Last();
            Console.WriteLine();
            Console.WriteLine(stud1);

            var stud2 = students.Single(s => s.Id == 2);
            Console.WriteLine();
            Console.WriteLine(stud2);

            var num6 = numbers.ElementAt(2);
            Console.WriteLine();
            Console.WriteLine(num6);

            #endregion

            #region set operators

            var unique = names.Distinct();
            Console.WriteLine();
            foreach(var name in unique)
            {
                Console.WriteLine(name);
            }

            var num7 = new List<int> { 1, 2, 3 }.Union(new List<int> { 3, 4, 5 });
            Console.WriteLine();
            foreach (int num in num7)
            {
                Console.WriteLine(num);
            }

            var stud3 = students.Select(s => s.Name).Intersect(names);
            Console.WriteLine();
            foreach (var  name in stud3)
            {
                Console.WriteLine(name);
            }

            var num8 = new List<int> { 1, 2, 3, 4 }.Except(new List<int> { 3, 4 });
            Console.WriteLine();
            foreach (var  num in num8)
            {
                Console.WriteLine(num);
            }

            #endregion

            #region joining

            var join1 = students.Join(names, s => s.Name, n => n, (s, n) => new { s.Id, s.Name, s.Age });
            Console.WriteLine();
            foreach (var item in join1)
            {
                Console.WriteLine($"Id={item.Id}, Name={item.Name}, Age={item.Age}");
            }

            var groupJoin1 = names.GroupJoin(students, n => n, s => s.Name, (n, studs) => new { Name = n, Students = studs });
            Console.WriteLine();
            foreach (var group in groupJoin1)
            {
                Console.WriteLine($"Name={group.Name}: " +
                                  string.Join(", ", group.Students.Select(s => s.ToString())));
            }

            #endregion

            #region grouping

            var group1 = students.GroupBy(s => s.Age);
            Console.WriteLine();
            foreach (var group in group1)
            {
                Console.WriteLine($"Age = {group.Key}: {string.Join(", ", group)}");
            }
            var group2 = names.GroupBy(n => n[0]);
            Console.WriteLine();
            foreach (var group in group2)
            {
                Console.WriteLine($"Name = {group.Key}: {string.Join(", ", group)}");
            }
            #endregion

            #region aggregation

            var agg1 = students.Count(s => s.Age > 20);
            Console.WriteLine();
            Console.WriteLine("Count: " + agg1);
            
            var agg2 = numbers.Sum();
            Console.WriteLine();
            Console.WriteLine("Sum: " + agg2);

            var agg3 = students.Average(s => s.Age);
            Console.WriteLine();
            Console.WriteLine("Average: " + agg3);

            var agg4 = students.Min(s => s.Age);
            Console.WriteLine();
            Console.WriteLine("Min: " + agg4);

            var agg5 = numbers.Take(5).Aggregate((a, b) => a * b);
            Console.WriteLine();
            Console.WriteLine("Multiply: " + agg5);

            #endregion

            #region quantifiers

            var q1 = students.Any(s => s.Age > 21);
            Console.WriteLine();
            Console.WriteLine(q1);

            var q2 = students.All(s => s.Age >= 18);
            Console.WriteLine();
            Console.WriteLine(q2);

            var q3 = names.Contains("Aya");
            Console.WriteLine();
            Console.WriteLine(q3);

            #endregion

            #region covnersion

            var c1 = numbers.ToArray();
            Console.WriteLine();
            Console.WriteLine(string.Join(", ", c1));

            var c2 = students.ToDictionary(s => s.Id, s => s.Name);
            Console.WriteLine();
            foreach (var stud in c2)
            {
                Console.WriteLine($"Id={stud.Key}, Name={stud.Value}");
            }

            ArrayList list = new ArrayList { 1, "two", 3 };
            var c3 = list.OfType<int>();
            Console.WriteLine();
            Console.WriteLine(string.Join(", ", c3));
            #endregion
        }
    }
}
