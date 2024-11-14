namespace GUI
{
    partial class frmUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.cmb_Sach = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtp_NgayMuon = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpk_NgayTraDuKien = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dgv_ThongTin = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btn_DangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.btnMuonSach = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ThongTin)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Sach
            // 
            this.cmb_Sach.BackColor = System.Drawing.Color.Transparent;
            this.cmb_Sach.BorderRadius = 12;
            this.cmb_Sach.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Sach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Sach.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_Sach.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_Sach.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_Sach.ForeColor = System.Drawing.Color.Black;
            this.cmb_Sach.ItemHeight = 30;
            this.cmb_Sach.Location = new System.Drawing.Point(104, 208);
            this.cmb_Sach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_Sach.Name = "cmb_Sach";
            this.cmb_Sach.Size = new System.Drawing.Size(488, 36);
            this.cmb_Sach.TabIndex = 0;
            // 
            // dtp_NgayMuon
            // 
            this.dtp_NgayMuon.BorderRadius = 12;
            this.dtp_NgayMuon.Checked = true;
            this.dtp_NgayMuon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_NgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtp_NgayMuon.Location = new System.Drawing.Point(96, 272);
            this.dtp_NgayMuon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_NgayMuon.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_NgayMuon.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_NgayMuon.Name = "dtp_NgayMuon";
            this.dtp_NgayMuon.Size = new System.Drawing.Size(200, 36);
            this.dtp_NgayMuon.TabIndex = 1;
            this.dtp_NgayMuon.Value = new System.DateTime(2024, 10, 22, 20, 48, 48, 8);
            this.dtp_NgayMuon.ValueChanged += new System.EventHandler(this.dtp_NgayMuon_ValueChanged);
            // 
            // dtpk_NgayTraDuKien
            // 
            this.dtpk_NgayTraDuKien.BorderRadius = 12;
            this.dtpk_NgayTraDuKien.Checked = true;
            this.dtpk_NgayTraDuKien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpk_NgayTraDuKien.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpk_NgayTraDuKien.Location = new System.Drawing.Point(96, 329);
            this.dtpk_NgayTraDuKien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpk_NgayTraDuKien.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpk_NgayTraDuKien.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpk_NgayTraDuKien.Name = "dtpk_NgayTraDuKien";
            this.dtpk_NgayTraDuKien.Size = new System.Drawing.Size(200, 36);
            this.dtpk_NgayTraDuKien.TabIndex = 2;
            this.dtpk_NgayTraDuKien.Value = new System.DateTime(2024, 10, 22, 20, 48, 48, 8);
            // 
            // dgv_ThongTin
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_ThongTin.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ThongTin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ThongTin.ColumnHeadersHeight = 4;
            this.dgv_ThongTin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ThongTin.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ThongTin.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_ThongTin.Location = new System.Drawing.Point(608, 0);
            this.dgv_ThongTin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_ThongTin.Name = "dgv_ThongTin";
            this.dgv_ThongTin.RowHeadersVisible = false;
            this.dgv_ThongTin.RowHeadersWidth = 51;
            this.dgv_ThongTin.RowTemplate.Height = 24;
            this.dgv_ThongTin.Size = new System.Drawing.Size(600, 496);
            this.dgv_ThongTin.TabIndex = 5;
            this.dgv_ThongTin.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_ThongTin.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_ThongTin.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_ThongTin.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_ThongTin.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_ThongTin.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_ThongTin.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_ThongTin.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_ThongTin.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_ThongTin.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_ThongTin.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_ThongTin.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_ThongTin.ThemeStyle.HeaderStyle.Height = 4;
            this.dgv_ThongTin.ThemeStyle.ReadOnly = false;
            this.dgv_ThongTin.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_ThongTin.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_ThongTin.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_ThongTin.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_ThongTin.ThemeStyle.RowsStyle.Height = 24;
            this.dgv_ThongTin.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_ThongTin.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên sách ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ngày mượn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ngày trả";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 471);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1205, 26);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::GUI.Properties.Resources.userLogin;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(248, 24);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(152, 160);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 10;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // btn_DangXuat
            // 
            this.btn_DangXuat.BorderRadius = 12;
            this.btn_DangXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_DangXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_DangXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_DangXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_DangXuat.FillColor = System.Drawing.Color.Red;
            this.btn_DangXuat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_DangXuat.ForeColor = System.Drawing.Color.White;
            this.btn_DangXuat.Image = global::GUI.Properties.Resources.login_rounded_26px;
            this.btn_DangXuat.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_DangXuat.Location = new System.Drawing.Point(264, 394);
            this.btn_DangXuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_DangXuat.Name = "btn_DangXuat";
            this.btn_DangXuat.Size = new System.Drawing.Size(166, 46);
            this.btn_DangXuat.TabIndex = 9;
            this.btn_DangXuat.Text = "Đăng xuất";
            this.btn_DangXuat.Click += new System.EventHandler(this.btn_DangXuat_Click);
            // 
            // btnMuonSach
            // 
            this.btnMuonSach.BorderRadius = 12;
            this.btnMuonSach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMuonSach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMuonSach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMuonSach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMuonSach.FillColor = System.Drawing.Color.Blue;
            this.btnMuonSach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMuonSach.ForeColor = System.Drawing.Color.White;
            this.btnMuonSach.Image = global::GUI.Properties.Resources.debt_24px;
            this.btnMuonSach.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMuonSach.Location = new System.Drawing.Point(88, 391);
            this.btnMuonSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMuonSach.Name = "btnMuonSach";
            this.btnMuonSach.Size = new System.Drawing.Size(168, 46);
            this.btnMuonSach.TabIndex = 3;
            this.btnMuonSach.Text = "Mượn sách ";
            this.btnMuonSach.Click += new System.EventHandler(this.btnMuonSach_Click);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 497);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.Controls.Add(this.btn_DangXuat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_ThongTin);
            this.Controls.Add(this.btnMuonSach);
            this.Controls.Add(this.dtpk_NgayTraDuKien);
            this.Controls.Add(this.dtp_NgayMuon);
            this.Controls.Add(this.cmb_Sach);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmUser";
            this.Text = "User";
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ThongTin)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cmb_Sach;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_NgayMuon;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpk_NgayTraDuKien;
        private Guna.UI2.WinForms.Guna2Button btnMuonSach;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_ThongTin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btn_DangXuat;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}