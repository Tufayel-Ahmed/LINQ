using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IEnumerable_and_IQueryable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dBContext = new LINQ_DBEntities();

            //Using IEnumerable
            IEnumerable<Student> data = dBContext.Students.Where(x => x.Gender == "Male");
            var students = data.Take(2);
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }

            //Using IQueryable
            IQueryable<Student> data2 = dBContext.Students.AsQueryable().Where(x => x.Gender == "Male");
            var students2 = data2.Take(2);
            foreach (var student in students2)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }

            Console.ReadKey();
        }
    }
}
