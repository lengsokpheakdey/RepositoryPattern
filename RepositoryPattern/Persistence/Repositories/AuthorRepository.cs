using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPattern.Core.Domain;
using RepositoryPattern.Core.Repositories;

namespace RepositoryPattern.Persistence.Repositories
{
    public class AuthorRepository : Repository<tblAuthor>, IAuthorRepository
    {
        public AuthorRepository(SchoolModel context) : base(context)
        {
        }

        public tblAuthor GetAuthorWithCourses(Guid id)
        {
            return Context.tblAuthors.Find(id);
        }

        public SchoolModel SchoolModel
        {
            get { return Context as SchoolModel; }
        }
    }
}