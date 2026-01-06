using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoAn_Handmade.SQL;

namespace DoAn_Handmade
{
    public partial class frm_DoanhThu : Form
    {
        QLCHContextDB db = new QLCHContextDB();

        public frm_DoanhThu()
        {
            InitializeComponent();
            dtp_TuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtp_DenNgay.Value = DateTime.Now;
            dgv_DoanhThu.DataError += (s, e) => { e.ThrowException = false; };
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                db = new QLCHContextDB(); 

                DateTime tuNgay = dtp_TuNgay.Value.Date;
                DateTime denNgay = dtp_DenNgay.Value.Date.AddDays(1).AddTicks(-1);

                // 1. LẤY DỮ LIỆU THÔ (Bao gồm cả thông tin Sản phẩm để lấy giá nhập)
                var queryRaw = db.ChiTietHoaDons
                    .Where(ct => ct.HoaDon.TrangThai == "Đã in" &&
                                 ct.HoaDon.NgayLap >= tuNgay &&
                                 ct.HoaDon.NgayLap <= denNgay)
                    .ToList();

                // Doanh thu = (Giá bán - Giảm giá) * Số lượng
                decimal tongDoanhThu = (decimal)queryRaw.Sum(ct => (ct.DonGia - (decimal)ct.GiamGia) * ct.SoLuong);

                // Chi phí = Giá nhập * Số lượng
                // (Sử dụng toán tử ?? 0 nếu GiaNhap trong DB cho phép null)
                decimal tongChiPhi = (decimal)queryRaw.Sum(ct => (ct.SanPham.GiaNhap ?? 0) * ct.SoLuong);

                // Lợi nhuận = Doanh thu - Chi phí
                decimal tongLoiNhuan = tongDoanhThu - tongChiPhi;

                txt_TongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";
                txt_TongChiPhi.Text = tongChiPhi.ToString("N0") + " VNĐ";
                txt_TongLoiNhuan.Text = tongLoiNhuan.ToString("N0") + " VNĐ";

                txt_TongLoiNhuan.ForeColor = tongLoiNhuan >= 0 ? Color.DarkGreen : Color.Red;

                var resultGrid = queryRaw
                    .GroupBy(ct => ct.HoaDon.TenTaiKhoan)
                    .Select(g => new
                    {
                        TenTK = g.Key,
                        SoDonDaMua = g.Select(x => x.MaHD).Distinct().Count(),
                        TongTien = g.Sum(x => (x.DonGia - (decimal)x.GiamGia) * x.SoLuong)
                    }).ToList();

                dgv_DoanhThu.AutoGenerateColumns = false;
                dgv_DoanhThu.DataSource = resultGrid;

                // Mapping cột cho DataGridView
                dgv_DoanhThu.Columns["Column1"].DataPropertyName = "TenTK";
                dgv_DoanhThu.Columns["Column2"].DataPropertyName = "SoDonDaMua";
                dgv_DoanhThu.Columns["Column3"].DataPropertyName = "TongTien";
                dgv_DoanhThu.Columns["Column3"].DefaultCellStyle.Format = "N0";

                if (queryRaw.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message);
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["frm_TrangChu"];
            if (frm != null) frm.Show();
            this.Hide();
        }

        private void frm_DoanhThu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frm_DoanhThu_Load(object sender, EventArgs e)
        {
            btn_ThongKe.BackColor = Color.LightBlue;
            btn_Thoat.BackColor = Color.LightGray;

        }
    }
}