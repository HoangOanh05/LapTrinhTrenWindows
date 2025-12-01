using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapTuan3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void lvStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStudents.SelectedIndices.Count > 0)
            {
                //lấy dòng dữ liệu đc chọn
                ListViewItem item = lvStudents.SelectedItems[0];
                // hiển thị dữ liệu lên các textbox
                txtLastName.Text = item.SubItems[0].Text;
                txtFirstName.Text = item.SubItems[1].Text;
                txtPhone.Text = item.SubItems[2].Text;
                
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // tạo 1 dòng dữ liệu
        ListViewItem item = new ListViewItem(txtLastName.Text);
            // thêm subitems

            item.SubItems.Add(txtFirstName.Text);
            item.SubItems.Add(txtPhone.Text);
            // thêm dòng dữ liệu vào listview

            lvStudents.Items.Add(item);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //lấy dòng dữ liệu đc chọn
            if (lvStudents.SelectedIndices.Count > 0)
            {
                // hiển thị dữ liệu lên các textbox
                ListViewItem item = lvStudents.SelectedItems[0];
                //sửa dữ liệu
                item.SubItems[0].Text = txtLastName.Text;
                item.SubItems[1].Text = txtFirstName.Text;
                item.SubItems[2].Text = txtPhone.Text;
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //lấy dòng dữ liệu đc chọn
            if (lvStudents.SelectedIndices.Count > 0)
            {
                // xóa dữ liệu
                lvStudents.Items.Remove(lvStudents.SelectedItems[0]);
            }
        }
    }
}
