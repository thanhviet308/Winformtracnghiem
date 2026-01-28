namespace PhanMemThiTracNghiem.Forms.Admin.LopHoc
{
    partial class frmGanSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.panelLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSVChuaGan = new System.Windows.Forms.Label();
            this.txtTimKiemChuaGan = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvSinhVienChuaGan = new System.Windows.Forms.DataGridView();
            this.colChuaGanChon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colChuaGanId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChuaGanHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChuaGanEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRight = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSVDaGan = new System.Windows.Forms.Label();
            this.txtTimKiemDaGan = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvSinhVienDaGan = new System.Windows.Forms.DataGridView();
            this.colDaGanChon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDaGanId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaGanHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaGanEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelButtons = new Guna.UI2.WinForms.Guna2Panel();
            this.btnGanVaoLop = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoaKhoiLop = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienChuaGan)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienDaGan)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(99)))), ((int)(((byte)(222)))));
            this.panelMain.BorderRadius = 15;
            this.panelMain.BorderThickness = 2;
            this.panelMain.Controls.Add(this.panelRight);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Controls.Add(this.panelLeft);
            this.panelMain.Controls.Add(this.lblTenLop);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.btnDong);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(900, 600);
            this.panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(99)))), ((int)(((byte)(222)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Gán sinh viên vào lớp";
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTenLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTenLop.Location = new System.Drawing.Point(310, 25);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(100, 25);
            this.lblTenLop.TabIndex = 1;
            this.lblTenLop.Text = "Tên lớp";
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelLeft.BorderRadius = 10;
            this.panelLeft.Controls.Add(this.dgvSinhVienChuaGan);
            this.panelLeft.Controls.Add(this.txtTimKiemChuaGan);
            this.panelLeft.Controls.Add(this.lblSVChuaGan);
            this.panelLeft.Location = new System.Drawing.Point(20, 70);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeft.Size = new System.Drawing.Size(370, 450);
            this.panelLeft.TabIndex = 2;
            // 
            // lblSVChuaGan
            // 
            this.lblSVChuaGan.AutoSize = true;
            this.lblSVChuaGan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSVChuaGan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSVChuaGan.Location = new System.Drawing.Point(10, 10);
            this.lblSVChuaGan.Name = "lblSVChuaGan";
            this.lblSVChuaGan.Size = new System.Drawing.Size(180, 21);
            this.lblSVChuaGan.TabIndex = 0;
            this.lblSVChuaGan.Text = "Sinh viên chưa gán lớp";
            // 
            // txtTimKiemChuaGan
            // 
            this.txtTimKiemChuaGan.BorderRadius = 8;
            this.txtTimKiemChuaGan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiemChuaGan.DefaultText = "";
            this.txtTimKiemChuaGan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiemChuaGan.Location = new System.Drawing.Point(10, 40);
            this.txtTimKiemChuaGan.Name = "txtTimKiemChuaGan";
            this.txtTimKiemChuaGan.PlaceholderText = "Tìm kiếm...";
            this.txtTimKiemChuaGan.SelectedText = "";
            this.txtTimKiemChuaGan.Size = new System.Drawing.Size(350, 32);
            this.txtTimKiemChuaGan.TabIndex = 1;
            this.txtTimKiemChuaGan.TextChanged += new System.EventHandler(this.txtTimKiemChuaGan_TextChanged);
            // 
            // dgvSinhVienChuaGan
            // 
            this.dgvSinhVienChuaGan.AllowUserToAddRows = false;
            this.dgvSinhVienChuaGan.AllowUserToDeleteRows = false;
            this.dgvSinhVienChuaGan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVienChuaGan.BackgroundColor = System.Drawing.Color.White;
            this.dgvSinhVienChuaGan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSinhVienChuaGan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVienChuaGan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChuaGanChon,
            this.colChuaGanId,
            this.colChuaGanHoTen,
            this.colChuaGanEmail});
            this.dgvSinhVienChuaGan.Location = new System.Drawing.Point(10, 80);
            this.dgvSinhVienChuaGan.Name = "dgvSinhVienChuaGan";
            this.dgvSinhVienChuaGan.RowHeadersVisible = false;
            this.dgvSinhVienChuaGan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVienChuaGan.Size = new System.Drawing.Size(350, 360);
            this.dgvSinhVienChuaGan.TabIndex = 2;
            // 
            // colChuaGanChon
            // 
            this.colChuaGanChon.HeaderText = "Chọn";
            this.colChuaGanChon.Name = "colChuaGanChon";
            this.colChuaGanChon.FillWeight = 40;
            // 
            // colChuaGanId
            // 
            this.colChuaGanId.HeaderText = "ID";
            this.colChuaGanId.Name = "colChuaGanId";
            this.colChuaGanId.ReadOnly = true;
            this.colChuaGanId.Visible = false;
            // 
            // colChuaGanHoTen
            // 
            this.colChuaGanHoTen.HeaderText = "Họ tên";
            this.colChuaGanHoTen.Name = "colChuaGanHoTen";
            this.colChuaGanHoTen.ReadOnly = true;
            this.colChuaGanHoTen.FillWeight = 100;
            // 
            // colChuaGanEmail
            // 
            this.colChuaGanEmail.HeaderText = "Email";
            this.colChuaGanEmail.Name = "colChuaGanEmail";
            this.colChuaGanEmail.ReadOnly = true;
            this.colChuaGanEmail.FillWeight = 120;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelButtons.Controls.Add(this.btnGanVaoLop);
            this.panelButtons.Controls.Add(this.btnXoaKhoiLop);
            this.panelButtons.Location = new System.Drawing.Point(400, 200);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(100, 150);
            this.panelButtons.TabIndex = 3;
            // 
            // btnGanVaoLop
            // 
            this.btnGanVaoLop.BorderRadius = 8;
            this.btnGanVaoLop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnGanVaoLop.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnGanVaoLop.ForeColor = System.Drawing.Color.White;
            this.btnGanVaoLop.Location = new System.Drawing.Point(10, 20);
            this.btnGanVaoLop.Name = "btnGanVaoLop";
            this.btnGanVaoLop.Size = new System.Drawing.Size(80, 50);
            this.btnGanVaoLop.TabIndex = 0;
            this.btnGanVaoLop.Text = ">>";
            this.btnGanVaoLop.Click += new System.EventHandler(this.btnGanVaoLop_Click);
            // 
            // btnXoaKhoiLop
            // 
            this.btnXoaKhoiLop.BorderRadius = 8;
            this.btnXoaKhoiLop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoaKhoiLop.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnXoaKhoiLop.ForeColor = System.Drawing.Color.White;
            this.btnXoaKhoiLop.Location = new System.Drawing.Point(10, 80);
            this.btnXoaKhoiLop.Name = "btnXoaKhoiLop";
            this.btnXoaKhoiLop.Size = new System.Drawing.Size(80, 50);
            this.btnXoaKhoiLop.TabIndex = 1;
            this.btnXoaKhoiLop.Text = "<<";
            this.btnXoaKhoiLop.Click += new System.EventHandler(this.btnXoaKhoiLop_Click);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelRight.BorderRadius = 10;
            this.panelRight.Controls.Add(this.dgvSinhVienDaGan);
            this.panelRight.Controls.Add(this.txtTimKiemDaGan);
            this.panelRight.Controls.Add(this.lblSVDaGan);
            this.panelRight.Location = new System.Drawing.Point(510, 70);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(10);
            this.panelRight.Size = new System.Drawing.Size(370, 450);
            this.panelRight.TabIndex = 4;
            // 
            // lblSVDaGan
            // 
            this.lblSVDaGan.AutoSize = true;
            this.lblSVDaGan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSVDaGan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSVDaGan.Location = new System.Drawing.Point(10, 10);
            this.lblSVDaGan.Name = "lblSVDaGan";
            this.lblSVDaGan.Size = new System.Drawing.Size(170, 21);
            this.lblSVDaGan.TabIndex = 0;
            this.lblSVDaGan.Text = "Sinh viên trong lớp";
            // 
            // txtTimKiemDaGan
            // 
            this.txtTimKiemDaGan.BorderRadius = 8;
            this.txtTimKiemDaGan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiemDaGan.DefaultText = "";
            this.txtTimKiemDaGan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiemDaGan.Location = new System.Drawing.Point(10, 40);
            this.txtTimKiemDaGan.Name = "txtTimKiemDaGan";
            this.txtTimKiemDaGan.PlaceholderText = "Tìm kiếm...";
            this.txtTimKiemDaGan.SelectedText = "";
            this.txtTimKiemDaGan.Size = new System.Drawing.Size(350, 32);
            this.txtTimKiemDaGan.TabIndex = 1;
            this.txtTimKiemDaGan.TextChanged += new System.EventHandler(this.txtTimKiemDaGan_TextChanged);
            // 
            // dgvSinhVienDaGan
            // 
            this.dgvSinhVienDaGan.AllowUserToAddRows = false;
            this.dgvSinhVienDaGan.AllowUserToDeleteRows = false;
            this.dgvSinhVienDaGan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVienDaGan.BackgroundColor = System.Drawing.Color.White;
            this.dgvSinhVienDaGan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSinhVienDaGan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVienDaGan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDaGanChon,
            this.colDaGanId,
            this.colDaGanHoTen,
            this.colDaGanEmail});
            this.dgvSinhVienDaGan.Location = new System.Drawing.Point(10, 80);
            this.dgvSinhVienDaGan.Name = "dgvSinhVienDaGan";
            this.dgvSinhVienDaGan.RowHeadersVisible = false;
            this.dgvSinhVienDaGan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVienDaGan.Size = new System.Drawing.Size(350, 360);
            this.dgvSinhVienDaGan.TabIndex = 2;
            // 
            // colDaGanChon
            // 
            this.colDaGanChon.HeaderText = "Chọn";
            this.colDaGanChon.Name = "colDaGanChon";
            this.colDaGanChon.FillWeight = 40;
            // 
            // colDaGanId
            // 
            this.colDaGanId.HeaderText = "ID";
            this.colDaGanId.Name = "colDaGanId";
            this.colDaGanId.ReadOnly = true;
            this.colDaGanId.Visible = false;
            // 
            // colDaGanHoTen
            // 
            this.colDaGanHoTen.HeaderText = "Họ tên";
            this.colDaGanHoTen.Name = "colDaGanHoTen";
            this.colDaGanHoTen.ReadOnly = true;
            this.colDaGanHoTen.FillWeight = 100;
            // 
            // colDaGanEmail
            // 
            this.colDaGanEmail.HeaderText = "Email";
            this.colDaGanEmail.Name = "colDaGanEmail";
            this.colDaGanEmail.ReadOnly = true;
            this.colDaGanEmail.FillWeight = 120;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BorderRadius = 8;
            this.btnDong.FillColor = System.Drawing.Color.Gray;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(760, 540);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 40);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmGanSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGanSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gán sinh viên vào lớp";
            this.Load += new System.EventHandler(this.frmGanSinhVien_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienChuaGan)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienDaGan)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenLop;
        private Guna.UI2.WinForms.Guna2Panel panelLeft;
        private System.Windows.Forms.Label lblSVChuaGan;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiemChuaGan;
        private System.Windows.Forms.DataGridView dgvSinhVienChuaGan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChuaGanChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChuaGanId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChuaGanHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChuaGanEmail;
        private Guna.UI2.WinForms.Guna2Panel panelButtons;
        private Guna.UI2.WinForms.Guna2Button btnGanVaoLop;
        private Guna.UI2.WinForms.Guna2Button btnXoaKhoiLop;
        private Guna.UI2.WinForms.Guna2Panel panelRight;
        private System.Windows.Forms.Label lblSVDaGan;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiemDaGan;
        private System.Windows.Forms.DataGridView dgvSinhVienDaGan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDaGanChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaGanId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaGanHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaGanEmail;
        private Guna.UI2.WinForms.Guna2Button btnDong;
    }
}
