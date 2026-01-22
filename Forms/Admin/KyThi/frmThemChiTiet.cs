using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Services;
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

namespace PhanMemThiTracNghiem.Forms.Admin.KyThi
{
    public partial class frmThemChiTiet : Form
    {
        private readonly AppDbContext AppDbContext;
        private readonly ChiTietKyThiService _chiTietKyThiService;
        private string makithi;
        private string tenkithi;


        public frmThemChiTiet()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
        }
        public frmThemChiTiet(string makt, string tenkt)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            AppDbContext = new AppDbContext();
            _chiTietKyThiService = new ChiTietKyThiService();
            this.makithi = makt;
            this.tenkithi = tenkt;
        }

        private void frmThemChiTiet_Load(object sender, EventArgs e)
        {
            labelMaKiThi.Text = makithi.ToString();
            labelTenKiThi.Text = tenkithi.ToString();
            
            // Load danh sách môn học
            var listMonHoc = AppDbContext.MonHoc.ToList();
            foreach (var item in listMonHoc)
            {
                cbMonThi.Items.Add(item.TenMon);
            }
            
            // Load danh sách bài thi
            var list = AppDbContext.BaiThi.ToList();
            dgvdemo.DataSource = list;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime thoiGianBatDau = datetimeBD.Value;
            DateTime thoiGianKetThuc = datetimeKT.Value;
            int thoigianthi = (thoiGianKetThuc.Hour * 60 + thoiGianKetThuc.Minute) - (thoiGianBatDau.Hour * 60 + thoiGianBatDau.Minute);
            string tenmt = cbMonThi.Text;
            
            // Lấy môn học theo tên
            var monHoc = AppDbContext.MonHoc.FirstOrDefault(p => p.TenMon == tenmt);
            var users = AppDbContext.NguoiDung.Where(x => x.MaVaiTro == 3).ToList(); // Lấy sinh viên (MaVaiTro = 3)
            
            try
            {
                foreach (var user in users)
                {
                    // Tạo bài thi cho mỗi sinh viên
                    var baiThi = new BaiThi
                    {
                        MaKyThi = long.TryParse(makithi, out long kyThiId) ? kyThiId : (long?)null,
                        MaSinhVien = user.Id,
                        ThoiGianBatDau = datetimeBD.Value,
                        TrangThai = "chua_thi"
                    };
                    AppDbContext.BaiThi.Add(baiThi);
                }
                AppDbContext.SaveChanges();
                MessageBox.Show("Cập nhật thành công");
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
                MessageBox.Show("Chưa nhập thời gian bắt đầu hoặc kết thúc");
            }
            else if (datetimeBD.Value > datetimeKT.Value)
            {
                MessageBox.Show("Thời gian bắt đầu không được lớn hơn thời gian kết thúc");
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
