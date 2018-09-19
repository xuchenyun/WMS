using CIT.Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace CIT.Client
{
    internal class MyMsgFrm : BaseForm
    {
        private string _CaptionText;

        private string _Message;

        private EnumMessageBox _MessageMode;

        private readonly int _MaxWidth = 600;

        private readonly int _MaxHeight = 400;

        private IContainer components = null;

        private TableLayoutPanel tableLayoutPanel1;

        private Panel panel2;

        private TXButton btn_no;

        private TXButton btn_ok;

        private TXPanel txPanel1;

        private TableLayoutPanel tableLayoutPanel2;

        private Label labMessage;

        private Panel panel1;

        private PictureBox pbImage;

        public MyMsgFrm()
        {
            InitializeComponent();
            base.ResizeEnable = false;
            base.TopMost = true;
            _CaptionText = "开铭智能温馨提醒";
            _Message = "开铭智能 引领科技潮流";
            _MessageMode = EnumMessageBox.Info;
            MaximumSize = new Size(_MaxWidth, _MaxHeight);
            ControlHelper.BindMouseMoveEvent(labMessage);
            ControlHelper.BindMouseMoveEvent(panel1);
            base.StartPosition = FormStartPosition.Manual;
            base.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - base.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - base.Height / 2);
        }

        public MyMsgFrm(string captionText, string message, EnumMessageBox messageBoxMode)
            : this()
        {
            _CaptionText = captionText;
            _MessageMode = messageBoxMode;
            if (messageBoxMode == EnumMessageBox.Error)
            {
                base.CapitionLogo = Resources.logo;
            }
            _Message = message;
            ResetSize();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void BindData()
        {
            Text = _CaptionText;
            labMessage.Text = _Message;
            switch (_MessageMode)
            {
                case EnumMessageBox.Info:
                    pbImage.Image = Resources.info1;
                    btn_no.Visible = false;
                    btn_ok.Location = new Point((base.Width - btn_ok.Width) / 2, btn_ok.Location.Y);
                    break;
                case EnumMessageBox.Question:
                    pbImage.Image = Resources.question1;
                    break;
                case EnumMessageBox.Warning:
                    pbImage.Image = Resources.warning1;
                    btn_no.Visible = false;
                    btn_ok.Location = new Point((base.Width - btn_ok.Width) / 2, btn_ok.Location.Y);
                    break;
                case EnumMessageBox.Error:
                    pbImage.Image = Resources.error1;
                    btn_no.Visible = false;
                    btn_ok.Location = new Point((base.Width - btn_ok.Width) / 2, btn_ok.Location.Y);
                    break;
            }
        }

        private void playSound(Stream fileStream)
        {
            using (SoundPlayer soundPlayer = new SoundPlayer())
            {
                soundPlayer.Stream = fileStream;
                soundPlayer.Play();
            }
        }

        private void ResetSize()
        {
            Size size = labMessage.Size;
            Size size2 = TextRenderer.MeasureText("CIT", Font);
            int num = size.Height / size2.Height;
            int num2 = size.Width * size.Height / (size2.Width * size2.Width);
            using (Graphics graphics = labMessage.CreateGraphics())
            {
                int charactersFitted = 0;
                int linesFilled = 0;
                graphics.MeasureString(_Message, Font, new SizeF((float)size.Width, (float)_MaxHeight), StringFormat.GenericDefault, out charactersFitted, out linesFilled);
                if (linesFilled > num)
                {
                    base.Size = new SizeF((float)base.Size.Width, (float)(base.Size.Height + size2.Height * (linesFilled - num))).ToSize();
                }
                if (charactersFitted > num2)
                {
                    float num3 = (float)(_Message.Length / num2);
                    num3 = 1f + (num3 - 1f) / 8f;
                    base.Size = new SizeF((float)base.Size.Width * num3, (float)base.Size.Height * num3).ToSize();
                }
            }
        }

        private void MyMsgFrm_Load(object sender, EventArgs e)
        {
            BindData();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panel2 = new System.Windows.Forms.Panel();
            btn_no = new CIT.Client.TXButton();
            btn_ok = new CIT.Client.TXButton();
            txPanel1 = new CIT.Client.TXPanel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            labMessage = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            pbImage = new System.Windows.Forms.PictureBox();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            txPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Controls.Add(txPanel1, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(1, 28);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.27461f));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.72539f));
            tableLayoutPanel1.Size = new System.Drawing.Size(350, 169);
            tableLayoutPanel1.TabIndex = 0;
            panel2.BackColor = System.Drawing.Color.Transparent;
            panel2.Controls.Add(btn_no);
            panel2.Controls.Add(btn_ok);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(3, 136);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(344, 30);
            panel2.TabIndex = 1;
            btn_no.Image = null;
            btn_no.Location = new System.Drawing.Point(207, 0);
            btn_no.Name = "btn_no";
            btn_no.Size = new System.Drawing.Size(85, 30);
            btn_no.TabIndex = 1;
            btn_no.Text = "取消";
            btn_no.UseVisualStyleBackColor = true;
            btn_no.Click += new System.EventHandler(btn_no_Click);
            btn_ok.Image = null;
            btn_ok.Location = new System.Drawing.Point(64, 0);
            btn_ok.Name = "btn_ok";
            btn_ok.Size = new System.Drawing.Size(85, 30);
            btn_ok.TabIndex = 0;
            btn_ok.Text = "确定";
            btn_ok.UseVisualStyleBackColor = true;
            btn_ok.Click += new System.EventHandler(btn_ok_Click);
            txPanel1.BackColor = System.Drawing.Color.Transparent;
            txPanel1.BorderColor = System.Drawing.Color.FromArgb(182, 168, 192);
            txPanel1.Controls.Add(tableLayoutPanel2);
            txPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            txPanel1.Location = new System.Drawing.Point(3, 3);
            txPanel1.Name = "txPanel1";
            txPanel1.Size = new System.Drawing.Size(344, 127);
            txPanel1.TabIndex = 2;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101f));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
            tableLayoutPanel2.Controls.Add(labMessage, 1, 0);
            tableLayoutPanel2.Controls.Add(panel1, 0, 1);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86f));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
            tableLayoutPanel2.Size = new System.Drawing.Size(344, 127);
            tableLayoutPanel2.TabIndex = 1;
            labMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            labMessage.Location = new System.Drawing.Point(111, 8);
            labMessage.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            labMessage.Name = "labMessage";
            tableLayoutPanel2.SetRowSpan(labMessage, 3);
            labMessage.Size = new System.Drawing.Size(225, 111);
            labMessage.TabIndex = 0;
            labMessage.Text = "上海开铭智能科技有限公司";
            labMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            panel1.Controls.Add(pbImage);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(8, 23);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(5);
            panel1.Size = new System.Drawing.Size(95, 80);
            panel1.TabIndex = 1;
            pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            pbImage.Location = new System.Drawing.Point(5, 5);
            pbImage.Name = "pbImage";
            pbImage.Padding = new System.Windows.Forms.Padding(12);
            pbImage.Size = new System.Drawing.Size(85, 70);
            pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbImage.TabIndex = 2;
            pbImage.TabStop = false;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(352, 198);
            base.Controls.Add(tableLayoutPanel1);
            Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            base.Location = new System.Drawing.Point(0, 0);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "MyMsgFrm";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            base.Load += new System.EventHandler(MyMsgFrm_Load);
            tableLayoutPanel1.ResumeLayout(performLayout: false);
            panel2.ResumeLayout(performLayout: false);
            txPanel1.ResumeLayout(performLayout: false);
            tableLayoutPanel2.ResumeLayout(performLayout: false);
            panel1.ResumeLayout(performLayout: false);
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(performLayout: false);
        }
    }
}
