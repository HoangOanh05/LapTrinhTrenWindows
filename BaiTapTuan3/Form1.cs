using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiTapTuan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeListView();
        }
        // khởi tạo ListView 
        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            // Tạo 3 cột để hiển thị subitems
            listView1.Columns.Add("", 100);  // Cột 1
            listView1.Columns.Add("", 100);  // Cột 2
            listView1.Columns.Add("", 120);  // Cột 3
            listView1.HeaderStyle = ColumnHeaderStyle.None; // Ẩn header
        }

        // nút Add Name 
        private void btnAddName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo item và subitems (chia 3 cột)
            ListViewItem item = new ListViewItem(txtLastName.Text);
            item.SubItems.Add(txtFirstName.Text);
            item.SubItems.Add(txtPhone.Text);

            // Thêm item vào ListView
            listView1.Items.Add(item);

            // Xóa TextBox và focus lại
            txtLastName.Clear();
            txtFirstName.Clear();
            txtPhone.Clear();
            txtLastName.Focus();
        }

        // Click chọn item trong ListView 
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                txtLastName.Text = selectedItem.Text;
                txtFirstName.Text = selectedItem.SubItems[1].Text;
                txtPhone.Text = selectedItem.SubItems[2].Text;
            }
        }
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            {
                if (listView1.SelectedItems.Count > 0)
                {
                    // Lấy item được chọn
                    ListViewItem selectedItem = listView1.SelectedItems[0];

                    // Lấy dữ liệu từng cột (cột 0: Last Name, cột 1: First Name, cột 2: Phone)
                    txtLastName.Text = selectedItem.Text;                     // Cột 0
                    txtFirstName.Text = selectedItem.SubItems[1].Text;       // Cột 1
                    txtPhone.Text = selectedItem.SubItems[2].Text;           // Cột 2
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.OldLace;
        }


        private void label1_Click_1(object sender, EventArgs e)
        {
            label1.BackColor = Color.OldLace;
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void lblPhone_Click(object sender, EventArgs e) { }
        private void lblDetail_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void txtLastName_TextChanged(object sender, EventArgs e) { }
        private void lblLastName_Click(object sender, EventArgs e) { }
        private void txtFirstName_TextChanged(object sender, EventArgs e) { }
        private void txtPhone_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void lblFile_Click(object sender, EventArgs e) { }
        private void lblView_Click(object sender, EventArgs e) { }
        private void lblFormat_Click(object sender, EventArgs e) { }
        private void lblListView_Click(object sender, EventArgs e) { }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
