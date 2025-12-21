using BaiTapT6.BUS;
using BaiTapT6.DAL.sql;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BaiTapT6
{
    public partial class frm_quanlysinhvien : Form
    {
        private string avatarPath = "";

        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        private readonly MajorService majorService = new MajorService();

        public frm_quanlysinhvien()
        {
            InitializeComponent();
            label6.ForeColor= Color.Red;
        }

        private void frm_quanlysinhvien_Load(object sender, EventArgs e)
        {
            LoadFaculty();
            BindGrid();
            ResetForm();
        }


        private void LoadFaculty()
        {
            cmbFaculty.DataSource = facultyService.GetAll();
            cmbFaculty.DisplayMember = "FacultyName";
            cmbFaculty.ValueMember = "FacultyID";
        }

   
        private void BindGrid()
        {
            dgvStudents.Rows.Clear();

            foreach (var s in studentService.GetAll())
            {
                int row = dgvStudents.Rows.Add();
                dgvStudents.Rows[row].Cells[0].Value = s.StudentID;
                dgvStudents.Rows[row].Cells[1].Value = s.FullName;
                dgvStudents.Rows[row].Cells[2].Value =
                    facultyService.GetFacultyName(s.FacultyID);
                dgvStudents.Rows[row].Cells[3].Value = s.AverageScore;
                dgvStudents.Rows[row].Cells[4].Value =
                    s.MajorID == null ? "" : majorService.GetMajorName(s.MajorID);
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string mssv = dgvStudents.Rows[e.RowIndex].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(mssv)) return;

            Student sv = studentService.GetById(mssv);
            if (sv == null) return;

            txtMaSV.Text = sv.StudentID;
            txtHoTen.Text = sv.FullName;
            txtDTB.Text = sv.AverageScore.ToString();
            cmbFaculty.SelectedValue = sv.FacultyID;
            chkNoMajor.Checked = sv.MajorID == null;

            avatarPath = sv.Avatar;
            LoadAvatar(avatarPath);
        }


        private void LoadAvatar(string path)
        {
            if (panel_Avatar.BackgroundImage != null)
            {
                panel_Avatar.BackgroundImage.Dispose();
                panel_Avatar.BackgroundImage = null;
            }

            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    panel_Avatar.BackgroundImage = Image.FromStream(fs);
                }
                panel_Avatar.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void btn_Add_Update_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtDTB.Text, out double score))
            {
                MessageBox.Show("Điểm trung bình không hợp lệ");
                return;
            }

            Student sv = studentService.GetById(txtMaSV.Text);

            if (sv == null)
            {
                sv = new Student();
            }

            sv.StudentID = txtMaSV.Text.Trim();
            sv.FullName = txtHoTen.Text.Trim();
            sv.AverageScore = score;
            sv.FacultyID = (int)cmbFaculty.SelectedValue;
            sv.MajorID = chkNoMajor.Checked ? null : sv.MajorID;
            sv.Avatar = avatarPath;

            studentService.AddOrUpdate(sv);

            BindGrid();
            ResetForm();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text)) return;

            studentService.Delete(txtMaSV.Text);
            BindGrid();
            ResetForm();
        }


        private void btn_up_save_avatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                avatarPath = dlg.FileName;
                LoadAvatar(avatarPath);
            }
        }
        private void ResetForm()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDTB.Clear();

            if (cmbFaculty.Items.Count > 0)
                cmbFaculty.SelectedIndex = 0;

            chkNoMajor.Checked = false;

            if (panel_Avatar.BackgroundImage != null)
            {
                panel_Avatar.BackgroundImage.Dispose();
                panel_Avatar.BackgroundImage = null;
            }

            avatarPath = "";
            txtMaSV.Focus();
        }

     
    }
}
