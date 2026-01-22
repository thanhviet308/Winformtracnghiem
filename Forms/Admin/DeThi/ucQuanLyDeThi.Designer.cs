namespace PhanMemThiTracNghiem.Forms.Admin.DeThi
{
    partial class ucQuanLyDeThi
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            
            // Môn Thi Section
            this.panelMonThi = new Guna.UI2.WinForms.Guna2Panel();
            this.panelMonThiHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMonThi = new System.Windows.Forms.Label();
            this.panelMonThiToolbar = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTimMonThi = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThemMonThi = new Guna.UI2.WinForms.Guna2Button();
            this.dgvMonThi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colMaMonThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMonThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSuaMonThi = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colXoaMonThi = new System.Windows.Forms.DataGridViewLinkColumn();
            
            // Đề Thi Section
            this.panelDeThi = new Guna.UI2.WinForms.Guna2Panel();
            this.panelDeThiHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDeThi = new System.Windows.Forms.Label();
            this.panelDeThiToolbar = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTimDeThi = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThemDeThi = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDeThi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colMaDeThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKyThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSuaDeThi = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colXoaDeThi = new System.Windows.Forms.DataGridViewLinkColumn();

            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelMonThi.SuspendLayout();
            this.panelMonThiHeader.SuspendLayout();
            this.panelMonThiToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonThi)).BeginInit();
            this.panelDeThi.SuspendLayout();
            this.panelDeThiHeader.SuspendLayout();
            this.panelDeThiToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeThi)).BeginInit();
            this.SuspendLayout();
            
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panelMain.Controls.Add(this.splitContainer);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1400, 750);
            this.panelMain.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(20, 20);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panelMonThi);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelDeThi);
            this.splitContainer.Size = new System.Drawing.Size(1360, 710);
            this.splitContainer.SplitterDistance = 340;
            this.splitContainer.TabIndex = 0;
            
            // ===================== MÔN THI SECTION =====================
            // 
            // panelMonThi
            // 
            this.panelMonThi.BackColor = System.Drawing.Color.White;
            this.panelMonThi.BorderRadius = 10;
            this.panelMonThi.Controls.Add(this.dgvMonThi);
            this.panelMonThi.Controls.Add(this.panelMonThiToolbar);
            this.panelMonThi.Controls.Add(this.panelMonThiHeader);
            this.panelMonThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMonThi.Location = new System.Drawing.Point(0, 0);
            this.panelMonThi.Name = "panelMonThi";
            this.panelMonThi.Padding = new System.Windows.Forms.Padding(15);
            this.panelMonThi.Size = new System.Drawing.Size(1360, 340);
            this.panelMonThi.TabIndex = 0;
            // 
            // panelMonThiHeader
            // 
            this.panelMonThiHeader.Controls.Add(this.lblMonThi);
            this.panelMonThiHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMonThiHeader.Location = new System.Drawing.Point(15, 15);
            this.panelMonThiHeader.Name = "panelMonThiHeader";
            this.panelMonThiHeader.Size = new System.Drawing.Size(1330, 40);
            this.panelMonThiHeader.TabIndex = 0;
            // 
            // lblMonThi
            // 
            this.lblMonThi.AutoSize = true;
            this.lblMonThi.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblMonThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblMonThi.Location = new System.Drawing.Point(0, 5);
            this.lblMonThi.Name = "lblMonThi";
            this.lblMonThi.Size = new System.Drawing.Size(180, 30);
            this.lblMonThi.TabIndex = 0;
            this.lblMonThi.Text = "Quản lý môn thi";
            // 
            // panelMonThiToolbar
            // 
            this.panelMonThiToolbar.Controls.Add(this.btnThemMonThi);
            this.panelMonThiToolbar.Controls.Add(this.txtTimMonThi);
            this.panelMonThiToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMonThiToolbar.Location = new System.Drawing.Point(15, 55);
            this.panelMonThiToolbar.Name = "panelMonThiToolbar";
            this.panelMonThiToolbar.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panelMonThiToolbar.Size = new System.Drawing.Size(1330, 55);
            this.panelMonThiToolbar.TabIndex = 1;
            // 
            // txtTimMonThi
            // 
            this.txtTimMonThi.BorderRadius = 8;
            this.txtTimMonThi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimMonThi.DefaultText = "";
            this.txtTimMonThi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimMonThi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimMonThi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimMonThi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimMonThi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtTimMonThi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimMonThi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtTimMonThi.Location = new System.Drawing.Point(0, 10);
            this.txtTimMonThi.Name = "txtTimMonThi";
            this.txtTimMonThi.PlaceholderText = "Tìm kiếm môn thi...";
            this.txtTimMonThi.SelectedText = "";
            this.txtTimMonThi.Size = new System.Drawing.Size(300, 36);
            this.txtTimMonThi.TabIndex = 0;
            this.txtTimMonThi.TextChanged += new System.EventHandler(this.txtTimMonThi_TextChanged);
            // 
            // btnThemMonThi
            // 
            this.btnThemMonThi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemMonThi.BorderRadius = 8;
            this.btnThemMonThi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemMonThi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemMonThi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemMonThi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemMonThi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnThemMonThi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThemMonThi.ForeColor = System.Drawing.Color.White;
            this.btnThemMonThi.Location = new System.Drawing.Point(1180, 7);
            this.btnThemMonThi.Name = "btnThemMonThi";
            this.btnThemMonThi.Size = new System.Drawing.Size(150, 40);
            this.btnThemMonThi.TabIndex = 1;
            this.btnThemMonThi.Text = "+ Thêm môn thi";
            this.btnThemMonThi.Click += new System.EventHandler(this.btnThemMonThi_Click);
            // 
            // dgvMonThi
            // 
            this.dgvMonThi.AllowUserToAddRows = false;
            this.dgvMonThi.AllowUserToDeleteRows = false;
            this.dgvMonThi.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvMonThi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMonThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonThi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMonThi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMonThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.dgvMonThi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMonThi.ColumnHeadersHeight = 45;
            this.dgvMonThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSuaMonThi,
            this.colXoaMonThi});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvMonThi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMonThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonThi.EnableHeadersVisualStyles = false;
            this.dgvMonThi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvMonThi.Location = new System.Drawing.Point(15, 110);
            this.dgvMonThi.Name = "dgvMonThi";
            this.dgvMonThi.ReadOnly = true;
            this.dgvMonThi.RowHeadersVisible = false;
            this.dgvMonThi.RowHeadersWidth = 51;
            this.dgvMonThi.RowTemplate.Height = 40;
            this.dgvMonThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonThi.Size = new System.Drawing.Size(1330, 215);
            this.dgvMonThi.TabIndex = 2;
            this.dgvMonThi.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvMonThi.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvMonThi.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvMonThi.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvMonThi.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.dgvMonThi.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.dgvMonThi.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMonThi.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvMonThi.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvMonThi.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dgvMonThi.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvMonThi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonThi_CellContentClick);
            // 
            // colSuaMonThi
            // 
            this.colSuaMonThi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSuaMonThi.HeaderText = "Thao tác";
            this.colSuaMonThi.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.colSuaMonThi.Name = "colSuaMonThi";
            this.colSuaMonThi.ReadOnly = true;
            this.colSuaMonThi.Text = "Sửa";
            this.colSuaMonThi.UseColumnTextForLinkValue = true;
            this.colSuaMonThi.Width = 60;
            // 
            // colXoaMonThi
            // 
            this.colXoaMonThi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colXoaMonThi.HeaderText = "";
            this.colXoaMonThi.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.colXoaMonThi.Name = "colXoaMonThi";
            this.colXoaMonThi.ReadOnly = true;
            this.colXoaMonThi.Text = "Xóa";
            this.colXoaMonThi.UseColumnTextForLinkValue = true;
            this.colXoaMonThi.Width = 60;

            // ===================== ĐỀ THI SECTION =====================
            // 
            // panelDeThi
            // 
            this.panelDeThi.BackColor = System.Drawing.Color.White;
            this.panelDeThi.BorderRadius = 10;
            this.panelDeThi.Controls.Add(this.dgvDeThi);
            this.panelDeThi.Controls.Add(this.panelDeThiToolbar);
            this.panelDeThi.Controls.Add(this.panelDeThiHeader);
            this.panelDeThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDeThi.Location = new System.Drawing.Point(0, 0);
            this.panelDeThi.Name = "panelDeThi";
            this.panelDeThi.Padding = new System.Windows.Forms.Padding(15);
            this.panelDeThi.Size = new System.Drawing.Size(1360, 366);
            this.panelDeThi.TabIndex = 0;
            // 
            // panelDeThiHeader
            // 
            this.panelDeThiHeader.Controls.Add(this.lblDeThi);
            this.panelDeThiHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDeThiHeader.Location = new System.Drawing.Point(15, 15);
            this.panelDeThiHeader.Name = "panelDeThiHeader";
            this.panelDeThiHeader.Size = new System.Drawing.Size(1330, 40);
            this.panelDeThiHeader.TabIndex = 0;
            // 
            // lblDeThi
            // 
            this.lblDeThi.AutoSize = true;
            this.lblDeThi.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDeThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblDeThi.Location = new System.Drawing.Point(0, 5);
            this.lblDeThi.Name = "lblDeThi";
            this.lblDeThi.Size = new System.Drawing.Size(170, 30);
            this.lblDeThi.TabIndex = 0;
            this.lblDeThi.Text = "Quản lý đề thi";
            // 
            // panelDeThiToolbar
            // 
            this.panelDeThiToolbar.Controls.Add(this.btnThemDeThi);
            this.panelDeThiToolbar.Controls.Add(this.txtTimDeThi);
            this.panelDeThiToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDeThiToolbar.Location = new System.Drawing.Point(15, 55);
            this.panelDeThiToolbar.Name = "panelDeThiToolbar";
            this.panelDeThiToolbar.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panelDeThiToolbar.Size = new System.Drawing.Size(1330, 55);
            this.panelDeThiToolbar.TabIndex = 1;
            // 
            // txtTimDeThi
            // 
            this.txtTimDeThi.BorderRadius = 8;
            this.txtTimDeThi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimDeThi.DefaultText = "";
            this.txtTimDeThi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimDeThi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimDeThi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimDeThi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimDeThi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtTimDeThi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimDeThi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtTimDeThi.Location = new System.Drawing.Point(0, 10);
            this.txtTimDeThi.Name = "txtTimDeThi";
            this.txtTimDeThi.PlaceholderText = "Tìm kiếm đề thi...";
            this.txtTimDeThi.SelectedText = "";
            this.txtTimDeThi.Size = new System.Drawing.Size(300, 36);
            this.txtTimDeThi.TabIndex = 0;
            this.txtTimDeThi.TextChanged += new System.EventHandler(this.txtTimDeThi_TextChanged);
            // 
            // btnThemDeThi
            // 
            this.btnThemDeThi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemDeThi.BorderRadius = 8;
            this.btnThemDeThi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemDeThi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemDeThi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemDeThi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemDeThi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnThemDeThi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThemDeThi.ForeColor = System.Drawing.Color.White;
            this.btnThemDeThi.Location = new System.Drawing.Point(1180, 7);
            this.btnThemDeThi.Name = "btnThemDeThi";
            this.btnThemDeThi.Size = new System.Drawing.Size(150, 40);
            this.btnThemDeThi.TabIndex = 1;
            this.btnThemDeThi.Text = "+ Thêm đề thi";
            this.btnThemDeThi.Click += new System.EventHandler(this.btnThemDeThi_Click);
            // 
            // dgvDeThi
            // 
            this.dgvDeThi.AllowUserToAddRows = false;
            this.dgvDeThi.AllowUserToDeleteRows = false;
            this.dgvDeThi.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvDeThi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDeThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeThi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeThi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDeThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.dgvDeThi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDeThi.ColumnHeadersHeight = 45;
            this.dgvDeThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSuaDeThi,
            this.colXoaDeThi});
            this.dgvDeThi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDeThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeThi.EnableHeadersVisualStyles = false;
            this.dgvDeThi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvDeThi.Location = new System.Drawing.Point(15, 110);
            this.dgvDeThi.Name = "dgvDeThi";
            this.dgvDeThi.ReadOnly = true;
            this.dgvDeThi.RowHeadersVisible = false;
            this.dgvDeThi.RowHeadersWidth = 51;
            this.dgvDeThi.RowTemplate.Height = 40;
            this.dgvDeThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeThi.Size = new System.Drawing.Size(1330, 241);
            this.dgvDeThi.TabIndex = 2;
            this.dgvDeThi.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvDeThi.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDeThi.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvDeThi.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvDeThi.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.dgvDeThi.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.dgvDeThi.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDeThi.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvDeThi.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvDeThi.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dgvDeThi.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvDeThi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeThi_CellContentClick);
            this.dgvDeThi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeThi_CellDoubleClick);
            // 
            // colSuaDeThi
            // 
            this.colSuaDeThi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSuaDeThi.HeaderText = "Thao tác";
            this.colSuaDeThi.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.colSuaDeThi.Name = "colSuaDeThi";
            this.colSuaDeThi.ReadOnly = true;
            this.colSuaDeThi.Text = "Sửa";
            this.colSuaDeThi.UseColumnTextForLinkValue = true;
            this.colSuaDeThi.Width = 60;
            // 
            // colXoaDeThi
            // 
            this.colXoaDeThi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colXoaDeThi.HeaderText = "";
            this.colXoaDeThi.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.colXoaDeThi.Name = "colXoaDeThi";
            this.colXoaDeThi.ReadOnly = true;
            this.colXoaDeThi.Text = "Xóa";
            this.colXoaDeThi.UseColumnTextForLinkValue = true;
            this.colXoaDeThi.Width = 60;
            // 
            // ucQuanLyDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "ucQuanLyDeThi";
            this.Size = new System.Drawing.Size(1400, 750);
            this.Load += new System.EventHandler(this.ucQuanLyDeThi_Load);
            this.panelMain.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelMonThi.ResumeLayout(false);
            this.panelMonThiHeader.ResumeLayout(false);
            this.panelMonThiHeader.PerformLayout();
            this.panelMonThiToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonThi)).EndInit();
            this.panelDeThi.ResumeLayout(false);
            this.panelDeThiHeader.ResumeLayout(false);
            this.panelDeThiHeader.PerformLayout();
            this.panelDeThiToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeThi)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainer;
        
        // Môn Thi
        private Guna.UI2.WinForms.Guna2Panel panelMonThi;
        private Guna.UI2.WinForms.Guna2Panel panelMonThiHeader;
        private System.Windows.Forms.Label lblMonThi;
        private Guna.UI2.WinForms.Guna2Panel panelMonThiToolbar;
        private Guna.UI2.WinForms.Guna2TextBox txtTimMonThi;
        private Guna.UI2.WinForms.Guna2Button btnThemMonThi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvMonThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMonThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMonThi;
        private System.Windows.Forms.DataGridViewLinkColumn colSuaMonThi;
        private System.Windows.Forms.DataGridViewLinkColumn colXoaMonThi;
        
        // Đề Thi
        private Guna.UI2.WinForms.Guna2Panel panelDeThi;
        private Guna.UI2.WinForms.Guna2Panel panelDeThiHeader;
        private System.Windows.Forms.Label lblDeThi;
        private Guna.UI2.WinForms.Guna2Panel panelDeThiToolbar;
        private Guna.UI2.WinForms.Guna2TextBox txtTimDeThi;
        private Guna.UI2.WinForms.Guna2Button btnThemDeThi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDeThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDeThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKyThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonThi;
        private System.Windows.Forms.DataGridViewLinkColumn colSuaDeThi;
        private System.Windows.Forms.DataGridViewLinkColumn colXoaDeThi;
    }
}
