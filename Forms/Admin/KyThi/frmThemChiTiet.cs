using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.KyThi
{
    public partial class frmThemChiTiet : Form
    {
        private readonly AppDbContext AppDbContext;
        private string makithi;
        private string tenkithi;


        public frmThemChiTiet()
        {
            InitializeComponent();
           
        }
        public frmThemChiTiet(string makt,string tenkt)
        {
            InitializeComponent();
            AppDbContext = new AppDbContext();
            this.makithi = makt;
            this.tenkithi = tenkt;
        }

        private void frmThemChiTiet_Load(object sender, EventArgs e)
        {
             labelMaKiThi.Text = makithi.ToString();
              labelTenKiThi.Text = tenkithi.ToString();
            List<MONTHI> listmonthi = AppDbContext.MONTHI.ToList();
            foreach (var item in listmonthi)
            {
                cbMonThi.Items.Add(item.TENMT);
            }
            List<CHITIETKYTHI> list = AppDbContext.CHITIETKYTHI.ToList();  
            dgvdemo.DataSource = list;      



        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime thoiGianBatDau = datetimeBD.Value;
            DateTime thoiGianKetThuc = datetimeKT.Value;
            int thoigianthi = (thoiGianKetThuc.Hour * 60 + thoiGianKetThuc.Minute) - (thoiGianBatDau.Hour * 60 + thoiGianBatDau.Minute);
            string tenmt = cbMonThi.Text;
            string loaimt="";
            List<MONTHI> listmonthi = AppDbContext.MONTHI.Where(p => p.TENMT == tenmt).ToList();
            var users = AppDbContext.NGUOIDUNG.Where(x => x.MAROLE == 3).ToList(); // L?y sinh viên (MAROLE = 3)
            foreach (var item in listmonthi)
            {
                loaimt = item.MAMT;
            }
            try
            {
                foreach (var user in users)
                {
                    ChiTietKiThiDTO chiTietKiThiDTO = new ChiTietKiThiDTO();
                    chiTietKiThiDTO.MaKiThi = makithi.ToString();
                    chiTietKiThiDTO.MaMonThi = loaimt.ToString();
                    chiTietKiThiDTO.Diem = 0.0;
                    chiTietKiThiDTO.ThoiGianBD = datetimeBD.Value;
                    chiTietKiThiDTO.ThoiGianKT = datetimeKT.Value;
                    chiTietKiThiDTO.ThoiGianThi = thoigianthi;
                    chiTietKiThiDTO.MaSinhVien = user.ID.ToString();
                    ChiTietKyThiService.InsertUpdate(chiTietKiThiDTO);
                }
                MessageBox.Show("C?p nh?p thành công");
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


       

     

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            DateTime thoiGianBatDau = datetimeBD.Value;
            DateTime thoiGianKetThuc = datetimeKT.Value;
            int thoigianthi = (thoiGianKetThuc.Hour * 60 + thoiGianKetThuc.Minute) - (thoiGianBatDau.Hour * 60 + thoiGianBatDau.Minute);
            if (datetimeBD.Value == null && datetimeKT.Value == null)
            {
                MessageBox.Show("Chua nh?p th?i gian b?t d?u ho?c k?t thúc");
            }
            else if (datetimeBD.Value > datetimeKT.Value)
            {
                MessageBox.Show("Th?i gian b?t d?u không du?c l?n hon th?i gian k?t thúc");
            }
            else
            {
                btnKiemTra.Text = thoigianthi.ToString();
            }
        }

        private void datetimeKT_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
