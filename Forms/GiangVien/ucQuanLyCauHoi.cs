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
    public partial class ucQuanLyCauHoi : UserControl
    {
        private readonly CauHoiService _cauHoiService;
        private readonly MonHocService _monHocService;
        private readonly AppDbContext _context;
        private NguoiDung _nguoiDung;
        private List<CauHoiThi> _allCauHoi;
        private readonly ToolTip _chuongToolTip = new ToolTip();

        public ucQuanLyCauHoi()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            _cauHoiService = new CauHoiService();
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

            List<MonHoc> monHocs;

            // Giảng viên chỉ thấy các môn đã được phân công
            if (_nguoiDung != null && _nguoiDung.MaVaiTro == 2)
            {
                var monIds = _context.PhanCongGiangDay
                    .Where(p => p.MaGiangVien == _nguoiDung.Id)
                    .Select(p => p.MaMon)
                    .Distinct()
                    .ToList();

                monHocs = monIds.Count == 0
                    ? new List<MonHoc>()
                    : _context.MonHoc
                        .Where(m => monIds.Contains(m.Id))
                        .OrderBy(m => m.Id)
                        .ToList();
            }
            else
            {
                monHocs = _monHocService.GetThongTinMonThi() ?? new List<MonHoc>();
                monHocs = monHocs.OrderBy(m => m.Id).ToList();
            }

            foreach (var mh in monHocs)
            {
                cboMonHoc.Items.Add(mh);
            }

            cboMonHoc.SelectedIndex = 0;
            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "Id";

            LoadChuong();
        }

        private void LoadChuong()
        {
            if (cboChuong == null) return;

            cboChuong.Items.Clear();
            cboChuong.Items.Add("-- Tất cả chương --");

            long? maMon = null;
            if (cboMonHoc != null && cboMonHoc.SelectedIndex > 0 && cboMonHoc.SelectedItem is MonHoc mh)
            {
                maMon = mh.Id;
            }

            if (maMon.HasValue)
            {
                var chuongs = _context.ChuongMonHoc
                    .Where(c => c.MaMon == maMon.Value)
                    .OrderBy(c => c.Id)
                    .ToList();

                foreach (var c in chuongs)
                {
                    cboChuong.Items.Add(c);
                }
            }

            cboChuong.DisplayMember = "TenChuong";
            cboChuong.ValueMember = "Id";
            cboChuong.SelectedIndex = 0;

            ApplyChuongComboUx();
        }

        private void ApplyChuongComboUx()
        {
            if (cboChuong == null) return;

            AutoSizeComboDropDownWidth(
                cboChuong,
                item => item is ChuongMonHoc c ? c.TenChuong : item?.ToString() ?? string.Empty,
                maxWidth: 800
            );

            UpdateChuongToolTip();
        }

        private void UpdateChuongToolTip()
        {
            if (cboChuong == null) return;
            _chuongToolTip.SetToolTip(cboChuong, cboChuong.Text);
        }

        private static void AutoSizeComboDropDownWidth(ComboBox combo, Func<object, string> getItemText, int maxWidth)
        {
            if (combo == null) return;

            var current = combo.DropDownWidth;
            var widest = current;

            foreach (var raw in combo.Items)
            {
                var text = getItemText?.Invoke(raw) ?? raw?.ToString() ?? string.Empty;
                var w = TextRenderer.MeasureText(text, combo.Font).Width;
                if (w > widest) widest = w;
            }

            widest += SystemInformation.VerticalScrollBarWidth + 30;
            if (widest < current) widest = current;
            if (widest > maxWidth) widest = maxWidth;

            combo.DropDownWidth = widest;
        }

        private void LoadData()
        {
            try
            {
                _allCauHoi = _context.CauHoiThi
                    .Where(c => c.TrangThai && (_nguoiDung == null || c.NguoiTao == _nguoiDung.Id))
                    .ToList();

                // Load lựa chọn cho mỗi câu hỏi
                foreach (var ch in _allCauHoi)
                {
                    ch.LuaChonTracNghiems = _context.LuaChonTracNghiem
                        .Where(l => l.MaCauHoi == ch.Id)
                        .ToList();

                    ch.MonHoc = _context.MonHoc.FirstOrDefault(m => m.Id == ch.MaMon);
                    if (ch.MaChuong.HasValue)
                    {
                        ch.ChuongMonHoc = _context.ChuongMonHoc.FirstOrDefault(c => c.Id == ch.MaChuong.Value);
                    }
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
            if (dgvCauHoi == null) return;
            dgvCauHoi.Rows.Clear();
            if (_allCauHoi == null) return;

            var filtered = _allCauHoi;

            // Lọc theo môn học
            if (cboMonHoc != null && cboMonHoc.SelectedIndex > 0 && cboMonHoc.SelectedItem is MonHoc monHoc)
            {
                filtered = filtered.Where(c => c.MaMon == monHoc.Id).ToList();
            }

            // Lọc theo chương
            if (cboChuong != null && cboChuong.SelectedIndex > 0 && cboChuong.SelectedItem is ChuongMonHoc chuong)
            {
                filtered = filtered.Where(c => c.MaChuong == chuong.Id).ToList();
            }

            // Lọc theo từ khóa
            if (txtTimKiem != null)
            {
                string keyword = txtTimKiem.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(keyword))
                {
                    filtered = filtered.Where(c => c.NoiDung.ToLower().Contains(keyword)).ToList();
                }
            }

            filtered = filtered.OrderBy(c => c.Id).ToList();

            foreach (var item in filtered)
            {
                int index = dgvCauHoi.Rows.Add();
                dgvCauHoi.Rows[index].Cells["colId"].Value = item.Id;
                dgvCauHoi.Rows[index].Cells["colNoiDung"].Value = item.NoiDung.Length > 80
                    ? item.NoiDung.Substring(0, 80) + "..."
                    : item.NoiDung;
                dgvCauHoi.Rows[index].Cells["colMonHoc"].Value = item.MonHoc?.TenMon ?? "N/A";
                dgvCauHoi.Rows[index].Cells["colSoLuaChon"].Value = item.LuaChonTracNghiems?.Count ?? 0;
                dgvCauHoi.Rows[index].Cells["colNgayTao"].Value = item.NgayTao.ToString("dd/MM/yyyy");
            }
        }

        private void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChuong();
            FilterData();
        }

        private void cboChuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
            UpdateChuongToolTip();
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

            var frm = new frmThemSuaCauHoi(_nguoiDung);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (_nguoiDung == null)
            {
                MessageBox.Show("Vui lòng đăng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frm = new frmImportCauHoi(_nguoiDung);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void dgvCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var columnName = dgvCauHoi.Columns[e.ColumnIndex].Name;
            var id = Convert.ToInt64(dgvCauHoi.Rows[e.RowIndex].Cells["colId"].Value);

            if (columnName == "colSua")
            {
                var cauHoi = _cauHoiService.GetById(id);
                if (cauHoi != null)
                {
                    var frm = new frmThemSuaCauHoi(_nguoiDung, cauHoi);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else if (columnName == "colXoa")
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa câu hỏi này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (_cauHoiService.Delete(id))
                    {
                        MessageBox.Show("Xóa câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa câu hỏi! Câu hỏi có thể đang được sử dụng trong kỳ thi.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
