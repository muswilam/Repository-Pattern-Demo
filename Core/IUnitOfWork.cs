using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork : IDisposable // To implement dispose method.
    {
        // Act like DbSets
        ICourseRepository Courses { get; }
        IAuthorRepository Authors { get; }
        bool Complete();
    }
}
