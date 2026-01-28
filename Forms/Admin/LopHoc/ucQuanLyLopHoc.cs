using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.LopHoc
{
    public partial class ucQuanLyLopHoc : UserControl
    {
        private readonly AppDbContext AppDbContext;
        private readonly LopHocService LopHocService;

        public ucQuanLyLopHoc()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            AppDbContext = new AppDbContext();
            LopHocService = new LopHocService();
        }

        private void ucQuanLyLopHoc_Load(object sender, EventArgs e)
        {
            LoadLopHoc();
        }

        public void LoadLopHoc()
        {
            dgvLopHoc.Rows.Clear();
            var list = LopHocService.GetAll();

            foreach (var lop in list)
            {
                int soSV = LopHocService.CountSinhVienInLop(lop.Id);
                int index = dgvLopHoc.Rows.Add();
                dgvLopHoc.Rows[index].Cells["colId"].Value = lop.Id;
                dgvLopHoc.Rows[index].Cells["colTenLop"].Value = lop.TenLop;
                dgvLopHoc.Rows[index].Cells["colSoSinhVien"].Value = soSV;
                dgvLopHoc.Rows[index].Cells["colNgayTao"].Value = lop.NgayTao.ToString("dd/MM/yyyy");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadLopHoc();
                return;
            }

            dgvLopHoc.Rows.Clear();
            var list = LopHocService.GetAll()
                .Where(l => l.TenLop.ToLower().Contains(keyword))
                .ToList();

            foreach (var lop in list)
            {
                int soSV = LopHocService.CountSinhVienInLop(lop.Id);
                int index = dgvLopHoc.Rows.Add();
                dgvLopHoc.Rows[index].Cells["colId"].Value = lop.Id;
                dgvLopHoc.Rows[index].Cells["colTenLop"].Value = lop.TenLop;
                dgvLopHoc.Rows[index].Cells["colSoSinhVien"].Value = soSV;
                dgvLopHoc.Rows[index].Cells["colNgayTao"].Value = lop.NgayTao.ToString("dd/MM/yyyy");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemLopHoc frm = new frmThemLopHoc();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadLopHoc();
            }
        }

        private void dgvLopHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            long maLop = Convert.ToInt64(dgvLopHoc.Rows[e.RowIndex].Cells["colId"].Value);
            string tenLop = dgvLopHoc.Rows[e.RowIndex].Cells["colTenLop"].Value?.ToString();

            // Gán sinh viên
            if (dgvLopHoc.Columns[e.ColumnIndex].Name == "colGanSV")
            {
                frmGanSinhVien frm = new frmGanSinhVien(maLop, tenLop);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadLopHoc();
                }
            }
            // Phân công giảng dạy
            else if (dgvLopHoc.Columns[e.ColumnIndex].Name == "colPhanCong")
            {
                frmPhanCongGiangDay frm = new frmPhanCongGiangDay(maLop, tenLop);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadLopHoc();
                }
            }
            // Sửa
            else if (dgvLopHoc.Columns[e.ColumnIndex].Name == "colSua")
            {
                var lopHoc = LopHocService.GetAll().FirstOrDefault(l => l.Id == maLop);
                if (lopHoc != null)
                {
                    frmSuaLopHoc frm = new frmSuaLopHoc(lopHoc);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadLopHoc();
                    }
                }
            }
            // Xóa
            else if (dgvLopHoc.Columns[e.ColumnIndex].Name == "colXoa")
            {
                if (MessageBox.Show($"Bạn có chắc muốn xóa lớp '{tenLop}'?\nTất cả sinh viên và phân công sẽ bị xóa!", 
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        if (LopHocService.Delete(maLop))
                        {
                            LoadLopHoc();
                            MessageBox.Show("Xóa lớp học thành công!", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa lớp học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
