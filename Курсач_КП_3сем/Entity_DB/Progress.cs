namespace Курсач_КП_3сем.Entity_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Progress")]
    public partial class Progress
    {
        public int Id { get; set; }

        public int Subject_Id { get; set; }

        public int? Student_Id { get; set; }

        [StringLength(10)]
        public string Mark { get; set; }

        public virtual Students Students { get; set; }

        public virtual Subjects Subjects { get; set; }
    }
}
