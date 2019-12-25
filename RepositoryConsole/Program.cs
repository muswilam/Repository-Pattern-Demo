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
                var author = new Author
                {
                    Name = "Tim Corey",
                };

                var courses = new List<Course>
                {
                    new Course { Name = "Ultimate C#", Description = "C# course from scratch to hero.", FullPrice = 40, AuthorId = 6},
                    new Course { Name = "ASP.NET MVC", Description = "MVC course from scratch to hero in ASP.NET.", FullPrice = 140, AuthorId = 6},
                    new Course { Name = "Javascript", Description = "Javascript course for begginers.", FullPrice = 60, AuthorId = 6}
                };

                unitOfWork.Authors.Add(author);
                unitOfWork.Courses.AddRange(courses);

                var result = unitOfWork.Complete(); // important to savechanges.

                if(result)
                    Console.WriteLine("Added.");
                else
                    Console.WriteLine("Error!");

                var allCourses = unitOfWork.Courses.GetAll();
                var moshCourse = unitOfWork.Authors.GetAuthorWithCourses(1);
                var specialCourses = unitOfWork.Courses.Where(c => c.Name.ToLower().Contains("c#"));

                foreach (var cour in specialCourses)
                {
                    Console.WriteLine(cour.Name);
                }
            }
        }
    }
}
