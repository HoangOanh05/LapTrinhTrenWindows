using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Globalization; // Thư viện để định dạng số 3.000
using DoAn_Handmade.SQL;

namespace DoAn_Handmade
{
    public partial class frm_MuaHang : Form
    {
        QLCHContextDB db = new QLCHContextDB();
        private string _tenTK;
        // Khai báo văn hóa Việt Nam dùng chung cho toàn Form
        CultureInfo culture = new CultureInfo("vi-VN");

        public frm_MuaHang(string user = "")
        {
            InitializeComponent();
            this._tenTK = user;

            this.Load += frm_MuaHang_Load;
            dgv_ThongTin.CellClick += dgv_ThongTin_CellClick;
            txt_SoLuong.TextChanged += txt_SoLuong_TextChanged;

            dgv_ThongTin.DataError += (s, e) => { e.ThrowException = false; };
        }

        private void frm_MuaHang_Load(object sender, EventArgs e)
        {
            btn_Mua.BackColor = Color.LightGreen;
            panel_anh.BackgroundImageLayout = ImageLayout.Zoom;
            panel_anh.BorderStyle = BorderStyle.FixedSingle;
            txt_SoLuong.Text = "1";
            txt_ThanhTien.ReadOnly = true;

            if (!string.IsNullOrEmpty(_tenTK))
                this.Text = "Cửa hàng Handmade - Xin chào: " + _tenTK;

            LoadDanhSachSanPham();
        }

        public void LoadDanhSachSanPham()
        {
            try
            {
                db = new QLCHContextDB();
                dgv_ThongTin.AutoGenerateColumns = false;

                dgv_ThongTin.Columns["column1"].DataPropertyName = "MaSP";
                dgv_ThongTin.Columns["column2"].DataPropertyName = "TenSP";
                dgv_ThongTin.Columns["column3"].DataPropertyName = "GiamGia";
                dgv_ThongTin.Columns["column4"].DataPropertyName = "GiaBan";
                dgv_ThongTin.Columns["column5"].DataPropertyName = "ChatLieu";

                // Định dạng hiển thị dấu chấm trên DataGridView
                dgv_ThongTin.Columns["column3"].DefaultCellStyle.Format = "N0";
                dgv_ThongTin.Columns["column4"].DefaultCellStyle.Format = "N0";

                var ds = db.SanPhams.Where(p => p.SoLuong > 0).ToList();
                dgv_ThongTin.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
            }
        }

        private void dgv_ThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var sp = dgv_ThongTin.Rows[e.RowIndex].DataBoundItem as SanPham;

