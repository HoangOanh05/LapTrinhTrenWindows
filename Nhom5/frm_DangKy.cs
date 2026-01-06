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
    public partial class frm_DangKy : Form
    {
        private Form _formStore;
        public frm_DangKy(Form formTruyenVao)
        {
            InitializeComponent();
            _formStore = formTruyenVao; // Gán Form Store vào biến để sử dụng sau này

        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_TenTaiKhoan.Text) || string.IsNullOrEmpty(txt_MatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên tài khoản và Mật khẩu!");
                return;
            }

            try
            {
                using (var db = new QLCHContextDB())
                {
                    // Kiểm tra xem tên tài khoản đã tồn tại trong SQL chưa
                    var checkExists = db.TaiKhoans.Find(txt_TenTaiKhoan.Text);
                    if (checkExists != null)
                    {
                        MessageBox.Show("Tên tài khoản này đã có người sử dụng. Vui lòng chọn tên khác!");
                        return;
                    }

                    // Tạo đối tượng người dùng mới
                    var nd = new TaiKhoan
                    {
                        TenTaiKhoan = txt_TenTaiKhoan.Text,
                        MatKhau = txt_MatKhau.Text
                    };

                    // Thêm vào bảng NguoiDung và Lưu thay đổi
                    db.TaiKhoans.Add(nd);
                    db.SaveChanges(); // Đây là lúc dữ liệu thực sự bay vào SQL

                    MessageBox.Show("Đăng ký tài khoản thành công");

                    // 3. Đóng Form để quay lại frm_Store
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu vào SQL: " + ex.Message);
            }
        }

        private void frm_DangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_formStore != null)
            {
                _formStore.Show(); // Hiện lại form Store khi form này đóng
            }
        }

        private void frm_DangKy_Load(object sender, EventArgs e)
        {

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["frm_Store"];
            if (frm != null) frm.Show();
            this.Hide();
        }
    }
}

