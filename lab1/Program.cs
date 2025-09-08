namespace lab1
{
    internal class Program
    {
        public static List<Person> People = new()
        {
            new("Aya", 28, "Cairo", 22000m, new DateTime(2022, 6, 1)),
            new("Karim", 35, "Giza", 31000m, new DateTime(2019, 11, 15)),
            new("Nour", 31, "Alexandria", 28000m, new DateTime(2021, 2, 5)),
            new("Hassan", 24, "Cairo", 18000m, new DateTime(2024, 3, 12)),
            new("Mona", 29, "Cairo", 26000m, new DateTime(2020, 7, 30)),
            new("Omar", 41, "Giza", 45000m, new DateTime(2016, 1, 10)),
            new("Sarah", 33, "Cairo", 33000m, new DateTime(2018, 9, 20)),
            new("Youssef", 27, "Alexandria", 21000m, new DateTime(2023, 5, 8)),
            new("Dina", 36, "Cairo", 38000m, new DateTime(2017, 12, 1)),
            new("Mahmoud", 30, "Giza", 30000m, new DateTime(2020, 4, 18)),
        };

        public static int[] Numbers = new[] { 3, 6, 9, 12, 15, 2, 4, 8, 16, 1, 5, 7, 10, 14, 18, 20 };

        
        static void Main(string[] args)
        {
            #region where
            var peopleAge = People.Where(ppl => ppl.Age >= 30);

            foreach (var ppl in peopleAge)
            {
                Console.WriteLine(ppl.Name);
            }

            var peopleSalCity = People.Where(ppl => ppl.City == "Cairo" && ppl.Salary >= 25000m && ppl.Salary <= 35000m);
            Console.WriteLine();
            foreach (var ppl in peopleSalCity)
            {
                Console.WriteLine(ppl);
            }
            #endregion

            #region select
            var filteredPeopleNames = People.Select(ppl => ppl.Name.ToUpper());
            Console.WriteLine();
            foreach (var ppl in filteredPeopleNames)
            {
                Console.WriteLine(ppl);
            }

            var projected = People.Select(p => new
            {
                p.Name,
                TenureYears = (DateTime.Now.Year - p.StartDate.Year) -
                  (DateTime.Now.DayOfYear < p.StartDate.DayOfYear ? 1 : 0)
            });

            Console.WriteLine();
            foreach (var item in projected)
            {
                Console.WriteLine($"{item.Name} - Tenure: {item.TenureYears} years");
            }
            #endregion

            #region orderby

            var orderAge = People.OrderBy(ppl => ppl.Age).ThenBy(ppl => ppl.Name);
            Console.WriteLine();
            foreach (var item in orderAge)
            {
                Console.WriteLine(item);
            }

            var salStart = People.OrderByDescending(ppl => ppl.Salary).ThenBy(ppl => ppl.StartDate);
            Console.WriteLine();
            foreach(var item in salStart)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region top

            var topSalaries = People.OrderByDescending(p => p.Salary).Take(3);
            Console.WriteLine();
            foreach (var person in topSalaries)
            {
                Console.WriteLine($"{person.Name} - Salary: {person.Salary}");
            }

            var ageSkip = People.OrderBy(ppl => ppl.Age).Skip(2).Take(5);
            Console.WriteLine();
            foreach ( var person in ageSkip)
            {
                Console.WriteLine(person);
            }

            int pageSize = 3;
            int pageNumber = 2; // 1-based

            var page = People.OrderBy(p => p.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            Console.WriteLine();
            foreach (var name in page)
            {
                Console.WriteLine(name);
            }

            #endregion

            #region takewhile

            var result = Numbers.OrderBy(n => n).TakeWhile(n => n < 10);
            Console.WriteLine();
            foreach (var n in result)
            {
                Console.WriteLine(n);
            }

            #endregion

            #region skipwhile

            var resultNumber = Numbers.OrderBy(n => n).SkipWhile(n => n < 10);
            Console.WriteLine();
            foreach (var n in result)
            {
                Console.WriteLine(n);
            }

            #endregion

            #region comp

            var topCairoEmployees = People.Where(p => p.City == "Cairo" && p.Age >= 28).OrderByDescending(p => p.StartDate)
            .Select(p => new
            {
                p.Name,
                TenureYears = (DateTime.Now.Year - p.StartDate.Year) -
                              (DateTime.Now.DayOfYear < p.StartDate.DayOfYear ? 1 : 0)
            })                                            
            .Take(3);
            Console.WriteLine();
            foreach (var emp in topCairoEmployees)
            {
                Console.WriteLine($"{emp.Name} - Tenure: {emp.TenureYears} years");
            }

            #endregion


        }
    }
}
