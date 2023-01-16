using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Data Source
            List<int> integerList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //lINQ Query Syntax
            var data = from obj in integerList where obj > 5 select obj;

            //Execution
            foreach (var item in data)
            {
                Console.WriteLine($"Number: {item}");
            }

            //LINQ Method Syntax
            var data2 = integerList.Where(obj => obj > 5).ToList();

            //Execution
            foreach (var item in data2)
            {
                Console.WriteLine($"Number: {item}");
            }

            //LINQ Mixed Syntax
            var data3 = (from obj in integerList where obj < 5 select obj).Sum();

            //Execution
            Console.WriteLine($"Sum: {data3}");

            List<Student> studentList = new List<Student>()
            {
                new Student(){ID = 1, Name = "James", Gender = "Male"},
                new Student(){ID = 2, Name = "Sara", Gender = "Female"},
                new Student(){ID = 3, Name = "Steve", Gender = "Male"},
                new Student(){ID = 4, Name = "Pam", Gender = "Female"}
            };

            //LINQ Query Syntax IEnumerable 
            //var students = from std in studentList where std.Gender == "Male" select std;

            //LINQ Query Syntax IEnumerable
            var students = studentList.AsQueryable().Where(x => x.Gender == "Male");

            //Execution
            foreach (var student in students)
            {
                Console.WriteLine($"Student Id: {student.ID}\tStudent Name: {student.Name}");
            }

            //Extension Method
            IEnumerable<int> evenNumbers = Enumerable.Where(integerList, n => n % 2 == 0);

            foreach (var item in evenNumbers)
            {
                Console.WriteLine($"Even Number: {item}");
            }

            Console.ReadKey();
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}
