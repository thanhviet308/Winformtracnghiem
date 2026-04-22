namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    partial class frmImportCauHoi
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
            this.lblTitle = new System.Windows.Forms.Label();
            // Guide panel
            this.panelGuide = new System.Windows.Forms.Panel();
            this.panelGuideContent = new System.Windows.Forms.Panel();
            this.lblGuideTitle = new System.Windows.Forms.Label();
            this.lblGuideFormat = new System.Windows.Forms.Label();
            this.panelFormatTable = new System.Windows.Forms.Panel();
            this.dgvFormat = new System.Windows.Forms.DataGridView();
            this.lblGuideNotes = new System.Windows.Forms.Label();
            this.panelGuideButtons = new System.Windows.Forms.Panel();
            this.btnTaiFileMau = new Guna.UI2.WinForms.Guna2Button();
            this.btnChonFile = new Guna.UI2.WinForms.Guna2Button();
            // Config panel
            this.panelConfig = new System.Windows.Forms.Panel();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.cboSheet = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSheet = new System.Windows.Forms.Label();
            this.cboMonHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.cboChuong = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblChuong = new System.Windows.Forms.Label();
            this.btnChonFileLai = new Guna.UI2.WinForms.Guna2Button();
            // Preview panel
            this.panelPreview = new System.Windows.Forms.Panel();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAnDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTongSo = new System.Windows.Forms.Label();
            // Bottom panel
            this.panelButtons = new System.Windows.Forms.Panel();
            this.progressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.btnImport = new Guna.UI2.WinForms.Guna2Button();

            this.panelHeader.SuspendLayout();
            this.panelGuide.SuspendLayout();
            this.panelGuideContent.SuspendLayout();
            this.panelGuideButtons.SuspendLayout();
            this.panelFormatTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormat)).BeginInit();
            this.panelConfig.SuspendLayout();
            this.panelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(850, 55);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "\ud83d\udce5 IMPORT C\u00c2U H\u1eceI T\u1eea EXCEL";
            // 
            // ===================== GUIDE PANEL =====================
            // 
            this.panelGuide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panelGuide.Controls.Add(this.panelGuideButtons);
            this.panelGuide.Controls.Add(this.panelGuideContent);
            this.panelGuide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGuide.Location = new System.Drawing.Point(0, 55);
            this.panelGuide.Name = "panelGuide";
            this.panelGuide.Padding = new System.Windows.Forms.Padding(25);
            this.panelGuide.Size = new System.Drawing.Size(850, 525);
            this.panelGuide.TabIndex = 10;
            // 
            // panelGuideContent
            // 
            this.panelGuideContent.BackColor = System.Drawing.Color.White;
            this.panelGuideContent.AutoScroll = true;
            this.panelGuideContent.Controls.Add(this.lblGuideNotes);
            this.panelGuideContent.Controls.Add(this.panelFormatTable);
            this.panelGuideContent.Controls.Add(this.lblGuideFormat);
            this.panelGuideContent.Controls.Add(this.lblGuideTitle);
            this.panelGuideContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGuideContent.Location = new System.Drawing.Point(25, 25);
            this.panelGuideContent.Name = "panelGuideContent";
            this.panelGuideContent.Padding = new System.Windows.Forms.Padding(25);
            this.panelGuideContent.Size = new System.Drawing.Size(800, 400);
            this.panelGuideContent.TabIndex = 0;
            // 
            // lblGuideTitle
            // 
            this.lblGuideTitle.AutoSize = true;
            this.lblGuideTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblGuideTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblGuideTitle.Location = new System.Drawing.Point(25, 20);
            this.lblGuideTitle.Name = "lblGuideTitle";
            this.lblGuideTitle.Size = new System.Drawing.Size(350, 25);
            this.lblGuideTitle.TabIndex = 0;
            this.lblGuideTitle.Text = "\ud83d\udcd6 H\u01af\u1edaNG D\u1eaaN IMPORT C\u00c2U H\u1eceI";
            // 
            // lblGuideFormat
            // 
            this.lblGuideFormat.AutoSize = false;
            this.lblGuideFormat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGuideFormat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblGuideFormat.Location = new System.Drawing.Point(25, 55);
            this.lblGuideFormat.Name = "lblGuideFormat";
            this.lblGuideFormat.Size = new System.Drawing.Size(750, 25);
            this.lblGuideFormat.TabIndex = 1;
            this.lblGuideFormat.Text = "File Excel c\u1ea7n c\u00f3 c\u00e1c c\u1ed9t theo \u0111\u00fang th\u1ee9 t\u1ef1 sau (d\u00f2ng 1 l\u00e0 ti\u00eau \u0111\u1ec1):";
            // 
            // panelFormatTable
            // 
            this.panelFormatTable.Controls.Add(this.dgvFormat);
            this.panelFormatTable.Location = new System.Drawing.Point(25, 85);
            this.panelFormatTable.Name = "panelFormatTable";
            this.panelFormatTable.Size = new System.Drawing.Size(750, 175);
            this.panelFormatTable.TabIndex = 2;
            // 
            // dgvFormat
            // 
            this.dgvFormat.AllowUserToAddRows = false;
            this.dgvFormat.AllowUserToDeleteRows = false;
            this.dgvFormat.AllowUserToResizeRows = false;
            this.dgvFormat.BackgroundColor = System.Drawing.Color.White;
            this.dgvFormat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvFormat.ColumnHeadersHeight = 35;
            this.dgvFormat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvFormat.EnableHeadersVisualStyles = false;
            this.dgvFormat.ReadOnly = true;
            this.dgvFormat.RowHeadersVisible = false;
            this.dgvFormat.RowTemplate.Height = 28;
            this.dgvFormat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFormat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvFormat.Name = "dgvFormat";
            this.dgvFormat.TabIndex = 0;
            // 
            // lblGuideNotes
            // 
            this.lblGuideNotes.AutoSize = true;
            this.lblGuideNotes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGuideNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblGuideNotes.Location = new System.Drawing.Point(25, 268);
            this.lblGuideNotes.MaximumSize = new System.Drawing.Size(750, 0);
            this.lblGuideNotes.Name = "lblGuideNotes";
            this.lblGuideNotes.TabIndex = 3;
            this.lblGuideNotes.Text = "\u26a0\ufe0f L\u01b0u \u00fd:\r\n\u2022  C\u1ed9t DAPANDUNG nh\u1eadp A, B, C ho\u1eb7c D (vi\u1ebft hoa) t\u01b0\u01a1ng \u1ee9ng v\u1edbi \u0111\u00e1p \u00e1n \u0111\u00fang.\r\n\u2022  Kh\u00f4ng \u0111\u01b0\u1ee3c \u0111\u1ec3 tr\u1ed1ng n\u1ed9i dung c\u00e2u h\u1ecfi.\r\n\u2022  M\u1ed7i c\u00e2u h\u1ecfi ph\u1ea3i c\u00f3 \u00edt nh\u1ea5t 2 \u0111\u00e1p \u00e1n.\r\n\u2022  D\u1eef li\u1ec7u b\u1eaft \u0111\u1ea7u t\u1eeb d\u00f2ng 2 (d\u00f2ng 1 l\u00e0 ti\u00eau \u0111\u1ec1, kh\u00f4ng x\u00f3a).";
            // 
            // panelGuideButtons
            // 
            this.panelGuideButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panelGuideButtons.Controls.Add(this.btnTaiFileMau);
            this.panelGuideButtons.Controls.Add(this.btnChonFile);
            this.panelGuideButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelGuideButtons.Location = new System.Drawing.Point(25, 440);
            this.panelGuideButtons.Name = "panelGuideButtons";
            this.panelGuideButtons.Size = new System.Drawing.Size(800, 60);
            this.panelGuideButtons.TabIndex = 1;
            // 
            // btnTaiFileMau
            // 
            this.btnTaiFileMau.BorderRadius = 8;
            this.btnTaiFileMau.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.btnTaiFileMau.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTaiFileMau.ForeColor = System.Drawing.Color.White;
            this.btnTaiFileMau.Location = new System.Drawing.Point(200, 10);
            this.btnTaiFileMau.Name = "btnTaiFileMau";
            this.btnTaiFileMau.Size = new System.Drawing.Size(180, 42);
            this.btnTaiFileMau.TabIndex = 0;
            this.btnTaiFileMau.Text = "\ud83d\udccb T\u1ea3i file m\u1eabu";
            this.btnTaiFileMau.Click += new System.EventHandler(this.btnTaiFileMau_Click);
            // 
            // btnChonFile
            // 
            this.btnChonFile.BorderRadius = 8;
            this.btnChonFile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnChonFile.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnChonFile.ForeColor = System.Drawing.Color.White;
            this.btnChonFile.Location = new System.Drawing.Point(400, 10);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(200, 42);
            this.btnChonFile.TabIndex = 1;
            this.btnChonFile.Text = "\ud83d\udcc2 Ch\u1ecdn file Excel...";
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // ===================== CONFIG PANEL =====================
            // 
            this.panelConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panelConfig.Controls.Add(this.btnChonFileLai);
            this.panelConfig.Controls.Add(this.lblFilePath);
            this.panelConfig.Controls.Add(this.cboSheet);
            this.panelConfig.Controls.Add(this.lblSheet);
            this.panelConfig.Controls.Add(this.cboMonHoc);
            this.panelConfig.Controls.Add(this.lblMonHoc);
            this.panelConfig.Controls.Add(this.cboChuong);
            this.panelConfig.Controls.Add(this.lblChuong);
            this.panelConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConfig.Location = new System.Drawing.Point(0, 55);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Padding = new System.Windows.Forms.Padding(15);
            this.panelConfig.Size = new System.Drawing.Size(850, 140);
            this.panelConfig.TabIndex = 1;
            this.panelConfig.Visible = false;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblFilePath.Location = new System.Drawing.Point(15, 15);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(0, 19);
            this.lblFilePath.TabIndex = 0;
            // 
            // btnChonFileLai
            // 
            this.btnChonFileLai.BorderRadius = 5;
            this.btnChonFileLai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnChonFileLai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChonFileLai.ForeColor = System.Drawing.Color.White;
            this.btnChonFileLai.Location = new System.Drawing.Point(700, 12);
            this.btnChonFileLai.Name = "btnChonFileLai";
            this.btnChonFileLai.Size = new System.Drawing.Size(155, 28);
            this.btnChonFileLai.TabIndex = 6;
            this.btnChonFileLai.Text = "\ud83d\udd04 \u0110\u1ed5i file kh\u00e1c";
            this.btnChonFileLai.Click += new System.EventHandler(this.btnChonFileLai_Click);
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMonHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblMonHoc.Location = new System.Drawing.Point(15, 55);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(66, 19);
            this.lblMonHoc.TabIndex = 1;
            this.lblMonHoc.Text = "M\u00f4n h\u1ecdc:";
            // 
            // cboMonHoc
            // 
            this.cboMonHoc.BackColor = System.Drawing.Color.Transparent;
            this.cboMonHoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMonHoc.BorderRadius = 5;
            this.cboMonHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.FillColor = System.Drawing.Color.White;
            this.cboMonHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cboMonHoc.ItemHeight = 25;
            this.cboMonHoc.Location = new System.Drawing.Point(90, 50);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(250, 31);
            this.cboMonHoc.TabIndex = 2;
            // 
            // lblSheet
            // 
            this.lblSheet.AutoSize = true;
            this.lblSheet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSheet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblSheet.Location = new System.Drawing.Point(370, 55);
            this.lblSheet.Name = "lblSheet";
            this.lblSheet.Size = new System.Drawing.Size(45, 19);
            this.lblSheet.TabIndex = 3;
            this.lblSheet.Text = "Sheet:";
            // 
            // cboSheet
            // 
            this.cboSheet.BackColor = System.Drawing.Color.Transparent;
            this.cboSheet.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSheet.BorderRadius = 5;
            this.cboSheet.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSheet.FillColor = System.Drawing.Color.White;
            this.cboSheet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cboSheet.ItemHeight = 25;
            this.cboSheet.Location = new System.Drawing.Point(430, 50);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(250, 31);
            this.cboSheet.TabIndex = 4;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);

            // 
            // lblChuong
            // 
            this.lblChuong.AutoSize = true;
            this.lblChuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblChuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblChuong.Location = new System.Drawing.Point(15, 90);
            this.lblChuong.Name = "lblChuong";
            this.lblChuong.Size = new System.Drawing.Size(60, 19);
            this.lblChuong.TabIndex = 5;
            this.lblChuong.Text = "Chương:";

            // 
            // cboChuong
            // 
            this.cboChuong.BackColor = System.Drawing.Color.Transparent;
            this.cboChuong.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboChuong.BorderRadius = 5;
            this.cboChuong.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboChuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboChuong.FillColor = System.Drawing.Color.White;
            this.cboChuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cboChuong.ItemHeight = 25;
            this.cboChuong.Location = new System.Drawing.Point(90, 85);
            this.cboChuong.Name = "cboChuong";
            this.cboChuong.Size = new System.Drawing.Size(590, 31);
            this.cboChuong.TabIndex = 6;
            // 
            // ===================== PREVIEW PANEL =====================
            // 
            this.panelPreview.BackColor = System.Drawing.Color.White;
            this.panelPreview.Controls.Add(this.dgvPreview);
            this.panelPreview.Controls.Add(this.lblTongSo);
            this.panelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPreview.Location = new System.Drawing.Point(0, 195);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Padding = new System.Windows.Forms.Padding(15);
            this.panelPreview.Size = new System.Drawing.Size(850, 305);
            this.panelPreview.TabIndex = 2;
            this.panelPreview.Visible = false;
            // 
            // lblTongSo
            // 
            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongSo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.lblTongSo.Location = new System.Drawing.Point(15, 10);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(100, 19);
            this.lblTongSo.TabIndex = 0;
            this.lblTongSo.Text = "T\u1ed5ng s\u1ed1: 0 c\u00e2u";
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.BackgroundColor = System.Drawing.Color.White;
            this.dgvPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPreview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPreview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPreview.ColumnHeadersHeight = 32;
            this.dgvPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colNoiDung,
            this.colDapAn1,
            this.colDapAn2,
            this.colDapAn3,
            this.colDapAn4,
            this.colDapAnDung});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPreview.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPreview.EnableHeadersVisualStyles = false;
            this.dgvPreview.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvPreview.Location = new System.Drawing.Point(15, 35);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.RowHeadersVisible = false;
            this.dgvPreview.RowTemplate.Height = 28;
            this.dgvPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreview.Size = new System.Drawing.Size(820, 295);
            this.dgvPreview.TabIndex = 1;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 45;
            // 
            // colNoiDung
            // 
            this.colNoiDung.HeaderText = "C\u00e2u h\u1ecfi";
            this.colNoiDung.Name = "colNoiDung";
            this.colNoiDung.ReadOnly = true;
            this.colNoiDung.Width = 220;
            // 
            // colDapAn1
            // 
            this.colDapAn1.HeaderText = "\u0110\u00e1p \u00e1n A";
            this.colDapAn1.Name = "colDapAn1";
            this.colDapAn1.ReadOnly = true;
            this.colDapAn1.Width = 110;
            // 
            // colDapAn2
            // 
            this.colDapAn2.HeaderText = "\u0110\u00e1p \u00e1n B";
            this.colDapAn2.Name = "colDapAn2";
            this.colDapAn2.ReadOnly = true;
            this.colDapAn2.Width = 110;
            // 
            // colDapAn3
            // 
            this.colDapAn3.HeaderText = "\u0110\u00e1p \u00e1n C";
            this.colDapAn3.Name = "colDapAn3";
            this.colDapAn3.ReadOnly = true;
            this.colDapAn3.Width = 110;
            // 
            // colDapAn4
            // 
            this.colDapAn4.HeaderText = "\u0110\u00e1p \u00e1n D";
            this.colDapAn4.Name = "colDapAn4";
            this.colDapAn4.ReadOnly = true;
            this.colDapAn4.Width = 110;
            // 
            // colDapAnDung
            // 
            this.colDapAnDung.HeaderText = "\u0110\u00e1p \u00e1n";
            this.colDapAnDung.Name = "colDapAnDung";
            this.colDapAnDung.ReadOnly = true;
            this.colDapAnDung.Width = 65;
            // 
            // ===================== BOTTOM BUTTONS =====================
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panelButtons.Controls.Add(this.progressBar);
            this.panelButtons.Controls.Add(this.btnHuy);
            this.panelButtons.Controls.Add(this.btnImport);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 510);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(15);
            this.panelButtons.Size = new System.Drawing.Size(850, 70);
            this.panelButtons.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.BorderRadius = 5;
            this.progressBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.progressBar.Location = new System.Drawing.Point(15, 20);
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.progressBar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.progressBar.Size = new System.Drawing.Size(560, 30);
            this.progressBar.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.BorderRadius = 8;
            this.btnImport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.btnImport.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(590, 17);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(150, 36);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "\u2705 Import";
            this.btnImport.Enabled = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 8;
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(720, 17);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 36);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "\u274c H\u1ee7y";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmImportCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(850, 580);
            this.Controls.Add(this.panelGuide);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelConfig);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportCauHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import c\u00e2u h\u1ecfi t\u1eeb Excel";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelGuide.ResumeLayout(false);
            this.panelGuideContent.ResumeLayout(false);
            this.panelGuideContent.PerformLayout();
            this.panelGuideButtons.ResumeLayout(false);
            this.panelFormatTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormat)).EndInit();
            this.panelConfig.ResumeLayout(false);
            this.panelConfig.PerformLayout();
            this.panelPreview.ResumeLayout(false);
            this.panelPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

            // Populate format guide table
            SetupFormatGuide();
        }

        private void SetupFormatGuide()
        {
            dgvFormat.Columns.Clear();
            dgvFormat.Columns.Add("colName", "T\u00ean c\u1ed9t");
            dgvFormat.Columns.Add("colDesc", "M\u00f4 t\u1ea3");
            dgvFormat.Columns.Add("colExample", "V\u00ed d\u1ee5");
            dgvFormat.Columns.Add("colRequired", "B\u1eaft bu\u1ed9c");

            dgvFormat.Columns["colName"].Width = 130;
            dgvFormat.Columns["colDesc"].Width = 220;
            dgvFormat.Columns["colExample"].Width = 250;
            dgvFormat.Columns["colRequired"].Width = 80;

            // Header style
            var headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.BackColor = System.Drawing.Color.FromArgb(94, 148, 255);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dgvFormat.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvFormat.EnableHeadersVisualStyles = false;

            // Row style
            var cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            cellStyle.BackColor = System.Drawing.Color.White;
            cellStyle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            cellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            cellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            cellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            dgvFormat.DefaultCellStyle = cellStyle;

            // Alternate row
            var altStyle = new System.Windows.Forms.DataGridViewCellStyle();
            altStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            altStyle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            altStyle.SelectionBackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            altStyle.SelectionForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            dgvFormat.AlternatingRowsDefaultCellStyle = altStyle;

            dgvFormat.Rows.Add("NDCAUHOI", "N\u1ed9i dung c\u00e2u h\u1ecfi", "Th\u1ee7 \u0111\u00f4 c\u1ee7a Vi\u1ec7t Nam l\u00e0 g\u00ec?", "\u2705 C\u00f3");
            dgvFormat.Rows.Add("DAPAN1", "\u0110\u00e1p \u00e1n A", "H\u00e0 N\u1ed9i", "\u2705 C\u00f3");
            dgvFormat.Rows.Add("DAPAN2", "\u0110\u00e1p \u00e1n B", "TP. H\u1ed3 Ch\u00ed Minh", "\u2705 C\u00f3");
            dgvFormat.Rows.Add("DAPAN3", "\u0110\u00e1p \u00e1n C", "\u0110\u00e0 N\u1eb5ng", "\u2705 C\u00f3");
            dgvFormat.Rows.Add("DAPAN4", "\u0110\u00e1p \u00e1n D", "Hu\u1ebf", "\u2705 C\u00f3");
            dgvFormat.Rows.Add("DAPANDUNG", "\u0110\u00e1p \u00e1n \u0111\u00fang (A/B/C/D)", "A", "\u2705 C\u00f3");
            dgvFormat.Rows.Add("CHUONG", "T\u00ean ch\u01b0\u01a1ng (t\u00f9y ch\u1ecdn)", "Ch\u01b0\u01a1ng 1", "\u274c Kh\u00f4ng");

            dgvFormat.ClearSelection();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        // Guide
        private System.Windows.Forms.Panel panelGuide;
        private System.Windows.Forms.Panel panelGuideContent;
        private System.Windows.Forms.Label lblGuideTitle;
        private System.Windows.Forms.Label lblGuideFormat;
        private System.Windows.Forms.Panel panelFormatTable;
        private System.Windows.Forms.DataGridView dgvFormat;
        private System.Windows.Forms.Label lblGuideNotes;
        private System.Windows.Forms.Panel panelGuideButtons;
        private Guna.UI2.WinForms.Guna2Button btnTaiFileMau;
        private Guna.UI2.WinForms.Guna2Button btnChonFile;
        // Config
        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.Label lblFilePath;
        private Guna.UI2.WinForms.Guna2Button btnChonFileLai;
        private System.Windows.Forms.Label lblMonHoc;
        private Guna.UI2.WinForms.Guna2ComboBox cboMonHoc;
        private System.Windows.Forms.Label lblSheet;
        private Guna.UI2.WinForms.Guna2ComboBox cboSheet;
        private System.Windows.Forms.Label lblChuong;
        private Guna.UI2.WinForms.Guna2ComboBox cboChuong;
        // Preview
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Label lblTongSo;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAnDung;
        // Bottom
        private System.Windows.Forms.Panel panelButtons;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar;
        private Guna.UI2.WinForms.Guna2Button btnImport;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}
