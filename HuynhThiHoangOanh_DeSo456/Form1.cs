using HuynhThiHoangOanh_DeSo456.sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace HuynhThiHoangOanh_DeSo456
{
    public partial class frm_thongtindiaphuong : Form
    {
        // Cache current list (sort direction not used anymore for this requirement)
        private List<DiaPhuong> _currentDiaPhuong;

        public frm_thongtindiaphuong()
        {
            InitializeComponent();
        }

        private void frm_thongtindiaphuong_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Model1())
                {
                    // Load DiaPhuong together with TrangThai so navigation property is available
                    var listDiaPhuong = context.DiaPhuong.Include(dp => dp.TrangThai).ToList();
                    var listTrangThai = context.TrangThai.ToList();

                    // store list in cache
                    _currentDiaPhuong = listDiaPhuong;

                    BindTrangThai(listTrangThai);
                    ShowDiaPhuong(_currentDiaPhuong);
                    ResetInputsToInitial();

                    // wire menu click handlers
                    this.sắpXếpTheoSốCaNhiễmToolStripMenuItem.Click += SapXepTheoSoCaNhiem_Click;
                    this.cácĐịaPhươngNhómNguyCơToolStripMenuItem.Click += CacDiaPhuongNhomNguyCo_Click;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindTrangThai(List<TrangThai> listTrangThai)
        {
            if (listTrangThai == null) return;

            cmbTrangThai.DataSource = listTrangThai;
            cmbTrangThai.DisplayMember = "TenTT";
            cmbTrangThai.ValueMember = "MaTT";
        }

        private void ShowDiaPhuong(List<DiaPhuong> listDiaPhuong)
        {
            if (listDiaPhuong == null) return;

            // Do not create/resize columns here — designer column sizes are preserved.
            dgv_thongtin.AutoGenerateColumns = false;
            dgv_thongtin.Rows.Clear();

            foreach (var dp in listDiaPhuong)
            {
                int rowIndex = dgv_thongtin.Rows.Add();
                var row = dgv_thongtin.Rows[rowIndex];

                // Use the designer-defined column names (Column1..Column4)
                row.Cells["Column1"].Value = dp.MaDP;
                row.Cells["Column2"].Value = dp.TenDP;
                row.Cells["Column3"].Value = dp.SoCaNhiemMoi;
                row.Cells["Column4"].Value = dp.TrangThai != null ? dp.TrangThai.TenTT : "";

                // Keep MaTT in Tag so ComboBox selection works without adding hidden columns.
                row.Tag = dp.MaTT;
            }
        }

        // Always sort by SoCaNhiemMoi descending (requirement: sắp xếp ca nhiễm giảm dần)
        private void SapXepTheoSoCaNhiem_Click(object sender, EventArgs e)
        {
            // Ensure we have data; if not, try to load from DB (with TrangThai)
            if (_currentDiaPhuong == null)
            {
                try
                {
                    using (var ctx = new Model1())
                    {
                        _currentDiaPhuong = ctx.DiaPhuong.Include(dp => dp.TrangThai).ToList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu để sắp xếp: " + ex.Message);
                    return;
                }
            }

            // Always sort descending by SoCaNhiemMoi
            var sorted = _currentDiaPhuong
                .OrderByDescending(dp => dp.SoCaNhiemMoi)
                .ToList();

            // show sorted data and update cache
            ShowDiaPhuong(sorted);
            _currentDiaPhuong = sorted;
        }

        // Menu handler: show only regions whose status is not "Bình thường" (F2)
        private void CacDiaPhuongNhomNguyCo_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new Model1())
                {
                    // load with TrangThai and filter where TenTT != "Bình thường" (case-insensitive)
                    var all = ctx.DiaPhuong.Include(dp => dp.TrangThai).ToList();
                    var risky = all.Where(dp => !string.Equals(dp.TrangThai?.TenTT, "Bình thường", StringComparison.OrdinalIgnoreCase)).ToList();

                    _currentDiaPhuong = risky;
                    ShowDiaPhuong(_currentDiaPhuong);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc các địa phương nhóm nguy cơ: " + ex.Message);
            }
        }

        private void dgv_thongtin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgv_thongtin.Rows[e.RowIndex];

            txt_MDP.Text = row.Cells["Column1"].Value?.ToString();
            txt_TDP.Text = row.Cells["Column2"].Value?.ToString();
            txt_SoCaNhiemMoi.Text = row.Cells["Column3"].Value?.ToString();

            if (row.Tag is int maTT)
            {
                cmbTrangThai.SelectedValue = maTT;
            }
            else
            {
                cmbTrangThai.SelectedIndex = -1;
            }
        }

        private void frm_thongtindiaphuong_Click(object sender, EventArgs e) { }

        private void dgv_thongtin_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btn_them_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập đầy đủ
            if (string.IsNullOrWhiteSpace(txt_MDP.Text) ||
                string.IsNullOrWhiteSpace(txt_TDP.Text) ||
                string.IsNullOrWhiteSpace(txt_SoCaNhiemMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // 2. Kiểm tra Mã ĐP = 3 ký tự
            var maDpInput = txt_MDP.Text.Trim();
            if (maDpInput.Length != 3)
            {
                MessageBox.Show("Mã địa phương phải đúng 3 ký tự!");
                return;
            }

            // 3. Kiểm tra số ca nhiễm ≥ 0
            if (!int.TryParse(txt_SoCaNhiemMoi.Text, out int soCa) || soCa < 0)
            {
                MessageBox.Show("Số ca nhiễm mới phải ≥ 0!");
                return;
            }

            // 4. Thêm vào CSDL bằng Entity Framework
            try
            {
                using (var context = new Model1())
                {
                    var exists = context.DiaPhuong.Find(maDpInput) != null;
                    if (exists)
                    {
                        MessageBox.Show("Mã địa phương đã tồn tại!");
                        return;
                    }

                    DiaPhuong dp = new DiaPhuong
                    {
                        MaDP = maDpInput,
                        TenDP = txt_TDP.Text.Trim(),
                        SoCaNhiemMoi = soCa,
                        MaTT = cmbTrangThai.SelectedValue != null ? (int)cmbTrangThai.SelectedValue : 0
                    };

                    context.DiaPhuong.Add(dp);
                    context.SaveChanges();

                    MessageBox.Show("Thêm mới thành công!");

                    // 5. Cập nhật lại cache và DataGridView
                    _currentDiaPhuong = context.DiaPhuong.Include(d => d.TrangThai).ToList();
                    ShowDiaPhuong(_currentDiaPhuong);

                    // 6. Reset dữ liệu về trạng thái ban đầu (optional)
                    ResetInputsToInitial();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
            }
        }

        // Update handlers call this
        private void button2_Click(object sender, EventArgs e)
        {
            UpdateDiaPhuong();
        }

        private void btn_capnhat_Click_1(object sender, EventArgs e)
        {
            UpdateDiaPhuong();
        }

        private void UpdateDiaPhuong()
        {
            var maDpInput = txt_MDP.Text?.Trim();
            if (string.IsNullOrWhiteSpace(maDpInput))
            {
                MessageBox.Show("Vui lòng nhập mã địa phương để cập nhật!");
                return;
            }

            try
            {
                using (var context = new Model1())
                {
                    var existing = context.DiaPhuong.Find(maDpInput);
                    if (existing == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin địa phương");
                        return;
                    }

                    // Validate SoCaNhiemMoi
                    if (!int.TryParse(txt_SoCaNhiemMoi.Text, out int soCa) || soCa < 0)
                    {
                        MessageBox.Show("Số ca nhiễm mới phải ≥ 0!");
                        return;
                    }

                    // Determine old and new status ids and names
                    int oldMaTT = existing.MaTT;
                    int newMaTT = cmbTrangThai.SelectedValue != null ? (int)cmbTrangThai.SelectedValue : 0;

                    // Get status names (use context lookup to get stored names)
                    string oldTenTT = context.TrangThai.Find(oldMaTT)?.TenTT ?? "(không xác định)";
                    string newTenTT = cmbTrangThai.Text ?? "(chưa chọn)";

                    // If status changed, prompt Yes/No
                    if (oldMaTT != newMaTT)
                    {
                        var confirm = MessageBox.Show(
                            $"Địa phương có sự thay dổi về từ \"{oldTenTT}\" -> \"{newTenTT}\"? ",
                            "Xác nhận thay đổi trạng thái",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (confirm != DialogResult.Yes)
                        {
                            // user chose No -> abort update
                            return;
                        }
                    }

                    // Perform update
                    existing.TenDP = txt_TDP.Text.Trim();
                    existing.SoCaNhiemMoi = soCa;
                    existing.MaTT = newMaTT;

                    context.SaveChanges();

                    MessageBox.Show("Cập nhật thành công!");

                    // Refresh cache and grid
                    _currentDiaPhuong = context.DiaPhuong.Include(d => d.TrangThai).ToList();
                    ShowDiaPhuong(_currentDiaPhuong);

                    // Reset inputs to initial state as on Load
                    ResetInputsToInitial();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
            }
        }

        // Reset input controls to the initial state (same as after Load)
        private void ResetInputsToInitial()
        {
            txt_MDP.Clear();
            txt_TDP.Clear();
            txt_SoCaNhiemMoi.Clear();
            cmbTrangThai.SelectedIndex = -1;
        }

        // Designer event wrappers (kept to avoid missing event references)
        private void sắpXếpTheoSốCaNhiễmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SapXepTheoSoCaNhiem_Click(sender, e);
        }

        private void cácĐịaPhươngNhómNguyCơToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CacDiaPhuongNhomNguyCo_Click(sender, e);
        }
    }
}