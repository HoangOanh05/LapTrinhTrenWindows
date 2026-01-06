using DoAn_Handmade.SQL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DoAn_Handmade
{
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txt_TenTaiKhoan.Text.Trim(); // .Trim() để loại bỏ khoảng trắng thừa
            string matKhau = txt_MatKhau.Text;
            string loaiNguoiDung = cmb_NguoiDung.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(loaiNguoiDung))
            {
                MessageBox.Show("Vui lòng chọn loại người dùng!");
                return;
            }

            // TRƯỜNG HỢP 1: ADMIN
            if (loaiNguoiDung == "Admin")
            {
                if (taiKhoan == "admin" && matKhau == "123456")
                {
                    MessageBox.Show("Chào sếp! Đăng nhập Admin thành công.");
                    frm_TrangChu trangChu = new frm_TrangChu();
                    trangChu.Show();
                    this.FormClosed -= frm_DangNhap_FormClosed;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu Admin!");
                }
            }
            // TRƯỜNG HỢP 2: KHÁCH HÀNG
            else if (loaiNguoiDung == "Khách hàng")
            {
                using (var db = new QLCHContextDB())
                {
                    var userTrongDb = db.TaiKhoans
                                        .FirstOrDefault(u => u.TenTaiKhoan == taiKhoan && u.MatKhau == matKhau);

                    if (userTrongDb != null)
                    {
                        MessageBox.Show("Chào khách hàng! Đăng nhập thành công.");

                        // --- ĐÃ SỬA Ở ĐÂY: Truyền 'taiKhoan' vào trong ngoặc ---
                        frm_MuaHang muaHang = new frm_MuaHang(taiKhoan);

                        muaHang.Show();

                        this.FormClosed -= frm_DangNhap_FormClosed;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu khách hàng không đúng!");
                    }
                }
            }
        }

        private void frm_DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["frm_Store"];
            if (frm != null) frm.Show();
            this.Hide();
        }
    }
}