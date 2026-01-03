using PhanMemThiTracNghiem.Helpers;
using PhanMemThiTracNghiem.Services;
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
                MessageBox.Show("Kh�ng t�m th?y ngu?i d�ng");
                return;
            }
            
            // So s�nh m?t kh?u cu d� m� h�a
            string hashedOldPassword = PasswordHelper.HashPassword(txtMatkhauCu.Text);
            if (hashedOldPassword != gv.MATKHAU)
            {
                MessageBox.Show("M?t kh?u cu kh�ng d�ng");
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Vui l�ng nh?p m?t kh?u m?i");
                return;
            }
            
            if (txtMatKhauMoi.Text != txtNhapLai.Text)
            {
                MessageBox.Show("M?t kh?u m?i kh�ng kh?p");
                return;
            }
            
            GiangVienService.DoiMatKhau(idGV, txtMatKhauMoi.Text);
            MessageBox.Show("�?i m?t kh?u th�nh c�ng");
            this.Close();
        }
    }
}
