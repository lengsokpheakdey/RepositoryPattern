using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPattern.Core.Repositories;

namespace RepositoryPattern.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        IAuthorRepository Authors { get; }
        int Complete();
    }
}