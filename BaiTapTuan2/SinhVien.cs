using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTuan2
{
    class SinhVien
    {
        private string maSV;
        private string hoTen;
        private float diemTB;
        private string khoa;
        private int tuoi;

        public string MaSV { get => maSV; set => maSV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public float DiemTB { get => diemTB; set => diemTB = value; }
        public string Khoa { get => khoa; set => khoa = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        

        public SinhVien(string maSV, string hoTen, float diemTB, string khoa, int tuoi)
        {
            this.maSV = maSV;
            this.hoTen = hoTen;
            this.diemTB = diemTB;
            this.khoa = khoa;
            this.tuoi = tuoi;
        }

        public SinhVien()
        {
        }

        public void Input()
        {
            Console.Write("Nhập MSSV: ");
            MaSV = Console.ReadLine();
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhập điểm trung bình: ");
            DiemTB = float.Parse(Console.ReadLine());

            Console.Write("Nhập khoa: ");
            Khoa = Console.ReadLine();

            Console.Write("Nhập tuổi:");
            Tuoi = int.Parse(Console.ReadLine());
        }
        public void Show()
        {
            Console.WriteLine("MSSV:{0} - Họ tên:{1} - Khoa:{2} - Điểm TB:{3} - Tuổi:{4}", this.MaSV, this.HoTen, this.Khoa, this.DiemTB, this.Tuoi);
        }
    }

}
