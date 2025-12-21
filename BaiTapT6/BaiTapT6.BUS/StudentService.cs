using BaiTapT6.DAL.sql;
using System.Collections.Generic;
using System.Linq;

namespace BaiTapT6.BUS
{
    public class StudentService
    {
        StudentModel context = new StudentModel();

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student GetById(string id)
        {
            return context.Students.FirstOrDefault(s => s.StudentID == id);
        }

        public void AddOrUpdate(Student sv)
        {
            var old = context.Students.FirstOrDefault(s => s.StudentID == sv.StudentID);

            if (old == null)
                context.Students.Add(sv);
            else
            {
                old.FullName = sv.FullName;
                old.AverageScore = sv.AverageScore;
                old.FacultyID = sv.FacultyID;
                old.MajorID = sv.MajorID;
                old.Avatar = sv.Avatar;
            }

            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var sv = context.Students.FirstOrDefault(s => s.StudentID == id);
            if (sv != null)
            {
                context.Students.Remove(sv);
                context.SaveChanges();
            }
        }
    }
}
