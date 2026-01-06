using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Handmade
{
    public partial class frm_Store : Form
    {
        public frm_Store()
        {
            InitializeComponent();
        }

        public void btn_DangKy_Click(object sender, EventArgs e)
        {
          frm_DangKy frm_DangKy = new frm_DangKy(this);
            frm_DangKy.Show();
            this.Hide();


        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            frm_DangNhap dangNhapForm = new frm_DangNhap();
            dangNhapForm.Show();
            this.Hide();
        }

        private void frm_Store_Load(object sender, EventArgs e)
        {

        }

        private void frm_Store_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
