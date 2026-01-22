using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Forms.Admin.DanhSachSinhVien;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin
{
    public partial class ucQuanLySinhVien : UserControl
    {
        private readonly AppDbContext AppDbContext;
        private readonly SinhVienService SinhVienService;
        private Form parentForm;

        public ucQuanLySinhVien()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            AppDbContext = new AppDbContext();
            SinhVienService = new SinhVienService();
        }

        public void SetParentForm(Form form)
        {
            parentForm = form;
        }

        private void ucQuanLySinhVien_Load(object sender, EventArgs e)
        {
            LoadSinhVien();
        }

        private void LoadSinhVien()
        {
            var list = SinhVienService.GetSINHVIENs();
            dgvSinhVien.DataSource = list;

            if (dgvSinhVien.Columns.Count > 0)
            {
                // Ẩn các cột không cần thiết
                if (dgvSinhVien.Columns.Contains("PASSWORD"))
                    dgvSinhVien.Columns["PASSWORD"].Visible = false;
                if (dgvSinhVien.Columns.Contains("MAROLE"))
                    dgvSinhVien.Columns["MAROLE"].Visible = false;
                if (dgvSinhVien.Columns.Contains("ROLE"))
                    dgvSinhVien.Columns["ROLE"].Visible = false;

                // Đặt tên cột
                if (dgvSinhVien.Columns.Contains("EMAIL"))
                    dgvSinhVien.Columns["EMAIL"].HeaderText = "Email";
                if (dgvSinhVien.Columns.Contains("HOTEN"))
                    dgvSinhVien.Columns["HOTEN"].HeaderText = "Họ tên";
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadSinhVien();
                return;
            }

            var list = AppDbContext.NGUOIDUNG
                .Where(n => n.MAROLE == 3 && 
                    (n.EMAIL.ToLower().Contains(keyword) || n.HOTEN.ToLower().Contains(keyword)))
                .ToList();

            dgvSinhVien.DataSource = list;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemSinhVien frm = new frmThemSinhVien();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadSinhVien();
            }
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            var frm = this.FindForm() as frmAdmin;
            if (frm != null)
            {
                NhapExcelSinhVien nhapExcel = new NhapExcelSinhVien(frm);
                nhapExcel.ShowDialog();
                LoadSinhVien();
            }
            else
            {
                MessageBox.Show("Không thể mở form nhập Excel!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string email = dgvSinhVien.Rows[e.RowIndex].Cells["EMAIL"].Value?.ToString();

            if (dgvSinhVien.Columns[e.ColumnIndex].Name == "colSua")
            {
                var sinhVien = AppDbContext.NGUOIDUNG.FirstOrDefault(n => n.EMAIL == email);
                if (sinhVien != null)
                {
                    frmSuaSinhVien frm = new frmSuaSinhVien(sinhVien);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadSinhVien();
                    }
                }
            }
            else if (dgvSinhVien.Columns[e.ColumnIndex].Name == "colXoa")
            {
                if (MessageBox.Show($"Bạn có chắc muốn xóa sinh viên này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var sv = AppDbContext.NGUOIDUNG.FirstOrDefault(n => n.EMAIL == email);
                        if (sv != null)
                        {
                            AppDbContext.NGUOIDUNG.Remove(sv);
                            AppDbContext.SaveChanges();
                            LoadSinhVien();
                            MessageBox.Show("Xóa thành công!", "Thông báo");
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
