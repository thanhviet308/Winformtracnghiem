using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Helpers;
using PhanMemThiTracNghiem.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.DanhSachGiangVien
{
    public partial class frmThemGiangVien : Form
    {
        private readonly AppDbContext AppDbContext;

        public frmThemGiangVien()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            AppDbContext = new AppDbContext();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                {
                    MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra email đã tồn tại
                if (AppDbContext.NguoiDung.Any(n => n.Email == txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NguoiDung gv = new NguoiDung();
                gv.Email = txtEmail.Text.Trim();
                gv.HoTen = txtHoTen.Text.Trim();
                gv.MatKhau = PasswordHelper.HashPassword(txtMatKhau.Text);
                gv.MaVaiTro = 2; // Giảng viên

                AppDbContext.NguoiDung.Add(gv);
                AppDbContext.SaveChanges();

                MessageBox.Show("Thêm giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
