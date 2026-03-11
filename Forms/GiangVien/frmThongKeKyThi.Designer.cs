namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    partial class frmThongKeKyThi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.lblTenKyThi = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelDiem = new System.Windows.Forms.Panel();
            this.lblDiemThapNhat = new System.Windows.Forms.Label();
            this.lblDiemThapNhatTitle = new System.Windows.Forms.Label();
            this.lblDiemCaoNhat = new System.Windows.Forms.Label();
            this.lblDiemCaoNhatTitle = new System.Windows.Forms.Label();
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.lblDiemTBTitle = new System.Windows.Forms.Label();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.lblPhanTramDaThi = new System.Windows.Forms.Label();
            this.progressDaThi = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.panelSoLieu = new System.Windows.Forms.Panel();
            this.lblChuaThi = new System.Windows.Forms.Label();
            this.lblChuaThiTitle = new System.Windows.Forms.Label();
            this.lblDaThi = new System.Windows.Forms.Label();
            this.lblDaThiTitle = new System.Windows.Forms.Label();
            this.lblTongSoSV = new System.Windows.Forms.Label();
            this.lblTongSoTitle = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMSSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNopBai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.btnXuatExcel = new Guna.UI2.WinForms.Guna2Button();
            this.panelHeader.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelDiem.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.panelSoLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.panelHeader.Controls.Add(this.lblThoiGian);
            this.panelHeader.Controls.Add(this.lblTenKyThi);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 THỐNG KÊ KỲ THI";
            // 
            // lblTenKyThi
            // 
            this.lblTenKyThi.AutoSize = true;
            this.lblTenKyThi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenKyThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblTenKyThi.Location = new System.Drawing.Point(15, 40);
            this.lblTenKyThi.Name = "lblTenKyThi";
            this.lblTenKyThi.Size = new System.Drawing.Size(100, 21);
            this.lblTenKyThi.TabIndex = 1;
            this.lblTenKyThi.Text = "Tên kỳ thi";
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThoiGian.ForeColor = System.Drawing.Color.LightGray;
            this.lblThoiGian.Location = new System.Drawing.Point(700, 15);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(60, 15);
            this.lblThoiGian.TabIndex = 2;
            this.lblThoiGian.Text = "Thời gian";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.panelStats.Controls.Add(this.panelDiem);
            this.panelStats.Controls.Add(this.panelProgress);
            this.panelStats.Controls.Add(this.panelSoLieu);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 80);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(900, 120);
            this.panelStats.TabIndex = 1;
            // 
            // panelSoLieu
            // 
            this.panelSoLieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(76)))));
            this.panelSoLieu.Controls.Add(this.lblChuaThi);
            this.panelSoLieu.Controls.Add(this.lblChuaThiTitle);
            this.panelSoLieu.Controls.Add(this.lblDaThi);
            this.panelSoLieu.Controls.Add(this.lblDaThiTitle);
            this.panelSoLieu.Controls.Add(this.lblTongSoSV);
            this.panelSoLieu.Controls.Add(this.lblTongSoTitle);
            this.panelSoLieu.Location = new System.Drawing.Point(15, 15);
            this.panelSoLieu.Name = "panelSoLieu";
            this.panelSoLieu.Size = new System.Drawing.Size(280, 90);
            this.panelSoLieu.TabIndex = 0;
            // 
            // lblTongSoTitle
            // 
            this.lblTongSoTitle.AutoSize = true;
            this.lblTongSoTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTongSoTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblTongSoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTongSoTitle.Name = "lblTongSoTitle";
            this.lblTongSoTitle.Size = new System.Drawing.Size(75, 15);
            this.lblTongSoTitle.TabIndex = 0;
            this.lblTongSoTitle.Text = "Tổng số sinh viên";
            // 
            // lblTongSoSV
            // 
            this.lblTongSoSV.AutoSize = true;
            this.lblTongSoSV.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongSoSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblTongSoSV.Location = new System.Drawing.Point(15, 35);
            this.lblTongSoSV.Name = "lblTongSoSV";
            this.lblTongSoSV.Size = new System.Drawing.Size(32, 37);
            this.lblTongSoSV.TabIndex = 1;
            this.lblTongSoSV.Text = "0";
            // 
            // lblDaThiTitle
            // 
            this.lblDaThiTitle.AutoSize = true;
            this.lblDaThiTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDaThiTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblDaThiTitle.Location = new System.Drawing.Point(110, 15);
            this.lblDaThiTitle.Name = "lblDaThiTitle";
            this.lblDaThiTitle.Size = new System.Drawing.Size(40, 15);
            this.lblDaThiTitle.TabIndex = 2;
            this.lblDaThiTitle.Text = "Đã thi";
            // 
            // lblDaThi
            // 
            this.lblDaThi.AutoSize = true;
            this.lblDaThi.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDaThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.lblDaThi.Location = new System.Drawing.Point(110, 35);
            this.lblDaThi.Name = "lblDaThi";
            this.lblDaThi.Size = new System.Drawing.Size(32, 37);
            this.lblDaThi.TabIndex = 3;
            this.lblDaThi.Text = "0";
            // 
            // lblChuaThiTitle
            // 
            this.lblChuaThiTitle.AutoSize = true;
            this.lblChuaThiTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChuaThiTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblChuaThiTitle.Location = new System.Drawing.Point(200, 15);
            this.lblChuaThiTitle.Name = "lblChuaThiTitle";
            this.lblChuaThiTitle.Size = new System.Drawing.Size(52, 15);
            this.lblChuaThiTitle.TabIndex = 4;
            this.lblChuaThiTitle.Text = "Chưa thi";
            // 
            // lblChuaThi
            // 
            this.lblChuaThi.AutoSize = true;
            this.lblChuaThi.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblChuaThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.lblChuaThi.Location = new System.Drawing.Point(200, 35);
            this.lblChuaThi.Name = "lblChuaThi";
            this.lblChuaThi.Size = new System.Drawing.Size(32, 37);
            this.lblChuaThi.TabIndex = 5;
            this.lblChuaThi.Text = "0";
            // 
            // panelProgress
            // 
            this.panelProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(76)))));
            this.panelProgress.Controls.Add(this.lblPhanTramDaThi);
            this.panelProgress.Controls.Add(this.progressDaThi);
            this.panelProgress.Location = new System.Drawing.Point(310, 15);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(280, 90);
            this.panelProgress.TabIndex = 1;
            // 
            // progressDaThi
            // 
            this.progressDaThi.BorderRadius = 10;
            this.progressDaThi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.progressDaThi.Location = new System.Drawing.Point(15, 50);
            this.progressDaThi.Name = "progressDaThi";
            this.progressDaThi.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.progressDaThi.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.progressDaThi.Size = new System.Drawing.Size(250, 25);
            this.progressDaThi.TabIndex = 0;
            // 
            // lblPhanTramDaThi
            // 
            this.lblPhanTramDaThi.AutoSize = true;
            this.lblPhanTramDaThi.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPhanTramDaThi.ForeColor = System.Drawing.Color.White;
            this.lblPhanTramDaThi.Location = new System.Drawing.Point(15, 15);
            this.lblPhanTramDaThi.Name = "lblPhanTramDaThi";
            this.lblPhanTramDaThi.Size = new System.Drawing.Size(100, 25);
            this.lblPhanTramDaThi.TabIndex = 1;
            this.lblPhanTramDaThi.Text = "0% đã thi";
            // 
            // panelDiem
            // 
            this.panelDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(76)))));
            this.panelDiem.Controls.Add(this.lblDiemThapNhat);
            this.panelDiem.Controls.Add(this.lblDiemThapNhatTitle);
            this.panelDiem.Controls.Add(this.lblDiemCaoNhat);
            this.panelDiem.Controls.Add(this.lblDiemCaoNhatTitle);
            this.panelDiem.Controls.Add(this.lblDiemTB);
            this.panelDiem.Controls.Add(this.lblDiemTBTitle);
            this.panelDiem.Location = new System.Drawing.Point(605, 15);
            this.panelDiem.Name = "panelDiem";
            this.panelDiem.Size = new System.Drawing.Size(280, 90);
            this.panelDiem.TabIndex = 2;
            // 
            // lblDiemTBTitle
            // 
            this.lblDiemTBTitle.AutoSize = true;
            this.lblDiemTBTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiemTBTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblDiemTBTitle.Location = new System.Drawing.Point(15, 15);
            this.lblDiemTBTitle.Name = "lblDiemTBTitle";
            this.lblDiemTBTitle.Size = new System.Drawing.Size(55, 15);
            this.lblDiemTBTitle.TabIndex = 0;
            this.lblDiemTBTitle.Text = "Điểm TB";
            // 
            // lblDiemTB
            // 
            this.lblDiemTB.AutoSize = true;
            this.lblDiemTB.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDiemTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblDiemTB.Location = new System.Drawing.Point(15, 35);
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(52, 30);
            this.lblDiemTB.TabIndex = 1;
            this.lblDiemTB.Text = "0.00";
            // 
            // lblDiemCaoNhatTitle
            // 
            this.lblDiemCaoNhatTitle.AutoSize = true;
            this.lblDiemCaoNhatTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiemCaoNhatTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblDiemCaoNhatTitle.Location = new System.Drawing.Point(105, 15);
            this.lblDiemCaoNhatTitle.Name = "lblDiemCaoNhatTitle";
            this.lblDiemCaoNhatTitle.Size = new System.Drawing.Size(55, 15);
            this.lblDiemCaoNhatTitle.TabIndex = 2;
            this.lblDiemCaoNhatTitle.Text = "Cao nhất";
            // 
            // lblDiemCaoNhat
            // 
            this.lblDiemCaoNhat.AutoSize = true;
            this.lblDiemCaoNhat.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDiemCaoNhat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.lblDiemCaoNhat.Location = new System.Drawing.Point(105, 35);
            this.lblDiemCaoNhat.Name = "lblDiemCaoNhat";
            this.lblDiemCaoNhat.Size = new System.Drawing.Size(52, 30);
            this.lblDiemCaoNhat.TabIndex = 3;
            this.lblDiemCaoNhat.Text = "0.00";
            // 
            // lblDiemThapNhatTitle
            // 
            this.lblDiemThapNhatTitle.AutoSize = true;
            this.lblDiemThapNhatTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiemThapNhatTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblDiemThapNhatTitle.Location = new System.Drawing.Point(195, 15);
            this.lblDiemThapNhatTitle.Name = "lblDiemThapNhatTitle";
            this.lblDiemThapNhatTitle.Size = new System.Drawing.Size(61, 15);
            this.lblDiemThapNhatTitle.TabIndex = 4;
            this.lblDiemThapNhatTitle.Text = "Thấp nhất";
            // 
            // lblDiemThapNhat
            // 
            this.lblDiemThapNhat.AutoSize = true;
            this.lblDiemThapNhat.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDiemThapNhat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.lblDiemThapNhat.Location = new System.Drawing.Point(195, 35);
            this.lblDiemThapNhat.Name = "lblDiemThapNhat";
            this.lblDiemThapNhat.Size = new System.Drawing.Size(52, 30);
            this.lblDiemThapNhat.TabIndex = 5;
            this.lblDiemThapNhat.Text = "0.00";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTiet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTiet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTiet.ColumnHeadersHeight = 35;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMSSV,
            this.colTenSV,
            this.colBatDau,
            this.colNopBai,
            this.colDiem,
            this.colTrangThai});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.EnableHeadersVisualStyles = false;
            this.dgvChiTiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(82)))));
            this.dgvChiTiet.Location = new System.Drawing.Point(0, 200);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowTemplate.Height = 30;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(900, 350);
            this.dgvChiTiet.TabIndex = 2;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 50;
            // 
            // colMSSV
            // 
            this.colMSSV.HeaderText = "MSSV";
            this.colMSSV.Name = "colMSSV";
            this.colMSSV.ReadOnly = true;
            this.colMSSV.Width = 100;
            // 
            // colTenSV
            // 
            this.colTenSV.HeaderText = "Họ tên";
            this.colTenSV.Name = "colTenSV";
            this.colTenSV.ReadOnly = true;
            this.colTenSV.Width = 200;
            // 
            // colBatDau
            // 
            this.colBatDau.HeaderText = "Bắt đầu";
            this.colBatDau.Name = "colBatDau";
            this.colBatDau.ReadOnly = true;
            this.colBatDau.Width = 100;
            // 
            // colNopBai
            // 
            this.colNopBai.HeaderText = "Nộp bài";
            this.colNopBai.Name = "colNopBai";
            this.colNopBai.ReadOnly = true;
            this.colNopBai.Width = 100;
            // 
            // colDiem
            // 
            this.colDiem.HeaderText = "Điểm";
            this.colDiem.Name = "colDiem";
            this.colDiem.ReadOnly = true;
            this.colDiem.Width = 80;
            // 
            // colTrangThai
            // 
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            this.colTrangThai.Width = 120;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.panelButtons.Controls.Add(this.btnDong);
            this.panelButtons.Controls.Add(this.btnXuatExcel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 550);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(900, 60);
            this.panelButtons.TabIndex = 3;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BorderRadius = 5;
            this.btnXuatExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(650, 12);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(160, 36);
            this.btnXuatExcel.TabIndex = 0;
            this.btnXuatExcel.Text = "📊 Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnDong
            // 
            this.btnDong.BorderRadius = 5;
            this.btnDong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(780, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 36);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmThongKeKyThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(900, 610);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongKeKyThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thống kê kỳ thi";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.panelDiem.ResumeLayout(false);
            this.panelDiem.PerformLayout();
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            this.panelSoLieu.ResumeLayout(false);
            this.panelSoLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenKyThi;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelSoLieu;
        private System.Windows.Forms.Label lblTongSoTitle;
        private System.Windows.Forms.Label lblTongSoSV;
        private System.Windows.Forms.Label lblDaThiTitle;
        private System.Windows.Forms.Label lblDaThi;
        private System.Windows.Forms.Label lblChuaThiTitle;
        private System.Windows.Forms.Label lblChuaThi;
        private System.Windows.Forms.Panel panelProgress;
        private Guna.UI2.WinForms.Guna2ProgressBar progressDaThi;
        private System.Windows.Forms.Label lblPhanTramDaThi;
        private System.Windows.Forms.Panel panelDiem;
        private System.Windows.Forms.Label lblDiemTBTitle;
        private System.Windows.Forms.Label lblDiemTB;
        private System.Windows.Forms.Label lblDiemCaoNhatTitle;
        private System.Windows.Forms.Label lblDiemCaoNhat;
        private System.Windows.Forms.Label lblDiemThapNhatTitle;
        private System.Windows.Forms.Label lblDiemThapNhat;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNopBai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.Panel panelButtons;
        private Guna.UI2.WinForms.Guna2Button btnXuatExcel;
        private Guna.UI2.WinForms.Guna2Button btnDong;
    }
}
