using System;
using System.Windows.Forms;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Helpers;

namespace PhanMemThiTracNghiem.Forms.Admin
{
    public partial class frmSuaSinhVien : Form
    {
        private readonly NguoiDungService _nguoiDungService;
        private NguoiDung _sinhVien;

        public frmSuaSinhVien(NguoiDung sinhVien)
        {
            InitializeComponent();
            _nguoiDungService = new NguoiDungService();
            _sinhVien = sinhVien;
        }

        private void frmSuaSinhVien_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyVietnameseFont(this);
            LoadSinhVienInfo();
        }

        private void LoadSinhVienInfo()
        {
            if (_sinhVien != null)
            {
                txtEmail.Text = _sinhVien.Email;
                txtHoTen.Text = _sinhVien.HoTen;
                // Không hiển thị mật khẩu cũ
            }
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

                // Kiểm tra email đã tồn tại chưa (nếu thay đổi email)
                if (txtEmail.Text.Trim() != _sinhVien.Email)
                {
                    var existingUser = _nguoiDungService.GetByEmail(txtEmail.Text.Trim());
                    if (existingUser != null)
                    {
                        MessageBox.Show("Email đã tồn tại trong hệ thống!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                        return;
                    }
                }

                _sinhVien.Email = txtEmail.Text.Trim();
                _sinhVien.HoTen = txtHoTen.Text.Trim();

                // Chỉ cập nhật mật khẩu nếu nhập mới
                if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    _sinhVien.MatKhau = PasswordHelper.HashPassword(txtMatKhau.Text);
                }

                _nguoiDungService.Update(_sinhVien);
                MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo",
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
