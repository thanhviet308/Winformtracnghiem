namespace PhanMemThiTracNghiem.Forms.Admin.DeThi
{
    partial class frmThemMonThi
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
            this.lblTenMonThi = new System.Windows.Forms.Label();
            this.txtTenMonThi = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderRadius = 15;
            this.panelMain.Controls.Add(this.btnHuy);
            this.panelMain.Controls.Add(this.btnThem);
            this.panelMain.Controls.Add(this.txtTenMonThi);
            this.panelMain.Controls.Add(this.lblTenMonThi);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(450, 220);
            this.panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(99)))), ((int)(((byte)(222)))));
            this.lblTitle.Location = new System.Drawing.Point(130, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(190, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm môn thi";
            // 
            // lblTenMonThi
            // 
            this.lblTenMonThi.AutoSize = true;
            this.lblTenMonThi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTenMonThi.Location = new System.Drawing.Point(25, 75);
            this.lblTenMonThi.Name = "lblTenMonThi";
            this.lblTenMonThi.Size = new System.Drawing.Size(106, 21);
            this.lblTenMonThi.TabIndex = 1;
            this.lblTenMonThi.Text = "Tên môn thi:";
            // 
            // txtTenMonThi
            // 
            this.txtTenMonThi.BorderRadius = 8;
            this.txtTenMonThi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenMonThi.DefaultText = "";
            this.txtTenMonThi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenMonThi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenMonThi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenMonThi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenMonThi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenMonThi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTenMonThi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenMonThi.Location = new System.Drawing.Point(25, 100);
            this.txtTenMonThi.Name = "txtTenMonThi";
            this.txtTenMonThi.PlaceholderText = "Nhập tên môn thi...";
            this.txtTenMonThi.SelectedText = "";
            this.txtTenMonThi.Size = new System.Drawing.Size(400, 40);
            this.txtTenMonThi.TabIndex = 2;
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 8;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(99)))), ((int)(((byte)(222)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(115, 160);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 40);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 8;
            this.btnHuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuy.FillColor = System.Drawing.Color.Gray;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(235, 160);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmThemMonThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 220);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThemMonThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm môn thi";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenMonThi;
        private Guna.UI2.WinForms.Guna2TextBox txtTenMonThi;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}
