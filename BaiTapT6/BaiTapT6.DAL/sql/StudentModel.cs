using System;
using BaiTapT6.DAL.sql;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BaiTapT6.DAL.sql
{
    public partial class StudentModel : DbContext
    {
        public StudentModel()
            : base("name=StudentModel")
        {
        }

        // Đổi tên thành số nhiều để khớp với code trong Service của bạn
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {

            modelBuilder.Entity<Faculty>()

                .HasMany(e => e.Major)

                .WithRequired(e => e.Faculty)

                .WillCascadeOnDelete(false);



            modelBuilder.Entity<Major>()

                .HasMany(e => e.Student)

                .WithOptional(e => e.Major)

                .HasForeignKey(e => new { e.FacultyID, e.MajorID });
        }
    }
}