using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;
using Core.Domain;

namespace RepositoryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new RepositoryContext()))
            {
                // Example 1
                var course = unitOfWork.Courses.Get(1);
                Console.WriteLine(course.Name);

                // Example 2
                var courses = unitOfWork.Courses.GetTopSellingCourses(3);

                // Example 3 
                var author = unitOfWork.Authors.GetAuthorWithCourses(2);
                Console.WriteLine(author.Name);
                foreach (var c in author.Courses)
                {
                    Console.WriteLine(c.Name);
                }
            }
        }
    }
}
