using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
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

namespace PhanMemThiTracNghiem.Forms.Admin.DanhSachSinhVien
{
    public partial class ThemMotSinhVien : Form
    {
        private readonly NguoiDungService NguoiDungService;
        frmAdmin frmAdmin = new frmAdmin();
        public ThemMotSinhVien(frmAdmin frm)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            NguoiDungService = new NguoiDungService();
            this.frmAdmin = frm;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                NGUOIDUNG sinhVien = new NGUOIDUNG();

                sinhVien.EMAIL = txtMaSinhVien.Text;
                sinhVien.HOTEN = txtTenSinhVien.Text;
                sinhVien.MATKHAU = PhanMemThiTracNghiem.Helpers.PasswordHelper.HashPassword(txtMatKhau.Text);
                sinhVien.MAROLE = 3; // Role SinhVien
                NguoiDungService.Add(sinhVien);
                frmAdmin.frmAdmin_Load(sender, e);
                MessageBox.Show("Thêm thành công!");
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
