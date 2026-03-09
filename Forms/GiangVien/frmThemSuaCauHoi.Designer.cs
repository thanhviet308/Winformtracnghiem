namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    partial class frmThemSuaCauHoi
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
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.cboMonHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.txtNoiDung = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDapAnA = new System.Windows.Forms.Label();
            this.txtDapAnA = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkDapAnA = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lblDapAnB = new System.Windows.Forms.Label();
            this.txtDapAnB = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkDapAnB = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lblDapAnC = new System.Windows.Forms.Label();
            this.txtDapAnC = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkDapAnC = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lblDapAnD = new System.Windows.Forms.Label();
            this.txtDapAnD = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkDapAnD = new Guna.UI2.WinForms.Guna2CheckBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
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
            this.panelHeader.Size = new System.Drawing.Size(600, 50);
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
            this.lblTitle.Text = "📝 THÊM CÂU HỎI MỚI";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.panelContent.Controls.Add(this.chkDapAnD);
            this.panelContent.Controls.Add(this.txtDapAnD);
            this.panelContent.Controls.Add(this.lblDapAnD);
            this.panelContent.Controls.Add(this.chkDapAnC);
            this.panelContent.Controls.Add(this.txtDapAnC);
            this.panelContent.Controls.Add(this.lblDapAnC);
            this.panelContent.Controls.Add(this.chkDapAnB);
            this.panelContent.Controls.Add(this.txtDapAnB);
            this.panelContent.Controls.Add(this.lblDapAnB);
            this.panelContent.Controls.Add(this.chkDapAnA);
            this.panelContent.Controls.Add(this.txtDapAnA);
            this.panelContent.Controls.Add(this.lblDapAnA);
            this.panelContent.Controls.Add(this.txtNoiDung);
            this.panelContent.Controls.Add(this.lblNoiDung);
            this.panelContent.Controls.Add(this.cboMonHoc);
            this.panelContent.Controls.Add(this.lblMonHoc);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 50);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(600, 450);
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
            this.cboMonHoc.Location = new System.Drawing.Point(120, 20);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(450, 31);
            this.cboMonHoc.TabIndex = 1;
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNoiDung.ForeColor = System.Drawing.Color.White;
            this.lblNoiDung.Location = new System.Drawing.Point(20, 65);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(128, 19);
            this.lblNoiDung.TabIndex = 2;
            this.lblNoiDung.Text = "Nội dung câu hỏi: *";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoiDung.BorderRadius = 5;
            this.txtNoiDung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNoiDung.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(76)))));
            this.txtNoiDung.ForeColor = System.Drawing.Color.White;
            this.txtNoiDung.Location = new System.Drawing.Point(20, 90);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtNoiDung.PlaceholderText = "Nhập nội dung câu hỏi...";
            this.txtNoiDung.SelectedText = "";
            this.txtNoiDung.Size = new System.Drawing.Size(550, 80);
            this.txtNoiDung.TabIndex = 3;
            // 
            // lblDapAnA
            // 
            this.lblDapAnA.AutoSize = true;
            this.lblDapAnA.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDapAnA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.lblDapAnA.Location = new System.Drawing.Point(20, 185);
            this.lblDapAnA.Name = "lblDapAnA";
            this.lblDapAnA.Size = new System.Drawing.Size(70, 19);
            this.lblDapAnA.TabIndex = 4;
            this.lblDapAnA.Text = "Đáp án A:";
            // 
            // txtDapAnA
            // 
            this.txtDapAnA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDapAnA.BorderRadius = 5;
            this.txtDapAnA.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDapAnA.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(76)))));
            this.txtDapAnA.ForeColor = System.Drawing.Color.White;
            this.txtDapAnA.Location = new System.Drawing.Point(100, 180);
            this.txtDapAnA.Name = "txtDapAnA";
            this.txtDapAnA.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtDapAnA.PlaceholderText = "Nhập đáp án A...";
            this.txtDapAnA.SelectedText = "";
            this.txtDapAnA.Size = new System.Drawing.Size(420, 31);
            this.txtDapAnA.TabIndex = 5;
            // 
            // chkDapAnA
            // 
            this.chkDapAnA.AutoSize = true;
            this.chkDapAnA.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.chkDapAnA.CheckedState.BorderRadius = 3;
            this.chkDapAnA.CheckedState.BorderThickness = 0;
            this.chkDapAnA.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.chkDapAnA.ForeColor = System.Drawing.Color.White;
            this.chkDapAnA.Location = new System.Drawing.Point(530, 185);
            this.chkDapAnA.Name = "chkDapAnA";
            this.chkDapAnA.Size = new System.Drawing.Size(55, 19);
            this.chkDapAnA.TabIndex = 6;
            this.chkDapAnA.Text = "Đúng";
            this.chkDapAnA.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDapAnA.UncheckedState.BorderRadius = 3;
            this.chkDapAnA.UncheckedState.BorderThickness = 0;
            this.chkDapAnA.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // lblDapAnB
            // 
            this.lblDapAnB.AutoSize = true;
            this.lblDapAnB.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDapAnB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblDapAnB.Location = new System.Drawing.Point(20, 230);
            this.lblDapAnB.Name = "lblDapAnB";
            this.lblDapAnB.Size = new System.Drawing.Size(70, 19);
            this.lblDapAnB.TabIndex = 7;
            this.lblDapAnB.Text = "Đáp án B:";
            // 
            // txtDapAnB
            // 
            this.txtDapAnB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDapAnB.BorderRadius = 5;
            this.txtDapAnB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDapAnB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(76)))));
            this.txtDapAnB.ForeColor = System.Drawing.Color.White;
            this.txtDapAnB.Location = new System.Drawing.Point(100, 225);
            this.txtDapAnB.Name = "txtDapAnB";
            this.txtDapAnB.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtDapAnB.PlaceholderText = "Nhập đáp án B...";
            this.txtDapAnB.SelectedText = "";
            this.txtDapAnB.Size = new System.Drawing.Size(420, 31);
            this.txtDapAnB.TabIndex = 8;
            // 
            // chkDapAnB
            // 
            this.chkDapAnB.AutoSize = true;
            this.chkDapAnB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.chkDapAnB.CheckedState.BorderRadius = 3;
            this.chkDapAnB.CheckedState.BorderThickness = 0;
            this.chkDapAnB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.chkDapAnB.ForeColor = System.Drawing.Color.White;
            this.chkDapAnB.Location = new System.Drawing.Point(530, 230);
            this.chkDapAnB.Name = "chkDapAnB";
            this.chkDapAnB.Size = new System.Drawing.Size(55, 19);
            this.chkDapAnB.TabIndex = 9;
            this.chkDapAnB.Text = "Đúng";
            this.chkDapAnB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDapAnB.UncheckedState.BorderRadius = 3;
            this.chkDapAnB.UncheckedState.BorderThickness = 0;
            this.chkDapAnB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // lblDapAnC
            // 
            this.lblDapAnC.AutoSize = true;
            this.lblDapAnC.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDapAnC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblDapAnC.Location = new System.Drawing.Point(20, 275);
            this.lblDapAnC.Name = "lblDapAnC";
            this.lblDapAnC.Size = new System.Drawing.Size(69, 19);
            this.lblDapAnC.TabIndex = 10;
            this.lblDapAnC.Text = "Đáp án C:";
            // 
            // txtDapAnC
            // 
            this.txtDapAnC.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDapAnC.BorderRadius = 5;
            this.txtDapAnC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDapAnC.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(76)))));
            this.txtDapAnC.ForeColor = System.Drawing.Color.White;
            this.txtDapAnC.Location = new System.Drawing.Point(100, 270);
            this.txtDapAnC.Name = "txtDapAnC";
            this.txtDapAnC.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtDapAnC.PlaceholderText = "Nhập đáp án C...";
            this.txtDapAnC.SelectedText = "";
            this.txtDapAnC.Size = new System.Drawing.Size(420, 31);
            this.txtDapAnC.TabIndex = 11;
            // 
            // chkDapAnC
            // 
            this.chkDapAnC.AutoSize = true;
            this.chkDapAnC.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.chkDapAnC.CheckedState.BorderRadius = 3;
            this.chkDapAnC.CheckedState.BorderThickness = 0;
            this.chkDapAnC.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.chkDapAnC.ForeColor = System.Drawing.Color.White;
            this.chkDapAnC.Location = new System.Drawing.Point(530, 275);
            this.chkDapAnC.Name = "chkDapAnC";
            this.chkDapAnC.Size = new System.Drawing.Size(55, 19);
            this.chkDapAnC.TabIndex = 12;
            this.chkDapAnC.Text = "Đúng";
            this.chkDapAnC.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDapAnC.UncheckedState.BorderRadius = 3;
            this.chkDapAnC.UncheckedState.BorderThickness = 0;
            this.chkDapAnC.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // lblDapAnD
            // 
            this.lblDapAnD.AutoSize = true;
            this.lblDapAnD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDapAnD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.lblDapAnD.Location = new System.Drawing.Point(20, 320);
            this.lblDapAnD.Name = "lblDapAnD";
            this.lblDapAnD.Size = new System.Drawing.Size(71, 19);
            this.lblDapAnD.TabIndex = 13;
            this.lblDapAnD.Text = "Đáp án D:";
            // 
            // txtDapAnD
            // 
            this.txtDapAnD.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDapAnD.BorderRadius = 5;
            this.txtDapAnD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDapAnD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(76)))));
            this.txtDapAnD.ForeColor = System.Drawing.Color.White;
            this.txtDapAnD.Location = new System.Drawing.Point(100, 315);
            this.txtDapAnD.Name = "txtDapAnD";
            this.txtDapAnD.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtDapAnD.PlaceholderText = "Nhập đáp án D...";
            this.txtDapAnD.SelectedText = "";
            this.txtDapAnD.Size = new System.Drawing.Size(420, 31);
            this.txtDapAnD.TabIndex = 14;
            // 
            // chkDapAnD
            // 
            this.chkDapAnD.AutoSize = true;
            this.chkDapAnD.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.chkDapAnD.CheckedState.BorderRadius = 3;
            this.chkDapAnD.CheckedState.BorderThickness = 0;
            this.chkDapAnD.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.chkDapAnD.ForeColor = System.Drawing.Color.White;
            this.chkDapAnD.Location = new System.Drawing.Point(530, 320);
            this.chkDapAnD.Name = "chkDapAnD";
            this.chkDapAnD.Size = new System.Drawing.Size(55, 19);
            this.chkDapAnD.TabIndex = 15;
            this.chkDapAnD.Text = "Đúng";
            this.chkDapAnD.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDapAnD.UncheckedState.BorderRadius = 3;
            this.chkDapAnD.UncheckedState.BorderThickness = 0;
            this.chkDapAnD.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.panelButtons.Controls.Add(this.btnHuy);
            this.panelButtons.Controls.Add(this.btnLuu);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(20);
            this.panelButtons.Size = new System.Drawing.Size(600, 60);
            this.panelButtons.TabIndex = 2;
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 5;
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(350, 12);
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
            this.btnHuy.Location = new System.Drawing.Point(470, 12);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 36);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmThemSuaCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(600, 560);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemSuaCauHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm/Sửa câu hỏi";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblMonHoc;
        private Guna.UI2.WinForms.Guna2ComboBox cboMonHoc;
        private System.Windows.Forms.Label lblNoiDung;
        private Guna.UI2.WinForms.Guna2TextBox txtNoiDung;
        private System.Windows.Forms.Label lblDapAnA;
        private Guna.UI2.WinForms.Guna2TextBox txtDapAnA;
        private Guna.UI2.WinForms.Guna2CheckBox chkDapAnA;
        private System.Windows.Forms.Label lblDapAnB;
        private Guna.UI2.WinForms.Guna2TextBox txtDapAnB;
        private Guna.UI2.WinForms.Guna2CheckBox chkDapAnB;
        private System.Windows.Forms.Label lblDapAnC;
        private Guna.UI2.WinForms.Guna2TextBox txtDapAnC;
        private Guna.UI2.WinForms.Guna2CheckBox chkDapAnC;
        private System.Windows.Forms.Label lblDapAnD;
        private Guna.UI2.WinForms.Guna2TextBox txtDapAnD;
        private Guna.UI2.WinForms.Guna2CheckBox chkDapAnD;
        private System.Windows.Forms.Panel panelButtons;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}
