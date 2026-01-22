using System;
using System.Windows.Forms;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Helpers;

namespace PhanMemThiTracNghiem.Forms.Admin
{
    public partial class frmThemSinhVien : Form
    {
        private readonly NguoiDungService _nguoiDungService;

        public frmThemSinhVien()
        {
            InitializeComponent();
            _nguoiDungService = new NguoiDungService();
        }

        private void frmThemSinhVien_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyVietnameseFont(this);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Vui lòng nhập email!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                {
                    MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                    return;
                }

                // Kiểm tra email đã tồn tại chưa
                var existingUser = _nguoiDungService.GetByEmail(txtEmail.Text.Trim());
                if (existingUser != null)
                {
                    MessageBox.Show("Email đã tồn tại trong hệ thống!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                var sinhVien = new NGUOIDUNG
                {
                    EMAIL = txtEmail.Text.Trim(),
                    HOTEN = txtHoTen.Text.Trim(),
                    MATKHAU = PasswordHelper.HashPassword(txtMatKhau.Text),
                    MAROLE = 3 // 3 = Sinh viên
                };

                _nguoiDungService.Add(sinhVien);
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
