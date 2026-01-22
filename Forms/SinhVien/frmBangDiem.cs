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
        private readonly NguoiDung nguoiDung;
        
        public frmBangDiem(NguoiDung nd)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            nguoiDung = nd;
        }

        private void frmBangDiem_Load(object sender, EventArgs e)
        {
            var db = new AppDbContext();
            
            // Lấy danh sách bài thi của sinh viên này
            var listBaiThi = db.BaiThi
                .Where(bt => bt.MaSinhVien == nguoiDung.Id)
                .ToList();

            // Mã số sinh viên label
            lblMaSoSinhVien.Text = nguoiDung.HoTen + " | " + nguoiDung.Email;

            // Tạo list report
            List<BANGDIEMreport> listReportBangDiem = new List<BANGDIEMreport>();
            
            foreach (var item in listBaiThi)
            {
                BANGDIEMreport diem = new BANGDIEMreport();
                diem.ID = (int)item.Id;
                diem.MAKITHI = item.MaKyThi?.ToString() ?? "";
                diem.MASV = item.MaSinhVien?.ToString() ?? "";
                diem.DIEM = item.DiemSo;
                listReportBangDiem.Add(diem);
            }
            
            if (listReportBangDiem.Count == 0)
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
