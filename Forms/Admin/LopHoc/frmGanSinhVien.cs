using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.LopHoc
{
    public partial class frmGanSinhVien : Form
    {
        private readonly LopHocService LopHocService;
        private readonly long _maLop;
        private readonly string _tenLop;
        private List<NguoiDung> _sinhVienChuaGan;
        private List<NguoiDung> _sinhVienDaGan;

        public frmGanSinhVien(long maLop, string tenLop)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            LopHocService = new LopHocService();
            _maLop = maLop;
            _tenLop = tenLop;
        }

        private void frmGanSinhVien_Load(object sender, EventArgs e)
        {
            lblTenLop.Text = $"- {_tenLop}";
            LoadData();
        }

        private void LoadData()
        {
            LoadSinhVienChuaGan();
            LoadSinhVienDaGan();
        }

        private void LoadSinhVienChuaGan(string keyword = "")
        {
            _sinhVienChuaGan = LopHocService.GetSinhVienChuaThuocLop(_maLop);
            
            if (!string.IsNullOrEmpty(keyword))
            {
                _sinhVienChuaGan = _sinhVienChuaGan
                    .Where(sv => sv.HoTen.ToLower().Contains(keyword.ToLower()) || 
                                 sv.Email.ToLower().Contains(keyword.ToLower()))
                    .ToList();
            }

            dgvSinhVienChuaGan.Rows.Clear();
            foreach (var sv in _sinhVienChuaGan)
            {
                int index = dgvSinhVienChuaGan.Rows.Add();
                dgvSinhVienChuaGan.Rows[index].Cells["colChuaGanChon"].Value = false;
                dgvSinhVienChuaGan.Rows[index].Cells["colChuaGanId"].Value = sv.Id;
                dgvSinhVienChuaGan.Rows[index].Cells["colChuaGanHoTen"].Value = sv.HoTen;
                dgvSinhVienChuaGan.Rows[index].Cells["colChuaGanEmail"].Value = sv.Email;
            }
        }

        private void LoadSinhVienDaGan(string keyword = "")
        {
            _sinhVienDaGan = LopHocService.GetSinhVienInLop(_maLop);
            
            if (!string.IsNullOrEmpty(keyword))
            {
                _sinhVienDaGan = _sinhVienDaGan
                    .Where(sv => sv.HoTen.ToLower().Contains(keyword.ToLower()) || 
                                 sv.Email.ToLower().Contains(keyword.ToLower()))
                    .ToList();
            }

            dgvSinhVienDaGan.Rows.Clear();
            foreach (var sv in _sinhVienDaGan)
            {
                int index = dgvSinhVienDaGan.Rows.Add();
                dgvSinhVienDaGan.Rows[index].Cells["colDaGanChon"].Value = false;
                dgvSinhVienDaGan.Rows[index].Cells["colDaGanId"].Value = sv.Id;
                dgvSinhVienDaGan.Rows[index].Cells["colDaGanHoTen"].Value = sv.HoTen;
                dgvSinhVienDaGan.Rows[index].Cells["colDaGanEmail"].Value = sv.Email;
            }
        }

        private void txtTimKiemChuaGan_TextChanged(object sender, EventArgs e)
        {
            LoadSinhVienChuaGan(txtTimKiemChuaGan.Text.Trim());
        }

        private void txtTimKiemDaGan_TextChanged(object sender, EventArgs e)
        {
            LoadSinhVienDaGan(txtTimKiemDaGan.Text.Trim());
        }

        private void btnGanVaoLop_Click(object sender, EventArgs e)
        {
            try
            {
                List<long> selectedIds = new List<long>();
                
                foreach (DataGridViewRow row in dgvSinhVienChuaGan.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row.Cells["colChuaGanChon"].Value ?? false);
                    if (isChecked)
                    {
                        long id = Convert.ToInt64(row.Cells["colChuaGanId"].Value);
                        selectedIds.Add(id);
                    }
                }

                if (selectedIds.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sinh viên!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int count = LopHocService.AddMultipleSinhVienToLop(_maLop, selectedIds);
                MessageBox.Show($"Đã gán {count} sinh viên vào lớp!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaKhoiLop_Click(object sender, EventArgs e)
        {
            try
            {
                List<long> selectedIds = new List<long>();
                
                foreach (DataGridViewRow row in dgvSinhVienDaGan.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row.Cells["colDaGanChon"].Value ?? false);
                    if (isChecked)
                    {
                        long id = Convert.ToInt64(row.Cells["colDaGanId"].Value);
                        selectedIds.Add(id);
                    }
                }

                if (selectedIds.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sinh viên!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc muốn xóa {selectedIds.Count} sinh viên khỏi lớp?", 
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int count = 0;
                    foreach (var id in selectedIds)
                    {
                        if (LopHocService.RemoveSinhVienFromLop(_maLop, id))
                            count++;
                    }
                    
                    MessageBox.Show($"Đã xóa {count} sinh viên khỏi lớp!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
