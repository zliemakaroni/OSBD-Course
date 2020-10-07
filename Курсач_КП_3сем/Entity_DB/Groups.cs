namespace Курсач_КП_3сем.Entity_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Groups
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Groups()
        {
            Students = new HashSet<Students>();
        }

        public int Id { get; set; }

        public int Number { get; set; }

        public int Faculty_Id { get; set; }

        public int Specialty_Id { get; set; }

        public int Course_Id { get; set; }

        public int Year { get; set; }

        public virtual Courses Courses { get; set; }

        public virtual Faculties Faculties { get; set; }

        public virtual Specialty Specialty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Students> Students { get; set; }
    }
}
