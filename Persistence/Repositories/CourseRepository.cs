using Core.Domain;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository // Inherit from generic Repository class with specify course type for code reuse.
    {
        public CourseRepository(RepositoryContext context) // Pass the context of application to the main one in Repository generic class.
            :base(context)
        {
        }

        // Property for casting main context in base class to application context.
        public RepositoryContext RepositoryContext { get { return Context as RepositoryContext; } }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return RepositoryContext.Courses.OrderByDescending(c => c.FullPrice).ToList(); // Simulating the logic of top selling not actual.
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize)
        {
            return RepositoryContext.Courses
                .Include(c => c.Author)
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
