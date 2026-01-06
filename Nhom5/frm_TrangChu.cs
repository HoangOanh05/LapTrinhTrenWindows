using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoAn_Handmade.SQL;

namespace DoAn_Handmade
{
    public partial class frm_TrangChu : Form
    {
        QLCHContextDB db = new QLCHContextDB();

        public frm_TrangChu()
        {
            InitializeComponent();
            this.Load += Frm_TrangChu_Load;
            dgv_TrangChu.RowPostPaint += dgv_TrangChu_RowPostPaint;
            dgv_TrangChu.CellClick += dgv_TrangChu_CellClick;
            dgv_TrangChu.DataError += (s, e) => { e.ThrowException = false; };

            txt_timkiemmasp.TextChanged += Filter_Changed;
            check_hoadonchuain.CheckedChanged += Filter_Changed;
        }

        private void Frm_TrangChu_Load(object sender, EventArgs e)
        {
            btn_XuatHoaDon.BackColor = Color.LightBlue;
            HienThiDonHangMoiNhat();
        }

        public void HienThiDonHangMoiNhat()
        {
            try
            {
                db = new QLCHContextDB(); 
                dgv_TrangChu.AutoGenerateColumns = false;

                var query = db.ChiTietHoaDons.AsQueryable();

                //  Lọc theo Mã SP
                string maSP = txt_timkiemmasp.Text.Trim();
                if (!string.IsNullOrEmpty(maSP))
                    query = query.Where(ct => ct.MaSP.Contains(maSP));


                //loc chưa in
                if (check_hoadonchuain.Checked)
                    query = query.Where(ct => ct.HoaDon.TrangThai == "Mới");

                var result = query
      .OrderByDescending(ct => ct.HoaDon.NgayLap)
      .Select(ct => new
      {
          MaHD = ct.MaHD,
          ChatLieu = ct.SanPham.ChatLieu,
          MaSP = ct.MaSP,
          TenSP = ct.SanPham.TenSP,
          SoLuongMua = ct.SoLuong,
          GiamGia = ct.GiamGia,
          GiaBan = ct.DonGia,
          Kho = ct.SanPham.SoLuong,
          TenTK = ct.HoaDon.TenTaiKhoan,

          TrangThai = ct.HoaDon.TrangThai == "Mới" ? "Chưa in" : "Đã in"
      }).ToList();


                dgv_TrangChu.DataSource = result;

                dgv_TrangChu.Columns["column1"].DataPropertyName = "ChatLieu";
                dgv_TrangChu.Columns["column2"].DataPropertyName = "MaSP";
                dgv_TrangChu.Columns["column3"].DataPropertyName = "TenSP";
                dgv_TrangChu.Columns["column4"].DataPropertyName = "SoLuongMua";
                dgv_TrangChu.Columns["column5"].DataPropertyName = "GiamGia";
                dgv_TrangChu.Columns["column6"].DataPropertyName = "GiaBan";
                dgv_TrangChu.Columns["column7"].DataPropertyName = "Kho";
                dgv_TrangChu.Columns["column8"].DataPropertyName = "TenTK";
                dgv_TrangChu.Columns["column9"].DataPropertyName = "TrangThai";

                dgv_TrangChu.Columns["Column5"].DefaultCellStyle.Format = "#,##0";
                dgv_TrangChu.Columns["Column6"].DefaultCellStyle.Format = "#,##0";


                decimal tongTatCa = (decimal)result.Sum(x => (x.GiaBan - (decimal)x.GiamGia) * x.SoLuongMua);
                txt_TongTienTatCaDonHang.Text = tongTatCa.ToString("N0");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            HienThiDonHangMoiNhat();
        }

        //  XUẤT HÓA ĐƠN
        private void btn_XuatHoaDon_Click(object sender, EventArgs e)
        {
            if (dgv_TrangChu.CurrentRow != null)
            {
                dynamic data = dgv_TrangChu.CurrentRow.DataBoundItem;
                string trangThai = data.TrangThai;

                // đơn đã in rồi
                if (trangThai == "Đã in")
                {
                    MessageBox.Show("Hóa đơn này đã được in thành công trước đó!\nBạn không thể in lại ở đây, hãy vào Lịch sử hóa đơn.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maHD = data.MaHD;
                frm_HoaDon frm = new frm_HoaDon(maHD);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng!");
            }
        }

        // --- 3. HIỂN THỊ THÀNH TIỀN DÒNG ĐANG CHỌN ---
        private void dgv_TrangChu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv_TrangChu.Rows[e.RowIndex];
                if (row.Cells["column4"].Value != null && row.Cells["column6"].Value != null)
                {
                    int sl = Convert.ToInt32(row.Cells["column4"].Value);
                    decimal giamGia = Convert.ToDecimal(row.Cells["column5"].Value);
                    decimal giaBan = Convert.ToDecimal(row.Cells["column6"].Value);

                    decimal thanhTien = (giaBan - giamGia) * sl;
                    txt_ThanhTien.Text = thanhTien.ToString("N0");
                }
            }
        }

        private void dgv_TrangChu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e) { new frm_SanPham().Show(); this.Hide(); }
        private void khachHangToolStripMenuItem_Click(object sender, EventArgs e) { new frm_KhachHang().Show(); this.Hide(); }
        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e) { new frm_DoanhThu().Show(); this.Hide(); }
        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e) { new frm_LichSuHoaDon().Show(); this.Hide(); }
        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e) { new frm_Store().Show(); this.Hide(); }
        private void frm_TrangChu_FormClosed(object sender, FormClosedEventArgs e) { Application.Exit(); }

        private void DoiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DoiMatKhau frm = new frm_DoiMatKhau();
            frm.Show();
            this.Hide();
        }
    }
}