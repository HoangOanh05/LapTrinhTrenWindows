using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoAn_Handmade.SQL;

namespace DoAn_Handmade
{
    public partial class frm_HoaDon : Form
    {
        private int _maHD;
        QLCHContextDB db = new QLCHContextDB();
        private string maHD;

        public frm_HoaDon(int maHD = 0)
        {
            InitializeComponent();
            _maHD = maHD;
            this.Load += Frm_HoaDon_Load;
        }

        public frm_HoaDon(string maHD)
        {
            this.maHD = maHD;
        }

        private void Frm_HoaDon_Load(object sender, EventArgs e)
        {
            if (_maHD > 0)
            {
                HienThiDuLieuHoaDon(_maHD);
                btn_TroVe.BackColor = Color.LightGray;
                btn_In.BackColor = Color.LightBlue;

            }
        }

        private string TaoMaHDNgauNhien()
        {
            Random r = new Random();
            char c1 = (char)r.Next('A', 'Z' + 1);
            char c2 = (char)r.Next('A', 'Z' + 1);
            int so = r.Next(100, 999);
            return $"{c1}{c2}{so}";
        }

        private void HienThiDuLieuHoaDon(int maHD)
        {
            try
            {
                db = new QLCHContextDB();
                var hoaDon = db.HoaDons.FirstOrDefault(h => h.MaHD == maHD);
                if (hoaDon == null) return;

                txt_MaHD.Text = TaoMaHDNgauNhien();
                dtp_NgayLap.Value = DateTime.Now;
                txt_TaiKhoan.Text = hoaDon.TenTaiKhoan;

                var listChiTietRaw = db.ChiTietHoaDons
                    .Where(ct => ct.MaHD == maHD)
                    .ToList();

                var chiTietHienThi = listChiTietRaw.Select(ct => new
                {
                    TenSP = ct.SanPham != null ? ct.SanPham.TenSP : "",
                    ChatLieu = ct.SanPham != null ? ct.SanPham.ChatLieu : "", // LẤY DỮ LIỆU Ở ĐÂY
                    SoLuong = ct.SoLuong,
                    GiamGia = ct.GiamGia,
                    GiaBan = ct.DonGia,
                    ThanhTien = (ct.DonGia - (decimal)ct.GiamGia) * ct.SoLuong
                }).ToList();

                dgv_HoaDon.AutoGenerateColumns = false;
                dgv_HoaDon.DataSource = chiTietHienThi;

                // Gán đúng tên thuộc tính vào các cột
                dgv_HoaDon.Columns["Column1"].DataPropertyName = "TenSP";
                dgv_HoaDon.Columns["Column2"].DataPropertyName = "SoLuong";
                dgv_HoaDon.Columns["Column3"].DataPropertyName = "GiamGia";
                dgv_HoaDon.Columns["Column4"].DataPropertyName = "GiaBan";
                dgv_HoaDon.Columns["Column5"].DataPropertyName = "ChatLieu"; // KHỚP VỚI PROPERTY Ở TRÊN

                dgv_HoaDon.Columns["Column4"].DefaultCellStyle.Format = "N0";
                dgv_HoaDon.Columns["Column3"].DefaultCellStyle.Format = "N0";

                decimal tongTien = (decimal)chiTietHienThi.Sum(x => x.ThanhTien);
                txt_ThanhTien.Text = tongTien.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị hóa đơn: " + ex.Message);
            }
        }

        private void btn_TroVe_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["frm_TrangChu"];
            if (frm != null) frm.Show();
            this.Hide();
        }

        private void frm_HoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = Application.OpenForms["frm_TrangChu"];
            if (frm != null) frm.Show();
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dbUpdate = new QLCHContextDB())
                {
                    var hd = dbUpdate.HoaDons.FirstOrDefault(x => x.MaHD == _maHD);
                    if (hd != null)
                    {
                        hd.TrangThai = "Đã in";
                        dbUpdate.SaveChanges();
                    }
                }

                MessageBox.Show("In hóa đơn thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Application.OpenForms["frm_TrangChu"] is frm_TrangChu trangChu)
                {
                    trangChu.HienThiDonHangMoiNhat();
                    trangChu.Show();
                }
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message);
            }
        }
    }
}
