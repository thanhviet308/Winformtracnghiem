using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    public partial class frmThemSuaKhungDe : Form
    {
        private readonly MonHocService _monHocService;
        private readonly NganHangDeService _nganHangDeService;
        private readonly AppDbContext _context;
        private NguoiDung _nguoiDung;
        private NganHangDe _nganHangDe;
        private bool _isEdit = false;

        public frmThemSuaKhungDe(NguoiDung nguoiDung, NganHangDe nganHangDe = null)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            _monHocService = new MonHocService();
            _nganHangDeService = new NganHangDeService();
            _context = new AppDbContext();
            _nguoiDung = nguoiDung;
            _nganHangDe = nganHangDe;
            _isEdit = nganHangDe != null;

            LoadMonHoc();

            if (_isEdit)
            {
                lblTitle.Text = "✏️ SỬA KHUNG ĐỀ THI";
                LoadKhungDe();
            }
        }

        private void LoadMonHoc()
        {
            cboMonHoc.Items.Clear();
            var monHocs = _monHocService.GetThongTinMonThi();
            foreach (var mh in monHocs)
            {
                cboMonHoc.Items.Add(mh);
            }
            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "Id";

            if (monHocs.Count > 0)
                cboMonHoc.SelectedIndex = 0;

            UpdateCauHoiCount();
        }

        private void LoadKhungDe()
        {
            if (_nganHangDe == null) return;

            txtTenDe.Text = _nganHangDe.TenDe;
            numTongSoCau.Value = _nganHangDe.TongSoCau;

            // Load môn học
            for (int i = 0; i < cboMonHoc.Items.Count; i++)
            {
                if (cboMonHoc.Items[i] is MonHoc mh && mh.Id == _nganHangDe.MaMon)
                {
                    cboMonHoc.SelectedIndex = i;
                    break;
                }
            }
        }

        private void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCauHoiCount();
        }

        private void UpdateCauHoiCount()
        {
            if (cboMonHoc.SelectedItem is MonHoc monHoc)
            {
                int count = _nganHangDeService.CountCauHoiByMonHoc(monHoc.Id);
                lblSoCauHoiHienCo.Text = $"Số câu hỏi hiện có trong ngân hàng: {count}";
                lblSoCauHoiHienCo.ForeColor = count > 0 
                    ? System.Drawing.Color.FromArgb(0, 192, 144) 
                    : System.Drawing.Color.FromArgb(255, 82, 82);
            }
        }

        private bool ValidateInput()
        {
            if (cboMonHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMonHoc.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenDe.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khung đề!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDe.Focus();
                return false;
            }

            if (numTongSoCau.Value < 1)
            {
                MessageBox.Show("Số câu hỏi phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numTongSoCau.Focus();
                return false;
            }

            // Kiểm tra số câu hỏi có đủ không
            var monHoc = (MonHoc)cboMonHoc.SelectedItem;
            int soCauHoiHienCo = _nganHangDeService.CountCauHoiByMonHoc(monHoc.Id);
            if (numTongSoCau.Value > soCauHoiHienCo)
            {
                MessageBox.Show($"Số câu hỏi yêu cầu ({numTongSoCau.Value}) vượt quá số câu hỏi hiện có ({soCauHoiHienCo})!", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                var monHoc = (MonHoc)cboMonHoc.SelectedItem;

                if (_isEdit)
                {
                    // Cập nhật khung đề
                    _nganHangDe.TenDe = txtTenDe.Text.Trim();
                    _nganHangDe.MaMon = monHoc.Id;
                    _nganHangDe.TongSoCau = (int)numTongSoCau.Value;

                    if (_nganHangDeService.Update(_nganHangDe))
                    {
                        MessageBox.Show("Cập nhật khung đề thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật khung đề!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Thêm khung đề mới
                    var nganHangDe = new NganHangDe
                    {
                        TenDe = txtTenDe.Text.Trim(),
                        MaMon = monHoc.Id,
                        TongSoCau = (int)numTongSoCau.Value,
                        NguoiTao = _nguoiDung.Id,
                        NgayTao = DateTime.Now
                    };

                    if (_nganHangDeService.Add(nganHangDe))
                    {
                        MessageBox.Show("Thêm khung đề thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm khung đề!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
