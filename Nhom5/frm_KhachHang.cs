using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoAn_Handmade.SQL; 

namespace DoAn_Handmade
{
    public partial class frm_KhachHang : Form
    {
        QLCHContextDB db = new QLCHContextDB();

        public frm_KhachHang()
        {
            InitializeComponent();
            this.Load += Frm_KhachHang_Load;
            dgv_KhachHang.CellClick += dgv_KhachHang_CellClick;
            txt_TimKiemKH.TextChanged += txt_TimKiemKH_TextChanged;
            dgv_KhachHang.DataError += (s, e) => { e.ThrowException = false; };
        }

        private void Frm_KhachHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhachHang();
            btn_Thoat.BackColor = Color.LightGray;
            btn_CapNhat.BackColor = Color.LightBlue;
            btn_Xoa.BackColor = Color.LightCoral;
        }

        // --- 1. HÀM TẢI DANH SÁCH (Tính Số đơn hàng dựa trên tên tài khoản) ---
        public void LoadDanhSachKhachHang()
        {
            try
            {
                db = new QLCHContextDB(); 
                dgv_KhachHang.AutoGenerateColumns = false;

                // TRUY VẤN: Lấy danh sách tài khoản và đếm số hóa đơn trong bảng HoaDon
                var query = db.TaiKhoans.Select(tk => new
                {
                    TenTK = tk.TenTaiKhoan,
                    MatKhau = tk.MatKhau,
                    // Đếm số lượng hóa đơn khớp với tên tài khoản này
                    SoDonMua = db.HoaDons.Count(hd => hd.TenTaiKhoan == tk.TenTaiKhoan)
                }).ToList();

                dgv_KhachHang.Columns["Column1"].DataPropertyName = "TenTK";
                dgv_KhachHang.Columns["Column2"].DataPropertyName = "MatKhau";
                dgv_KhachHang.Columns["Column3"].DataPropertyName = "SoDonMua";

                dgv_KhachHang.DataSource = query;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message);
            }
        }

        // --- 2. TRẢ DỮ LIỆU VỀ GROUPBOX KHI CLICK DÒNG ---
        private void dgv_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng dữ liệu hiện tại
                var row = dgv_KhachHang.Rows[e.RowIndex];

                // Hiển thị thông tin lên các TextBox trong GroupBox
                txt_TenTK.Text = row.Cells["Column1"].Value?.ToString();
                textBox2.Text = row.Cells["Column2"].Value?.ToString(); 

            }
        }

        // --- 3. TÌM KIẾM KHÁCH HÀNG (txt_TimKiemKH) ---
        private void txt_TimKiemKH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txt_TimKiemKH.Text.Trim().ToLower();
                db = new QLCHContextDB();

                var filtered = db.TaiKhoans
                    .Where(tk => tk.TenTaiKhoan.Contains(keyword))
                    .Select(tk => new
                    {
                        TenTK = tk.TenTaiKhoan,
                        MatKhau = tk.MatKhau,
                        SoDonMua = db.HoaDons.Count(hd => hd.TenTaiKhoan == tk.TenTaiKhoan)
                    }).ToList();

                dgv_KhachHang.DataSource = filtered;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm kiếm khách hàng: " + ex.Message);
            }
        }

        // --- 4. CẬP NHẬT (Sửa mật khẩu khách hàng) ---
        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string tenTK = txt_TenTK.Text.Trim();
                var tk = db.TaiKhoans.FirstOrDefault(x => x.TenTaiKhoan == tenTK);

                if (tk != null)
                {
                    tk.MatKhau = textBox2.Text; // Gán mật khẩu mới từ GroupBox
                    db.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!");
                    LoadDanhSachKhachHang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        // --- 5. XÓA TÀI KHOẢN KHÁCH HÀNG ---
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string tenTK = txt_TenTK.Text.Trim();
                var tk = db.TaiKhoans.FirstOrDefault(x => x.TenTaiKhoan == tenTK);

                if (tk != null)
                {
                    // KIỂM TRA RÀNG BUỘC: Nếu khách đã mua hàng thì không nên xóa để giữ lịch sử
                    bool daCoHoaDon = db.HoaDons.Any(h => h.TenTaiKhoan == tenTK);
                    if (daCoHoaDon)
                    {
                        MessageBox.Show("Tài khoản này đã có lịch sử mua hàng, không thể xóa!");
                        return;
                    }

                    if (MessageBox.Show("Xác nhận xóa khách hàng này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        db.TaiKhoans.Remove(tk);
                        db.SaveChanges();
                        LoadDanhSachKhachHang();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        // --- ĐIỀU HƯỚNG ---
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["frm_TrangChu"];
            if (frm != null) frm.Show();
            this.Hide();
        }

        private void frm_KhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}