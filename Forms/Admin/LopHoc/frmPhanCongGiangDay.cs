using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.LopHoc
{
    public partial class frmPhanCongGiangDay : Form
    {
        private readonly LopHocService LopHocService;
        private readonly long _maLop;
        private readonly string _tenLop;
        private List<Models.MonHoc> _monHocs;
        private List<NguoiDung> _giangViens;

        public frmPhanCongGiangDay(long maLop, string tenLop)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            LopHocService = new LopHocService();
            _maLop = maLop;
            _tenLop = tenLop;
        }

        private void frmPhanCongGiangDay_Load(object sender, EventArgs e)
        {
            lblTenLop.Text = $"- {_tenLop}";
            LoadComboBoxes();
            LoadPhanCong();
        }

        private void LoadComboBoxes()
        {
            // Load môn học
            _monHocs = LopHocService.GetAllMonHoc();
            cboMonHoc.Items.Clear();
            cboMonHoc.Items.Add("-- Chọn môn học --");
            foreach (var mon in _monHocs)
            {
                cboMonHoc.Items.Add(mon.TenMon);
            }
            cboMonHoc.SelectedIndex = 0;

            // Load giảng viên
            _giangViens = LopHocService.GetAllGiangVien();
            cboGiangVien.Items.Clear();
            cboGiangVien.Items.Add("-- Chọn giảng viên --");
            foreach (var gv in _giangViens)
            {
                cboGiangVien.Items.Add($"{gv.HoTen} ({gv.Email})");
            }
            cboGiangVien.SelectedIndex = 0;
        }

        private void LoadPhanCong()
        {
            var phanCongs = LopHocService.GetPhanCongByLop(_maLop);
            
            dgvPhanCong.Rows.Clear();
            foreach (var pc in phanCongs)
            {
                int index = dgvPhanCong.Rows.Add();
                dgvPhanCong.Rows[index].Cells["colMaLop"].Value = pc.MaLop;
                dgvPhanCong.Rows[index].Cells["colMaMon"].Value = pc.MaMon;
                dgvPhanCong.Rows[index].Cells["colTenMon"].Value = pc.MonHoc?.TenMon ?? "";
                dgvPhanCong.Rows[index].Cells["colTenGiangVien"].Value = pc.GiangVien?.HoTen ?? "(Chưa phân công)";
                dgvPhanCong.Rows[index].Cells["colNgayPhanCong"].Value = pc.NgayPhanCong.ToString("dd/MM/yyyy");
            }
        }

        private void btnThemPhanCong_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMonHoc.SelectedIndex <= 0)
                {
                    MessageBox.Show("Vui lòng chọn môn học!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                long maMon = _monHocs[cboMonHoc.SelectedIndex - 1].Id;
                long? maGiangVien = null;
                
                if (cboGiangVien.SelectedIndex > 0)
                {
                    maGiangVien = _giangViens[cboGiangVien.SelectedIndex - 1].Id;
                }

                if (LopHocService.AddPhanCong(_maLop, maMon, maGiangVien))
                {
                    MessageBox.Show("Thêm/Cập nhật phân công thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhanCong();
                    
                    // Reset combobox
                    cboMonHoc.SelectedIndex = 0;
                    cboGiangVien.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Không thể thêm phân công!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPhanCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPhanCong.Columns[e.ColumnIndex].Name == "colXoa")
            {
                long maMon = Convert.ToInt64(dgvPhanCong.Rows[e.RowIndex].Cells["colMaMon"].Value);
                string tenMon = dgvPhanCong.Rows[e.RowIndex].Cells["colTenMon"].Value?.ToString();

                if (MessageBox.Show($"Bạn có chắc muốn xóa phân công môn '{tenMon}'?", 
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (LopHocService.DeletePhanCong(_maLop, maMon))
                        {
                            MessageBox.Show("Xóa phân công thành công!", "Thông báo");
                            LoadPhanCong();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa phân công!", "Lỗi", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
