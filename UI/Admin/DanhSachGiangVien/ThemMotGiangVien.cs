using PhanMemThiTracNghiem.BAL;
using PhanMemThiTracNghiem.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.UI.Admin.DanhSachGiangVien
{
    

    public partial class ThemMotGiangVien : Form
    {
        private readonly NguoiDungBAL nguoiDungBAL;
        frmAdmin frmAdmin = new frmAdmin();
        public ThemMotGiangVien(frmAdmin frm)
        {
            InitializeComponent();
            nguoiDungBAL = new NguoiDungBAL();
            this.frmAdmin = frm;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                NGUOIDUNG giangVien = new NGUOIDUNG();
                
                giangVien.EMAIL = txtMaGiangVien.Text;
                giangVien.HOTEN = txtTenGiangVien.Text;
                giangVien.MATKHAU = PhanMemThiTracNghiem.BAL.PasswordHelper.HashPassword(txtMatKhau.Text);
                giangVien.MAROLE = 2; // Role GiangVien
                nguoiDungBAL.Add(giangVien);
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
