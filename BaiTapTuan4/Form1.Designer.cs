namespace BaiTapTuan4
{
    partial class frm_quanlythongtinsinhvien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.grb_ttsv = new System.Windows.Forms.GroupBox();
            this.txt_diem = new System.Windows.Forms.TextBox();
            this.rad_Nu = new System.Windows.Forms.RadioButton();
            this.rad_Nam = new System.Windows.Forms.RadioButton();
            this.txt_hoten = new System.Windows.Forms.TextBox();
            this.txt_mssv = new System.Windows.Forms.TextBox();
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_ttsv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ThemSua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_tongNam = new System.Windows.Forms.TextBox();
            this.txt_tongNu = new System.Windows.Forms.TextBox();
            this.grb_ttsv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ttsv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(366, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(491, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Thông Tin Sinh Viên";
            // 
            // grb_ttsv
            // 
            this.grb_ttsv.Controls.Add(this.txt_diem);
            this.grb_ttsv.Controls.Add(this.rad_Nu);
            this.grb_ttsv.Controls.Add(this.rad_Nam);
            this.grb_ttsv.Controls.Add(this.txt_hoten);
            this.grb_ttsv.Controls.Add(this.txt_mssv);
            this.grb_ttsv.Controls.Add(this.cmbKhoa);
            this.grb_ttsv.Controls.Add(this.label6);
            this.grb_ttsv.Controls.Add(this.label5);
            this.grb_ttsv.Controls.Add(this.label4);
            this.grb_ttsv.Controls.Add(this.label3);
            this.grb_ttsv.Controls.Add(this.label2);
            this.grb_ttsv.Location = new System.Drawing.Point(53, 118);
            this.grb_ttsv.Margin = new System.Windows.Forms.Padding(4);
            this.grb_ttsv.Name = "grb_ttsv";
            this.grb_ttsv.Padding = new System.Windows.Forms.Padding(4);
            this.grb_ttsv.Size = new System.Drawing.Size(429, 322);
            this.grb_ttsv.TabIndex = 1;
            this.grb_ttsv.TabStop = false;
            this.grb_ttsv.Text = "Thông Tin Sinh Viên";
            // 
            // txt_diem
            // 
            this.txt_diem.Location = new System.Drawing.Point(165, 187);
            this.txt_diem.Margin = new System.Windows.Forms.Padding(4);
            this.txt_diem.Name = "txt_diem";
            this.txt_diem.Size = new System.Drawing.Size(132, 22);
            this.txt_diem.TabIndex = 10;
            // 
            // rad_Nu
            // 
            this.rad_Nu.AutoSize = true;
            this.rad_Nu.Checked = true;
            this.rad_Nu.Location = new System.Drawing.Point(275, 143);
            this.rad_Nu.Margin = new System.Windows.Forms.Padding(4);
            this.rad_Nu.Name = "rad_Nu";
            this.rad_Nu.Size = new System.Drawing.Size(45, 20);
            this.rad_Nu.TabIndex = 9;
            this.rad_Nu.TabStop = true;
            this.rad_Nu.Text = "Nữ";
            this.rad_Nu.UseVisualStyleBackColor = true;
            // 
            // rad_Nam
            // 
            this.rad_Nam.AutoSize = true;
            this.rad_Nam.Location = new System.Drawing.Point(165, 143);
            this.rad_Nam.Margin = new System.Windows.Forms.Padding(4);
            this.rad_Nam.Name = "rad_Nam";
            this.rad_Nam.Size = new System.Drawing.Size(57, 20);
            this.rad_Nam.TabIndex = 8;
            this.rad_Nam.Text = "Nam";
            this.rad_Nam.UseVisualStyleBackColor = true;
            // 
            // txt_hoten
            // 
            this.txt_hoten.Location = new System.Drawing.Point(165, 89);
            this.txt_hoten.Margin = new System.Windows.Forms.Padding(4);
            this.txt_hoten.Name = "txt_hoten";
            this.txt_hoten.Size = new System.Drawing.Size(212, 22);
            this.txt_hoten.TabIndex = 7;
            // 
            // txt_mssv
            // 
            this.txt_mssv.Location = new System.Drawing.Point(165, 42);
            this.txt_mssv.Margin = new System.Windows.Forms.Padding(4);
            this.txt_mssv.Name = "txt_mssv";
            this.txt_mssv.Size = new System.Drawing.Size(212, 22);
            this.txt_mssv.TabIndex = 6;
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.FormattingEnabled = true;
            this.cmbKhoa.Items.AddRange(new object[] {
            "QTKD",
            "CNTT",
            "NNA"});
            this.cmbKhoa.Location = new System.Drawing.Point(165, 258);
            this.cmbKhoa.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(160, 24);
            this.cmbKhoa.TabIndex = 5;
            this.cmbKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbKhoa_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 268);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Chuyên ngành";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 196);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Điểm TB";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Giới tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Họ tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã sinh viên";
            // 
            // dgv_ttsv
            // 
            this.dgv_ttsv.AllowUserToAddRows = false;
            this.dgv_ttsv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ttsv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgv_ttsv.Location = new System.Drawing.Point(526, 118);
            this.dgv_ttsv.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_ttsv.Name = "dgv_ttsv";
            this.dgv_ttsv.RowHeadersWidth = 51;
            this.dgv_ttsv.Size = new System.Drawing.Size(771, 345);
            this.dgv_ttsv.TabIndex = 2;
            this.dgv_ttsv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ttsv_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 150F;
            this.Column1.HeaderText = "MSSV";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 200F;
            this.Column2.HeaderText = "Họ Tên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Giới tính";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Điểm TB";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Khoa";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // btn_ThemSua
            // 
            this.btn_ThemSua.Location = new System.Drawing.Point(219, 466);
            this.btn_ThemSua.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ThemSua.Name = "btn_ThemSua";
            this.btn_ThemSua.Size = new System.Drawing.Size(100, 28);
            this.btn_ThemSua.TabIndex = 3;
            this.btn_ThemSua.Text = "Thêm/Sửa";
            this.btn_ThemSua.UseVisualStyleBackColor = true;
            this.btn_ThemSua.Click += new System.EventHandler(this.btn_ThemSua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(383, 466);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(100, 28);
            this.btn_Xoa.TabIndex = 4;
            this.btn_Xoa.Text = "Xoá";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(811, 497);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tổng SV Nam";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1104, 497);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Nữ";
            // 
            // txt_tongNam
            // 
            this.txt_tongNam.Location = new System.Drawing.Point(917, 494);
            this.txt_tongNam.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tongNam.Name = "txt_tongNam";
            this.txt_tongNam.Size = new System.Drawing.Size(119, 22);
            this.txt_tongNam.TabIndex = 7;
            this.txt_tongNam.Text = "0";
            this.txt_tongNam.TextChanged += new System.EventHandler(this.txt_tongNam_TextChanged);
            // 
            // txt_tongNu
            // 
            this.txt_tongNu.Location = new System.Drawing.Point(1140, 494);
            this.txt_tongNu.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tongNu.Name = "txt_tongNu";
            this.txt_tongNu.Size = new System.Drawing.Size(132, 22);
            this.txt_tongNu.TabIndex = 8;
            this.txt_tongNu.Text = "0";
            this.txt_tongNu.TextChanged += new System.EventHandler(this.txt_tongNu_TextChanged);
            // 
            // frm_quanlythongtinsinhvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 554);
            this.Controls.Add(this.txt_tongNu);
            this.Controls.Add(this.txt_tongNam);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_ThemSua);
            this.Controls.Add(this.dgv_ttsv);
            this.Controls.Add(this.grb_ttsv);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_quanlythongtinsinhvien";
            this.Text = "Quản Lý Thông Tin Sinh Viên";
            this.Load += new System.EventHandler(this.frm_quanlythongtinsinhvien_Load);
            this.grb_ttsv.ResumeLayout(false);
            this.grb_ttsv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ttsv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grb_ttsv;
        private System.Windows.Forms.TextBox txt_diem;
        private System.Windows.Forms.RadioButton rad_Nu;
        private System.Windows.Forms.RadioButton rad_Nam;
        private System.Windows.Forms.TextBox txt_hoten;
        private System.Windows.Forms.TextBox txt_mssv;
        private System.Windows.Forms.ComboBox cmbKhoa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_ttsv;
        private System.Windows.Forms.Button btn_ThemSua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_tongNam;
        private System.Windows.Forms.TextBox txt_tongNu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}

