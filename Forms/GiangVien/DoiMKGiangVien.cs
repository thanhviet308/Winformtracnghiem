using PhanMemThiTracNghiem.Helpers;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    public partial class DoiMKGiangVien : Form
    {
        private readonly GiangVienService GiangVienService;
        int idGV;
        public DoiMKGiangVien(int id)
        {
            this.idGV = id;
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            GiangVienService = new GiangVienService();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            NguoiDungService NguoiDungService = new NguoiDungService();
            var gv = NguoiDungService.GetById(idGV);
            
            if (gv == null)
            {
                MessageBox.Show("Không tìm thấy người dùng");
                return;
            }
            
            // So sánh mật khẩu cũ đã mã hóa
            string hashedOldPassword = PasswordHelper.HashPassword(txtMatkhauCu.Text);
            if (hashedOldPassword != gv.MATKHAU)
            {
                MessageBox.Show("Mật khẩu cũ không đúng");
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới");
                return;
            }
            
            if (txtMatKhauMoi.Text != txtNhapLai.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp");
                return;
            }
            
            GiangVienService.DoiMatKhau(idGV, txtMatKhauMoi.Text);
            MessageBox.Show("Đổi mật khẩu thành công");
            this.Close();
        }
    }
}
