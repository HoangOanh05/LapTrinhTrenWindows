using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTuan2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<SinhVien> DSSinhVien = new List<SinhVien>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1.Thêm sinh viên");
                Console.WriteLine( "2.Hiển thị danh sách sinh viên" );
                Console.WriteLine("3.Tìm sinh viên tuổi 15-18");
                Console.WriteLine("4.Tìm sinh viên tên bắt đầu bằng chữ 'A'");
                Console.WriteLine("5.Tổng tuổi tất cả sinh viên");
                Console.WriteLine("6.Học sinh có tuổi lớn nhất");
                Console.WriteLine("7.Sắp xếp theo tuổi tăng dần");
                Console.WriteLine("0.Thoát");
                Console.Write("Chọn chức năng (0-7): ");
               

                string choice = Console.ReadLine();
                switch ( choice)
                {
                    case "1":
                        ThemSinhVien(DSSinhVien); break;
                    case "2":
                        InDSSV(DSSinhVien); break;
                    case "3":
                        DSTuoi(DSSinhVien); break;
                    case "4":
                        TimTen(DSSinhVien); break;
                    case "5":
                        TinhTongTuoi(DSSinhVien); break;
                    case "6":
                        TimVaInTuoiLonNhat(DSSinhVien); break;
                    case "7":
                        SapXepTangDanVaInDS(DSSinhVien); break;

                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình");
                        break;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ , vui lòng nhập lại");
                        break;

                }
                Console.WriteLine();


            }
         
        }

        

        static void InDSSV(List<SinhVien> DSSinhVien)
        {
            Console.WriteLine("==Danh sách chi tiết thông tin sinh viên==");
            foreach (SinhVien sv in DSSinhVien)
            {
                sv.Show();
            }    
        }

       static void ThemSinhVien(List<SinhVien> DSSinhVien)
        {
            Console.WriteLine("==Nhập thông tin sinh viên==");
            SinhVien sv = new SinhVien();
            sv.Input();
            DSSinhVien.Add(sv);
            Console.WriteLine("THÊM SINH VIÊN THÀNH CÔNG!");

        }
        static void SapXepTangDanVaInDS(List<SinhVien> dSSinhVien)
        {
            var dsSapXep = dSSinhVien.OrderBy(s => s.Tuoi).ToList();
            Console.WriteLine("== Danh sách sau khi sắp xếp theo tuổi tăng dần ==");
            foreach (var sv in dsSapXep)
                sv.Show();
        }

        static void TimVaInTuoiLonNhat(List<SinhVien> dSSinhVien)
        {
            var svMax = dSSinhVien.OrderByDescending(s => s.Tuoi).FirstOrDefault();
            if (svMax != null)
            {
                Console.WriteLine("== Sinh viên có tuổi lớn nhất ==");
                svMax.Show();
            }
            else
                Console.WriteLine("Danh sách rỗng!");
        }

         static void TinhTongTuoi(List<SinhVien> dSSinhVien)
        {
            int tong = dSSinhVien.Sum(s => s.Tuoi);
            Console.WriteLine($"Tổng tuổi của tất cả sinh viên: {tong}");
        }

        static void TimTen(List<SinhVien> dSSinhVien)
        {
            var ketqua = dSSinhVien
                .Where(s => s.HoTen.StartsWith("A", StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine("== Sinh viên có tên bắt đầu bằng 'A' ==");
            foreach (var sv in ketqua)
                sv.Show();
        }

         static void DSTuoi(List<SinhVien> dSSinhVien)
        {
            var ketqua = dSSinhVien.Where(s => s.Tuoi >= 15 && s.Tuoi <= 18).ToList();
            Console.WriteLine("== Sinh viên tuổi 15 đến 18 ==");
            foreach (var sv in ketqua)
                sv.Show();
        }

    }
}
