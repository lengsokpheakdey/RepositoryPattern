using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPattern.Core.Domain;
using RepositoryPattern.Core.Repositories;

namespace RepositoryPattern.Persistence.Repositories
{
    public class CourseRepository : Repository<tblCourse>, ICourseRepository
    {
        public CourseRepository(SchoolModel context) : base(context)
        {

        }

        public IEnumerable<tblCourse> GetTopSellingCourses(int count)
        {
            return PlutoContext.tblCourses.OrderByDescending(c => c.name).Take(count).ToList();
        }

        public SchoolModel PlutoContext
        {
            get { return Context as SchoolModel; }
        }
    }
}