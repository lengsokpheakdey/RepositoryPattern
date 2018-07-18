using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPattern.Core;
using RepositoryPattern.Core.Domain;
using RepositoryPattern.Core.Repositories;
using RepositoryPattern.Persistence.Repositories;

namespace RepositoryPattern.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolModel _context;

        public UnitOfWork(SchoolModel context)
        {
            _context = context;
            Courses = new CourseRepository(context);
            Authors = new AuthorRepository(context);
        }

        public ICourseRepository Courses { get; }
        public IAuthorRepository Authors { get; }
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