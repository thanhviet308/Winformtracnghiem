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

namespace PhanMemThiTracNghiem.Forms.Admin.DanhSachGiangVien
{
    

    public partial class ThemMotGiangVien : Form
    {
        private readonly NguoiDungService NguoiDungService;
        frmAdmin frmAdmin = new frmAdmin();
        public ThemMotGiangVien(frmAdmin frm)
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
                NGUOIDUNG giangVien = new NGUOIDUNG();
                
                giangVien.EMAIL = txtMaGiangVien.Text;
                giangVien.HOTEN = txtTenGiangVien.Text;
                giangVien.MATKHAU = PhanMemThiTracNghiem.Helpers.PasswordHelper.HashPassword(txtMatKhau.Text);
                giangVien.MAROLE = 2; // Role GiangVien
                NguoiDungService.Add(giangVien);
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
