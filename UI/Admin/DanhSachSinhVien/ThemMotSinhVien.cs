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

namespace PhanMemThiTracNghiem.UI.Admin.DanhSachSinhVien
{
    public partial class ThemMotSinhVien : Form
    {
        private readonly NguoiDungBAL nguoiDungBAL;
        frmAdmin frmAdmin = new frmAdmin();
        public ThemMotSinhVien(frmAdmin frm)
        {
            InitializeComponent();
            nguoiDungBAL = new NguoiDungBAL();
            this.frmAdmin = frm;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                NGUOIDUNG sinhVien = new NGUOIDUNG();

                sinhVien.TENTAIKHOAN = txtMaSinhVien.Text;
                sinhVien.HOTEN = txtTenSinhVien.Text;
                sinhVien.NGAYSINH = dtNgaySinhSinhVien.Value;
                sinhVien.MATKHAU = txtMatKhau.Text;
                sinhVien.MAROLE = 3; // Role SinhVien
                nguoiDungBAL.Add(sinhVien);
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
