namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    partial class ucQuanLyKyThi
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.cboTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.dgvKyThi = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKyThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhungDe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLopHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoiGianBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoiLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThongKe = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colSua = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colXoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelHeader.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyThi)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🎓 QUẢN LÝ KỲ THI";
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panelFilter.Controls.Add(this.lblTongSo);
            this.panelFilter.Controls.Add(this.btnThem);
            this.panelFilter.Controls.Add(this.txtTimKiem);
            this.panelFilter.Controls.Add(this.cboTrangThai);
            this.panelFilter.Controls.Add(this.lblTrangThai);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 50);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1100, 70);
            this.panelFilter.TabIndex = 1;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTrangThai.Location = new System.Drawing.Point(15, 25);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(72, 19);
            this.lblTrangThai.TabIndex = 0;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.cboTrangThai.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTrangThai.BorderRadius = 5;
            this.cboTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FillColor = System.Drawing.Color.White;
            this.cboTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cboTrangThai.ItemHeight = 25;
            this.cboTrangThai.Items.AddRange(new object[] {
            "-- Tất cả --",
            "⏳ Sắp diễn ra",
            "🔴 Đang diễn ra",
            "✅ Đã kết thúc"});
            this.cboTrangThai.Location = new System.Drawing.Point(95, 18);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(180, 31);
            this.cboTrangThai.TabIndex = 1;
            this.cboTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboTrangThai_SelectedIndexChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.BorderRadius = 5;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.FillColor = System.Drawing.Color.White;
            this.txtTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtTimKiem.Location = new System.Drawing.Point(290, 18);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.PlaceholderText = "🔍 Tìm kiếm kỳ thi...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(250, 31);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 5;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(970, 18);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 31);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "➕ Tạo kỳ thi";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lblTongSo
            // 
            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongSo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.lblTongSo.Location = new System.Drawing.Point(560, 24);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(100, 19);
            this.lblTongSo.TabIndex = 4;
            this.lblTongSo.Text = "Tổng số: 0 kỳ thi";
            // 
            // dgvKyThi
            // 
            this.dgvKyThi.AllowUserToAddRows = false;
            this.dgvKyThi.AllowUserToDeleteRows = false;
            this.dgvKyThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvKyThi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKyThi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKyThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.dgvKyThi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKyThi.ColumnHeadersHeight = 40;
            this.dgvKyThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colTenKyThi,
            this.colKhungDe,
            this.colLopHoc,
            this.colThoiGianBD,
            this.colThoiLuong,
            this.colTrangThai,
            this.colThongKe,
            this.colSua,
            this.colXoa});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvKyThi.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKyThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKyThi.EnableHeadersVisualStyles = false;
            this.dgvKyThi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvKyThi.Location = new System.Drawing.Point(0, 120);
            this.dgvKyThi.Name = "dgvKyThi";
            this.dgvKyThi.ReadOnly = true;
            this.dgvKyThi.RowHeadersVisible = false;
            this.dgvKyThi.RowTemplate.Height = 35;
            this.dgvKyThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKyThi.Size = new System.Drawing.Size(1100, 480);
            this.dgvKyThi.TabIndex = 2;
            this.dgvKyThi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKyThi_CellContentClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 50;
            // 
            // colTenKyThi
            // 
            this.colTenKyThi.HeaderText = "Tên kỳ thi";
            this.colTenKyThi.Name = "colTenKyThi";
            this.colTenKyThi.ReadOnly = true;
            this.colTenKyThi.Width = 200;
            // 
            // colKhungDe
            // 
            this.colKhungDe.HeaderText = "Khung đề";
            this.colKhungDe.Name = "colKhungDe";
            this.colKhungDe.ReadOnly = true;
            this.colKhungDe.Width = 150;
            // 
            // colLopHoc
            // 
            this.colLopHoc.HeaderText = "Lớp học";
            this.colLopHoc.Name = "colLopHoc";
            this.colLopHoc.ReadOnly = true;
            this.colLopHoc.Width = 120;
            // 
            // colThoiGianBD
            // 
            this.colThoiGianBD.HeaderText = "Thời gian bắt đầu";
            this.colThoiGianBD.Name = "colThoiGianBD";
            this.colThoiGianBD.ReadOnly = true;
            this.colThoiGianBD.Width = 140;
            // 
            // colThoiLuong
            // 
            this.colThoiLuong.HeaderText = "Thời lượng";
            this.colThoiLuong.Name = "colThoiLuong";
            this.colThoiLuong.ReadOnly = true;
            this.colThoiLuong.Width = 90;
            // 
            // colTrangThai
            // 
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            this.colTrangThai.Width = 100;
            // 
            // colThongKe
            // 
            this.colThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colThongKe.HeaderText = "";
            this.colThongKe.Name = "colThongKe";
            this.colThongKe.ReadOnly = true;
            this.colThongKe.Text = "📊";
            this.colThongKe.ToolTipText = "Xem thống kê";
            this.colThongKe.UseColumnTextForButtonValue = true;
            this.colThongKe.Width = 50;
            // 
            // colSua
            // 
            this.colSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colSua.HeaderText = "";
            this.colSua.Name = "colSua";
            this.colSua.ReadOnly = true;
            this.colSua.Text = "Sửa";
            this.colSua.UseColumnTextForButtonValue = true;
            this.colSua.Width = 60;
            // 
            // colXoa
            // 
            this.colXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colXoa.HeaderText = "";
            this.colXoa.Name = "colXoa";
            this.colXoa.ReadOnly = true;
            this.colXoa.Text = "Xóa";
            this.colXoa.UseColumnTextForButtonValue = true;
            this.colXoa.Width = 60;
            // 
            // ucQuanLyKyThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.dgvKyThi);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelHeader);
            this.Name = "ucQuanLyKyThi";
            this.Size = new System.Drawing.Size(1100, 600);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyThi)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblTrangThai;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private System.Windows.Forms.Label lblTongSo;
        private System.Windows.Forms.DataGridView dgvKyThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKyThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhungDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLopHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiGianBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewButtonColumn colThongKe;
        private System.Windows.Forms.DataGridViewButtonColumn colSua;
        private System.Windows.Forms.DataGridViewButtonColumn colXoa;
    }
}
