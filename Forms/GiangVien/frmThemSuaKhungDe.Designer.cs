namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    partial class frmThemSuaKhungDe
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.lblSoCauHoiHienCo = new System.Windows.Forms.Label();
            this.numTongSoCau = new System.Windows.Forms.NumericUpDown();
            this.lblTongSoCau = new System.Windows.Forms.Label();
            this.txtTenDe = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTenDe = new System.Windows.Forms.Label();
            this.cboMonHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTongSoCau)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(500, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 THÊM KHUNG ĐỀ MỚI";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.panelContent.Controls.Add(this.lblSoCauHoiHienCo);
            this.panelContent.Controls.Add(this.numTongSoCau);
            this.panelContent.Controls.Add(this.lblTongSoCau);
            this.panelContent.Controls.Add(this.txtTenDe);
            this.panelContent.Controls.Add(this.lblTenDe);
            this.panelContent.Controls.Add(this.cboMonHoc);
            this.panelContent.Controls.Add(this.lblMonHoc);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 50);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(500, 230);
            this.panelContent.TabIndex = 1;
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMonHoc.ForeColor = System.Drawing.Color.White;
            this.lblMonHoc.Location = new System.Drawing.Point(20, 25);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(80, 19);
            this.lblMonHoc.TabIndex = 0;
            this.lblMonHoc.Text = "Môn học: *";
            // 
            // cboMonHoc
            // 
            this.cboMonHoc.BackColor = System.Drawing.Color.Transparent;
            this.cboMonHoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMonHoc.BorderRadius = 5;
            this.cboMonHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(76)))));
            this.cboMonHoc.ForeColor = System.Drawing.Color.White;
            this.cboMonHoc.ItemHeight = 25;
            this.cboMonHoc.Location = new System.Drawing.Point(140, 20);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(330, 31);
            this.cboMonHoc.TabIndex = 1;
            this.cboMonHoc.SelectedIndexChanged += new System.EventHandler(this.cboMonHoc_SelectedIndexChanged);
            // 
            // lblTenDe
            // 
            this.lblTenDe.AutoSize = true;
            this.lblTenDe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenDe.ForeColor = System.Drawing.Color.White;
            this.lblTenDe.Location = new System.Drawing.Point(20, 75);
            this.lblTenDe.Name = "lblTenDe";
            this.lblTenDe.Size = new System.Drawing.Size(107, 19);
            this.lblTenDe.TabIndex = 2;
            this.lblTenDe.Text = "Tên khung đề: *";
            // 
            // txtTenDe
            // 
            this.txtTenDe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenDe.BorderRadius = 5;
            this.txtTenDe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenDe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(76)))));
            this.txtTenDe.ForeColor = System.Drawing.Color.White;
            this.txtTenDe.Location = new System.Drawing.Point(140, 70);
            this.txtTenDe.Name = "txtTenDe";
            this.txtTenDe.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTenDe.PlaceholderText = "Nhập tên khung đề...";
            this.txtTenDe.SelectedText = "";
            this.txtTenDe.Size = new System.Drawing.Size(330, 31);
            this.txtTenDe.TabIndex = 3;
            // 
            // lblTongSoCau
            // 
            this.lblTongSoCau.AutoSize = true;
            this.lblTongSoCau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTongSoCau.ForeColor = System.Drawing.Color.White;
            this.lblTongSoCau.Location = new System.Drawing.Point(20, 125);
            this.lblTongSoCau.Name = "lblTongSoCau";
            this.lblTongSoCau.Size = new System.Drawing.Size(104, 19);
            this.lblTongSoCau.TabIndex = 4;
            this.lblTongSoCau.Text = "Số câu hỏi: *";
            // 
            // numTongSoCau
            // 
            this.numTongSoCau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(76)))));
            this.numTongSoCau.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numTongSoCau.ForeColor = System.Drawing.Color.White;
            this.numTongSoCau.Location = new System.Drawing.Point(140, 120);
            this.numTongSoCau.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numTongSoCau.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numTongSoCau.Name = "numTongSoCau";
            this.numTongSoCau.Size = new System.Drawing.Size(120, 27);
            this.numTongSoCau.TabIndex = 5;
            this.numTongSoCau.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblSoCauHoiHienCo
            // 
            this.lblSoCauHoiHienCo.AutoSize = true;
            this.lblSoCauHoiHienCo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSoCauHoiHienCo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.lblSoCauHoiHienCo.Location = new System.Drawing.Point(140, 155);
            this.lblSoCauHoiHienCo.Name = "lblSoCauHoiHienCo";
            this.lblSoCauHoiHienCo.Size = new System.Drawing.Size(200, 15);
            this.lblSoCauHoiHienCo.TabIndex = 6;
            this.lblSoCauHoiHienCo.Text = "Số câu hỏi hiện có trong ngân hàng: 0";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.panelButtons.Controls.Add(this.btnHuy);
            this.panelButtons.Controls.Add(this.btnLuu);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 280);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(500, 60);
            this.panelButtons.TabIndex = 2;
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 5;
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(260, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(110, 36);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 5;
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(380, 12);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 36);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmThemSuaKhungDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(500, 340);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemSuaKhungDe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm/Sửa khung đề";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTongSoCau)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblMonHoc;
        private Guna.UI2.WinForms.Guna2ComboBox cboMonHoc;
        private System.Windows.Forms.Label lblTenDe;
        private Guna.UI2.WinForms.Guna2TextBox txtTenDe;
        private System.Windows.Forms.Label lblTongSoCau;
        private System.Windows.Forms.NumericUpDown numTongSoCau;
        private System.Windows.Forms.Label lblSoCauHoiHienCo;
        private System.Windows.Forms.Panel panelButtons;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}
