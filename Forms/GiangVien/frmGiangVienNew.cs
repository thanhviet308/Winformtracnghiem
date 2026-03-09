using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    public partial class frmGiangVienNew : Form
    {
        private NguoiDung _nguoiDung;
        
        // UserControls
        private ucQuanLyCauHoi _ucQuanLyCauHoi;
        private ucQuanLyKhungDe _ucQuanLyKhungDe;
        private ucQuanLyKyThi _ucQuanLyKyThi;
        private ucThongKeTongQuan _ucThongKeTongQuan;
        private ucKetQuaThi _ucKetQuaThi;
        private ucViPhamSinhVien _ucViPhamSinhVien;

        // Buttons Menu
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Guna.UI2.WinForms.Guna2Button btnCauHoi;
        private Guna.UI2.WinForms.Guna2Button btnKhungDe;
        private Guna.UI2.WinForms.Guna2Button btnKyThi;
        private Guna.UI2.WinForms.Guna2Button btnKetQua;
        private Guna.UI2.WinForms.Guna2Button btnViPham;
        private Guna.UI2.WinForms.Guna2Button btnThongTin;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;

        // Panels
        private Panel panelMenu;
        private Panel panelContent;
        private Panel panelHeader;
        private Label lblWelcome;
        private Label lblLogo;

        public frmGiangVienNew(NguoiDung nguoiDung)
        {
            _nguoiDung = nguoiDung;
            InitializeComponents();
            ThemeHelper.ApplyVietnameseFont(this);

            lblWelcome.Text = $"Xin chào, {_nguoiDung.HoTen}!";
            
            // Mặc định hiển thị trang thống kê (Dashboard)
            ShowDashboard();
        }

        private void InitializeComponents()
        {
            this.SuspendLayout();

            // Form settings
            this.Text = "Hệ thống thi trắc nghiệm - Giảng viên";
            this.Size = new Size(1400, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(37, 37, 56);
            this.FormBorderStyle = FormBorderStyle.None;

            // Header Panel
            panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 45,
                BackColor = Color.FromArgb(45, 45, 68)
            };

            // Panel điều khiển bên phải
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

            // Menu Panel (Sidebar giống Admin)
            panelMenu = new Panel
            {
                Dock = DockStyle.Left,
                Width = 220,
                BackColor = Color.FromArgb(45, 45, 68)
            };

            // Logo (Đồng nhất style với Admin)
            lblLogo = new Label
            {
                Text = "⚡ TEACHER HUB",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(94, 148, 255), // Màu xanh thương hiệu
                AutoSize = false,
                Size = new Size(200, 50),
                Location = new Point(10, 15),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelMenu.Controls.Add(lblLogo);

            // Menu Buttons (Đồng bộ kiểu nút với Admin)
            int btnY = 80;
            int btnHeight = 45;
            int spacing = 10;

            btnDashboard = CreateMenuButton("📊 Thống kê", btnY);
            btnDashboard.Click += (s, e) => ShowDashboard();
            panelMenu.Controls.Add(btnDashboard);
            btnY += btnHeight + spacing;

            btnCauHoi = CreateMenuButton("❓ Câu hỏi", btnY);
            btnCauHoi.Click += (s, e) => ShowQuanLyCauHoi();
            panelMenu.Controls.Add(btnCauHoi);
            btnY += btnHeight + spacing;

            btnKhungDe = CreateMenuButton("📋 Khung đề", btnY);
            btnKhungDe.Click += (s, e) => ShowQuanLyKhungDe();
            panelMenu.Controls.Add(btnKhungDe);
            btnY += btnHeight + spacing;

            btnKyThi = CreateMenuButton("🎓 Kỳ thi", btnY);
            btnKyThi.Click += (s, e) => ShowQuanLyKyThi();
            panelMenu.Controls.Add(btnKyThi);
            btnY += btnHeight + spacing;

            btnKetQua = CreateMenuButton("📊 Kết quả thi", btnY);
            btnKetQua.Click += (s, e) => ShowKetQuaThi();
            panelMenu.Controls.Add(btnKetQua);
            btnY += btnHeight + spacing;

            btnViPham = CreateMenuButton("⚠ Vi phạm", btnY);
            btnViPham.Click += (s, e) => ShowViPhamSinhVien();
            panelMenu.Controls.Add(btnViPham);
            btnY += btnHeight + spacing;

            btnThongTin = CreateMenuButton("👤 Cá nhân", btnY);
            btnThongTin.Click += (s, e) => ShowThongTin();
            panelMenu.Controls.Add(btnThongTin);

            // Đăng xuất button at bottom
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

            // Content Panel
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
                FillColor = Color.Transparent, // Để trong suốt mặc định
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
            var buttons = new[] { btnDashboard, btnCauHoi, btnKhungDe, btnKyThi, btnKetQua, btnViPham, btnThongTin };
            foreach (var btn in buttons)
            {
                btn.FillColor = Color.Transparent;
                btn.ForeColor = Color.White;
            }
            activeBtn.FillColor = Color.FromArgb(94, 148, 255);
            activeBtn.ForeColor = Color.White;
        }

        private void ShowDashboard()
        {
            ClearContent();
            SetActiveButton(btnDashboard);

            if (_ucThongKeTongQuan == null)
            {
                _ucThongKeTongQuan = new ucThongKeTongQuan();
            }
            _ucThongKeTongQuan.SetNguoiDung(_nguoiDung);
            _ucThongKeTongQuan.Dock = DockStyle.Fill;
            panelContent.Controls.Add(_ucThongKeTongQuan);
        }

        private void ShowQuanLyCauHoi()
        {
            try
            {
                ClearContent();
                SetActiveButton(btnCauHoi);

                if (_ucQuanLyCauHoi == null)
                {
                    _ucQuanLyCauHoi = new ucQuanLyCauHoi();
                }
                _ucQuanLyCauHoi.Dock = DockStyle.Fill;
                panelContent.Controls.Add(_ucQuanLyCauHoi);
                _ucQuanLyCauHoi.SetNguoiDung(_nguoiDung);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị Quản lý câu hỏi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowQuanLyKhungDe()
        {
            try
            {
                ClearContent();
                SetActiveButton(btnKhungDe);
                if (_ucQuanLyKhungDe == null) _ucQuanLyKhungDe = new ucQuanLyKhungDe();
                _ucQuanLyKhungDe.Dock = DockStyle.Fill;
                panelContent.Controls.Add(_ucQuanLyKhungDe);
                _ucQuanLyKhungDe.SetNguoiDung(_nguoiDung);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị Quản lý khung đề: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowQuanLyKyThi()
        {
            try
            {
                ClearContent();
                SetActiveButton(btnKyThi);
                if (_ucQuanLyKyThi == null) _ucQuanLyKyThi = new ucQuanLyKyThi();
                _ucQuanLyKyThi.Dock = DockStyle.Fill;
                panelContent.Controls.Add(_ucQuanLyKyThi);
                _ucQuanLyKyThi.SetNguoiDung(_nguoiDung);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị Quản lý kỳ thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowKetQuaThi()
        {
            try
            {
                ClearContent();
                SetActiveButton(btnKetQua);
                if (_ucKetQuaThi == null) _ucKetQuaThi = new ucKetQuaThi();
                _ucKetQuaThi.Dock = DockStyle.Fill;
                panelContent.Controls.Add(_ucKetQuaThi);
                _ucKetQuaThi.SetNguoiDung(_nguoiDung);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị Kết quả thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowViPhamSinhVien()
        {
            try
            {
                ClearContent();
                SetActiveButton(btnViPham);
                if (_ucViPhamSinhVien == null) _ucViPhamSinhVien = new ucViPhamSinhVien();
                _ucViPhamSinhVien.Dock = DockStyle.Fill;
                panelContent.Controls.Add(_ucViPhamSinhVien);
                _ucViPhamSinhVien.SetNguoiDung(_nguoiDung);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị Vi phạm sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowThongTin()
        {
            ClearContent();
            SetActiveButton(btnThongTin);

            var panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(245, 248, 250), Padding = new Padding(20) };
            var lblTitle = new Label { Text = "👤 THÔNG TIN CÁ NHÂN GIÁO VIÊN", Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Color.FromArgb(33, 37, 41), AutoSize = true, Location = new Point(20, 20) };
            panel.Controls.Add(lblTitle);

            var infoPanel = new Panel { Location = new Point(20, 70), Size = new Size(600, 350), BackColor = Color.White };
            infoPanel.Controls.Add(CreateInfoLabel($"Họ tên: {_nguoiDung.HoTen}", 20));
            infoPanel.Controls.Add(CreateInfoLabel($"Email: {_nguoiDung.Email}", 70));
            infoPanel.Controls.Add(CreateInfoLabel($"Chức vụ: Giảng viên", 120));

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

        private Label CreateLabel(string text, int top)
        {
            return new Label { Text = text, Font = new Font("Segoe UI", 14), ForeColor = Color.White, AutoSize = true, Location = new Point(20, top) };
        }

        private Label CreateInfoLabel(string text, int top)
        {
            return new Label { Text = text, Font = new Font("Segoe UI", 14), ForeColor = Color.FromArgb(33, 37, 41), AutoSize = true, Location = new Point(20, top) };
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
