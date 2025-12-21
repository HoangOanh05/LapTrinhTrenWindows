using BaiTapTuan6.sql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace BaiTapTuan6
{
    public partial class Form1 : Form
    {
        StudentModel context = new StudentModel();
        string avatarPath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFaculty();
                BindGrid();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadFaculty()
        {
            cmbFaculty.DataSource = context.Faculties.ToList();
            cmbFaculty.DisplayMember = "FacultyName";
            cmbFaculty.ValueMember = "FacultyID";
        }
        private void BindGrid()
        {
            dgvStudents.Rows.Clear();

            var data =
                from s in context.Students
                join f in context.Faculties
                    on s.FacultyID equals f.FacultyID

                join m in context.Majors
                    on new { s.FacultyID, s.MajorID }
                    equals new { FacultyID = (int?)m.FacultyID, MajorID = (int?)m.MajorID }
                    into mj
                from m in mj.DefaultIfEmpty() // LEFT JOIN

                select new
                {
                    s.StudentID,
                    s.FullName,
                    FacultyName = f.FacultyName,
                    s.AverageScore,
                    MajorName = m == null ? "" : m.Name
                };

            foreach (var item in data.ToList())
            {
                int index = dgvStudents.Rows.Add();
                dgvStudents.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudents.Rows[index].Cells[1].Value = item.FullName;
                dgvStudents.Rows[index].Cells[2].Value = item.FacultyName;
                dgvStudents.Rows[index].Cells[3].Value = item.AverageScore;
                dgvStudents.Rows[index].Cells[4].Value = item.MajorName;
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string mssv = dgvStudents.Rows[e.RowIndex].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(mssv)) return;

            Student sv = context.Students.FirstOrDefault(s => s.StudentID == mssv);
            if (sv == null) return;

            // ===== HIỂN THỊ GROUPBOX =====
            txtMaSV.Text = sv.StudentID;
            txtHoTen.Text = sv.FullName;
            txtDTB.Text = sv.AverageScore?.ToString();

            cmbFaculty.SelectedValue = sv.FacultyID;

            // ===== CHUYÊN NGÀNH =====
            chkNoMajor.Checked = sv.MajorID == null;

            // ===== AVATAR =====
            avatarPath = sv.Avatar;
            LoadAvatar(sv.Avatar);
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

            Student sv = context.Students.FirstOrDefault(s => s.StudentID == txtMaSV.Text);

            if (sv == null)
            {
                sv = new Student();
                context.Students.Add(sv);
            }

            sv.StudentID = txtMaSV.Text;
            sv.FullName = txtHoTen.Text;
            sv.AverageScore = score;
            sv.FacultyID = (int)cmbFaculty.SelectedValue;
            sv.MajorID = chkNoMajor.Checked ? null : sv.MajorID;
            sv.Avatar = avatarPath;

            context.SaveChanges();

            BindGrid();
            ResetForm();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Student sv = context.Students.FirstOrDefault(s => s.StudentID == txtMaSV.Text);
            if (sv != null)
            {
                context.Students.Remove(sv);
                context.SaveChanges();
                BindGrid();
                ResetForm();
            }
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
