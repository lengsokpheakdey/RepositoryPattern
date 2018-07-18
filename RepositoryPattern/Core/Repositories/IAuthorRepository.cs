using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern.Core.Domain;

namespace RepositoryPattern.Core.Repositories
{
    public interface IAuthorRepository : IRepository<tblAuthor>
    {
        tblAuthor GetAuthorWithCourses(Guid id);
    }
}
