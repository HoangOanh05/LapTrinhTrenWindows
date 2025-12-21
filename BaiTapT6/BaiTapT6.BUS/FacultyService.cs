using BaiTapT6.DAL.sql;
using System.Collections.Generic;
using System.Linq;

namespace BaiTapT6.BUS
{
    public class FacultyService
    {
        StudentModel context = new StudentModel();

        public List<Faculty> GetAll()
        {
            return context.Faculties.ToList();
        }
       
        public string GetFacultyName(int? facultyId)
        {
            var f = context.Faculties
                           .FirstOrDefault(x => x.FacultyID == facultyId);
            return f != null ? f.FacultyName : "";
        }
    }
}
