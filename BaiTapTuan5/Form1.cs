using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace BaiTapTuan5
{
    public partial class frm_soanthaovanban : Form
    {
        string currentFile = "";   // lưu file đang mở

        public frm_soanthaovanban()
        {
            InitializeComponent();
        }
        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;

            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.Font = fontDlg.Font;
                richTextBox1.ForeColor = fontDlg.Color;
            }
        }
        private void frm_soanthaovanban_Load(object sender, EventArgs e)
        {
            // Load tất cả font hệ thống
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily f in fonts.Families)
                cmbFont.Items.Add(f.Name);

            // Load size
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int s in sizes)
                cmbSize.Items.Add(s);

            // Giá trị mặc định
            cmbFont.Text = "Tahoma";
            cmbSize.Text = "14";
            richTextBox1.Font = new Font("Tahoma", 14);
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            currentFile = "";   // trở về file mới

            cmbFont.Text = "Tahoma";
            cmbSize.Text = "14";
            richTextBox1.Font = new Font("Tahoma", 14);
        }


        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text (*.rtf)|*.rtf|Text File (*.txt)|*.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName.EndsWith(".rtf"))
                    richTextBox1.LoadFile(dlg.FileName);
                else
                    richTextBox1.Text = System.IO.File.ReadAllText(dlg.FileName);

                currentFile = dlg.FileName;
            }
        }

      
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Nếu chưa lưu lần nào → Save As
            if (string.IsNullOrEmpty(currentFile))
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Rich Text (*.rtf)|*.rtf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText);
                    currentFile = dlg.FileName;
                    MessageBox.Show("Lưu thành công!");
                }
            }
            else
            {
                // Lưu đè file cũ
                richTextBox1.SaveFile(currentFile, RichTextBoxStreamType.RichText);
                MessageBox.Show("Lưu thành công!");
            }
        }


        //hàm xử lý chung nút B/I/U
        private void ToggleStyle(FontStyle style)
        {
            if (richTextBox1.SelectionFont == null) return;

            Font current = richTextBox1.SelectionFont;
            FontStyle newStyle;

            if (current.Style.HasFlag(style))
                newStyle = current.Style & ~style;   // tắt style
            else
                newStyle = current.Style | style;    // bật style

            richTextBox1.SelectionFont = new Font(current.FontFamily,
                                                 current.Size,
                                                 newStyle);
        }
         
        private void btnB_Click(object sender, EventArgs e)
        {
            ToggleStyle(FontStyle.Bold); //nút B
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            ToggleStyle(FontStyle.Italic); //I
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            ToggleStyle(FontStyle.Underline);//U
        }

        //đổi font khi chọn
        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                richTextBox1.SelectionFont = new Font(
                        cmbFont.Text,
                        richTextBox1.SelectionFont.Size,
                        richTextBox1.SelectionFont.Style);
            }
        }

            //đổi size khi chọn
        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                float newSize = float.Parse(cmbSize.Text);

                richTextBox1.SelectionFont = new Font(
                        richTextBox1.SelectionFont.FontFamily,
                        newSize,
                        richTextBox1.SelectionFont.Style);
            }
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {

            // xóa nội dung
            richTextBox1.Clear();

            // xóa file đang mở
            currentFile = "";

            // khôi phục giá trị mặc định
            string defaultFont = "Tahoma";
            float defaultSize = 14;

            cmbFont.Text = defaultFont;
            cmbSize.Text = defaultSize.ToString();

            // đặt lại font cho richtextbox 
            richTextBox1.Font = new Font(defaultFont, defaultSize);


        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Mở tập tin văn bản";
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|Text File (*.txt)|*.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // nếu file rtf LoadFile
                if (dlg.FileName.EndsWith(".rtf"))
                {
                    richTextBox1.LoadFile(dlg.FileName, RichTextBoxStreamType.RichText);
                }
                else   // nếu file txt đọc text bth
                {
                    richTextBox1.Text = System.IO.File.ReadAllText(dlg.FileName);
                }

                // cập nhật file hiện tại
                currentFile = dlg.FileName;

               
           

            }

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            // nếu chưa lưu thì save as
            if (string.IsNullOrEmpty(currentFile))
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "Lưu tập tin";
                dlg.Filter = "Rich Text Format (*.rtf)|*.rtf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Lưu thành công!");
                }
            }
            else
            {
                // lưu file đè
                richTextBox1.SaveFile(currentFile, RichTextBoxStreamType.RichText);
                MessageBox.Show("Lưu thành công!");

            }

        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void tạoTậpTinMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNew_Click(sender, e);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFont_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //ko bôi đen thì ko đổi font
            if (richTextBox1.SelectionLength == 0)
                return;

            if (richTextBox1.SelectionFont != null)
            {
                richTextBox1.SelectionFont = new Font(
                    cmbFont.Text,
                    richTextBox1.SelectionFont.Size,
                    richTextBox1.SelectionFont.Style
                );
            }
        }

        private void cmbSize_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // ko bôi đen thì ko đổi size
            if (richTextBox1.SelectionLength == 0)
                return;

            if (richTextBox1.SelectionFont != null)
            {
                float newSize = float.Parse(cmbSize.Text);

                richTextBox1.SelectionFont = new Font(
                    richTextBox1.SelectionFont.FontFamily,
                    newSize,
                    richTextBox1.SelectionFont.Style
                );
            }
        }
    }
    }


