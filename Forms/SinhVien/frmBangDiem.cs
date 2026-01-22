using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Repositories;
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
using PhanMemThiTracNghiem.Forms.SinhVien;

namespace PhanMemThiTracNghiem.Forms.SinhVien
{
    public partial class frmBangDiem : Form
    {
        private readonly NGUOIDUNG nguoiDung;
        public frmBangDiem(NGUOIDUNG nd)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            nguoiDung = nd;
        }

        private void frmBangDiem_Load(object sender, EventArgs e)
        {
            var db  = new AppDbContext();
            List<BANGDIEM> listBangDiem = new List<BANGDIEM>();
            List<BANGDIEMreport> listReportBangDiem = new List<BANGDIEMreport>();
            listBangDiem = db.BANGDIEM.ToList();

            // Mã số sinh viên label
            lblMaSoSinhVien.Text = nguoiDung.HOTEN +" | "+ nguoiDung.EMAIL;

            foreach (BANGDIEM item in listBangDiem)
            {
                if (nguoiDung.ID.ToString() == item.MASV)
                {
                    BANGDIEMreport diem = new BANGDIEMreport();
                    diem.ID = item.ID;
                    diem.MAKITHI = item.MAKITHI;
                    diem.MASV = item.MASV;
                    diem.DIEM = item.DIEM;
                    diem.MAMT = item.MAMT;
                    listReportBangDiem.Add(diem);
                }                                                                              
            }
            if(listReportBangDiem.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu điểm! Vui lòng chờ cập nhật");
            }
            else
            {
                dgvBangDiem.DataSource = listReportBangDiem;
                
                // Đặt tên cột hiển thị
                if (dgvBangDiem.Columns["ID"] != null)
                    dgvBangDiem.Columns["ID"].HeaderText = "STT";
                if (dgvBangDiem.Columns["MAKITHI"] != null)
                    dgvBangDiem.Columns["MAKITHI"].HeaderText = "Mã Kỳ Thi";
                if (dgvBangDiem.Columns["MASV"] != null)
                    dgvBangDiem.Columns["MASV"].HeaderText = "ID Sinh Viên";
                if (dgvBangDiem.Columns["DIEM"] != null)
                    dgvBangDiem.Columns["DIEM"].HeaderText = "Điểm";
                if (dgvBangDiem.Columns["MAMT"] != null)
                    dgvBangDiem.Columns["MAMT"].HeaderText = "Mã Môn Thi";
            }           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmSinhVien frmSinhVien = new frmSinhVien(nguoiDung);
            this.Hide();
            frmSinhVien.ShowDialog();
            this.Close();
            
        }
    }
}
