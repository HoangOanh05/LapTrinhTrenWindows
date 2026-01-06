using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoAn_Handmade.SQL;
using System.Data.Entity; 
namespace DoAn_Handmade
{
    public partial class frm_LichSuHoaDon : Form
    {
        QLCHContextDB db = new QLCHContextDB();

        public frm_LichSuHoaDon()
        {
            InitializeComponent();
            this.Load += Frm_LichSuHoaDon_Load;

            dgv_LSHD.DataError += (s, e) => { e.ThrowException = false; };
            dgv_LSHD.RowPostPaint += dgv_LSHD_RowPostPaint;

            txt_TimKiemMaHD.TextChanged += txt_TimKiemMaHD_TextChanged;
        }

        private void Frm_LichSuHoaDon_Load(object sender, EventArgs e)
        {
            LoadLichSuHoaDon(); 
            btn_XuatLaiHoaDon.BackColor = Color.LightBlue;
            btn_Thoat.BackColor = Color.LightGray;
        }

        // Hàm tạo mã hiển thị 
        private string TaoMaHienThi(int idGoc)
        {
            Random r = new Random(idGoc);
            char c1 = (char)r.Next('A', 'Z' + 1);
            char c2 = (char)r.Next('A', 'Z' + 1);
            int so = r.Next(100, 999);
            return $"{c1}{c2}{so}";
        }

        // --- SỬA LẠI HÀM LOAD ĐỂ HỖ TRỢ TÌM KIẾM ---
        public void LoadLichSuHoaDon(string keyword = "")
        {
            try
            {
                db = new QLCHContextDB();

                // 1. Lấy dữ liệu từ DB (Eager Loading với Include)
                var listFromDB = db.ChiTietHoaDons
                    .Include(ct => ct.HoaDon)
                    .Include(ct => ct.SanPham)
                    .Where(ct => ct.HoaDon.TrangThai == "Đã in")
                    .OrderByDescending(ct => ct.HoaDon.NgayLap)
                    .ToList();

                // 2. Chuyển đổi sang dạng hiển thị (Anonymous Type)
                var result = listFromDB.Select(ct => new
                {
                    MaHienThi = TaoMaHienThi(ct.HoaDon.MaHD),
                    MaHD = ct.HoaDon.MaHD,
                    TenTK = ct.HoaDon.TenTaiKhoan,
                    NgayLap = ct.HoaDon.NgayLap,
                    TenSP = ct.SanPham != null ? ct.SanPham.TenSP : "N/A",
                    ChatLieu = ct.SanPham != null ? ct.SanPham.ChatLieu : "N/A", // Đã bổ sung
                    SoLuong = ct.SoLuong,
                    GiamGia = ct.GiamGia,
                    GiaBan = ct.DonGia,
                    TongTien = (ct.DonGia - (decimal)ct.GiamGia) * ct.SoLuong
                }).ToList();

                // 3. Lọc theo từ khóa
                if (!string.IsNullOrEmpty(keyword))
                {
                    string k = keyword.ToLower();
                    result = result.Where(x => x.MaHienThi.ToLower().Contains(k)).ToList();
                }

                dgv_LSHD.AutoGenerateColumns = false;
                dgv_LSHD.DataSource = result;

                // Gán dữ liệu cho các cột (Đảm bảo tên DataPropertyName khớp chính xác)
                dgv_LSHD.Columns["Column1"].DataPropertyName = "MaHienThi";
                dgv_LSHD.Columns["Column2"].DataPropertyName = "TenTK";
                dgv_LSHD.Columns["Column3"].DataPropertyName = "NgayLap";
                dgv_LSHD.Columns["Column4"].DataPropertyName = "TenSP";
                dgv_LSHD.Columns["Column5"].DataPropertyName = "SoLuong";
                dgv_LSHD.Columns["Column6"].DataPropertyName = "ChatLieu"; // Cột này sẽ hiển thị đúng
                dgv_LSHD.Columns["Column7"].DataPropertyName = "GiamGia";
                dgv_LSHD.Columns["Column8"].DataPropertyName = "GiaBan";
                dgv_LSHD.Columns["Column9"].DataPropertyName = "TongTien";

                dgv_LSHD.Columns["Column8"].DefaultCellStyle.Format = "N0";
                dgv_LSHD.Columns["Column9"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txt_TimKiemMaHD_TextChanged(object sender, EventArgs e)
        {
            // Gọi hàm Load với từ khóa hiện tại
            LoadLichSuHoaDon(txt_TimKiemMaHD.Text.Trim());
        }

        private void btn_XuatLaiHoaDon_Click(object sender, EventArgs e)
        {
            if (dgv_LSHD.CurrentRow == null) return;

            dynamic item = dgv_LSHD.CurrentRow.DataBoundItem;
            int maHD = item.MaHD;

            frm_HoaDon frm = new frm_HoaDon(maHD);
            frm.Show();
            this.Hide();
        }


        private void dgv_LSHD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["frm_TrangChu"];
            frm?.Show();
            this.Hide();
        }

        private void frm_LichSuHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void txt_TimKiemMaHD_Click(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
