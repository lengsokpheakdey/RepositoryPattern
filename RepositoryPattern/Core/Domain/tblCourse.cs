namespace RepositoryPattern.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCourse")]
    public partial class tblCourse
    {
        public Guid id { get; set; }

        [StringLength(50)]
        public string name { get; set; }
    }
}
