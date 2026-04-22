namespace PhanMemThiTracNghiem.Forms.Admin.MonHoc
{
    partial class frmSuaMonHoc
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
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.txtTenMon = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblChuong = new System.Windows.Forms.Label();
            this.txtTenChuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThemChuong = new Guna.UI2.WinForms.Guna2Button();
            this.btnSuaChuong = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoaChuong = new Guna.UI2.WinForms.Guna2Button();
            this.dgvChuong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colChuongId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenChuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuong)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlMain.BorderRadius = 15;
            this.pnlMain.BorderThickness = 1;
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblTenMon);
            this.pnlMain.Controls.Add(this.txtTenMon);
            this.pnlMain.Controls.Add(this.lblChuong);
            this.pnlMain.Controls.Add(this.txtTenChuong);
            this.pnlMain.Controls.Add(this.btnThemChuong);
            this.pnlMain.Controls.Add(this.btnSuaChuong);
            this.pnlMain.Controls.Add(this.btnXoaChuong);
            this.pnlMain.Controls.Add(this.dgvChuong);
            this.pnlMain.Controls.Add(this.btnLuu);
            this.pnlMain.Controls.Add(this.btnHuy);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(450, 560);
            this.pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(199, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cập nhật môn học";
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTenMon.Location = new System.Drawing.Point(30, 85);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(117, 19);
            this.lblTenMon.TabIndex = 1;
            this.lblTenMon.Text = "Tên môn học";
            // 
            // txtTenMon
            // 
            this.txtTenMon.BorderRadius = 10;
            this.txtTenMon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenMon.DefaultText = "";
            this.txtTenMon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenMon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenMon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenMon.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenMon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtTenMon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtTenMon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenMon.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtTenMon.Location = new System.Drawing.Point(30, 110);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.PasswordChar = '\0';
            this.txtTenMon.PlaceholderText = "Nhập tên môn học...";
            this.txtTenMon.SelectedText = "";
            this.txtTenMon.Size = new System.Drawing.Size(390, 45);
            this.txtTenMon.TabIndex = 2;

            // 
            // lblChuong
            // 
            this.lblChuong.AutoSize = true;
            this.lblChuong.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblChuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblChuong.Location = new System.Drawing.Point(30, 170);
            this.lblChuong.Name = "lblChuong";
            this.lblChuong.Size = new System.Drawing.Size(56, 19);
            this.lblChuong.TabIndex = 3;
            this.lblChuong.Text = "Chương";

            // 
            // txtTenChuong
            // 
            this.txtTenChuong.BorderRadius = 10;
            this.txtTenChuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenChuong.DefaultText = "";
            this.txtTenChuong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenChuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenChuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenChuong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenChuong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtTenChuong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtTenChuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenChuong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtTenChuong.Location = new System.Drawing.Point(30, 195);
            this.txtTenChuong.Name = "txtTenChuong";
            this.txtTenChuong.PasswordChar = '\0';
            this.txtTenChuong.PlaceholderText = "Nhập tên chương...";
            this.txtTenChuong.SelectedText = "";
            this.txtTenChuong.Size = new System.Drawing.Size(250, 40);
            this.txtTenChuong.TabIndex = 6;

            // 
            // btnThemChuong
            // 
            this.btnThemChuong.BorderRadius = 10;
            this.btnThemChuong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemChuong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemChuong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemChuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemChuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemChuong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnThemChuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemChuong.ForeColor = System.Drawing.Color.White;
            this.btnThemChuong.Location = new System.Drawing.Point(290, 195);
            this.btnThemChuong.Name = "btnThemChuong";
            this.btnThemChuong.Size = new System.Drawing.Size(130, 40);
            this.btnThemChuong.TabIndex = 7;
            this.btnThemChuong.Text = "+ Thêm chương";
            this.btnThemChuong.Click += new System.EventHandler(this.btnThemChuong_Click);

            // 
            // btnSuaChuong
            // 
            this.btnSuaChuong.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnSuaChuong.BorderRadius = 10;
            this.btnSuaChuong.BorderThickness = 1;
            this.btnSuaChuong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaChuong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSuaChuong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSuaChuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSuaChuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSuaChuong.FillColor = System.Drawing.Color.White;
            this.btnSuaChuong.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnSuaChuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSuaChuong.Location = new System.Drawing.Point(290, 240);
            this.btnSuaChuong.Name = "btnSuaChuong";
            this.btnSuaChuong.Size = new System.Drawing.Size(130, 36);
            this.btnSuaChuong.TabIndex = 8;
            this.btnSuaChuong.Text = "Cập nhật";
            this.btnSuaChuong.Click += new System.EventHandler(this.btnSuaChuong_Click);

            // 
            // btnXoaChuong
            // 
            this.btnXoaChuong.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnXoaChuong.BorderRadius = 10;
            this.btnXoaChuong.BorderThickness = 1;
            this.btnXoaChuong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaChuong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaChuong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaChuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoaChuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoaChuong.FillColor = System.Drawing.Color.White;
            this.btnXoaChuong.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaChuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnXoaChuong.Location = new System.Drawing.Point(30, 240);
            this.btnXoaChuong.Name = "btnXoaChuong";
            this.btnXoaChuong.Size = new System.Drawing.Size(120, 36);
            this.btnXoaChuong.TabIndex = 9;
            this.btnXoaChuong.Text = "Xóa";
            this.btnXoaChuong.Click += new System.EventHandler(this.btnXoaChuong_Click);

            // 
            // dgvChuong
            // 
            this.dgvChuong.AllowUserToAddRows = false;
            this.dgvChuong.AllowUserToDeleteRows = false;
            this.dgvChuong.AllowUserToResizeRows = false;
            this.dgvChuong.BackgroundColor = System.Drawing.Color.White;
            this.dgvChuong.ColumnHeadersHeight = 40;
            this.dgvChuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChuongId,
            this.colTenChuong});
            this.dgvChuong.Location = new System.Drawing.Point(30, 285);
            this.dgvChuong.Name = "dgvChuong";
            this.dgvChuong.ReadOnly = true;
            this.dgvChuong.RowHeadersVisible = false;
            this.dgvChuong.RowTemplate.Height = 35;
            this.dgvChuong.Size = new System.Drawing.Size(390, 170);
            this.dgvChuong.TabIndex = 10;
            this.dgvChuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChuong_CellClick);

            // 
            // colChuongId
            // 
            this.colChuongId.HeaderText = "ID";
            this.colChuongId.Name = "colChuongId";
            this.colChuongId.ReadOnly = true;
            this.colChuongId.Visible = false;

            // 
            // colTenChuong
            // 
            this.colTenChuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenChuong.HeaderText = "Tên chương";
            this.colTenChuong.Name = "colTenChuong";
            this.colTenChuong.ReadOnly = true;
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 10;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(270, 485);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 50);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu thay đổi";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnHuy.BorderRadius = 10;
            this.btnHuy.BorderThickness = 1;
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuy.FillColor = System.Drawing.Color.White;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnHuy.Location = new System.Drawing.Point(140, 485);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 50);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmSuaMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 560);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSuaMonHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sửa môn học";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuong)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenMon;
        private Guna.UI2.WinForms.Guna2TextBox txtTenMon;
        private System.Windows.Forms.Label lblChuong;
        private Guna.UI2.WinForms.Guna2TextBox txtTenChuong;
        private Guna.UI2.WinForms.Guna2Button btnThemChuong;
        private Guna.UI2.WinForms.Guna2Button btnSuaChuong;
        private Guna.UI2.WinForms.Guna2Button btnXoaChuong;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChuongId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenChuong;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}
