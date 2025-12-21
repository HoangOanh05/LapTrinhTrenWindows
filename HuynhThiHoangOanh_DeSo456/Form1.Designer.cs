namespace HuynhThiHoangOanh_DeSo456
{
    partial class frm_thongtindiaphuong
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtBáoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_capnhat = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.txt_SoCaNhiemMoi = new System.Windows.Forms.TextBox();
            this.txt_TDP = new System.Windows.Forms.TextBox();
            this.txt_MDP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_thongtin = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtin)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1121, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem,
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem,
            this.xuấtBáoCáoToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // sắpXếpTheoSốCaNhiễmToolStripMenuItem
            // 
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem.Name = "sắpXếpTheoSốCaNhiễmToolStripMenuItem";
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem.Size = new System.Drawing.Size(319, 26);
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem.Text = "Sắp xếp theo số ca nhiễm";
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem.Click += new System.EventHandler(this.sắpXếpTheoSốCaNhiễmToolStripMenuItem_Click);
            // 
            // cácĐịaPhươngNhómNguyCơToolStripMenuItem
            // 
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem.Name = "cácĐịaPhươngNhómNguyCơToolStripMenuItem";
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem.Size = new System.Drawing.Size(319, 26);
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem.Text = "Các địa phương nhóm nguy cơ";
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem.Click += new System.EventHandler(this.cácĐịaPhươngNhómNguyCơToolStripMenuItem_Click);
            // 
            // xuấtBáoCáoToolStripMenuItem
            // 
            this.xuấtBáoCáoToolStripMenuItem.Name = "xuấtBáoCáoToolStripMenuItem";
            this.xuấtBáoCáoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.xuấtBáoCáoToolStripMenuItem.Size = new System.Drawing.Size(319, 26);
            this.xuấtBáoCáoToolStripMenuItem.Text = "Xuất báo cáo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(384, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tình hình dịch Covid 19";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_capnhat);
            this.groupBox1.Controls.Add(this.btn_them);
            this.groupBox1.Controls.Add(this.cmbTrangThai);
            this.groupBox1.Controls.Add(this.txt_SoCaNhiemMoi);
            this.groupBox1.Controls.Add(this.txt_TDP);
            this.groupBox1.Controls.Add(this.txt_MDP);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(14, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 339);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin địa phương";
            // 
            // btn_capnhat
            // 
            this.btn_capnhat.Location = new System.Drawing.Point(235, 285);
            this.btn_capnhat.Name = "btn_capnhat";
            this.btn_capnhat.Size = new System.Drawing.Size(86, 33);
            this.btn_capnhat.TabIndex = 9;
            this.btn_capnhat.Text = "Cập nhật";
            this.btn_capnhat.UseVisualStyleBackColor = true;
            this.btn_capnhat.Click += new System.EventHandler(this.btn_capnhat_Click_1);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(101, 285);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(90, 33);
            this.btn_them.TabIndex = 8;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Location = new System.Drawing.Point(127, 200);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(194, 24);
            this.cmbTrangThai.TabIndex = 7;
            // 
            // txt_SoCaNhiemMoi
            // 
            this.txt_SoCaNhiemMoi.Location = new System.Drawing.Point(127, 143);
            this.txt_SoCaNhiemMoi.Name = "txt_SoCaNhiemMoi";
            this.txt_SoCaNhiemMoi.Size = new System.Drawing.Size(101, 22);
            this.txt_SoCaNhiemMoi.TabIndex = 6;
            // 
            // txt_TDP
            // 
            this.txt_TDP.Location = new System.Drawing.Point(127, 93);
            this.txt_TDP.Name = "txt_TDP";
            this.txt_TDP.Size = new System.Drawing.Size(194, 22);
            this.txt_TDP.TabIndex = 5;
            // 
            // txt_MDP
            // 
            this.txt_MDP.Location = new System.Drawing.Point(127, 49);
            this.txt_MDP.Name = "txt_MDP";
            this.txt_MDP.Size = new System.Drawing.Size(101, 22);
            this.txt_MDP.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Trạng Thái";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số ca nhiễm mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên Địa Phương";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Địa Phương";
            // 
            // dgv_thongtin
            // 
            this.dgv_thongtin.AllowUserToAddRows = false;
            this.dgv_thongtin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_thongtin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgv_thongtin.Location = new System.Drawing.Point(411, 98);
            this.dgv_thongtin.Name = "dgv_thongtin";
            this.dgv_thongtin.RowHeadersWidth = 51;
            this.dgv_thongtin.RowTemplate.Height = 24;
            this.dgv_thongtin.Size = new System.Drawing.Size(699, 338);
            this.dgv_thongtin.TabIndex = 3;
            this.dgv_thongtin.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_thongtin_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "MDP";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 75;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên ĐP";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ca nhiễm";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 75;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Trạng Thái";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 175;
            // 
            // frm_thongtindiaphuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 471);
            this.Controls.Add(this.dgv_thongtin);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_thongtindiaphuong";
            this.Text = "Thông tin địa phương";
            this.Load += new System.EventHandler(this.frm_thongtindiaphuong_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sắpXếpTheoSốCaNhiễmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cácĐịaPhươngNhómNguyCơToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuấtBáoCáoToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_capnhat;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.TextBox txt_SoCaNhiemMoi;
        private System.Windows.Forms.TextBox txt_TDP;
        private System.Windows.Forms.TextBox txt_MDP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_thongtin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

