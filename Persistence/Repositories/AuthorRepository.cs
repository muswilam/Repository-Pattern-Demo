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
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext context)
            :base(context)
        {
        }

        public RepositoryContext RepositoryContext { get { return Context as RepositoryContext; } }

        public Author GetAuthorWithCourses(int id)
        {
            return RepositoryContext.Authors.Include(a => a.Courses).SingleOrDefault(a => a.Id == id);
        }
    }
}
