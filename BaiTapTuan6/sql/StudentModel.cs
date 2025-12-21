using System.Data.Entity;

namespace BaiTapTuan6.sql
{
    public class StudentModel : DbContext
    {
        public StudentModel() : base("name=StudentModel") { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Major> Majors { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }

    }
}
