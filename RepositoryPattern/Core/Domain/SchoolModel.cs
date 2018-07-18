namespace RepositoryPattern.Core.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SchoolModel : DbContext
    {
        public SchoolModel()
            : base("name=School")
        {
        }

        public virtual DbSet<tblAuthor> tblAuthors { get; set; }
        public virtual DbSet<tblCourse> tblCourses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
