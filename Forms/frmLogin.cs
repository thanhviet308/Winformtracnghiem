using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PhanMemThiTracNghiem.Forms.Admin;
using PhanMemThiTracNghiem.Forms.GiangVien;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Forms.SinhVien;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Models;

namespace PhanMemThiTracNghiem
{
    public partial class frmLogin : Form
    {
        private readonly NguoiDungService NguoiDungService;

        public frmLogin()
        {
            InitializeComponent();
            NguoiDungService = new NguoiDungService();
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Length == 0 && txtMatKhau.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nh?p email và m?t kh?u");
                return;
            }
            else if (txtTaiKhoan.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nh?p email");
                return;
            }
            else if (txtMatKhau.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nh?p m?t kh?u");
                return;
            }

            // Ðang nh?p v?i b?ng NGUOIDUNG
            NGUOIDUNG nguoiDung = NguoiDungService.DangNhap(txtTaiKhoan.Text.Trim(), txtMatKhau.Text);

            if (nguoiDung == null)
            {
                MessageBox.Show("Email ho?c m?t kh?u không chính xác!");
                return;
            }

            // Ði?u hu?ng theo Role
            // MAROLE: 1 = Admin, 2 = GiangVien, 3 = SinhVien
            switch (nguoiDung.MAROLE)
            {
                case 1: // Admin
                    frmAdmin frmAdmin = new frmAdmin(nguoiDung);
                    this.Hide();
                    frmAdmin.ShowDialog();
                    this.Close();
                    break;

                case 2: // Gi?ng viên
                    frmGiangVien frmGiangVien = new frmGiangVien(nguoiDung);
                    this.Hide();
                    frmGiangVien.ShowDialog();
                    this.Close();
                    break;

                case 3: // Sinh viên
                    frmSinhVien frmSinhVien = new frmSinhVien(nguoiDung);
                    this.Hide();
                    frmSinhVien.ShowDialog();
                    this.Close();
                    break;

                default:
                    MessageBox.Show("Email này chua du?c phân quy?n!");
                    break;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Focus vào textbox email
            txtTaiKhoan.Focus();
        }

        

        private void chkHienMatKhau_CheckedChanged_1(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = (chkHienMatKhau.Checked) ? '\0' : '?';
        }
    }
}
