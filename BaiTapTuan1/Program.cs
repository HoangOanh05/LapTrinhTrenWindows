using System;

namespace GiaiPT
{
    ///<summary>
    /// lớp cha giải ptr bậc 1
    ///  bx + c=0
    /// </summary>

    public class GiaiPTBac1
    {
        protected double b;
        protected double c;

        public
            GiaiPTBac1(double b, double c)
        {
            this.b = b;
            this.c = c;
        }

        public virtual string Giai()
        {
            // bx +c=0
            if (b == 0)
            {
                if (c == 0)
                    return "Phương tình vô số nghiệm";
                else
                    return "Phương trình vô nghiệm";

            }
            double x = -c / b;
            //dấu $ dùng để chèn trực tiếp giá trị biến vào chuỗi
            return $"Phương trình có 1 nghiệm x = {x} ";
        }
    }

    /// <summary>
    /// lớp con giả ptr bậc 2
    /// ax^2 + bx + c =0
    /// </summary>
    public class GiaiPTBac2 : GiaiPTBac1

    {
        protected double a;
        private object x2;

        public GiaiPTBac2(double a, double b, double c) : base(b, c)
        {
            this.a = a;
        }
        public override string Giai()
        {
            // nếu a =0 thì ptr trở thành bx +c =0 -> gọi lớp cha để giải
            if (a == 0)
            {
                return " Phương trình suy biến thành bậc 1: \n" + base.Giai();
            }
            // tính delta b^2 - 4ac
            double delta = b * b - 4 * a * c;

            if (delta < 0)
            {
                return "Phương trình vô nghiệm thực";
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                return $"Phương trình có nghiệm kép: x1 = x2 = {x}";
            }
            else
            {

                double sqrtDelta = Math.Sqrt(delta);
                double x1 = (-b + sqrtDelta) / (2 * a);
                double x2 = (-b - sqrtDelta) / (2 * a);
                return $"Phương trình có 2 nghiệm phân biệt:nx1 = {x1}\nx2 ={x2} ";
            }
        }
    }
    /// <summary>
    /// lớp chính (main)
    /// </summary
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Trường hợp 1: 2 nghiệm(a =1, b =-3, c =2) ");
            var ptr1 = new GiaiPTBac2(1, -3, 2);
            Console.WriteLine(ptr1.Giai());

            Console.WriteLine("\nTrường hợp 2: nghiệm kép(a =1, b =2, c =1) ");
            var ptr2 = new GiaiPTBac2(1, 2, 1);
            Console.WriteLine(ptr2.Giai());

            Console.WriteLine("\nTrường hợp 3: vô nghiệm(a=5, b =2, c =1) ");
            var ptr3 = new GiaiPTBac2(5, 2, 1);
            Console.WriteLine(ptr3.Giai());

            Console.WriteLine("\nTrường hợp 4: suy biến( a =0, b =2, c =-4) ");
            var ptr4 = new GiaiPTBac2(0, 2, -4);
            Console.WriteLine(ptr4.Giai());

            Console.ReadKey();

        }
    }

}
