using DoAn_Handmade.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Handmade
{
    public partial class frm_DoiMatKhau : Form
    {
        public frm_DoiMatKhau()
        {
            InitializeComponent();
        }
        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            string tenTK = txt_TenTK.Text.Trim();
            string mkCu = txt_MKCu.Text;
            string mkMoi = txt_MKMoi.Text;
            string xacNhanMK = txt_XacNhanMKMoi.Text;



            // 3. Kiểm tra mật khẩu mới và xác nhận mật khẩu có khớp nhau không
            if (mkMoi != xacNhanMK)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không trùng khớp!", "Lỗi");
                return;
            }

            try
            {
                using (var db = new QLCHContextDB())
                {
                    // Tìm người dùng dựa trên Tên tài khoản và Mật khẩu cũ
                    var nguoiDung = db.TaiKhoans.FirstOrDefault(u => u.TenTaiKhoan == tenTK && u.MatKhau == mkCu);

                    if (nguoiDung != null)
                    {
                        // 5. Nếu tìm thấy, thực hiện cập nhật mật khẩu mới
                        nguoiDung.MatKhau = mkMoi;

                        db.SaveChanges(); // Lưu thay đổi vào SQL Server

                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");

                        // Sau khi đổi thành công, có thể thoát về trang chủ hoặc yêu cầu đăng nhập lại
                        frm_Store frm = new frm_Store();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Nếu không tìm thấy dòng nào khớp (Tài khoản hoặc MK cũ sai)
                        MessageBox.Show("Tên tài khoản hoặc mật khẩu cũ không chính xác!", "Lỗi");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống");
            }
        }
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["frm_TrangChu"];

            if (frm != null)
            {
                frm.Show(); // Hiện lại trang chủ
            }

            this.Hide(); // Đóng form Sản phẩm hiện tại
        }

        private void frm_DoiMatKhau_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txt_TenTK_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_MKCu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_MKMoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_XacNhanMKMoi_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
