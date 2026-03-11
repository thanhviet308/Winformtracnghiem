namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    partial class ucThongKeTongQuan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelCards = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCard1 = new System.Windows.Forms.Panel();
            this.lblSoCauHoi = new System.Windows.Forms.Label();
            this.lblCauHoiTitle = new System.Windows.Forms.Label();
            this.panelCard2 = new System.Windows.Forms.Panel();
            this.lblSoKhungDe = new System.Windows.Forms.Label();
            this.lblKhungDeTitle = new System.Windows.Forms.Label();
            this.panelCard3 = new System.Windows.Forms.Panel();
            this.lblSoKyThi = new System.Windows.Forms.Label();
            this.lblKyThiTitle = new System.Windows.Forms.Label();
            this.panelCard4 = new System.Windows.Forms.Panel();
            this.lblSoBaiThi = new System.Windows.Forms.Label();
            this.lblBaiThiTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.dgvThongKeCauHoi = new System.Windows.Forms.DataGridView();
            this.colMonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoCauHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblThongKeCauHoi = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvKyThiGanDay = new System.Windows.Forms.DataGridView();
            this.colTenKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThaiKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblKyThiGanDay = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelCards.SuspendLayout();
            this.panelCard1.SuspendLayout();
            this.panelCard2.SuspendLayout();
            this.panelCard3.SuspendLayout();
            this.panelCard4.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeCauHoi)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyThiGanDay)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.btnRefresh);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 THỐNG KÊ TỔNG QUAN";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(880, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelCards
            // 
            this.panelCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panelCards.Controls.Add(this.panelCard1);
            this.panelCards.Controls.Add(this.panelCard2);
            this.panelCards.Controls.Add(this.panelCard3);
            this.panelCards.Controls.Add(this.panelCard4);
            this.panelCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCards.Location = new System.Drawing.Point(0, 50);
            this.panelCards.Name = "panelCards";
            this.panelCards.Padding = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.panelCards.Size = new System.Drawing.Size(1000, 130);
            this.panelCards.TabIndex = 1;
            // 
            // panelCard1
            // 
            this.panelCard1.BackColor = System.Drawing.Color.White;
            this.panelCard1.Controls.Add(this.lblSoCauHoi);
            this.panelCard1.Controls.Add(this.lblCauHoiTitle);
            this.panelCard1.Location = new System.Drawing.Point(15, 18);
            this.panelCard1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panelCard1.Name = "panelCard1";
            this.panelCard1.Size = new System.Drawing.Size(230, 90);
            this.panelCard1.TabIndex = 0;
            // 
            // lblCauHoiTitle
            // 
            this.lblCauHoiTitle.AutoSize = true;
            this.lblCauHoiTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCauHoiTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblCauHoiTitle.Location = new System.Drawing.Point(15, 15);
            this.lblCauHoiTitle.Name = "lblCauHoiTitle";
            this.lblCauHoiTitle.Size = new System.Drawing.Size(100, 19);
            this.lblCauHoiTitle.TabIndex = 0;
            this.lblCauHoiTitle.Text = "❓ Câu hỏi đã tạo";
            // 
            // lblSoCauHoi
            // 
            this.lblSoCauHoi.AutoSize = true;
            this.lblSoCauHoi.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSoCauHoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblSoCauHoi.Location = new System.Drawing.Point(15, 40);
            this.lblSoCauHoi.Name = "lblSoCauHoi";
            this.lblSoCauHoi.Size = new System.Drawing.Size(45, 51);
            this.lblSoCauHoi.TabIndex = 1;
            this.lblSoCauHoi.Text = "0";
            // 
            // panelCard2
            // 
            this.panelCard2.BackColor = System.Drawing.Color.White;
            this.panelCard2.Controls.Add(this.lblSoKhungDe);
            this.panelCard2.Controls.Add(this.lblKhungDeTitle);
            this.panelCard2.Location = new System.Drawing.Point(255, 18);
            this.panelCard2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panelCard2.Name = "panelCard2";
            this.panelCard2.Size = new System.Drawing.Size(230, 90);
            this.panelCard2.TabIndex = 1;
            // 
            // lblKhungDeTitle
            // 
            this.lblKhungDeTitle.AutoSize = true;
            this.lblKhungDeTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKhungDeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblKhungDeTitle.Location = new System.Drawing.Point(15, 15);
            this.lblKhungDeTitle.Name = "lblKhungDeTitle";
            this.lblKhungDeTitle.Size = new System.Drawing.Size(110, 19);
            this.lblKhungDeTitle.TabIndex = 0;
            this.lblKhungDeTitle.Text = "📋 Khung đề thi";
            // 
            // lblSoKhungDe
            // 
            this.lblSoKhungDe.AutoSize = true;
            this.lblSoKhungDe.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSoKhungDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.lblSoKhungDe.Location = new System.Drawing.Point(15, 40);
            this.lblSoKhungDe.Name = "lblSoKhungDe";
            this.lblSoKhungDe.Size = new System.Drawing.Size(45, 51);
            this.lblSoKhungDe.TabIndex = 1;
            this.lblSoKhungDe.Text = "0";
            // 
            // panelCard3
            // 
            this.panelCard3.BackColor = System.Drawing.Color.White;
            this.panelCard3.Controls.Add(this.lblSoKyThi);
            this.panelCard3.Controls.Add(this.lblKyThiTitle);
            this.panelCard3.Location = new System.Drawing.Point(495, 18);
            this.panelCard3.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panelCard3.Name = "panelCard3";
            this.panelCard3.Size = new System.Drawing.Size(230, 90);
            this.panelCard3.TabIndex = 2;
            // 
            // lblKyThiTitle
            // 
            this.lblKyThiTitle.AutoSize = true;
            this.lblKyThiTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKyThiTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblKyThiTitle.Location = new System.Drawing.Point(15, 15);
            this.lblKyThiTitle.Name = "lblKyThiTitle";
            this.lblKyThiTitle.Size = new System.Drawing.Size(100, 19);
            this.lblKyThiTitle.TabIndex = 0;
            this.lblKyThiTitle.Text = "🎓 Kỳ thi đã tạo";
            // 
            // lblSoKyThi
            // 
            this.lblSoKyThi.AutoSize = true;
            this.lblSoKyThi.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSoKyThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.lblSoKyThi.Location = new System.Drawing.Point(15, 40);
            this.lblSoKyThi.Name = "lblSoKyThi";
            this.lblSoKyThi.Size = new System.Drawing.Size(45, 51);
            this.lblSoKyThi.TabIndex = 1;
            this.lblSoKyThi.Text = "0";
            // 
            // panelCard4
            // 
            this.panelCard4.BackColor = System.Drawing.Color.White;
            this.panelCard4.Controls.Add(this.lblSoBaiThi);
            this.panelCard4.Controls.Add(this.lblBaiThiTitle);
            this.panelCard4.Location = new System.Drawing.Point(735, 18);
            this.panelCard4.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panelCard4.Name = "panelCard4";
            this.panelCard4.Size = new System.Drawing.Size(230, 90);
            this.panelCard4.TabIndex = 3;
            // 
            // lblBaiThiTitle
            // 
            this.lblBaiThiTitle.AutoSize = true;
            this.lblBaiThiTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBaiThiTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblBaiThiTitle.Location = new System.Drawing.Point(15, 15);
            this.lblBaiThiTitle.Name = "lblBaiThiTitle";
            this.lblBaiThiTitle.Size = new System.Drawing.Size(120, 19);
            this.lblBaiThiTitle.TabIndex = 0;
            this.lblBaiThiTitle.Text = "📝 Bài thi đã chấm";
            // 
            // lblSoBaiThi
            // 
            this.lblSoBaiThi.AutoSize = true;
            this.lblSoBaiThi.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSoBaiThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.lblSoBaiThi.Location = new System.Drawing.Point(15, 40);
            this.lblSoBaiThi.Name = "lblSoBaiThi";
            this.lblSoBaiThi.Size = new System.Drawing.Size(45, 51);
            this.lblSoBaiThi.TabIndex = 1;
            this.lblSoBaiThi.Text = "0";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panelContent.Controls.Add(this.panelRight);
            this.panelContent.Controls.Add(this.panelLeft);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 180);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(15);
            this.panelContent.Size = new System.Drawing.Size(1000, 420);
            this.panelContent.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.dgvKyThiGanDay);
            this.panelLeft.Controls.Add(this.lblKyThiGanDay);
            this.panelLeft.Location = new System.Drawing.Point(15, 15);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(600, 390);
            this.panelLeft.TabIndex = 0;
            // 
            // lblKyThiGanDay
            // 
            this.lblKyThiGanDay.AutoSize = true;
            this.lblKyThiGanDay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblKyThiGanDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblKyThiGanDay.Location = new System.Drawing.Point(15, 15);
            this.lblKyThiGanDay.Name = "lblKyThiGanDay";
            this.lblKyThiGanDay.Size = new System.Drawing.Size(150, 21);
            this.lblKyThiGanDay.TabIndex = 0;
            this.lblKyThiGanDay.Text = "📅 Kỳ thi gần đây";
            // 
            // dgvKyThiGanDay
            // 
            this.dgvKyThiGanDay.AllowUserToAddRows = false;
            this.dgvKyThiGanDay.AllowUserToDeleteRows = false;
            this.dgvKyThiGanDay.BackgroundColor = System.Drawing.Color.White;
            this.dgvKyThiGanDay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKyThiGanDay.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKyThiGanDay.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.dgvKyThiGanDay.ColumnHeadersHeight = 35;
            this.dgvKyThiGanDay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenKT,
            this.colNgayThi,
            this.colSoLuong,
            this.colTrangThaiKT});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvKyThiGanDay.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKyThiGanDay.EnableHeadersVisualStyles = false;
            this.dgvKyThiGanDay.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvKyThiGanDay.Location = new System.Drawing.Point(15, 50);
            this.dgvKyThiGanDay.Name = "dgvKyThiGanDay";
            this.dgvKyThiGanDay.ReadOnly = true;
            this.dgvKyThiGanDay.RowHeadersVisible = false;
            this.dgvKyThiGanDay.RowTemplate.Height = 35;
            this.dgvKyThiGanDay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKyThiGanDay.Size = new System.Drawing.Size(570, 320);
            this.dgvKyThiGanDay.TabIndex = 1;
            // 
            // colTenKT
            // 
            this.colTenKT.HeaderText = "Tên kỳ thi";
            this.colTenKT.Name = "colTenKT";
            this.colTenKT.ReadOnly = true;
            this.colTenKT.Width = 220;
            // 
            // colNgayThi
            // 
            this.colNgayThi.HeaderText = "Ngày thi";
            this.colNgayThi.Name = "colNgayThi";
            this.colNgayThi.ReadOnly = true;
            this.colNgayThi.Width = 100;
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "Đã nộp";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            this.colSoLuong.Width = 100;
            // 
            // colTrangThaiKT
            // 
            this.colTrangThaiKT.HeaderText = "Trạng thái";
            this.colTrangThaiKT.Name = "colTrangThaiKT";
            this.colTrangThaiKT.ReadOnly = true;
            this.colTrangThaiKT.Width = 120;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.dgvThongKeCauHoi);
            this.panelRight.Controls.Add(this.lblThongKeCauHoi);
            this.panelRight.Location = new System.Drawing.Point(630, 15);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(350, 390);
            this.panelRight.TabIndex = 1;
            // 
            // lblThongKeCauHoi
            // 
            this.lblThongKeCauHoi.AutoSize = true;
            this.lblThongKeCauHoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblThongKeCauHoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblThongKeCauHoi.Location = new System.Drawing.Point(15, 15);
            this.lblThongKeCauHoi.Name = "lblThongKeCauHoi";
            this.lblThongKeCauHoi.Size = new System.Drawing.Size(170, 21);
            this.lblThongKeCauHoi.TabIndex = 0;
            this.lblThongKeCauHoi.Text = "📊 Câu hỏi theo môn";
            // 
            // dgvThongKeCauHoi
            // 
            this.dgvThongKeCauHoi.AllowUserToAddRows = false;
            this.dgvThongKeCauHoi.AllowUserToDeleteRows = false;
            this.dgvThongKeCauHoi.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKeCauHoi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThongKeCauHoi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongKeCauHoi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.dgvThongKeCauHoi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThongKeCauHoi.ColumnHeadersHeight = 35;
            this.dgvThongKeCauHoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMonHoc,
            this.colSoCauHoi});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvThongKeCauHoi.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvThongKeCauHoi.EnableHeadersVisualStyles = false;
            this.dgvThongKeCauHoi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvThongKeCauHoi.Location = new System.Drawing.Point(15, 50);
            this.dgvThongKeCauHoi.Name = "dgvThongKeCauHoi";
            this.dgvThongKeCauHoi.ReadOnly = true;
            this.dgvThongKeCauHoi.RowHeadersVisible = false;
            this.dgvThongKeCauHoi.RowTemplate.Height = 35;
            this.dgvThongKeCauHoi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKeCauHoi.Size = new System.Drawing.Size(320, 320);
            this.dgvThongKeCauHoi.TabIndex = 1;
            // 
            // colMonHoc
            // 
            this.colMonHoc.HeaderText = "Môn học";
            this.colMonHoc.Name = "colMonHoc";
            this.colMonHoc.ReadOnly = true;
            this.colMonHoc.Width = 200;
            // 
            // colSoCauHoi
            // 
            this.colSoCauHoi.HeaderText = "Số câu";
            this.colSoCauHoi.Name = "colSoCauHoi";
            this.colSoCauHoi.ReadOnly = true;
            this.colSoCauHoi.Width = 100;
            // 
            // ucThongKeTongQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelCards);
            this.Controls.Add(this.panelHeader);
            this.Name = "ucThongKeTongQuan";
            this.Size = new System.Drawing.Size(1000, 600);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelCards.ResumeLayout(false);
            this.panelCard1.ResumeLayout(false);
            this.panelCard1.PerformLayout();
            this.panelCard2.ResumeLayout(false);
            this.panelCard2.PerformLayout();
            this.panelCard3.ResumeLayout(false);
            this.panelCard3.PerformLayout();
            this.panelCard4.ResumeLayout(false);
            this.panelCard4.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeCauHoi)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyThiGanDay)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel panelCards;
        private System.Windows.Forms.Panel panelCard1;
        private System.Windows.Forms.Label lblCauHoiTitle;
        private System.Windows.Forms.Label lblSoCauHoi;
        private System.Windows.Forms.Panel panelCard2;
        private System.Windows.Forms.Label lblKhungDeTitle;
        private System.Windows.Forms.Label lblSoKhungDe;
        private System.Windows.Forms.Panel panelCard3;
        private System.Windows.Forms.Label lblKyThiTitle;
        private System.Windows.Forms.Label lblSoKyThi;
        private System.Windows.Forms.Panel panelCard4;
        private System.Windows.Forms.Label lblBaiThiTitle;
        private System.Windows.Forms.Label lblSoBaiThi;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblKyThiGanDay;
        private System.Windows.Forms.DataGridView dgvKyThiGanDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThaiKT;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblThongKeCauHoi;
        private System.Windows.Forms.DataGridView dgvThongKeCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoCauHoi;
    }
}
