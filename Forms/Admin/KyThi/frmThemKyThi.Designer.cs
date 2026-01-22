namespace PhanMemThiTracNghiem.Forms.Admin
{
    partial class frmThemKyThi
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
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.dtpKetThuc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblKetThuc = new System.Windows.Forms.Label();
            this.dtpBatDau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblBatDau = new System.Windows.Forms.Label();
            this.txtTenKyThi = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTenKyThi = new System.Windows.Forms.Label();
            this.txtMaKyThi = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMaKyThi = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelMain.BorderRadius = 10;
            this.panelMain.BorderThickness = 1;
            this.panelMain.ShadowDecoration.Enabled = true;
            this.panelMain.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelMain.ShadowDecoration.Depth = 20;
            this.panelMain.Controls.Add(this.btnHuy);
            this.panelMain.Controls.Add(this.btnLuu);
            this.panelMain.Controls.Add(this.dtpKetThuc);
            this.panelMain.Controls.Add(this.lblKetThuc);
            this.panelMain.Controls.Add(this.dtpBatDau);
            this.panelMain.Controls.Add(this.lblBatDau);
            this.panelMain.Controls.Add(this.txtTenKyThi);
            this.panelMain.Controls.Add(this.lblTenKyThi);
            this.panelMain.Controls.Add(this.txtMaKyThi);
            this.panelMain.Controls.Add(this.lblMaKyThi);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30);
            this.panelMain.Size = new System.Drawing.Size(480, 450);
            this.panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(190, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm kỳ thi mới";
            // 
            // lblMaKyThi
            // 
            this.lblMaKyThi.AutoSize = true;
            this.lblMaKyThi.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaKyThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblMaKyThi.Location = new System.Drawing.Point(32, 80);
            this.lblMaKyThi.Name = "lblMaKyThi";
            this.lblMaKyThi.Size = new System.Drawing.Size(73, 19);
            this.lblMaKyThi.TabIndex = 1;
            this.lblMaKyThi.Text = "Mã kỳ thi";
            // 
            // txtMaKyThi
            // 
            this.txtMaKyThi.BorderRadius = 8;
            this.txtMaKyThi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaKyThi.DefaultText = "";
            this.txtMaKyThi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaKyThi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaKyThi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKyThi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKyThi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtMaKyThi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaKyThi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtMaKyThi.Location = new System.Drawing.Point(35, 102);
            this.txtMaKyThi.Name = "txtMaKyThi";
            this.txtMaKyThi.PlaceholderText = "Mã kỳ thi (tự động)";
            this.txtMaKyThi.SelectedText = "";
            this.txtMaKyThi.Size = new System.Drawing.Size(410, 40);
            this.txtMaKyThi.TabIndex = 2;
            // 
            // lblTenKyThi
            // 
            this.lblTenKyThi.AutoSize = true;
            this.lblTenKyThi.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenKyThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTenKyThi.Location = new System.Drawing.Point(32, 155);
            this.lblTenKyThi.Name = "lblTenKyThi";
            this.lblTenKyThi.Size = new System.Drawing.Size(77, 19);
            this.lblTenKyThi.TabIndex = 3;
            this.lblTenKyThi.Text = "Tên kỳ thi";
            // 
            // txtTenKyThi
            // 
            this.txtTenKyThi.BorderRadius = 8;
            this.txtTenKyThi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenKyThi.DefaultText = "";
            this.txtTenKyThi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenKyThi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenKyThi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKyThi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKyThi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtTenKyThi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenKyThi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtTenKyThi.Location = new System.Drawing.Point(35, 177);
            this.txtTenKyThi.Name = "txtTenKyThi";
            this.txtTenKyThi.PlaceholderText = "Nhập tên kỳ thi";
            this.txtTenKyThi.SelectedText = "";
            this.txtTenKyThi.Size = new System.Drawing.Size(410, 40);
            this.txtTenKyThi.TabIndex = 4;
            // 
            // lblBatDau
            // 
            this.lblBatDau.AutoSize = true;
            this.lblBatDau.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblBatDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblBatDau.Location = new System.Drawing.Point(32, 230);
            this.lblBatDau.Name = "lblBatDau";
            this.lblBatDau.Size = new System.Drawing.Size(126, 19);
            this.lblBatDau.TabIndex = 5;
            this.lblBatDau.Text = "Thời gian bắt đầu";
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.BorderRadius = 8;
            this.dtpBatDau.Checked = true;
            this.dtpBatDau.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpBatDau.FillColor = System.Drawing.Color.White;
            this.dtpBatDau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBatDau.Location = new System.Drawing.Point(35, 252);
            this.dtpBatDau.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpBatDau.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(410, 40);
            this.dtpBatDau.TabIndex = 6;
            this.dtpBatDau.Value = new System.DateTime(2025, 1, 6, 0, 0, 0, 0);
            // 
            // lblKetThuc
            // 
            this.lblKetThuc.AutoSize = true;
            this.lblKetThuc.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblKetThuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblKetThuc.Location = new System.Drawing.Point(32, 305);
            this.lblKetThuc.Name = "lblKetThuc";
            this.lblKetThuc.Size = new System.Drawing.Size(130, 19);
            this.lblKetThuc.TabIndex = 7;
            this.lblKetThuc.Text = "Thời gian kết thúc";
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.BorderRadius = 8;
            this.dtpKetThuc.Checked = true;
            this.dtpKetThuc.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpKetThuc.FillColor = System.Drawing.Color.White;
            this.dtpKetThuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKetThuc.Location = new System.Drawing.Point(35, 327);
            this.dtpKetThuc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpKetThuc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(410, 40);
            this.dtpKetThuc.TabIndex = 8;
            this.dtpKetThuc.Value = new System.DateTime(2025, 1, 13, 0, 0, 0, 0);
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 8;
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(250, 390);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 40);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 8;
            this.btnHuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(355, 390);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(90, 40);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmThemKyThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 450);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemKyThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm kỳ thi mới";
            this.Load += new System.EventHandler(this.frmThemKyThi_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMaKyThi;
        private Guna.UI2.WinForms.Guna2TextBox txtMaKyThi;
        private System.Windows.Forms.Label lblTenKyThi;
        private Guna.UI2.WinForms.Guna2TextBox txtTenKyThi;
        private System.Windows.Forms.Label lblBatDau;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpBatDau;
        private System.Windows.Forms.Label lblKetThuc;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpKetThuc;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}
