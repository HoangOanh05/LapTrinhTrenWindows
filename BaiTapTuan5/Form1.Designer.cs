namespace BaiTapTuan5
{
    partial class frm_soanthaovanban
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_soanthaovanban));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tạoTậpTinMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mởTậpTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuNộiDungVănBảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.địnhDạngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnB = new System.Windows.Forms.ToolStripButton();
            this.btnI = new System.Windows.Forms.ToolStripButton();
            this.btnU = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbFont = new System.Windows.Forms.ComboBox();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.địnhDạngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tạoTậpTinMớiToolStripMenuItem,
            this.mởTậpTinToolStripMenuItem,
            this.lưuNộiDungVănBảnToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // tạoTậpTinMớiToolStripMenuItem
            // 
            this.tạoTậpTinMớiToolStripMenuItem.Image = global::BaiTapTuan5.Properties.Resources.tao_moi_file;
            this.tạoTậpTinMớiToolStripMenuItem.Name = "tạoTậpTinMớiToolStripMenuItem";
            this.tạoTậpTinMớiToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tạoTậpTinMớiToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.tạoTậpTinMớiToolStripMenuItem.Text = "Tạo văn bản mới";
            this.tạoTậpTinMớiToolStripMenuItem.Click += new System.EventHandler(this.tạoTậpTinMớiToolStripMenuItem_Click);
            // 
            // mởTậpTinToolStripMenuItem
            // 
            this.mởTậpTinToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mởTậpTinToolStripMenuItem.Image")));
            this.mởTậpTinToolStripMenuItem.Name = "mởTậpTinToolStripMenuItem";
            this.mởTậpTinToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.mởTậpTinToolStripMenuItem.Text = "Mở tập tin";
            this.mởTậpTinToolStripMenuItem.Click += new System.EventHandler(this.mởTậpTinToolStripMenuItem_Click);
            // 
            // lưuNộiDungVănBảnToolStripMenuItem
            // 
            this.lưuNộiDungVănBảnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("lưuNộiDungVănBảnToolStripMenuItem.Image")));
            this.lưuNộiDungVănBảnToolStripMenuItem.Name = "lưuNộiDungVănBảnToolStripMenuItem";
            this.lưuNộiDungVănBảnToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.lưuNộiDungVănBảnToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.lưuNộiDungVănBảnToolStripMenuItem.Text = "Lưu nội dung văn bản";
            this.lưuNộiDungVănBảnToolStripMenuItem.Click += new System.EventHandler(this.lưuNộiDungVănBảnToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // địnhDạngToolStripMenuItem
            // 
            this.địnhDạngToolStripMenuItem.Name = "địnhDạngToolStripMenuItem";
            this.địnhDạngToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.địnhDạngToolStripMenuItem.Text = "Định dạng";
            this.địnhDạngToolStripMenuItem.Click += new System.EventHandler(this.địnhDạngToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnSave,
            this.btnB,
            this.btnI,
            this.btnU});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 50);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(29, 50);
            this.btnNew.Text = "toolStripButton1";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(29, 50);
            this.btnSave.Text = "toolStripButton2";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnB
            // 
            this.btnB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnB.Image = ((System.Drawing.Image)(resources.GetObject("btnB.Image")));
            this.btnB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnB.Margin = new System.Windows.Forms.Padding(170, 0, 0, 0);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(29, 50);
            this.btnB.Text = "toolStripButton3";
            this.btnB.Click += new System.EventHandler(this.btnB_Click);
            // 
            // btnI
            // 
            this.btnI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnI.Image = ((System.Drawing.Image)(resources.GetObject("btnI.Image")));
            this.btnI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnI.Margin = new System.Windows.Forms.Padding(0);
            this.btnI.Name = "btnI";
            this.btnI.Size = new System.Drawing.Size(29, 50);
            this.btnI.Text = "toolStripButton4";
            this.btnI.Click += new System.EventHandler(this.btnI_Click);
            // 
            // btnU
            // 
            this.btnU.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnU.Image = ((System.Drawing.Image)(resources.GetObject("btnU.Image")));
            this.btnU.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnU.Margin = new System.Windows.Forms.Padding(0);
            this.btnU.Name = "btnU";
            this.btnU.Size = new System.Drawing.Size(29, 50);
            this.btnU.Text = "toolStripButton5";
            this.btnU.Click += new System.EventHandler(this.btnU_Click);
            // 
            // cmbFont
            // 
            this.cmbFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFont.FormattingEnabled = true;
            this.cmbFont.Location = new System.Drawing.Point(85, 41);
            this.cmbFont.Name = "cmbFont";
            this.cmbFont.Size = new System.Drawing.Size(147, 26);
            this.cmbFont.TabIndex = 5;
            this.cmbFont.SelectedIndexChanged += new System.EventHandler(this.cmbFont_SelectedIndexChanged_1);
            // 
            // cmbSize
            // 
            this.cmbSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Location = new System.Drawing.Point(245, 41);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(49, 26);
            this.cmbSize.TabIndex = 6;
            this.cmbSize.SelectedIndexChanged += new System.EventHandler(this.cmbSize_SelectedIndexChanged_1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 86);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(800, 274);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // frm_soanthaovanban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 372);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cmbSize);
            this.Controls.Add(this.cmbFont);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_soanthaovanban";
            this.Text = "Soạn thảo văn bản";
            this.Load += new System.EventHandler(this.frm_soanthaovanban_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem địnhDạngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tạoTậpTinMớiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mởTậpTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lưuNộiDungVănBảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnB;
        private System.Windows.Forms.ToolStripButton btnI;
        private System.Windows.Forms.ToolStripButton btnU;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbFont;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

