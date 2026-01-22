using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using PhanMemThiTracNghiem.Forms.Admin.DanhSachGiangVien;
using PhanMemThiTracNghiem.Forms.Admin.DanhSachSinhVien;
using PhanMemThiTracNghiem.Forms.Admin.DeThi;
using PhanMemThiTracNghiem.Forms.Admin.KyThi;
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
        private readonly NGUOIDUNG nguoiDung;
        private readonly KyThiService KyThiService;
        private readonly AppDbContext AppDbContext;
        private readonly MonThiService MonThiService;
     
        
        public frmAdmin(NGUOIDUNG nd)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            GiangVienService = new GiangVienService();
            SinhVienService = new SinhVienService();
            KyThiService = new KyThiService();
            AppDbContext = new AppDbContext();
            MonThiService = new MonThiService();
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
            labelAdmin.Text = nguoiDung.HOTEN.ToString();
            
            // Khởi tạo các tab với UserControl mới
            InitializeGiangVienTab();
            InitializeSinhVienTab();
            InitializeDeThiTab();
            InitializeKyThiTab();
            
            // Ẩn các panel không còn dùng
            guna2Panel4.Visible = false; // Panel ngày sinh giáo viên
           
            foreach (var item in KyThiService.GetKITHIs())
            {
                cbTenKiThi1.Items.Add(item.TENKITHI);
            }
            cbTenKiThi1.SelectedIndex = -1;
            foreach (var item in MonThiService.GetThongTinMonThi())
            {
                cbTenMonThi.Items.Add(item.TENMT);
            }
            cbTenMonThi.SelectedIndex = -1;
            
        }

        /// <summary>
        /// Khởi tạo tab Quản lý đề thi với UserControl mới
        /// </summary>
        private void InitializeDeThiTab()
        {
            // Ẩn các panel cũ
            guna2Panel16.Visible = false;
            guna2Panel20.Visible = false;

            // Tạo và thêm UserControl mới
            var ucQuanLyDeThi = new DeThi.ucQuanLyDeThi();
            ucQuanLyDeThi.Dock = System.Windows.Forms.DockStyle.Fill;
            tabPage3.Controls.Add(ucQuanLyDeThi);
            ucQuanLyDeThi.BringToFront();
        }

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

        /// <summary>
        /// Khởi tạo tab Quản lý kỳ thi với UserControl mới
        /// </summary>
        private void InitializeKyThiTab()
        {
            // Ẩn tất cả controls cũ trên tabPage4
            foreach (Control ctrl in tabPage4.Controls)
            {
                ctrl.Visible = false;
            }

            // Tạo và thêm UserControl mới
            var ucQuanLyKyThi = new ucQuanLyKyThi();
            ucQuanLyKyThi.Dock = System.Windows.Forms.DockStyle.Fill;
            tabPage4.Controls.Add(ucQuanLyKyThi);
            ucQuanLyKyThi.BringToFront();
        }

        private void LoadDGVKiThi(List<KITHI> listkithi)
        {
            dgvKiThi.Rows.Clear();
            foreach (var item in listkithi)
            {
                int index = dgvKiThi.Rows.Add();
                dgvKiThi.Rows[index].Cells["colSTT"].Value = item.ID;
                dgvKiThi.Rows[index].Cells["colMaKiThi"].Value = item.MAKITHI;
                dgvKiThi.Rows[index].Cells["colTenKiThi"].Value = item.TENKITHI;
                dgvKiThi.Rows[index].Cells["colThoiGianBD"].Value = item.THOIGIANBDKITHI;
                dgvKiThi.Rows[index].Cells["colThoiGianKT"].Value = item.THOIGIANKTKITHI;
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
                string email = txtMaSinhVien.Text;
                string hoten = txtTenSinhVien.Text;
                SinhVienService.CapNhapSinhVien(id, email, hoten);
                MessageBox.Show("Cập nhật thành công!");
                frmAdmin_Load(sender,e);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiemSinhVien_TextChanged(object sender, EventArgs e)
        {
            string tensv = txtTimKiemSinhVien.Text.Trim();
            if (tensv == "")
            {
                frmAdmin_Load(sender, e);
            }
            else
            {
                dgvDanhSachSinhVien.DataSource = SinhVienService.FindName(tensv);
            }
        }



      

        private void btnThemMonThi_Click(object sender, EventArgs e)
        {
            frmThemMonThi frmThemMonThi = new frmThemMonThi();
            if (frmThemMonThi.ShowDialog() == DialogResult.OK)
            {
                frmAdmin_Load(sender, e); // Reload data
            }
        }

        private void btnThemKiThi_Click_1(object sender, EventArgs e)
        {
            try
            {
                KiThiDTO kithi = new KiThiDTO();
                kithi.ID++;
                kithi.MaKiThi = txtMaKiThi.Text;
                kithi.TenKiThi = txtTenKiThi.Text;
                kithi.Admin = nguoiDung.EMAIL.ToString();
                kithi.ThoiGianBD = dateBD.Value;
                kithi.ThoiGianKT = dateKT.Value;
                frmThemChiTiet frmThemChiTiet = new frmThemChiTiet(txtMaKiThi.Text, txtTenKiThi.Text);
                frmThemChiTiet.ShowDialog();
                KyThiService.InsertUpdate(kithi);
                frmAdmin_Load(sender, e);
                MessageBox.Show("Thêm thành công!");
                txtMaKiThi.Clear();
                txtTenKiThi.Clear();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemDeThi_Click(object sender, EventArgs e)
        {
            frmThemDeThi frmThemDeThi = new frmThemDeThi();
            if (frmThemDeThi.ShowDialog() == DialogResult.OK)
            {
                frmAdmin_Load(sender, e); // Reload data
                
                // Mở chi tiết đề thi chỉnh sửa
                ChiTietDeThi chiTietDeThi = new ChiTietDeThi(frmThemDeThi.MaDeThiMoi);
                chiTietDeThi.ShowDialog();
                frmAdmin_Load(sender, e);
            }
        }

        private void dgvKiThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvKiThi.CurrentRow.Selected = true;
            txtMaKiThi.Text = dgvKiThi.Rows[e.RowIndex].Cells["colMaKiThi"].FormattedValue.ToString();
            txtTenKiThi.Text = dgvKiThi.Rows[e.RowIndex].Cells["colTenKiThi"].FormattedValue.ToString();
            dateBD.Value =DateTime.Parse( dgvKiThi.Rows[e.RowIndex].Cells["colThoiGianBD"].FormattedValue.ToString());
            dateKT.Value = DateTime.Parse(dgvKiThi.Rows[e.RowIndex].Cells["colThoiGianKT"].FormattedValue.ToString());

        }

        private void dgvKiThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string makithi = dgvKiThi.Rows[e.RowIndex].Cells["colMaKiThi"].FormattedValue.ToString();
            string tenkithi = dgvKiThi.Rows[e.RowIndex].Cells["colTenKiThi"].FormattedValue.ToString();
            frmChiTietKiThi frmChiTietKiThi = new frmChiTietKiThi(makithi,tenkithi);
            frmChiTietKiThi.ShowDialog();   
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
