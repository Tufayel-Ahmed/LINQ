using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection_Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //----- Query Syntax -----
            Console.WriteLine("---------- Query Syntax ----------");

            Console.WriteLine("\nSelect All Property Using Query Syntax");
            List<Employee> employees = (from e in Employee.GetEmployees() select e).ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"Id: {employee.ID}\tName: {employee.FirstName} {employee.LastName}\tSalaryy: {employee.Salary}");
            }

            Console.WriteLine("\nSelect Single Property Using Query Syntax");
             List<int> employees12 = (from e in Employee.GetEmployees() select e.ID).ToList();
            foreach (var employee in employees12)
            {
                Console.WriteLine($"Id: {employee}");
            }

            Console.WriteLine("\nSelect Multiple Property to Same Class Using Query Syntax");
            List <Employee> employees13 = (from e in Employee.GetEmployees() select new Employee()
            {
                FirstName = e.FirstName,
                LastName = e.LastName
            }).ToList();
            foreach (var employee in employees13)
            {
                Console.WriteLine($"First Name: {employee.FirstName}\tLast Name: {employee.LastName}");
            }

            Console.WriteLine("\nSelect Multiple Property to Another Class Using Query Syntax");
            List <EmployeeBasicInfo> employees14 = (from e in Employee.GetEmployees()
                                          select new EmployeeBasicInfo()
                                          {
                                              FirstName = e.FirstName,
                                              LastName = e.LastName
                                          }).ToList();
            foreach (var employee in employees14)
            {
                Console.WriteLine($"First Name: {employee.FirstName}\tLast Name: {employee.LastName}");
            }

            Console.WriteLine("\nSelect Multiple Property to Anonymous Using Query Syntax");
            var employees15 = (from e in Employee.GetEmployees()
                                                   select new
                                                   {
                                                       FirstName = e.FirstName,
                                                       LastName = e.LastName
                                                   }).ToList();
            foreach (var employee in employees15)
            {
                Console.WriteLine($"First Name: {employee.FirstName}\tLast Name: {employee.LastName}");
            }

            Console.WriteLine("\nPerform Calculations to Anonymous Using Query Syntax");
            var employees16 = (from e in Employee.GetEmployees()
                               select new
                               {
                                   Name = e.FirstName + " " + e.LastName,
                                   AnnualSalary = e.Salary * 12
                               }).ToList();
            foreach (var employee in employees16)
            {
                Console.WriteLine($"Name: {employee.Name}\tAnnual Salary: {employee.AnnualSalary}");
            }

            Console.WriteLine("\nSelect Property with Index Value Using Query Syntax");
            var employees17 = (from e in Employee.GetEmployees().Select((value, index) => new { value, index})
                               select new
                               {
                                    IndexPosition = e.index,
                                    Name = e.value.FirstName + " " + e.value.LastName,
                                    AnnualSalary = e.value.Salary * 12
                               }).ToList();
            foreach (var employee in employees17)
            {
                Console.WriteLine($"Index: {employee.IndexPosition}\tName: {employee.Name}\tAnnual Salary: {employee.AnnualSalary}");
            }

            Console.WriteLine("\nSelect Property Using SelectMany in Query Syntax");
            var programs = (from p in Student.GetStudents() from program in p.Programming select program).Distinct().ToList(); 
            foreach (var program in programs)
            {
                Console.WriteLine($"Programming Language: {program}");
            }

            //----- Method Syntax -----
            Console.WriteLine("\n---------- Method Syntax ----------");

            Console.WriteLine("\nSelect All Property Using Method Syntax");
            IEnumerable <Employee> employees2 = Employee.GetEmployees().ToList();
            foreach (var employee in employees2)
            {
                Console.WriteLine($"Id: {employee.ID}\tName: {employee.FirstName} {employee.LastName}\tSalary: {employee.Salary}");
            }

            Console.WriteLine("\nSelect Single Property Using Method Syntax");
            IEnumerable<int> employees22 = Employee.GetEmployees().Select(e => e.ID).ToList();
            foreach (var employee in employees22)
            {
                Console.WriteLine($"Id: {employee}");
            }

            Console.WriteLine("\nSelect Multiple Property to Same Class Using Method Syntax");
            List <Employee> employees23 = Employee.GetEmployees().Select
                                          (e => new Employee()
                                          {
                                              FirstName = e.FirstName,
                                              LastName = e.LastName
                                          }).ToList();
            foreach (var employee in employees23)
            {
                Console.WriteLine($"First Name: {employee.FirstName}\tLast Name: {employee.LastName}");
            }

            Console.WriteLine("\nSelect Multiple Property to Another Class Using Method Syntax");
            List<EmployeeBasicInfo> employees24 = Employee.GetEmployees().Select
                                          (e => new EmployeeBasicInfo()
                                          {
                                              FirstName = e.FirstName,
                                              LastName = e.LastName
                                          }).ToList();
            foreach (var employee in employees24)
            {
                Console.WriteLine($"First Name: {employee.FirstName}\tLast Name: {employee.LastName}");
            }

            Console.WriteLine("\nSelect Multiple Property to Anonymous Type Using Method Syntax");
            var employees25 = Employee.GetEmployees().Select
                                          (e => new
                                          {
                                              FirstName = e.FirstName,
                                              LastName = e.LastName
                                          }).ToList();
            foreach (var employee in employees25)
            {
                Console.WriteLine($"First Name: {employee.FirstName}\tLast Name: {employee.LastName}");
            }

            Console.WriteLine("\nPerform Calculations to Anonymous Type Using Method Syntax");
            var employees26 = Employee.GetEmployees().Select
                                          (e => new
                                          {
                                              Name = e.FirstName + " " + e.LastName,
                                              AnnualSalary = e.Salary * 12
                                          }).ToList();
            foreach (var employee in employees26)
            {
                Console.WriteLine($"Name: {employee.Name}\tAnnual Salary: {employee.AnnualSalary}");
            }

            Console.WriteLine("\nSelect Property with Index Value Using Method Syntax");
            var employees27 = Employee.GetEmployees().Select(
                                          (e, index ) => new
                                          {
                                              IndexPosition = index,
                                              Name = e.FirstName + " " + e.LastName,
                                              AnnualSalary = e.Salary * 12
                                          }).ToList();
            foreach (var employee in employees27)
            {
                Console.WriteLine($"Index: {employee.IndexPosition}\tName: {employee.Name}\tAnnual Salary: {employee.AnnualSalary}");
            }

            Console.WriteLine("\nSelect Property Using SelectMany in Method Syntax");
            List<string> programs2 = Student.GetStudents().SelectMany(s => s.Programming).Distinct().ToList();
            foreach (var program in programs2)
            {
                Console.WriteLine($"Programming Language: {program}");
            }

            Console.ReadKey();
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee {ID = 101, FirstName = "Preety", LastName = "Tiwary", Salary = 60000 },
                new Employee {ID = 102, FirstName = "Priyanka", LastName = "Dewangan", Salary = 70000 },
                new Employee {ID = 103, FirstName = "Hina", LastName = "Sharma", Salary = 80000 },
                new Employee {ID = 104, FirstName = "Anurag", LastName = "Mohanty", Salary = 90000 },
                new Employee {ID = 105, FirstName = "Sambit", LastName = "Satapathy", Salary = 100000 },
                new Employee {ID = 106, FirstName = "Sushanta", LastName = "Jena", Salary = 160000 }
            };

            return employees;
        }
    }
    public class EmployeeBasicInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Programming { get; set; }

        public static List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student(){ID = 1, Name = "James", Email = "James@j.com", Programming = new List<string>() { "C#", "Jave", "C++"} },
                new Student(){ID = 2, Name = "Sam", Email = "Sara@j.com", Programming = new List<string>() { "WCF", "SQL Server", "C#" }},
                new Student(){ID = 3, Name = "Patrik", Email = "Patrik@j.com", Programming = new List<string>() { "MVC", "Jave", "LINQ"} },
                new Student(){ID = 4, Name = "Sara", Email = "Sara@j.com", Programming = new List<string>() { "ADO.NET", "C#", "LINQ" } }
            };
        }
    }
}
