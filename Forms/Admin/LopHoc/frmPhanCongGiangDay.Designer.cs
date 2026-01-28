namespace PhanMemThiTracNghiem.Forms.Admin.LopHoc
{
    partial class frmPhanCongGiangDay
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
            this.panelThemPhanCong = new Guna.UI2.WinForms.Guna2Panel();
            this.lblThemPhanCong = new System.Windows.Forms.Label();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.cboMonHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblGiangVien = new System.Windows.Forms.Label();
            this.cboGiangVien = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnThemPhanCong = new Guna.UI2.WinForms.Guna2Button();
            this.dgvPhanCong = new System.Windows.Forms.DataGridView();
            this.colMaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenGiangVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayPhanCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain.SuspendLayout();
            this.panelThemPhanCong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCong)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(99)))), ((int)(((byte)(222)))));
            this.panelMain.BorderRadius = 15;
            this.panelMain.BorderThickness = 2;
            this.panelMain.Controls.Add(this.btnDong);
            this.panelMain.Controls.Add(this.dgvPhanCong);
            this.panelMain.Controls.Add(this.panelThemPhanCong);
            this.panelMain.Controls.Add(this.lblTenLop);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(750, 550);
            this.panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(99)))), ((int)(((byte)(222)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Phân công giảng dạy";
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTenLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTenLop.Location = new System.Drawing.Point(290, 25);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(100, 25);
            this.lblTenLop.TabIndex = 1;
            this.lblTenLop.Text = "Tên lớp";
            // 
            // panelThemPhanCong
            // 
            this.panelThemPhanCong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelThemPhanCong.BorderRadius = 10;
            this.panelThemPhanCong.Controls.Add(this.btnThemPhanCong);
            this.panelThemPhanCong.Controls.Add(this.cboGiangVien);
            this.panelThemPhanCong.Controls.Add(this.lblGiangVien);
            this.panelThemPhanCong.Controls.Add(this.cboMonHoc);
            this.panelThemPhanCong.Controls.Add(this.lblMonHoc);
            this.panelThemPhanCong.Controls.Add(this.lblThemPhanCong);
            this.panelThemPhanCong.Location = new System.Drawing.Point(20, 70);
            this.panelThemPhanCong.Name = "panelThemPhanCong";
            this.panelThemPhanCong.Padding = new System.Windows.Forms.Padding(15);
            this.panelThemPhanCong.Size = new System.Drawing.Size(710, 130);
            this.panelThemPhanCong.TabIndex = 2;
            // 
            // lblThemPhanCong
            // 
            this.lblThemPhanCong.AutoSize = true;
            this.lblThemPhanCong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblThemPhanCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblThemPhanCong.Location = new System.Drawing.Point(15, 10);
            this.lblThemPhanCong.Name = "lblThemPhanCong";
            this.lblThemPhanCong.Size = new System.Drawing.Size(180, 21);
            this.lblThemPhanCong.TabIndex = 0;
            this.lblThemPhanCong.Text = "Thêm phân công mới";
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMonHoc.Location = new System.Drawing.Point(15, 45);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(75, 20);
            this.lblMonHoc.TabIndex = 1;
            this.lblMonHoc.Text = "Môn học:";
            // 
            // cboMonHoc
            // 
            this.cboMonHoc.BackColor = System.Drawing.Color.Transparent;
            this.cboMonHoc.BorderRadius = 8;
            this.cboMonHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMonHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMonHoc.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboMonHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboMonHoc.ItemHeight = 30;
            this.cboMonHoc.Location = new System.Drawing.Point(15, 70);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(250, 36);
            this.cboMonHoc.TabIndex = 2;
            // 
            // lblGiangVien
            // 
            this.lblGiangVien.AutoSize = true;
            this.lblGiangVien.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblGiangVien.Location = new System.Drawing.Point(285, 45);
            this.lblGiangVien.Name = "lblGiangVien";
            this.lblGiangVien.Size = new System.Drawing.Size(88, 20);
            this.lblGiangVien.TabIndex = 3;
            this.lblGiangVien.Text = "Giảng viên:";
            // 
            // cboGiangVien
            // 
            this.cboGiangVien.BackColor = System.Drawing.Color.Transparent;
            this.cboGiangVien.BorderRadius = 8;
            this.cboGiangVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGiangVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGiangVien.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboGiangVien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboGiangVien.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboGiangVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboGiangVien.ItemHeight = 30;
            this.cboGiangVien.Location = new System.Drawing.Point(285, 70);
            this.cboGiangVien.Name = "cboGiangVien";
            this.cboGiangVien.Size = new System.Drawing.Size(280, 36);
            this.cboGiangVien.TabIndex = 4;
            // 
            // btnThemPhanCong
            // 
            this.btnThemPhanCong.BorderRadius = 8;
            this.btnThemPhanCong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnThemPhanCong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThemPhanCong.ForeColor = System.Drawing.Color.White;
            this.btnThemPhanCong.Location = new System.Drawing.Point(585, 70);
            this.btnThemPhanCong.Name = "btnThemPhanCong";
            this.btnThemPhanCong.Size = new System.Drawing.Size(110, 36);
            this.btnThemPhanCong.TabIndex = 5;
            this.btnThemPhanCong.Text = "+ Thêm";
            this.btnThemPhanCong.Click += new System.EventHandler(this.btnThemPhanCong_Click);
            // 
            // dgvPhanCong
            // 
            this.dgvPhanCong.AllowUserToAddRows = false;
            this.dgvPhanCong.AllowUserToDeleteRows = false;
            this.dgvPhanCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhanCong.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhanCong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaLop,
            this.colMaMon,
            this.colTenMon,
            this.colTenGiangVien,
            this.colNgayPhanCong,
            this.colXoa});
            this.dgvPhanCong.Location = new System.Drawing.Point(20, 220);
            this.dgvPhanCong.Name = "dgvPhanCong";
            this.dgvPhanCong.ReadOnly = true;
            this.dgvPhanCong.RowHeadersVisible = false;
            this.dgvPhanCong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhanCong.Size = new System.Drawing.Size(710, 270);
            this.dgvPhanCong.TabIndex = 3;
            this.dgvPhanCong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhanCong_CellContentClick);
            // 
            // colMaLop
            // 
            this.colMaLop.HeaderText = "Mã lớp";
            this.colMaLop.Name = "colMaLop";
            this.colMaLop.ReadOnly = true;
            this.colMaLop.Visible = false;
            // 
            // colMaMon
            // 
            this.colMaMon.HeaderText = "Mã môn";
            this.colMaMon.Name = "colMaMon";
            this.colMaMon.ReadOnly = true;
            this.colMaMon.Visible = false;
            // 
            // colTenMon
            // 
            this.colTenMon.HeaderText = "Môn học";
            this.colTenMon.Name = "colTenMon";
            this.colTenMon.ReadOnly = true;
            this.colTenMon.FillWeight = 150;
            // 
            // colTenGiangVien
            // 
            this.colTenGiangVien.HeaderText = "Giảng viên";
            this.colTenGiangVien.Name = "colTenGiangVien";
            this.colTenGiangVien.ReadOnly = true;
            this.colTenGiangVien.FillWeight = 150;
            // 
            // colNgayPhanCong
            // 
            this.colNgayPhanCong.HeaderText = "Ngày phân công";
            this.colNgayPhanCong.Name = "colNgayPhanCong";
            this.colNgayPhanCong.ReadOnly = true;
            this.colNgayPhanCong.FillWeight = 100;
            // 
            // colXoa
            // 
            this.colXoa.HeaderText = "Xóa";
            this.colXoa.Name = "colXoa";
            this.colXoa.ReadOnly = true;
            this.colXoa.Text = "Xóa";
            this.colXoa.UseColumnTextForButtonValue = true;
            this.colXoa.FillWeight = 60;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BorderRadius = 8;
            this.btnDong.FillColor = System.Drawing.Color.Gray;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(610, 500);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 40);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmPhanCongGiangDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPhanCongGiangDay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phân công giảng dạy";
            this.Load += new System.EventHandler(this.frmPhanCongGiangDay_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelThemPhanCong.ResumeLayout(false);
            this.panelThemPhanCong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCong)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenLop;
        private Guna.UI2.WinForms.Guna2Panel panelThemPhanCong;
        private System.Windows.Forms.Label lblThemPhanCong;
        private System.Windows.Forms.Label lblMonHoc;
        private Guna.UI2.WinForms.Guna2ComboBox cboMonHoc;
        private System.Windows.Forms.Label lblGiangVien;
        private Guna.UI2.WinForms.Guna2ComboBox cboGiangVien;
        private Guna.UI2.WinForms.Guna2Button btnThemPhanCong;
        private System.Windows.Forms.DataGridView dgvPhanCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenGiangVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayPhanCong;
        private System.Windows.Forms.DataGridViewButtonColumn colXoa;
        private Guna.UI2.WinForms.Guna2Button btnDong;
    }
}
