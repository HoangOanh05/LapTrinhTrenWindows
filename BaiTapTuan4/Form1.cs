using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapTuan4
{
    public partial class frm_quanlythongtinsinhvien : Form
    {
        public frm_quanlythongtinsinhvien()
        {
            InitializeComponent();
        }
        private void frm_quanlythongtinsinhvien_Load(object sender, EventArgs e)
        {
            cmbKhoa.SelectedIndex = 0;
        }

        private int GetSelectedRow(string mssv)
        {
            for (int i = 0; i < dgv_ttsv.Rows.Count; i++)
            {
                if (dgv_ttsv.Rows[i].Cells[0].Value.ToString() == mssv)
                {
                    return i;
                }
            }
            return -1;
        }

        private void InsertUpdate(int rowIndex)
        {
            dgv_ttsv.Rows[rowIndex].Cells[0].Value = txt_mssv.Text;
            dgv_ttsv.Rows[rowIndex].Cells[1].Value = txt_hoten.Text;
            dgv_ttsv.Rows[rowIndex].Cells[2].Value = rad_Nu.Checked ? "Nữ" : "Nam";
            dgv_ttsv.Rows[rowIndex].Cells[3].Value = txt_diem.Text;
            dgv_ttsv.Rows[rowIndex].Cells[4].Value = cmbKhoa.Text;
        }

        private void btn_ThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_mssv.Text == "" || txt_hoten.Text == "" || txt_diem.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin sinh viên");

                int seclectRow = GetSelectedRow(txt_mssv.Text);
                if (seclectRow == -1)
                {
                    seclectRow = dgv_ttsv.Rows.Add();
                    InsertUpdate(seclectRow);
                    MessageBox.Show("Thêm mới dữ liệu thành công");
                }
                else
                {
                    InsertUpdate(seclectRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            CountGender();

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = GetSelectedRow(txt_mssv.Text);
                if (selectedRow == -1)
                {
                    throw new Exception("Không tìm thấy mssv cần xoá");

                }
                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xoá?", "YES/NO");
                    if (dr == DialogResult.Yes)
                    {
                        dgv_ttsv.Rows.RemoveAt(selectedRow);
                        MessageBox.Show("Xoá sinh viên thành công");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
            CountGender();
        }

        private void dgv_ttsv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgv_ttsv.Rows[e.RowIndex];

                txt_mssv.Text = r.Cells[0].Value.ToString();
                txt_hoten.Text = r.Cells[1].Value.ToString();

                string gender = r.Cells[2].Value.ToString();
                if (gender == "Nữ")
                    rad_Nu.Checked = true;
                else
                    rad_Nam.Checked = true;

                txt_diem.Text = r.Cells[3].Value.ToString();
                cmbKhoa.Text = r.Cells[4].Value.ToString();
            }
        }
        private void CountGender()
        {
            int male = 0;
            int female = 0;

            foreach (DataGridViewRow row in dgv_ttsv.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    string gender = row.Cells[2].Value.ToString();
                    if (gender == "Nam")
                        male++;
                    else if (gender == "Nữ")
                        female++;
                }
            }

            txt_tongNam.Text = "Nam: " + male;
            txt_tongNu.Text = "Nữ: " + female;
        }

        private void txt_tongNam_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_tongNu_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
