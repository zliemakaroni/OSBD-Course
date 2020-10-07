namespace Курсач_КП_3сем.Entity_DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Faculties> Faculties { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Progress> Progress { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Courses)
                .HasForeignKey(e => e.Course_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faculties>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Faculties)
                .HasForeignKey(e => e.Faculty_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Groups)
                .HasForeignKey(e => e.Group_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Progress>()
                .Property(e => e.Mark)
                .IsFixedLength();

            modelBuilder.Entity<Specialty>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Specialty)
                .HasForeignKey(e => e.Specialty_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.Date_of_birth)
                .IsFixedLength();

            modelBuilder.Entity<Students>()
                .HasMany(e => e.Progress)
                .WithOptional(e => e.Students)
                .HasForeignKey(e => e.Student_Id);

            modelBuilder.Entity<Subjects>()
                .HasMany(e => e.Progress)
                .WithRequired(e => e.Subjects)
                .HasForeignKey(e => e.Subject_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teachers>()
                .Property(e => e.Date_of_birth)
                .IsFixedLength();

            modelBuilder.Entity<Teachers>()
                .HasMany(e => e.Subjects)
                .WithOptional(e => e.Teachers)
                .HasForeignKey(e => e.Teacher_Id);
        }
    }
}
