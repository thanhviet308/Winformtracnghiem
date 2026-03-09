using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using PhanMemThiTracNghiem.Forms.Admin.DanhSachGiangVien;
using PhanMemThiTracNghiem.Forms.Admin.DanhSachSinhVien;
using PhanMemThiTracNghiem.Forms.Admin.LopHoc;
using PhanMemThiTracNghiem.Forms.Admin.MonHoc;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin
{
    public partial class frmAdminNew : Form
    {
        private NguoiDung _nguoiDung;
        
        // UserControls
        private ucQuanLyGiangVien _ucGiangVien;
        private ucQuanLySinhVien _ucSinhVien;
        private ucQuanLyMonHoc _ucMonHoc;
        private ucQuanLyLopHoc _ucLopHoc;

        // Buttons Menu
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Guna.UI2.WinForms.Guna2Button btnGiangVien;
        private Guna.UI2.WinForms.Guna2Button btnSinhVien;
        private Guna.UI2.WinForms.Guna2Button btnMonHoc;
        private Guna.UI2.WinForms.Guna2Button btnLopHoc;
        private Guna.UI2.WinForms.Guna2Button btnThongTin;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;

        // Panels
        private Panel panelMenu;
        private Panel panelContent;
        private Panel panelHeader;
        private Label lblWelcome;

        public frmAdminNew(NguoiDung nguoiDung)
        {
            _nguoiDung = nguoiDung;
            InitializeComponents();
            ThemeHelper.ApplyVietnameseFont(this);

            lblWelcome.Text = $"Xin chào, {_nguoiDung.HoTen}!";
            
            // Mặc định hiển thị trang quản lý giảng viên (hoặc dashboard nếu có)
            ShowQuanLyGiangVien();
        }

        private void InitializeComponents()
        {
            this.SuspendLayout();

            // Form settings
            this.Text = "Hệ thống thi trắc nghiệm - Admin";
            this.Size = new Size(1400, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(37, 37, 56);
            this.FormBorderStyle = FormBorderStyle.None;

            // Header Panel
            panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 45, // Giảm chiều cao cho thanh thoát gọn hơn
                BackColor = Color.FromArgb(45, 45, 68)
            };

            // Panel chứa các nút điều khiển bên phải (Đảm bảo không bị mất)
            Panel pnlControl = new Panel
            {
                Dock = DockStyle.Right,
                Width = 140,
                BackColor = Color.Transparent
            };
            panelHeader.Controls.Add(pnlControl);

            var btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox
            {
                Size = new Size(45, 45),
                Dock = DockStyle.Right,
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
                FillColor = Color.Transparent,
                IconColor = Color.White,
                HoverState = { FillColor = Color.FromArgb(232, 17, 35) }
            };
            pnlControl.Controls.Add(btnClose);

            lblWelcome = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 10)
            };
            panelHeader.Controls.Add(lblWelcome);

            // Menu Panel
            panelMenu = new Panel
            {
                Dock = DockStyle.Left,
                Width = 220,
                BackColor = Color.FromArgb(45, 45, 68)
            };

            // Logo
            var lblLogo = new Label
            {
                Text = "⚡ ADMIN PANEL",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
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

            btnGiangVien = CreateMenuButton("👨‍🏫 Giảng viên", btnY);
            btnGiangVien.Click += (s, e) => ShowQuanLyGiangVien();
            panelMenu.Controls.Add(btnGiangVien);
            btnY += btnHeight + spacing;

            btnSinhVien = CreateMenuButton("👨‍🎓 Sinh viên", btnY);
            btnSinhVien.Click += (s, e) => ShowQuanLySinhVien();
            panelMenu.Controls.Add(btnSinhVien);
            btnY += btnHeight + spacing;

            btnMonHoc = CreateMenuButton("📚 Môn học", btnY);
            btnMonHoc.Click += (s, e) => ShowQuanLyMonHoc();
            panelMenu.Controls.Add(btnMonHoc);
            btnY += btnHeight + spacing;

            btnLopHoc = CreateMenuButton("🏫 Lớp học", btnY);
            btnLopHoc.Click += (s, e) => ShowQuanLyLopHoc();
            panelMenu.Controls.Add(btnLopHoc);
            btnY += btnHeight + spacing;

            btnThongTin = CreateMenuButton("👤 Cá nhân", btnY);
            btnThongTin.Click += (s, e) => ShowThongTin();
            panelMenu.Controls.Add(btnThongTin);

            // Logout button at bottom
            btnDangXuat = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "🚪 Đăng xuất",
                Size = new Size(200, 40),
                Location = new Point(10, 700),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(255, 82, 82),
                BorderRadius = 5
            };
            btnDangXuat.Click += (s, e) => DangXuat();
            panelMenu.Controls.Add(btnDangXuat);

            // Content Panel
            panelContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(37, 37, 56),
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
                FillColor = Color.Transparent, // Đồng bộ sidebar
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
            var buttons = new[] { btnGiangVien, btnSinhVien, btnMonHoc, btnLopHoc, btnThongTin };
            foreach (var btn in buttons)
            {
                btn.FillColor = Color.Transparent;
                btn.ForeColor = Color.White;
            }
            activeBtn.FillColor = Color.FromArgb(94, 148, 255);
            activeBtn.ForeColor = Color.White;
        }

        private void ShowQuanLyGiangVien()
        {
            ClearContent();
            SetActiveButton(btnGiangVien);

            if (_ucGiangVien == null)
            {
                _ucGiangVien = new ucQuanLyGiangVien();
            }
            _ucGiangVien.Dock = DockStyle.Fill;
            panelContent.Controls.Add(_ucGiangVien);
        }

        private void ShowQuanLySinhVien()
        {
            ClearContent();
            SetActiveButton(btnSinhVien);

            if (_ucSinhVien == null)
            {
                _ucSinhVien = new ucQuanLySinhVien();
            }
            _ucSinhVien.Dock = DockStyle.Fill;
            panelContent.Controls.Add(_ucSinhVien);
        }

        private void ShowQuanLyMonHoc()
        {
            ClearContent();
            SetActiveButton(btnMonHoc);

            if (_ucMonHoc == null)
            {
                _ucMonHoc = new ucQuanLyMonHoc();
            }
            _ucMonHoc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(_ucMonHoc);
        }

        private void ShowQuanLyLopHoc()
        {
            ClearContent();
            SetActiveButton(btnLopHoc);

            if (_ucLopHoc == null)
            {
                _ucLopHoc = new ucQuanLyLopHoc();
            }
            _ucLopHoc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(_ucLopHoc);
        }

        private void ShowThongTin()
        {
            ClearContent();
            SetActiveButton(btnThongTin);

            // Create a simple info panel (Tương tự frmGiangVienNew)
            var panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(37, 37, 56), Padding = new Padding(20) };
            var lblTitle = new Label { Text = "👤 THÔNG TIN QUẢN TRỊ VIÊN", Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Color.White, AutoSize = true, Location = new Point(20, 20) };
            panel.Controls.Add(lblTitle);

            var infoPanel = new Panel { Location = new Point(20, 70), Size = new Size(600, 350), BackColor = Color.FromArgb(50, 50, 76) };
            infoPanel.Controls.Add(CreateLabel($"Họ tên: {_nguoiDung.HoTen}", 20));
            infoPanel.Controls.Add(CreateLabel($"Email: {_nguoiDung.Email}", 70));
            infoPanel.Controls.Add(CreateLabel($"Vai trò: Quản trị viên (Admin)", 120));

            // Nút đăng xuất trong phần cá nhân
            var btnLogout = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "🚪 Đăng xuất",
                Size = new Size(200, 45),
                Location = new Point(20, 190),
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

        private Label CreateLabel(string text, int top)
        {
            return new Label { Text = text, Font = new Font("Segoe UI", 14), ForeColor = Color.White, AutoSize = true, Location = new Point(20, top) };
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
