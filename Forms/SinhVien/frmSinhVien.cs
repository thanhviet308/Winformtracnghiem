using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Repositories;
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

namespace PhanMemThiTracNghiem.Forms.SinhVien
{
    public partial class frmSinhVien : Form
    {
        AppDbContext AppDbContext = new AppDbContext();

        ChiTietKyThiService ChiTietKyThiService;
        MonThiService MonThiService;
        KyThiService KyThiService;
        NGUOIDUNG nguoiDung;
        MONTHI monThi;
        DateTime thoiGianThiGanNhat = DateTime.Now;
        DateTime thoiGianThi ;
        DateTime thoiGianKetThuc;

        public frmSinhVien(NGUOIDUNG nd)
        {
            InitializeComponent();
            ChiTietKyThiService = new ChiTietKyThiService();
            KyThiService = new KyThiService();
            MonThiService = new MonThiService();
            nguoiDung = nd;
        }
        public frmSinhVien(NGUOIDUNG nd, int i)
        {
            InitializeComponent();
            ChiTietKyThiService = new ChiTietKyThiService();
            KyThiService = new KyThiService();
            nguoiDung = nd;
            btnVaoThi.Enabled = false;
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            btnXemDiem.Hide();
            
            // ?n tru?ng L?p (không còn trong NGUOIDUNG)
            label2.Visible = false;
            lblLop.Visible = false;
            
           // Tìm k? thi trong th?i gian hi?n t?i
            foreach (var item in KyThiService.GetThongTinKyThi())
            {
                if(item.THOIGIANBDKITHI < thoiGianThiGanNhat && item.THOIGIANKTKITHI > thoiGianThiGanNhat)
                {
                    lblTenKyThi.Text = item.TENKITHI + " : " + item.MAKITHI;
                    lblTenKyThi.Text = lblTenKyThi.Text.ToUpper();
                    lblTenKyThi.Name = item.MAKITHI;
                }
            }

            // L?y th?i gian so sánh tìm thông tin g?n nh?t 
            thoiGianThiGanNhat = new DateTime(1 / 1 / 2000);
            foreach (var item in ChiTietKyThiService.GetThongTinChiTietKyThi())
            {
                if (lblTenKyThi.Name == item.MAKITHI && item.MASV == nguoiDung.ID.ToString())
                {
                    
                    lblHoTen.Text = nguoiDung.HOTEN;
                    if (thoiGianThiGanNhat < item.THOIGIANBD)
                    {
                        thoiGianThiGanNhat = (DateTime)item.THOIGIANBD;
                        foreach (var i in MonThiService.GetThongTinMonThi())
                        {
                            if (i.MAMT == item.MAMT)
                            {
                                lblMonThi.Text = i.TENMT;
                                lblMonThi.Name = item.MAMT;
                                monThi = i;
                                break;
                            }
                        }
                        
                        lblNgayThi.Text = item.THOIGIANTHI.ToString();
                        lblThoiGianBatDau.Text = item.THOIGIANBD.ToString();
                        lblThoiGianKetThuc.Text = item.THOIGIANKT.ToString();
                        thoiGianThi = (DateTime)item.THOIGIANBD;
                        thoiGianKetThuc = (DateTime)item.THOIGIANKT;
                    }
                }
            }
        }

        // B? ki?m tra tru?ng h?p ngày thay d?i "Thi dêm"
        private bool KiemTraThoiGianVaoThi()
        {

            if (DateTime.Now.Year == thoiGianThi.Year && DateTime.Now.Month == thoiGianThi.Month && DateTime.Now.Day == thoiGianThi.Day 
                && (DateTime.Now.Hour <= thoiGianThi.Hour || DateTime.Now.Hour <= thoiGianKetThuc.Hour))
            {
                if (DateTime.Now.Hour == thoiGianThi.Hour -1 && DateTime.Now.Minute == 59 && DateTime.Now.Second >= 30 
                    || (DateTime.Now.Hour < thoiGianKetThuc.Hour && DateTime.Now.Hour > thoiGianThi.Hour) 
                    || (DateTime.Now.Hour == thoiGianKetThuc.Hour && DateTime.Now.Minute < thoiGianKetThuc.Minute))
                {
                    return true;                  
                }
                else
                {
                    if (DateTime.Now.Hour == thoiGianThi.Hour && DateTime.Now.Minute < thoiGianThi.Minute - 1 && DateTime.Now.Second >= 30 || DateTime.Now < thoiGianKetThuc
                        || (DateTime.Now.Hour == thoiGianKetThuc.Hour && DateTime.Now.Minute < thoiGianKetThuc.Minute) )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
            }
            else
            {
                return false;
            }
        }

        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            frmBangDiem frmBangDiem = new frmBangDiem(nguoiDung);
            this.Hide();
            frmBangDiem.ShowDialog();         
            this.Close();



        }
        private void btnVaoThi_Click(object sender, EventArgs e)
        {
            if (KiemTraThoiGianVaoThi() == true)
            {
                frmThi frmThi = new frmThi(nguoiDung, monThi, DateTime.Now,thoiGianKetThuc);
                this.Hide();
                frmThi.WindowState = FormWindowState.Maximized;
                frmThi.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Chua d?n th?i gian b?t d?u thi \nHi?n t?i là: " + DateTime.Now.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.ShowDialog();
            this.Close();
        }
    }
}
