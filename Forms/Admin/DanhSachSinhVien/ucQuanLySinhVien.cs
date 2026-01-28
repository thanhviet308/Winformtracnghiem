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
                string[] hiddenColumns = { "MatKhau", "MaVaiTro", "VaiTro", 
                    "CauHoiThis", "NganHangDes", "LopHocSinhViens", 
                    "PhanCongGiangDays", "PhanCongGiamSats", "BaiThis" };
                
                foreach (var col in hiddenColumns)
                {
                    if (dgvSinhVien.Columns.Contains(col))
                        dgvSinhVien.Columns[col].Visible = false;
                }

                // Đặt tên cột hiển thị tiếng Việt
                if (dgvSinhVien.Columns.Contains("Id"))
                    dgvSinhVien.Columns["Id"].HeaderText = "ID";
                if (dgvSinhVien.Columns.Contains("HoTen"))
                    dgvSinhVien.Columns["HoTen"].HeaderText = "Họ tên";
                if (dgvSinhVien.Columns.Contains("Email"))
                    dgvSinhVien.Columns["Email"].HeaderText = "Email";
                if (dgvSinhVien.Columns.Contains("NgayTao"))
                    dgvSinhVien.Columns["NgayTao"].HeaderText = "Ngày tạo";

                // Di chuyển cột thao tác về cuối cùng
                if (dgvSinhVien.Columns.Contains("colSua"))
                    dgvSinhVien.Columns["colSua"].DisplayIndex = dgvSinhVien.Columns.Count - 2;
                if (dgvSinhVien.Columns.Contains("colXoa"))
                    dgvSinhVien.Columns["colXoa"].DisplayIndex = dgvSinhVien.Columns.Count - 1;
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

            var list = AppDbContext.NguoiDung
                .Where(n => n.MaVaiTro == 3 && 
                    (n.Email.ToLower().Contains(keyword) || n.HoTen.ToLower().Contains(keyword)))
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
                var sinhVien = AppDbContext.NguoiDung.FirstOrDefault(n => n.Email == email);
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
                        var sv = AppDbContext.NguoiDung.FirstOrDefault(n => n.Email == email);
                        if (sv != null)
                        {
                            AppDbContext.NguoiDung.Remove(sv);
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
