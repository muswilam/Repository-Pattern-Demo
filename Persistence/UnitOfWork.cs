using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Repositories;
using Persistence.Repositories;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext _context;

        public UnitOfWork(RepositoryContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            //Authors = new AuthorRepository(_context); // early state.
        }

        // Act like DbSets.
        public ICourseRepository Courses { get; private set; } // Or using this way.
        public IAuthorRepository Authors { get { return new AuthorRepository(_context); } }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
