using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }

        public Person(string name, int age, string city, decimal salary, DateTime startDate)
        {
            Name = name;
            Age = age;
            City = city;
            Salary = salary;
            StartDate = startDate;
        }

        public override string ToString()
        {
            return $"{Name}, Age: {Age}, City: {City}, Salary: {Salary}, StartDate: {StartDate:yyyy-MM-dd}";
        }
    }
}
