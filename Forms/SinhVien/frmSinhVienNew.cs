using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PhanMemThiTracNghiem.Forms.GiangVien;

namespace PhanMemThiTracNghiem.Forms.SinhVien
{
    public class frmSinhVienNew : Form
    {
        private NguoiDung _nguoiDung;

        // Panels
        private Panel panelMenu;
        private Panel panelContent;
        private Panel panelHeader;
        private Label lblWelcome;
        private Label lblLogo;
        private Label lblPageTitle;

        // Menu Buttons
        private Guna.UI2.WinForms.Guna2Button btnDanhSachKyThi;
        private Guna.UI2.WinForms.Guna2Button btnLichSuThi;
        private Guna.UI2.WinForms.Guna2Button btnHoSo;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;

        public frmSinhVienNew(NguoiDung nguoiDung)
        {
            _nguoiDung = nguoiDung;
            InitializeComponents();
            ThemeHelper.ApplyVietnameseFont(this);

            lblWelcome.Text = _nguoiDung.HoTen;

            // Mặc định hiển thị danh sách kỳ thi
            ShowDanhSachKyThi();
        }

        // Constructor cho trường hợp sau khi thi xong quay lại
        public frmSinhVienNew(NguoiDung nguoiDung, int i) : this(nguoiDung)
        {
        }

        private void InitializeComponents()
        {
            this.SuspendLayout();

            // Form settings
            this.Text = "Phần mềm thi trắc nghiệm - Sinh viên";
            this.Size = new Size(1400, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(37, 37, 56);
            this.FormBorderStyle = FormBorderStyle.None;

            // ===== HEADER =====
            panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(45, 45, 68)
            };

            // Panel điều khiển (Close, Minimize, Maximize)
            Panel pnlControl = new Panel
            {
                Dock = DockStyle.Right,
                Width = 135,
                BackColor = Color.Transparent
            };
            pnlControl.Padding = new Padding(0);

            // Lưu ý: Với DockStyle.Right, control Add SAU sẽ nằm ngoài cùng bên phải.
            var btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox
            {
                Size = new Size(45, 45),
                Dock = DockStyle.Right,
                Margin = new Padding(0),
                ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox,
                FillColor = Color.Transparent,
                IconColor = Color.White,
                HoverState = { FillColor = Color.FromArgb(60, 60, 90) }
            };
            pnlControl.Controls.Add(btnMinimize);

            var btnMaximize = new Guna.UI2.WinForms.Guna2ControlBox
            {
                Size = new Size(45, 45),
                Dock = DockStyle.Right,
                Margin = new Padding(0),
                ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox,
                FillColor = Color.Transparent,
                IconColor = Color.White,
                HoverState = { FillColor = Color.FromArgb(60, 60, 90) }
            };
            pnlControl.Controls.Add(btnMaximize);

            var btnClose = new Guna.UI2.WinForms.Guna2ControlBox
            {
                Size = new Size(45, 45),
                Dock = DockStyle.Right,
                Margin = new Padding(0),
                FillColor = Color.Transparent,
                IconColor = Color.White,
                HoverState = { FillColor = Color.FromArgb(232, 17, 35) }
            };
            pnlControl.Controls.Add(btnClose);

            // Tên trang
            lblPageTitle = new Label
            {
                Text = "Trang sinh viên",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Dock = DockStyle.Left,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };

            // Tên sinh viên bên phải header (trước nút điều khiển)
            lblWelcome = new Label
            {
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Dock = DockStyle.Left,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
            panelHeader.Controls.Add(lblWelcome);

            panelHeader.Controls.Add(lblPageTitle);

            // Đưa cụm nút điều khiển ra ngoài cùng bên phải
            panelHeader.Controls.Add(pnlControl);

            // ===== SIDEBAR =====
            panelMenu = new Panel
            {
                Dock = DockStyle.Left,
                Width = 220,
                BackColor = Color.FromArgb(45, 45, 68)
            };

            // Logo
            lblLogo = new Label
            {
                Text = "📝 SINH VIÊN",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(94, 148, 255),
                AutoSize = false,
                Size = new Size(200, 50),
                Location = new Point(10, 15),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelMenu.Controls.Add(lblLogo);

            // Menu Buttons
            int btnY = 80;
            int btnHeight = 45;
            int spacing = 10;

            btnDanhSachKyThi = CreateMenuButton("📋 Danh sách kỳ thi", btnY);
            btnDanhSachKyThi.Click += (s, e) => ShowDanhSachKyThi();
            panelMenu.Controls.Add(btnDanhSachKyThi);
            btnY += btnHeight + spacing;

            btnLichSuThi = CreateMenuButton("📊 Lịch sử thi", btnY);
            btnLichSuThi.Click += (s, e) => ShowLichSuThi();
            panelMenu.Controls.Add(btnLichSuThi);
            btnY += btnHeight + spacing;

            btnHoSo = CreateMenuButton("👤 Hồ sơ", btnY);
            btnHoSo.Click += (s, e) => ShowHoSo();
            panelMenu.Controls.Add(btnHoSo);

            // Đăng xuất button
            btnDangXuat = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "🚪 Đăng xuất",
                Size = new Size(200, 40),
                Location = new Point(10, 700),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(255, 82, 82),
                BorderRadius = 5,
                Animated = true
            };
            btnDangXuat.Click += (s, e) => DangXuat();
            panelMenu.Controls.Add(btnDangXuat);

            // ===== CONTENT =====
            panelContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 248, 250),
                Padding = new Padding(10)
            };

