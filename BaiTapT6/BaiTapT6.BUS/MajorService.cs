using BaiTapT6.DAL.sql;
using System.Linq;

namespace BaiTapT6.BUS
{
    public class MajorService
    {
        StudentModel context = new StudentModel();

        public string GetMajorName(int? majorId)
        {
            if (majorId == null) return "";
            return context.Majors
                          .Where(m => m.MajorID == majorId)
                          .Select(m => m.Name)
                          .FirstOrDefault();
        }
    }
}
