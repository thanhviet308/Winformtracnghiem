using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Forms.Admin.DanhSachGiangVien;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin
{
    public partial class ucQuanLyGiangVien : UserControl
    {
        private readonly AppDbContext AppDbContext;
        private readonly GiangVienService GiangVienService;
        private Form parentForm;

        public ucQuanLyGiangVien()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            AppDbContext = new AppDbContext();
            GiangVienService = new GiangVienService();
        }

        public void SetParentForm(Form form)
        {
            parentForm = form;
        }

        private void ucQuanLyGiangVien_Load(object sender, EventArgs e)
        {
            LoadGiangVien();
        }

        private void LoadGiangVien()
        {
            var list = GiangVienService.GetGIANGVIENs();
            dgvGiangVien.DataSource = list;

            if (dgvGiangVien.Columns.Count > 0)
            {
                // Ẩn các cột không cần thiết
                string[] hiddenColumns = { "MatKhau", "MaVaiTro", "VaiTro", 
                    "CauHoiThis", "NganHangDes", "LopHocSinhViens", 
                    "PhanCongGiangDays", "PhanCongGiamSats", "BaiThis" };
                
                foreach (var col in hiddenColumns)
                {
                    if (dgvGiangVien.Columns.Contains(col))
                        dgvGiangVien.Columns[col].Visible = false;
                }

                // Đặt tên cột hiển thị tiếng Việt
                if (dgvGiangVien.Columns.Contains("Id"))
                    dgvGiangVien.Columns["Id"].HeaderText = "ID";
                if (dgvGiangVien.Columns.Contains("HoTen"))
                    dgvGiangVien.Columns["HoTen"].HeaderText = "Họ tên";
                if (dgvGiangVien.Columns.Contains("Email"))
                    dgvGiangVien.Columns["Email"].HeaderText = "Email";
                if (dgvGiangVien.Columns.Contains("NgayTao"))
                    dgvGiangVien.Columns["NgayTao"].HeaderText = "Ngày tạo";

                // Di chuyển cột thao tác về cuối cùng
                if (dgvGiangVien.Columns.Contains("colSua"))
                    dgvGiangVien.Columns["colSua"].DisplayIndex = dgvGiangVien.Columns.Count - 2;
                if (dgvGiangVien.Columns.Contains("colXoa"))
                    dgvGiangVien.Columns["colXoa"].DisplayIndex = dgvGiangVien.Columns.Count - 1;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadGiangVien();
                return;
            }

            var list = AppDbContext.NguoiDung
                .Where(n => n.MaVaiTro == 2 && 
                    (n.Email.ToLower().Contains(keyword) || n.HoTen.ToLower().Contains(keyword)))
                .ToList();

            dgvGiangVien.DataSource = list;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemGiangVien frm = new frmThemGiangVien();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadGiangVien();
            }
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            var frm = this.FindForm() as frmAdmin;
            if (frm != null)
            {
                NhapExcelGiangVien nhapExcel = new NhapExcelGiangVien(frm);
                nhapExcel.ShowDialog();
                LoadGiangVien();
            }
            else
            {
                MessageBox.Show("Không thể mở form nhập Excel!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGiangVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string email = dgvGiangVien.Rows[e.RowIndex].Cells["Email"].Value?.ToString();

            if (dgvGiangVien.Columns[e.ColumnIndex].Name == "colSua")
            {
                frmSuaGiangVien frm = new frmSuaGiangVien(email);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadGiangVien();
                }
            }
            else if (dgvGiangVien.Columns[e.ColumnIndex].Name == "colXoa")
            {
                if (MessageBox.Show($"Bạn có chắc muốn xóa giảng viên này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var gv = AppDbContext.NguoiDung.FirstOrDefault(n => n.Email == email);
                        if (gv != null)
                        {
                            AppDbContext.NguoiDung.Remove(gv);
                            AppDbContext.SaveChanges();
                            LoadGiangVien();
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