                if (sp != null)
                {
                    // 1. Gán thông tin chữ
                    txt_MaSP.Text = sp.MaSP;
                    txt_TenSP.Text = sp.TenSP;
                    txt_ChatLieu.Text = sp.ChatLieu; // Trả thông tin chất liệu về GroupBox

                    // 2. Gán thông tin số kèm định dạng 3.000 (Sử dụng văn hóa vi-VN)
                    txt_GiaBan.Text = (sp.GiaBan ?? 0).ToString("N0", culture);
                    txt_GiamGia.Text = (sp.GiamGia ?? 0).ToString("N0", culture);

                    txt_SoLuong.Text = "1";
                    TinhThanhTien();

                    // 3. Xử lý hiển thị ảnh
                    if (panel_anh.BackgroundImage != null) panel_anh.BackgroundImage.Dispose();
                    if (!string.IsNullOrEmpty(sp.AnhSP))
                    {
                        string path = Path.Combine(Application.StartupPath, "image", sp.AnhSP);
                        if (File.Exists(path))
                        {
                            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                            {
                                panel_anh.BackgroundImage = Image.FromStream(fs);
                            }
                        }
                        else panel_anh.BackgroundImage = null;
                    }
                    else panel_anh.BackgroundImage = null;
                }
            }
        }

        private void TinhThanhTien()
        {
            try
            {
                // Khi Parse ngược lại từ chuỗi "3.000", cần sử dụng NumberStyles.AllowThousands
                if (decimal.TryParse(txt_GiaBan.Text, NumberStyles.AllowThousands, culture, out decimal gia) &&
                    decimal.TryParse(txt_GiamGia.Text, NumberStyles.AllowThousands, culture, out decimal giam) &&
                    int.TryParse(txt_SoLuong.Text, out int sl))
                {
                    decimal thanhTien = (gia - giam) * sl;
                    // Hiển thị kết quả định dạng 3.000
                    txt_ThanhTien.Text = thanhTien.ToString("N0", culture);
                }
            }
            catch { txt_ThanhTien.Text = "0"; }
        }

        private void btn_Tang_Click(object sender, EventArgs e)
        {
            var sp = dgv_ThongTin.CurrentRow?.DataBoundItem as SanPham;
            if (sp != null && int.TryParse(txt_SoLuong.Text, out int hienTai))
            {
                if (hienTai < sp.SoLuong)
                    txt_SoLuong.Text = (hienTai + 1).ToString();
                else
                    MessageBox.Show("Cửa hàng chỉ còn " + sp.SoLuong + " sản phẩm này.");
            }
        }

        private void btn_Giam_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txt_SoLuong.Text, out int hienTai) && hienTai > 1)
            {
                txt_SoLuong.Text = (hienTai - 1).ToString();
            }
        }

        private void txt_SoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void btn_Mua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_tenTK))
                {
                    MessageBox.Show("Lỗi: Không tìm thấy tài khoản. Vui lòng đăng nhập lại!");
                    return;
                }

                var spChon = dgv_ThongTin.CurrentRow?.DataBoundItem as SanPham;
                if (spChon == null)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm!");
                    return;
                }

                int slMua = int.Parse(txt_SoLuong.Text);
                if (slMua > spChon.SoLuong)
                {
                    MessageBox.Show("Số lượng mua vượt quá hàng trong kho!");
                    return;
                }

                // Lưu Hóa đơn
                HoaDon hd = new HoaDon
                {
                    NgayLap = DateTime.Now,
                    TenTaiKhoan = this._tenTK,
                    TrangThai = "Mới"
                };
                db.HoaDons.Add(hd);
                db.SaveChanges();

                // Lưu Chi tiết hóa đơn
                ChiTietHoaDon ct = new ChiTietHoaDon
                {
                    MaHD = hd.MaHD,
                    MaSP = spChon.MaSP,
                    SoLuong = slMua,
                    DonGia = spChon.GiaBan,
                    GiamGia = (double?)(decimal?)spChon.GiamGia // Đảm bảo ép kiểu khớp DB
                };
                db.ChiTietHoaDons.Add(ct);

                // Cập nhật tồn kho
                spChon.SoLuong -= slMua;
                if (spChon.SoLuong == 0) spChon.TrangThai = "Hết hàng";

                db.SaveChanges();
                MessageBox.Show("Đặt hàng thành công!");

                frm_TrangChu frmChu = (frm_TrangChu)Application.OpenForms["frm_TrangChu"];
                if (frmChu != null) frmChu.HienThiDonHangMoiNhat();

                LoadDanhSachSanPham();
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException != null ? ex.InnerException.InnerException : ex;
                MessageBox.Show("Lỗi mua hàng: " + inner.Message);
            }
        }

        private void txt_timkiemtensp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchName = txt_timkiemtensp.Text.Trim().ToLower();
                using (var dbSearch = new QLCHContextDB())
                {
                    var filteredList = dbSearch.SanPhams
                        .Where(p => p.TenSP.ToLower().Contains(searchName) && p.SoLuong > 0)
                        .ToList();
                    dgv_ThongTin.DataSource = filteredList;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_Store().Show();
            this.Hide();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DoiMatKhau frm = new frm_DoiMatKhau();
            frm.Show();
            this.Hide();
        }

        private void frm_MuaHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}