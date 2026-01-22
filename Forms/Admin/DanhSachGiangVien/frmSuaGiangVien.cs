using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Helpers;
using PhanMemThiTracNghiem.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.DanhSachGiangVien
{
    public partial class frmSuaGiangVien : Form
    {
        private readonly AppDbContext AppDbContext;
        private readonly string _email;

        public frmSuaGiangVien(string email)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            AppDbContext = new AppDbContext();
            _email = email;
            LoadData();
        }

        private void LoadData()
        {
            var gv = AppDbContext.NGUOIDUNG.FirstOrDefault(n => n.EMAIL == _email);
            if (gv != null)
            {
                txtEmail.Text = gv.EMAIL;
                txtEmail.Enabled = false; // Không cho sửa email
                txtHoTen.Text = gv.HOTEN;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                {
                    MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var gv = AppDbContext.NGUOIDUNG.FirstOrDefault(n => n.EMAIL == _email);
                if (gv != null)
                {
                    gv.HOTEN = txtHoTen.Text.Trim();
                    
                    // Nếu nhập mật khẩu mới thì cập nhật
                    if (!string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
                    {
                        gv.MATKHAU = PasswordHelper.HashPassword(txtMatKhauMoi.Text);
                    }

                    AppDbContext.SaveChanges();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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
