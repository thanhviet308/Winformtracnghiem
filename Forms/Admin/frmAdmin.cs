// ...existing code...
using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using PhanMemThiTracNghiem.Forms.Admin.DanhSachGiangVien;
using PhanMemThiTracNghiem.Forms.Admin.DanhSachSinhVien;
// Đã xóa DeThi và KyThi - không thuộc Admin
using PhanMemThiTracNghiem.Forms.Admin.LopHoc;
using PhanMemThiTracNghiem.Forms.Admin.MonHoc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin
{
    public partial class frmAdmin: Form
    {
        private readonly GiangVienService GiangVienService;
        private readonly SinhVienService SinhVienService;
        private readonly NguoiDung nguoiDung;
        // KyThiService đã xóa - không thuộc Admin
        private readonly AppDbContext AppDbContext;
        private readonly MonHocService MonHocService;
     
        
        public frmAdmin(NguoiDung nd)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            GiangVienService = new GiangVienService();
            SinhVienService = new SinhVienService();
            // KyThiService đã xóa
            AppDbContext = new AppDbContext();
            MonHocService = new MonHocService();
            nguoiDung = nd;
        }

        public frmAdmin()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
        }

        private void btnNhapExcelGiangVien_Click(object sender, EventArgs e)
        {
            
            NhapExcelGiangVien nhapExcelGiangVien = new NhapExcelGiangVien(this);
            nhapExcelGiangVien.ShowDialog();
        }

        public void frmAdmin_Load(object sender, EventArgs e)
        {
            labelAdmin.Text = nguoiDung.HoTen.ToString();
            
            // Khởi tạo các tab với UserControl mới
            InitializeGiangVienTab();
            InitializeSinhVienTab();
            
            // Thiết lập tab Lớp học và Môn học (thay thế Đề thi và Kỳ thi)
            SetupAdminTabs();
            
            // Ẩn các panel không còn dùng
            guna2Panel4.Visible = false; // Panel ngày sinh giáo viên
        }

        /// <summary>
        /// Thiết lập các tab cho Admin: Lớp học và Môn học
        /// </summary>
        private void SetupAdminTabs()
        {
            // Tìm TabControl
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2TabControl tabControl)
                {
                    // === Chuyển tabPage3 thành Quản lý Môn học ===
                    tabPage3.Text = "QUẢN LÝ MÔN HỌC";
                    tabPage3.Controls.Clear();
                    var ucQuanLyMonHoc = new ucQuanLyMonHoc();
                    ucQuanLyMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
                    tabPage3.Controls.Add(ucQuanLyMonHoc);

                    // === Chuyển tabPage4 thành Quản lý Lớp học ===
                    tabPage4.Text = "QUẢN LÝ LỚP HỌC";
                    tabPage4.Controls.Clear();
                    var ucQuanLyLopHoc = new ucQuanLyLopHoc();
                    ucQuanLyLopHoc.Dock = System.Windows.Forms.DockStyle.Fill;
                    tabPage4.Controls.Add(ucQuanLyLopHoc);

                    break;
                }
            }
        }

        // Đã xóa InitializeDeThiTab - không thuộc Admin

        /// <summary>
        /// Khởi tạo tab Quản lý giảng viên với UserControl mới
        /// </summary>
        private void InitializeGiangVienTab()
        {
            // Ẩn tất cả controls cũ trên tabPage1
            foreach (Control ctrl in tabPage1.Controls)
            {
                ctrl.Visible = false;
            }

            // Tạo và thêm UserControl mới
            var ucQuanLyGiangVien = new ucQuanLyGiangVien();
            ucQuanLyGiangVien.Dock = System.Windows.Forms.DockStyle.Fill;
            tabPage1.Controls.Add(ucQuanLyGiangVien);
            ucQuanLyGiangVien.BringToFront();
        }

        /// <summary>
        /// Khởi tạo tab Quản lý sinh viên với UserControl mới
        /// </summary>
        private void InitializeSinhVienTab()
        {
            // Ẩn tất cả controls cũ trên tabPage2
            foreach (Control ctrl in tabPage2.Controls)
            {
                ctrl.Visible = false;
            }

            // Tạo và thêm UserControl mới
            var ucQuanLySinhVien = new ucQuanLySinhVien();
            ucQuanLySinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            tabPage2.Controls.Add(ucQuanLySinhVien);
            ucQuanLySinhVien.BringToFront();
        }
        // Đã chuyển sang SetupAdminTabs

        private void LoadDGVKiThi(List<Models.KyThi> listkithi)
        {
            dgvKiThi.Rows.Clear();
            foreach (var item in listkithi)
            {
                int index = dgvKiThi.Rows.Add();
                dgvKiThi.Rows[index].Cells["colSTT"].Value = item.Id;
                dgvKiThi.Rows[index].Cells["colMaKiThi"].Value = item.Id;
                dgvKiThi.Rows[index].Cells["colTenKiThi"].Value = item.TenKyThi;
                dgvKiThi.Rows[index].Cells["colThoiGianBD"].Value = item.ThoiGianBatDau;
                dgvKiThi.Rows[index].Cells["colThoiGianKT"].Value = item.ThoiGianKetThuc;
            }
        }

   

        private void dgvDanhSachGiangVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvDanhSachGiangVien.CurrentRow.Selected = true;
            txtMaGiangVien.Text = dgvDanhSachGiangVien.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
            txtTenGiangVien.Text = dgvDanhSachGiangVien.Rows[e.RowIndex].Cells["HoTen"].FormattedValue.ToString();
            // Lưu ID vào Tag để dùng khi cập nhật
            txtMaGiangVien.Tag = dgvDanhSachGiangVien.Rows[e.RowIndex].Cells["ID"].Value;
        }

        private void dgvDanhSachSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvDanhSachSinhVien.CurrentRow.Selected = true;
            txtMaSinhVien.Text = dgvDanhSachSinhVien.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
            txtTenSinhVien.Text = dgvDanhSachSinhVien.Rows[e.RowIndex].Cells["HoTen"].FormattedValue.ToString();
            // Lưu ID vào Tag để dùng khi cập nhật
            txtMaSinhVien.Tag = dgvDanhSachSinhVien.Rows[e.RowIndex].Cells["ID"].Value;
        }

        private void btnCapNhapGiangVien_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgvDanhSachGiangVien.SelectedRows[0].Cells["ID"].Value.ToString());
                string email = txtMaGiangVien.Text;
                string hoten = txtTenGiangVien.Text;
                string matkhau = txtMatKhauGiangVien.Text;
                GiangVienService.CapNhapGiangVien(id, email, hoten, matkhau);
                
                MessageBox.Show("Cập nhật thành công!");
                frmAdmin_Load(sender, e);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         
        }

        private void btnNhapMotGiangVien_Click(object sender, EventArgs e)
        {
            ThemMotGiangVien themMot = new ThemMotGiangVien(this);
            themMot.ShowDialog();
        }

        private void btnXoaMotGiangVien_Click(object sender, EventArgs e)
        {
            dgvDanhSachGiangVien.CurrentRow.Selected = true;
            int id = int.Parse(dgvDanhSachGiangVien.SelectedRows[0].Cells["ID"].Value.ToString());
            try
            {
                GiangVienService.Delete(id);
                MessageBox.Show("Xóa thành công !!!");
                dgvDanhSachGiangVien.DataSource = GiangVienService.GetGIANGVIENs();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiemGiangVien_TextChanged(object sender, EventArgs e)
        {
            string tengv = txtTimKiemGiangVien.Text.Trim();
            if (tengv == "")
            {
                frmAdmin_Load(sender, e);
            }
            else
            {
                dgvDanhSachGiangVien.DataSource  = GiangVienService.FindName(tengv);
            }
        }

        private void btnNhapExcelSinhVien_Click(object sender, EventArgs e)
        {
            NhapExcelSinhVien nhapExcelSinhVien = new NhapExcelSinhVien(this);
            nhapExcelSinhVien.ShowDialog();
        }

        private void btnThemMotSinhVien_Click(object sender, EventArgs e)
        {
            ThemMotSinhVien themMotSinhVien = new ThemMotSinhVien(this);
            themMotSinhVien.ShowDialog();
        }

        private void btnXoaMotSinhVien_Click(object sender, EventArgs e)
        {
            dgvDanhSachSinhVien.CurrentRow.Selected = true;
            int id = int.Parse(dgvDanhSachSinhVien.SelectedRows[0].Cells["ID"].Value.ToString());
            try
            {
                SinhVienService.Delete(id);
                MessageBox.Show("Xóa thành công !!!");
                dgvDanhSachSinhVien.DataSource = SinhVienService.GetSINHVIENs();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhapSV_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgvDanhSachSinhVien.SelectedRows[0].Cells["ID"].Value.ToString());
                // ...existing code...
                string hoten = txtTenSinhVien.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
