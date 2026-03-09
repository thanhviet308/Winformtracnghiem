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
    public partial class ucQuanLyKhungDe : UserControl
    {
        private readonly NganHangDeService _nganHangDeService;
        private readonly MonHocService _monHocService;
        private readonly AppDbContext _context;
        private NguoiDung _nguoiDung;
        private List<NganHangDe> _allNganHangDe;

        public ucQuanLyKhungDe()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            _nganHangDeService = new NganHangDeService();
            _monHocService = new MonHocService();
            _context = new AppDbContext();
        }

        public void SetNguoiDung(NguoiDung nguoiDung)
        {
            _nguoiDung = nguoiDung;
            LoadMonHoc();
            LoadData();
        }

        private void LoadMonHoc()
        {
            if (cboMonHoc == null) return;
            cboMonHoc.Items.Clear();
            cboMonHoc.Items.Add("-- Tất cả môn học --");

            var monHocs = _monHocService.GetThongTinMonThi();
            if (monHocs != null)
            {
                foreach (var mh in monHocs)
                {
                    cboMonHoc.Items.Add(mh);
                }
            }
            cboMonHoc.SelectedIndex = 0;
            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "Id";
        }

        private void LoadData()
        {
            try
            {
                if (_nguoiDung != null)
                {
                    _allNganHangDe = _nganHangDeService.GetByNguoiTao(_nguoiDung.Id);
                }
                else
                {
                    _allNganHangDe = _nganHangDeService.GetAll();
                }

                // Load thêm thông tin môn học
                foreach (var nhd in _allNganHangDe)
                {
                    nhd.MonHoc = _context.MonHoc.FirstOrDefault(m => m.Id == nhd.MaMon);
                }

                FilterData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterData()
        {
            if (dgvKhungDe == null) return;
            dgvKhungDe.Rows.Clear();
            if (_allNganHangDe == null) return;

            var filtered = _allNganHangDe;

            // Lọc theo môn học
            if (cboMonHoc != null && cboMonHoc.SelectedIndex > 0 && cboMonHoc.SelectedItem is MonHoc monHoc)
            {
                filtered = filtered.Where(n => n.MaMon == monHoc.Id).ToList();
            }

            // Lọc theo từ khóa
            if (txtTimKiem != null)
            {
                string keyword = txtTimKiem.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(keyword))
                {
                    filtered = filtered.Where(n => n.TenDe.ToLower().Contains(keyword)).ToList();
                }
            }

            foreach (var item in filtered)
            {
                int index = dgvKhungDe.Rows.Add();
                dgvKhungDe.Rows[index].Cells["colId"].Value = item.Id;
                dgvKhungDe.Rows[index].Cells["colTenDe"].Value = item.TenDe;
                dgvKhungDe.Rows[index].Cells["colMonHoc"].Value = item.MonHoc?.TenMon ?? "N/A";
                dgvKhungDe.Rows[index].Cells["colTongSoCau"].Value = item.TongSoCau;
                dgvKhungDe.Rows[index].Cells["colNgayTao"].Value = item.NgayTao.ToString("dd/MM/yyyy");
            }
        }

        private void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_nguoiDung == null)
            {
                MessageBox.Show("Vui lòng đăng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frm = new frmThemSuaKhungDe(_nguoiDung);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void dgvKhungDe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var columnName = dgvKhungDe.Columns[e.ColumnIndex].Name;
            var id = Convert.ToInt64(dgvKhungDe.Rows[e.RowIndex].Cells["colId"].Value);

            if (columnName == "colSua")
            {
                var nganHangDe = _nganHangDeService.GetById(id);
                if (nganHangDe != null)
                {
                    var frm = new frmThemSuaKhungDe(_nguoiDung, nganHangDe);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else if (columnName == "colXoa")
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa khung đề này?\n\n⚠️ Lưu ý: Không thể xóa nếu khung đề đang được sử dụng trong kỳ thi.",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (_nganHangDeService.Delete(id))
                    {
                        MessageBox.Show("Xóa khung đề thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa khung đề! Khung đề có thể đang được sử dụng trong kỳ thi.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
