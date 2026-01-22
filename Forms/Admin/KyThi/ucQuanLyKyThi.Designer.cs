namespace PhanMemThiTracNghiem.Forms.Admin
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelContent = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvKyThi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelToolbar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyThi)).BeginInit();
            this.panelToolbar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1400, 750);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.BorderRadius = 10;
            this.panelContent.Controls.Add(this.dgvKyThi);
            this.panelContent.Controls.Add(this.panelToolbar);
            this.panelContent.Controls.Add(this.panelHeader);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(20, 20);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(15);
            this.panelContent.Size = new System.Drawing.Size(1360, 710);
            this.panelContent.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(15, 15);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1330, 45);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý kỳ thi";
            // 
            // panelToolbar
            // 
            this.panelToolbar.Controls.Add(this.btnThem);
            this.panelToolbar.Controls.Add(this.txtTimKiem);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(15, 60);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panelToolbar.Size = new System.Drawing.Size(1330, 55);
            this.panelToolbar.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderRadius = 8;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtTimKiem.Location = new System.Drawing.Point(0, 10);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Tìm kiếm kỳ thi...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 36);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BorderRadius = 8;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(1170, 7);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 40);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "+ Thêm kỳ thi";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvKyThi
            // 
            this.dgvKyThi.AllowUserToAddRows = false;
            this.dgvKyThi.AllowUserToDeleteRows = false;
            this.dgvKyThi.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvKyThi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKyThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKyThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvKyThi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKyThi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKyThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.dgvKyThi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKyThi.ColumnHeadersHeight = 45;
            this.dgvKyThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKyThi.EnableHeadersVisualStyles = false;
            this.dgvKyThi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvKyThi.Location = new System.Drawing.Point(15, 115);
            this.dgvKyThi.Name = "dgvKyThi";
            this.dgvKyThi.ReadOnly = true;
            this.dgvKyThi.RowHeadersVisible = false;
            this.dgvKyThi.RowHeadersWidth = 51;
            this.dgvKyThi.RowTemplate.Height = 45;
            this.dgvKyThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKyThi.Size = new System.Drawing.Size(1330, 580);
            this.dgvKyThi.TabIndex = 2;
            this.dgvKyThi.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvKyThi.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvKyThi.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvKyThi.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvKyThi.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.dgvKyThi.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.dgvKyThi.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKyThi.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvKyThi.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvKyThi.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dgvKyThi.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvKyThi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKyThi_CellContentClick);
            // 
            // ucQuanLyKyThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "ucQuanLyKyThi";
            this.Size = new System.Drawing.Size(1400, 750);
            this.Load += new System.EventHandler(this.ucQuanLyKyThi_Load);
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyThi)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private Guna.UI2.WinForms.Guna2Panel panelContent;
        private Guna.UI2.WinForms.Guna2Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel panelToolbar;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvKyThi;
    }
}
