using DoAn_Handmade.SQL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DoAn_Handmade
{
    public partial class frm_SanPham : Form
    {
        QLCHContextDB db = new QLCHContextDB();
        string duongDanFull = "";
        CultureInfo vi = new CultureInfo("vi-VN");

        public frm_SanPham()
        {
            InitializeComponent();
            this.Load += frm_SanPham_Load;
            dgv_SanPham.RowPostPaint += dgv_SanPham_RowPostPaint;
            dgv_SanPham.DataError += (s, e) => { e.ThrowException = false; };

            txt_GiaBan.Leave += TxtGia_Leave;
            txt_GiaNhap.Leave += TxtGia_Leave;
            txt_GiamGia.Leave += TxtGiamGia_Leave;
        }

        private void frm_SanPham_Load(object sender, EventArgs e)
        {
            btn_CapNhat.BackColor = Color.LightBlue;
            btn_Xoa.BackColor = Color.LightCoral;
            btn_Thoat.BackColor = Color.LightGray;
            KhoiTaoComboBoxChatLieu();
            LoadDataGrid();

            panel_anh.BackgroundImageLayout = ImageLayout.Zoom;
            panel_anh.BorderStyle = BorderStyle.FixedSingle;

            txt_GiaBan.Text = "0";
            txt_GiaNhap.Text = "0";
            txt_GiamGia.Text = "0";
        }

        private void KhoiTaoComboBoxChatLieu()
        {
            cmb_ChatLieu.Items.Clear();
            cmb_ChatLieu.Items.AddRange(new string[]
            {
                "Cotton","Len sữa","Len cotton","Len lông cừu",
                "Vải canvas","Vải nỉ","Vải bố",
                "Vải lanh (linen)","Vải jeans","Vải dạ"
            });
            cmb_ChatLieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_ChatLieu.SelectedIndex = 0;
        }

        private void LoadDataGrid()
        {
            db = new QLCHContextDB();
            dgv_SanPham.AutoGenerateColumns = false;
            dgv_SanPham.DataSource = db.SanPhams.ToList();

            dgv_SanPham.Columns["Column1"].DataPropertyName = "MaSP";
            dgv_SanPham.Columns["Column2"].DataPropertyName = "TenSP";
            dgv_SanPham.Columns["Column3"].DataPropertyName = "ChatLieu";
            dgv_SanPham.Columns["Column4"].DataPropertyName = "NgayNhap";
            dgv_SanPham.Columns["Column5"].DataPropertyName = "GiaBan";
            dgv_SanPham.Columns["Column6"].DataPropertyName = "GiaNhap";
            dgv_SanPham.Columns["Column7"].DataPropertyName = "SoLuong";
            dgv_SanPham.Columns["Column8"].DataPropertyName = "GiamGia";
            dgv_SanPham.Columns["Column9"].DataPropertyName = "TrangThai";

            dgv_SanPham.Columns["Column5"].DefaultCellStyle.Format = "#,##0";
            dgv_SanPham.Columns["Column6"].DefaultCellStyle.Format = "#,##0";
            dgv_SanPham.Columns["Column8"].DefaultCellStyle.Format = "#,##0";
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            string ma = txt_MaSP.Text.Trim();
            // Nếu mã trống, tự động sinh mã mới cho đến khi không trùng trong DB
            if (string.IsNullOrEmpty(ma))
            {
                do
                {
                    ma = TaoMaSPNgauNhien();
                }
                while (db.SanPhams.Any(p => p.MaSP == ma));

                txt_MaSP.Text = ma;
            }
         
            var sp = db.SanPhams.FirstOrDefault(p => p.MaSP == ma);
            if (sp == null)
            {
                sp = new SanPham { MaSP = ma };
                db.SanPhams.Add(sp);
            }

            sp.TenSP = txt_TenSP.Text;
            sp.ChatLieu = cmb_ChatLieu.Text;
            sp.NgayNhap = dtp_NgayNhap.Value;
            sp.GiaBan = decimal.Parse(txt_GiaBan.Text.Replace(".", ""));
            sp.GiaNhap = decimal.Parse(txt_GiaNhap.Text.Replace(".", ""));
            sp.SoLuong = int.Parse(txt_SoLuong.Text);
            sp.GiamGia = double.Parse(txt_GiamGia.Text);
            sp.TrangThai = sp.SoLuong > 0 ? "Còn hàng" : "Hết hàng";

            if (!string.IsNullOrEmpty(duongDanFull))
            {
                string folder = Path.Combine(Application.StartupPath, "image");
                Directory.CreateDirectory(folder);
                string file = ma + Path.GetExtension(duongDanFull);
                File.Copy(duongDanFull, Path.Combine(folder, file), true);
                sp.AnhSP = file;
            }

            db.SaveChanges();
            MessageBox.Show("Lưu thành công!");
            LoadDataGrid();
            btn_LamMoi_Click(sender, e);
        }

        private void dgv_SanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var sp = dgv_SanPham.Rows[e.RowIndex].DataBoundItem as SanPham;

            txt_MaSP.Text = sp.MaSP;
            txt_TenSP.Text = sp.TenSP;
            cmb_ChatLieu.Text = sp.ChatLieu;
            dtp_NgayNhap.Value = sp.NgayNhap ?? DateTime.Now;
            txt_GiaBan.Text = sp.GiaBan?.ToString("#,##0", vi) ?? "0";
            txt_GiaNhap.Text = sp.GiaNhap?.ToString("#,##0", vi) ?? "0";
            txt_SoLuong.Text = sp.SoLuong.ToString();
            txt_GiamGia.Text = sp.GiamGia?.ToString("#,##0") ?? "0";

            if (panel_anh.BackgroundImage != null) panel_anh.BackgroundImage.Dispose();
            if (!string.IsNullOrEmpty(sp.AnhSP))
            {
                string path = Path.Combine(Application.StartupPath, "image", sp.AnhSP);
                if (File.Exists(path))
                    panel_anh.BackgroundImage = Image.FromFile(path);
            }
        }

        private void TxtGia_Leave(object sender, EventArgs e)
        {

        }

        private void TxtGiamGia_Leave(object sender, EventArgs e)
        {

        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_MaSP.Clear();
            txt_TenSP.Clear();
            txt_GiaBan.Text = "";
            txt_GiaNhap.Text = "";
            txt_GiamGia.Text = "";
            txt_SoLuong.Text = "";
            cmb_ChatLieu.SelectedIndex = 0;
            dtp_NgayNhap.Value = DateTime.Now;
            panel_anh.BackgroundImage = null;
            duongDanFull = "";
        }

        private string TaoMaSPNgauNhien()
        {
            Random res = new Random();
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            List<char> selectedChars = new List<char>();

            // 1. Lấy 2 chữ cái ngẫu nhiên
            for (int i = 0; i < 2; i++)
                selectedChars.Add(letters[res.Next(letters.Length)]);

            // 2. Lấy 4 chữ số ngẫu nhiên
            for (int i = 0; i < 4; i++)
                selectedChars.Add(numbers[res.Next(numbers.Length)]);

            return new string(selectedChars.OrderBy(x => res.Next()).ToArray());
        }

        private void dgv_SanPham_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                Font, Brushes.Black,
                e.RowBounds.Left + 10, e.RowBounds.Top + 4);
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["frm_TrangChu"];
            if (frm != null) frm.Show();
            this.Hide();
        }

        private void frm_SanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_up_anh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh sản phẩm";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Giải phóng ảnh cũ nếu có
                    if (panel_anh.BackgroundImage != null)
                    {
                        panel_anh.BackgroundImage.Dispose();
                        panel_anh.BackgroundImage = null;
                    }

                    // Hiển thị ảnh mới
                    panel_anh.BackgroundImage = Image.FromFile(ofd.FileName);
                    panel_anh.BackgroundImageLayout = ImageLayout.Zoom;

                    // Lưu đường dẫn & tên file
                    duongDanFull = ofd.FileName;
                    panel_anh.Tag = Path.GetFileName(ofd.FileName);
                }
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy mã sản phẩm từ ô TextBox
                string ma = txt_MaSP.Text.Trim();

                if (string.IsNullOrEmpty(ma))
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xóa từ danh sách!", "Thông báo");
                    return;
                }

                // 2. Tìm sản phẩm trong Cơ sở dữ liệu
                var sp = db.SanPhams.FirstOrDefault(p => p.MaSP == ma);

                if (sp != null)
                {
                    // 3. Hỏi xác nhận trước khi xóa
                    DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm: {sp.TenSP}?",
                        "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        // 4. Kiểm tra ràng buộc: Nếu sản phẩm đã nằm trong hóa đơn thì không cho xóa
                        bool daCoHoaDon = db.ChiTietHoaDons.Any(ct => ct.MaSP == ma);
                        if (daCoHoaDon)
                        {
                            MessageBox.Show("Không thể xóa sản phẩm này vì đã có dữ liệu trong các hóa đơn cũ!",
                                "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        // 5. Xử lý xóa ảnh trong thư mục để giải phóng dung lượng (tùy chọn)
                        if (!string.IsNullOrEmpty(sp.AnhSP))
                        {
                            string path = Path.Combine(Application.StartupPath, "image", sp.AnhSP);

                            // Giải phóng ảnh trên giao diện trước khi xóa file vật lý
                            if (panel_anh.BackgroundImage != null)
                            {
                                panel_anh.BackgroundImage.Dispose();
                                panel_anh.BackgroundImage = null;
                            }

                            if (File.Exists(path))
                            {
                                try { File.Delete(path); } catch { /* Bỏ qua nếu file đang bị khóa */ }
                            }
                        }

                        // 6. Thực hiện xóa trong DB
                        db.SanPhams.Remove(sp);
                        db.SaveChanges();

                        MessageBox.Show("Đã xóa sản phẩm thành công!");

                        // 7. Làm mới lại danh sách và ô nhập liệu
                        LoadDataGrid();
                        btn_LamMoi_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để xóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }

        private void txt_timkiemmasanpham_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy chuỗi tìm kiếm từ TextBox và chuẩn hóa (xóa khoảng trắng, chuyển về chữ thường)
                string keyword = txt_timkiemmasanpham.Text.Trim().ToLower();

                // 2. Nếu ô tìm kiếm trống, hiển thị lại toàn bộ danh sách
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadDataGrid();
                    return;
                }

                // 3. Truy vấn LINQ để lọc danh sách sản phẩm theo Mã SP
                var filteredData = db.SanPhams
                                     .Where(p => p.MaSP.ToLower().Contains(keyword))
                                     .ToList();

                // 4. Cập nhật lại nguồn dữ liệu cho DataGridView
                dgv_SanPham.DataSource = filteredData;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm kiếm: " + ex.Message);
            }
        }
    }
}
