using Core;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryWeb
{
    public static class Factory
    {
        public static IUnitOfWork GetUnitOfWork { get { return new UnitOfWork(new RepositoryContext()); } }
    }
}