namespace PhanMemThiTracNghiem.Forms.Admin.DeThi
{
    partial class frmThemDeThi
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
            this.lblKyThi = new System.Windows.Forms.Label();
            this.cbKyThi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblMonThi = new System.Windows.Forms.Label();
            this.cbMonThi = new Guna.UI2.WinForms.Guna2ComboBox();
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
            this.panelMain.Controls.Add(this.cbMonThi);
            this.panelMain.Controls.Add(this.lblMonThi);
            this.panelMain.Controls.Add(this.cbKyThi);
            this.panelMain.Controls.Add(this.lblKyThi);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(480, 300);
            this.panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(99)))), ((int)(((byte)(222)))));
            this.lblTitle.Location = new System.Drawing.Point(150, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm đề thi";
            // 
            // lblKyThi
            // 
            this.lblKyThi.AutoSize = true;
            this.lblKyThi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKyThi.Location = new System.Drawing.Point(25, 75);
            this.lblKyThi.Name = "lblKyThi";
            this.lblKyThi.Size = new System.Drawing.Size(62, 21);
            this.lblKyThi.TabIndex = 1;
            this.lblKyThi.Text = "Kỳ thi:";
            // 
            // cbKyThi
            // 
            this.cbKyThi.BackColor = System.Drawing.Color.Transparent;
            this.cbKyThi.BorderRadius = 8;
            this.cbKyThi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbKyThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKyThi.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbKyThi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbKyThi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbKyThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbKyThi.ItemHeight = 30;
            this.cbKyThi.Location = new System.Drawing.Point(25, 100);
            this.cbKyThi.Name = "cbKyThi";
            this.cbKyThi.Size = new System.Drawing.Size(430, 36);
            this.cbKyThi.TabIndex = 2;
            // 
            // lblMonThi
            // 
            this.lblMonThi.AutoSize = true;
            this.lblMonThi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblMonThi.Location = new System.Drawing.Point(25, 150);
            this.lblMonThi.Name = "lblMonThi";
            this.lblMonThi.Size = new System.Drawing.Size(79, 21);
            this.lblMonThi.TabIndex = 3;
            this.lblMonThi.Text = "Môn thi:";
            // 
            // cbMonThi
            // 
            this.cbMonThi.BackColor = System.Drawing.Color.Transparent;
            this.cbMonThi.BorderRadius = 8;
            this.cbMonThi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMonThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonThi.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMonThi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMonThi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbMonThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbMonThi.ItemHeight = 30;
            this.cbMonThi.Location = new System.Drawing.Point(25, 175);
            this.cbMonThi.Name = "cbMonThi";
            this.cbMonThi.Size = new System.Drawing.Size(430, 36);
            this.cbMonThi.TabIndex = 4;
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
            this.btnThem.Location = new System.Drawing.Point(130, 235);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 40);
            this.btnThem.TabIndex = 5;
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
            this.btnHuy.Location = new System.Drawing.Point(250, 235);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmThemDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 300);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThemDeThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm đề thi";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblKyThi;
        private Guna.UI2.WinForms.Guna2ComboBox cbKyThi;
        private System.Windows.Forms.Label lblMonThi;
        private Guna.UI2.WinForms.Guna2ComboBox cbMonThi;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}
