using BaiTapTuan8.sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BaiTapTuan8
{
    public partial class Form1 : Form
    {
        private SchoolContext db = new SchoolContext();
        private BindingSource studentBindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            dgv_ttsv.Columns["column1"].DataPropertyName = "StudentId";
            dgv_ttsv.Columns["column2"].DataPropertyName = "FullName";
            dgv_ttsv.Columns["column3"].DataPropertyName = "Age";
            dgv_ttsv.Columns["column4"].DataPropertyName = "Major";
            SetupUI();
        }

        private void SetupUI()
        {
      
            label4.ForeColor = Color.Chocolate;
            btn_them.BackColor = Color.Green;
            btn_sua.BackColor = Color.Orange;
            btn_xoa.BackColor = Color.Red;
            btn_next.BackColor = Color.LightBlue;
            btn_prev.BackColor = Color.Aqua;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Thiết lập ComboBox
            cmb_major.Items.Clear();
            cmb_major.Items.AddRange(new string[]
            {
                "Công nghệ thông tin",
                "Kế toán",
                "Quản trị kinh doanh",
                "Ngôn ngữ Anh"
            });

            LoadData();
            AddDataBinding();
        }

        private void LoadData()
        {
            try
            {
      
                db.Students.Load();
                studentBindingSource.DataSource = db.Students.Local.ToBindingList();
                dgv_ttsv.DataSource = studentBindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }


        private void AddDataBinding()
        {
            txt_fullname.DataBindings.Clear();
            txt_age.DataBindings.Clear();
            cmb_major.DataBindings.Clear();

            txt_fullname.DataBindings.Add("Text", studentBindingSource, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            txt_age.DataBindings.Add("Text", studentBindingSource, "Age", true, DataSourceUpdateMode.OnPropertyChanged);
            cmb_major.DataBindings.Add("Text", studentBindingSource, "Major", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào cơ bản
                if (string.IsNullOrEmpty(txt_fullname.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên!");
                    return;
                }

                int age;
                int.TryParse(txt_age.Text, out age); 

                Student sv = new Student
                {
                    FullName = txt_fullname.Text,
                    Age = age,
                    Major = cmb_major.Text
                };

                db.Students.Add(sv);
                db.SaveChanges();

                MessageBox.Show("Thêm sinh viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }
        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                Student sv = studentBindingSource.Current as Student;
                if (sv != null)
                {
                    db.SaveChanges(); 
                    dgv_ttsv.Refresh();
                    MessageBox.Show("Cập nhật thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            Student sv = studentBindingSource.Current as Student;
            if (sv != null)
            {
                if (MessageBox.Show($"Xóa sinh viên {sv.FullName}?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Students.Remove(sv);
                    db.SaveChanges();
                }
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            studentBindingSource.MoveNext();
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            studentBindingSource.MovePrevious();
        }
    }
}