            // Add panels to form
            this.Controls.Add(panelContent);
            this.Controls.Add(panelMenu);
            this.Controls.Add(panelHeader);

            // Drag control
            var dragControl = new Guna.UI2.WinForms.Guna2DragControl(new System.ComponentModel.Container());
            dragControl.TargetControl = panelHeader;

            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Button CreateMenuButton(string text, int top)
        {
            return new Guna.UI2.WinForms.Guna2Button
            {
                Text = text,
                Size = new Size(200, 45),
                Location = new Point(10, top),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                FillColor = Color.Transparent,
                BorderRadius = 8,
                TextAlign = HorizontalAlignment.Left,
                TextOffset = new Point(20, 0),
                Animated = true,
                HoverState = { FillColor = Color.FromArgb(60, 60, 90) }
            };
        }

        private void ClearContent()
        {
            panelContent.Controls.Clear();
        }

        private void SetActiveButton(Guna.UI2.WinForms.Guna2Button activeBtn)
        {
            var buttons = new[] { btnDanhSachKyThi, btnLichSuThi, btnHoSo };
            foreach (var btn in buttons)
            {
                btn.FillColor = Color.Transparent;
                btn.ForeColor = Color.White;
            }
            activeBtn.FillColor = Color.FromArgb(94, 148, 255);
            activeBtn.ForeColor = Color.White;
        }

        // ===== DANH SÁCH KỲ THI =====
        private void ShowDanhSachKyThi()
        {
            ClearContent();
            SetActiveButton(btnDanhSachKyThi);

            var uc = new ucDanhSachKyThi(_nguoiDung);
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        // ===== LỊCH SỬ THI =====
        private void ShowLichSuThi()
        {
            ClearContent();
            SetActiveButton(btnLichSuThi);

            var uc = new ucLichSuThi(_nguoiDung);
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        // ===== HỒ SƠ =====
        private void ShowHoSo()
        {
            ClearContent();
            SetActiveButton(btnHoSo);

            var panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(245, 248, 250), Padding = new Padding(20) };

            var lblTitle = new Label
            {
                Text = "👤 HỒ SƠ SINH VIÊN",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            panel.Controls.Add(lblTitle);

            var infoPanel = new Panel
            {
                Location = new Point(20, 70),
                Size = new Size(600, 350),
                BackColor = Color.White
            };

            infoPanel.Controls.Add(CreateInfoLabel($"Họ tên: {_nguoiDung.HoTen}", 20));
            infoPanel.Controls.Add(CreateInfoLabel($"Email: {_nguoiDung.Email}", 70));
            infoPanel.Controls.Add(CreateInfoLabel($"Vai trò: Sinh viên", 120));

            var btnChangePass = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "🔑 Đổi mật khẩu",
                Size = new Size(180, 45),
                Location = new Point(20, 190),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(94, 148, 255),
                BorderRadius = 8,
                Animated = true,
                HoverState = { FillColor = Color.FromArgb(70, 120, 230) }
            };
            btnChangePass.Click += (s, e) => new DoiMKGiangVien((int)_nguoiDung.Id).ShowDialog();
            infoPanel.Controls.Add(btnChangePass);

            var btnLogout = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "🚪 Đăng xuất",
                Size = new Size(180, 45),
                Location = new Point(220, 190),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(255, 82, 82),
                BorderRadius = 8,
                Animated = true,
                HoverState = { FillColor = Color.FromArgb(220, 50, 50) }
            };
            btnLogout.Click += (s, e) => DangXuat();
            infoPanel.Controls.Add(btnLogout);

            panel.Controls.Add(infoPanel);
            panelContent.Controls.Add(panel);
        }

        private Label CreateInfoLabel(string text, int top)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.FromArgb(33, 37, 41),
                AutoSize = true,
                Location = new Point(20, top)
            };
        }

        private void DangXuat()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                new frmLogin().ShowDialog();
                this.Close();
            }
        }
    }
}
