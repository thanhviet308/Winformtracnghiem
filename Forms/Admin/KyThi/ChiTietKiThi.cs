using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.KyThi
{
    public partial class frmChiTietKiThi : Form
    {
        private readonly AppDbContext AppDbContext;
        private long maKyThi;
        private string tenKyThi;

        public frmChiTietKiThi(long maKyThi, string tenKyThi)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            this.maKyThi = maKyThi;
            this.tenKyThi = tenKyThi;
            AppDbContext = new AppDbContext();
        }

        private void frmChiTietKiThi_Load(object sender, EventArgs e)
        {
            cbMaKiThi.Items.Add(maKyThi.ToString());
            cbMaKiThi.SelectedIndex = 0;
            cbTenKiThi.Items.Add(tenKyThi);
            cbTenKiThi.SelectedIndex = 0;
            
            // Lấy danh sách bài thi của kỳ thi này
            var list = AppDbContext.BaiThi.Where(p => p.MaKyThi == maKyThi).ToList();
            LoadDGVchitKiThi(list);
        }

        private void LoadDGVchitKiThi(List<BaiThi> list)
        {
            dgvChiTietKiThi.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvChiTietKiThi.Rows.Add();
                dgvChiTietKiThi.Rows[index].Cells["colMaKiThi"].Value = item.MaKyThi;
                dgvChiTietKiThi.Rows[index].Cells["colMaSV"].Value = item.MaSinhVien;
                dgvChiTietKiThi.Rows[index].Cells["colDiem"].Value = item.DiemSo;
                
                // Tính thời gian thi
                if (item.ThoiGianBatDau.HasValue && item.ThoiGianNopBai.HasValue)
                {
                    var thoiGianThi = (item.ThoiGianNopBai.Value - item.ThoiGianBatDau.Value).TotalMinutes;
                    dgvChiTietKiThi.Rows[index].Cells["colThoiGianThi"].Value = $"{(int)thoiGianThi} phút";
                }
                
                dgvChiTietKiThi.Rows[index].Cells["colThoiGianBD"].Value = item.ThoiGianBatDau;
                dgvChiTietKiThi.Rows[index].Cells["colThoiGianKT"].Value = item.ThoiGianNopBai;
            }
        }

        private void dgvChiTietKiThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            dgvChiTietKiThi.CurrentRow.Selected = true;
            
            var diemCell = dgvChiTietKiThi.Rows[e.RowIndex].Cells["colDiem"].Value;
            if (diemCell != null && diemCell.ToString() != "")
            {
                MessageBox.Show("Kỳ thi này đã hoàn thành không thể sửa !!!");
            }
        }
    }
}
