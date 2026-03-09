namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    partial class frmThemSuaKyThi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.chkTronDapAn = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkTronCauHoi = new Guna.UI2.WinForms.Guna2CheckBox();
            this.numTongDiem = new System.Windows.Forms.NumericUpDown();
            this.lblTongDiem = new System.Windows.Forms.Label();
            this.numThoiLuong = new System.Windows.Forms.NumericUpDown();
            this.lblThoiLuong = new System.Windows.Forms.Label();
            this.numPhut = new System.Windows.Forms.NumericUpDown();
            this.lblDauCham = new System.Windows.Forms.Label();
            this.cboGio = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblBatDau = new System.Windows.Forms.Label();
            this.cboLopHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblLopHoc = new System.Windows.Forms.Label();
            this.cboKhungDe = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblKhungDe = new System.Windows.Forms.Label();
            this.txtTenKyThi = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTenKyThi = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTongDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThoiLuong)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(45, 45, 68);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(520, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🎓 TẠO KỲ THI MỚI";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(37, 37, 56);
            this.panelContent.Controls.Add(this.chkTronDapAn);
            this.panelContent.Controls.Add(this.chkTronCauHoi);
            this.panelContent.Controls.Add(this.numTongDiem);
            this.panelContent.Controls.Add(this.lblTongDiem);
            this.panelContent.Controls.Add(this.numThoiLuong);
            this.panelContent.Controls.Add(this.lblThoiLuong);
            this.panelContent.Controls.Add(this.numPhut);
            this.panelContent.Controls.Add(this.lblDauCham);
            this.panelContent.Controls.Add(this.cboGio);
            this.panelContent.Controls.Add(this.dtpNgayBatDau);
            this.panelContent.Controls.Add(this.lblBatDau);
            this.panelContent.Controls.Add(this.cboLopHoc);
            this.panelContent.Controls.Add(this.lblLopHoc);
            this.panelContent.Controls.Add(this.cboKhungDe);
            this.panelContent.Controls.Add(this.lblKhungDe);
            this.panelContent.Controls.Add(this.txtTenKyThi);
            this.panelContent.Controls.Add(this.lblTenKyThi);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 50);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(520, 300);
            this.panelContent.TabIndex = 1;
            // 
            // lblTenKyThi
            // 
            this.lblTenKyThi.AutoSize = true;
            this.lblTenKyThi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenKyThi.ForeColor = System.Drawing.Color.White;
            this.lblTenKyThi.Location = new System.Drawing.Point(20, 25);
            this.lblTenKyThi.Name = "lblTenKyThi";
            this.lblTenKyThi.Size = new System.Drawing.Size(90, 19);
            this.lblTenKyThi.TabIndex = 0;
            this.lblTenKyThi.Text = "Tên kỳ thi: *";
            // 
            // txtTenKyThi
            // 
            this.txtTenKyThi.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtTenKyThi.BorderRadius = 5;
            this.txtTenKyThi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenKyThi.FillColor = System.Drawing.Color.FromArgb(50, 50, 76);
            this.txtTenKyThi.ForeColor = System.Drawing.Color.White;
            this.txtTenKyThi.Location = new System.Drawing.Point(140, 20);
            this.txtTenKyThi.Name = "txtTenKyThi";
            this.txtTenKyThi.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTenKyThi.PlaceholderText = "Nhập tên kỳ thi...";
            this.txtTenKyThi.SelectedText = "";
            this.txtTenKyThi.Size = new System.Drawing.Size(355, 31);
            this.txtTenKyThi.TabIndex = 1;
            // 
            // lblKhungDe
            // 
            this.lblKhungDe.AutoSize = true;
            this.lblKhungDe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKhungDe.ForeColor = System.Drawing.Color.White;
            this.lblKhungDe.Location = new System.Drawing.Point(20, 65);
            this.lblKhungDe.Name = "lblKhungDe";
            this.lblKhungDe.Size = new System.Drawing.Size(86, 19);
            this.lblKhungDe.TabIndex = 2;
            this.lblKhungDe.Text = "Khung đề: *";
            // 
            // cboKhungDe
            // 
            this.cboKhungDe.BackColor = System.Drawing.Color.Transparent;
            this.cboKhungDe.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.cboKhungDe.BorderRadius = 5;
            this.cboKhungDe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboKhungDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhungDe.FillColor = System.Drawing.Color.FromArgb(50, 50, 76);
            this.cboKhungDe.ForeColor = System.Drawing.Color.White;
            this.cboKhungDe.ItemHeight = 25;
            this.cboKhungDe.Location = new System.Drawing.Point(140, 60);
            this.cboKhungDe.Name = "cboKhungDe";
            this.cboKhungDe.Size = new System.Drawing.Size(355, 31);
            this.cboKhungDe.TabIndex = 3;
            // 
            // lblLopHoc
            // 
            this.lblLopHoc.AutoSize = true;
            this.lblLopHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLopHoc.ForeColor = System.Drawing.Color.White;
            this.lblLopHoc.Location = new System.Drawing.Point(20, 105);
            this.lblLopHoc.Name = "lblLopHoc";
            this.lblLopHoc.Size = new System.Drawing.Size(75, 19);
            this.lblLopHoc.TabIndex = 4;
            this.lblLopHoc.Text = "Lớp học: *";
            // 
            // cboLopHoc
            // 
            this.cboLopHoc.BackColor = System.Drawing.Color.Transparent;
            this.cboLopHoc.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.cboLopHoc.BorderRadius = 5;
            this.cboLopHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLopHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLopHoc.FillColor = System.Drawing.Color.FromArgb(50, 50, 76);
            this.cboLopHoc.ForeColor = System.Drawing.Color.White;
            this.cboLopHoc.ItemHeight = 25;
            this.cboLopHoc.Location = new System.Drawing.Point(140, 100);
            this.cboLopHoc.Name = "cboLopHoc";
            this.cboLopHoc.Size = new System.Drawing.Size(355, 31);
            this.cboLopHoc.TabIndex = 5;
            // 
            // lblBatDau
            // 
            this.lblBatDau.AutoSize = true;
            this.lblBatDau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBatDau.ForeColor = System.Drawing.Color.White;
            this.lblBatDau.Location = new System.Drawing.Point(20, 150);
            this.lblBatDau.Name = "lblBatDau";
            this.lblBatDau.Size = new System.Drawing.Size(58, 19);
            this.lblBatDau.TabIndex = 6;
            this.lblBatDau.Text = "Bắt đầu:";
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.CalendarForeColor = System.Drawing.Color.White;
            this.dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBatDau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(140, 145);
            this.dtpNgayBatDau.MinDate = new System.DateTime(2026, 1, 1);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(160, 25);
            this.dtpNgayBatDau.TabIndex = 7;
            // 
            // cboGio
            // 
            this.cboGio.BackColor = System.Drawing.Color.Transparent;
            this.cboGio.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.cboGio.BorderRadius = 5;
            this.cboGio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGio.FillColor = System.Drawing.Color.FromArgb(50, 50, 76);
            this.cboGio.ForeColor = System.Drawing.Color.White;
            this.cboGio.ItemHeight = 22;
            this.cboGio.Location = new System.Drawing.Point(315, 143);
            this.cboGio.Name = "cboGio";
            this.cboGio.Size = new System.Drawing.Size(68, 28);
            this.cboGio.TabIndex = 8;
            // 
            // lblDauCham
            // 
            this.lblDauCham.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDauCham.ForeColor = System.Drawing.Color.White;
            this.lblDauCham.Location = new System.Drawing.Point(385, 145);
            this.lblDauCham.Name = "lblDauCham";
            this.lblDauCham.Size = new System.Drawing.Size(16, 25);
            this.lblDauCham.TabIndex = 9;
            this.lblDauCham.Text = ":";
            this.lblDauCham.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numPhut
            // 
            ((System.ComponentModel.ISupportInitialize)(this.numPhut)).BeginInit();
            this.numPhut.BackColor = System.Drawing.Color.FromArgb(50, 50, 76);
            this.numPhut.ForeColor = System.Drawing.Color.White;
            this.numPhut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPhut.Location = new System.Drawing.Point(403, 143);
            this.numPhut.Name = "numPhut";
            this.numPhut.Size = new System.Drawing.Size(68, 28);
            this.numPhut.TabIndex = 10;
            this.numPhut.Minimum = 0;
            this.numPhut.Maximum = 59;
            this.numPhut.Value = 0;
            this.numPhut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            ((System.ComponentModel.ISupportInitialize)(this.numPhut)).EndInit();
            // 
            // lblThoiLuong
            // 
            this.lblThoiLuong.AutoSize = true;
            this.lblThoiLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThoiLuong.ForeColor = System.Drawing.Color.White;
            this.lblThoiLuong.Location = new System.Drawing.Point(20, 195);
            this.lblThoiLuong.Name = "lblThoiLuong";
            this.lblThoiLuong.Size = new System.Drawing.Size(115, 19);
            this.lblThoiLuong.TabIndex = 11;
            this.lblThoiLuong.Text = "Thời lượng (phút):";
            // 
            // numThoiLuong
            // 
            this.numThoiLuong.BackColor = System.Drawing.Color.FromArgb(50, 50, 76);
            this.numThoiLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numThoiLuong.ForeColor = System.Drawing.Color.White;
            this.numThoiLuong.Location = new System.Drawing.Point(140, 190);
            this.numThoiLuong.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            this.numThoiLuong.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numThoiLuong.Name = "numThoiLuong";
            this.numThoiLuong.Size = new System.Drawing.Size(100, 25);
            this.numThoiLuong.TabIndex = 12;
            this.numThoiLuong.Value = new decimal(new int[] { 45, 0, 0, 0 });
            // 
            // lblTongDiem
            // 
            this.lblTongDiem.AutoSize = true;
            this.lblTongDiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTongDiem.ForeColor = System.Drawing.Color.White;
            this.lblTongDiem.Location = new System.Drawing.Point(270, 195);
            this.lblTongDiem.Name = "lblTongDiem";
            this.lblTongDiem.Size = new System.Drawing.Size(77, 19);
            this.lblTongDiem.TabIndex = 13;
            this.lblTongDiem.Text = "Tổng điểm:";
            // 
            // numTongDiem
            // 
            this.numTongDiem.BackColor = System.Drawing.Color.FromArgb(50, 50, 76);
            this.numTongDiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numTongDiem.ForeColor = System.Drawing.Color.White;
            this.numTongDiem.Location = new System.Drawing.Point(355, 190);
            this.numTongDiem.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numTongDiem.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numTongDiem.Name = "numTongDiem";
            this.numTongDiem.Size = new System.Drawing.Size(100, 25);
            this.numTongDiem.TabIndex = 14;
            this.numTongDiem.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // chkTronCauHoi
            // 
            this.chkTronCauHoi.AutoSize = true;
            this.chkTronCauHoi.CheckedState.BorderColor = System.Drawing.Color.FromArgb(0, 192, 144);
            this.chkTronCauHoi.CheckedState.BorderRadius = 3;
            this.chkTronCauHoi.CheckedState.BorderThickness = 0;
            this.chkTronCauHoi.CheckedState.FillColor = System.Drawing.Color.FromArgb(0, 192, 144);
            this.chkTronCauHoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkTronCauHoi.ForeColor = System.Drawing.Color.White;
            this.chkTronCauHoi.Location = new System.Drawing.Point(140, 235);
            this.chkTronCauHoi.Name = "chkTronCauHoi";
            this.chkTronCauHoi.Size = new System.Drawing.Size(123, 23);
            this.chkTronCauHoi.TabIndex = 15;
            this.chkTronCauHoi.Text = "🔀 Trộn câu hỏi";
            this.chkTronCauHoi.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
            this.chkTronCauHoi.UncheckedState.BorderRadius = 3;
            this.chkTronCauHoi.UncheckedState.BorderThickness = 0;
            this.chkTronCauHoi.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
            // 
            // chkTronDapAn
            // 
            this.chkTronDapAn.AutoSize = true;
            this.chkTronDapAn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(0, 192, 144);
            this.chkTronDapAn.CheckedState.BorderRadius = 3;
            this.chkTronDapAn.CheckedState.BorderThickness = 0;
            this.chkTronDapAn.CheckedState.FillColor = System.Drawing.Color.FromArgb(0, 192, 144);
            this.chkTronDapAn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkTronDapAn.ForeColor = System.Drawing.Color.White;
            this.chkTronDapAn.Location = new System.Drawing.Point(290, 235);
            this.chkTronDapAn.Name = "chkTronDapAn";
            this.chkTronDapAn.Size = new System.Drawing.Size(116, 23);
            this.chkTronDapAn.TabIndex = 16;
            this.chkTronDapAn.Text = "🔀 Trộn đáp án";
            this.chkTronDapAn.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
            this.chkTronDapAn.UncheckedState.BorderRadius = 3;
            this.chkTronDapAn.UncheckedState.BorderThickness = 0;
            this.chkTronDapAn.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(37, 37, 56);
            this.panelButtons.Controls.Add(this.btnHuy);
            this.panelButtons.Controls.Add(this.btnLuu);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 350);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(520, 60);
            this.panelButtons.TabIndex = 2;
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 5;
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(0, 192, 144);
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(280, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(110, 36);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 5;
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(255, 82, 82);
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(400, 12);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 36);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmThemSuaKyThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(37, 37, 56);
            this.ClientSize = new System.Drawing.Size(520, 410);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemSuaKyThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo/Sửa kỳ thi";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTongDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThoiLuong)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblTenKyThi;
        private Guna.UI2.WinForms.Guna2TextBox txtTenKyThi;
        private System.Windows.Forms.Label lblKhungDe;
        private Guna.UI2.WinForms.Guna2ComboBox cboKhungDe;
        private System.Windows.Forms.Label lblLopHoc;
        private Guna.UI2.WinForms.Guna2ComboBox cboLopHoc;
        private System.Windows.Forms.Label lblBatDau;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private Guna.UI2.WinForms.Guna2ComboBox cboGio;
        private System.Windows.Forms.Label lblDauCham;
        private System.Windows.Forms.NumericUpDown numPhut;
        private System.Windows.Forms.Label lblThoiLuong;
        private System.Windows.Forms.NumericUpDown numThoiLuong;
        private System.Windows.Forms.Label lblTongDiem;
        private System.Windows.Forms.NumericUpDown numTongDiem;
        private Guna.UI2.WinForms.Guna2CheckBox chkTronCauHoi;
        private Guna.UI2.WinForms.Guna2CheckBox chkTronDapAn;
        private System.Windows.Forms.Panel panelButtons;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}
