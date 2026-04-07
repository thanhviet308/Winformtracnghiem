namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    partial class ucViPhamSinhVien
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

        private void InitializeComponent()
        {
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.cboKyThi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvViPham = new Guna.UI2.WinForms.Guna2DataGridView();

            this.panelTitle.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViPham)).BeginInit();
            this.SuspendLayout();

            // ===== panelTitle =====
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.lblThongKe);
            this.panelTitle.Controls.Add(this.lblTongSo);
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1200, 60);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitle.Location = new System.Drawing.Point(15, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "⚠ VI PHẠM SINH VIÊN";

            // lblTongSo
            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTongSo.ForeColor = System.Drawing.Color.Gray;
            this.lblTongSo.Location = new System.Drawing.Point(350, 10);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Text = "Tổng số: 0 sinh viên vi phạm";

            // lblThongKe
            this.lblThongKe.AutoSize = true;
            this.lblThongKe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblThongKe.ForeColor = System.Drawing.Color.FromArgb(255, 82, 82);
            this.lblThongKe.Location = new System.Drawing.Point(15, 35);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Text = "";

            // ===== panelFilter =====
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.Controls.Add(this.cboKyThi);
            this.panelFilter.Controls.Add(this.txtTimKiem);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 60);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1200, 70);
            this.panelFilter.Padding = new System.Windows.Forms.Padding(10);

            // cboKyThi
            this.cboKyThi.BackColor = System.Drawing.Color.Transparent;
            this.cboKyThi.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
            this.cboKyThi.BorderRadius = 5;
            this.cboKyThi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboKyThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKyThi.FocusedColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.cboKyThi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboKyThi.ForeColor = System.Drawing.Color.FromArgb(68, 88, 112);
            this.cboKyThi.ItemHeight = 30;
            this.cboKyThi.Location = new System.Drawing.Point(15, 15);
            this.cboKyThi.Name = "cboKyThi";
            this.cboKyThi.Size = new System.Drawing.Size(350, 36);
            this.cboKyThi.SelectedIndexChanged += new System.EventHandler(this.cboKyThi_SelectedIndexChanged);

            // txtTimKiem
            this.txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
            this.txtTimKiem.BorderRadius = 5;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.FromArgb(68, 88, 112);
            this.txtTimKiem.Location = new System.Drawing.Point(380, 15);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "🔍 Tìm theo tên SV, email, kỳ thi...";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 36);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            // ===== dgvViPham =====
            this.dgvViPham.AllowUserToAddRows = false;
            this.dgvViPham.AllowUserToDeleteRows = false;
            this.dgvViPham.AllowUserToResizeRows = false;
            this.dgvViPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvViPham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvViPham.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvViPham.ReadOnly = true;
            this.dgvViPham.RowHeadersVisible = false;
            this.dgvViPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViPham.RowTemplate.Height = 40;
            this.dgvViPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvViPham.Name = "dgvViPham";

            // Column Header Style
            var headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.BackColor = System.Drawing.Color.FromArgb(255, 82, 82);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViPham.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvViPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvViPham.ColumnHeadersHeight = 55;
            this.dgvViPham.EnableHeadersVisualStyles = false;

            // Cell Style
            var cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            cellStyle.BackColor = System.Drawing.Color.White;
            cellStyle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            cellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            cellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 235, 235);
            cellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            cellStyle.Padding = new System.Windows.Forms.Padding(5);
            this.dgvViPham.DefaultCellStyle = cellStyle;

            // Alternating Row Style
            var altStyle = new System.Windows.Forms.DataGridViewCellStyle();
            altStyle.BackColor = System.Drawing.Color.FromArgb(255, 248, 248);
            this.dgvViPham.AlternatingRowsDefaultCellStyle = altStyle;

            // Columns
            this.dgvViPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colSTT", HeaderText = "STT", MinimumWidth = 50, FillWeight = 30 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colHoTen", HeaderText = "Họ tên SV", MinimumWidth = 160, FillWeight = 130 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colEmail", HeaderText = "Email", MinimumWidth = 170, FillWeight = 140 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colKyThi", HeaderText = "Kỳ thi", MinimumWidth = 100, FillWeight = 100 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colLopHoc", HeaderText = "Lớp", MinimumWidth = 80, FillWeight = 80 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colChuyenTab", HeaderText = "Chuyển tab", MinimumWidth = 110, FillWeight = 90 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colCopy", HeaderText = "Copy", MinimumWidth = 70, FillWeight = 55 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colPaste", HeaderText = "Paste", MinimumWidth = 70, FillWeight = 55 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colTongViPham", HeaderText = "Tổng", MinimumWidth = 70, FillWeight = 55 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colLanCuoi", HeaderText = "Lần cuối", MinimumWidth = 150, FillWeight = 130 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colMucDo", HeaderText = "Mức độ", MinimumWidth = 120, FillWeight = 100 }
            });

            // ===== ucViPhamSinhVien =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvViPham);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTitle);
            this.Name = "ucViPhamSinhVien";
            this.Size = new System.Drawing.Size(1200, 700);

            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViPham)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTongSo;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Panel panelFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cboKyThi;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvViPham;
    }
}
