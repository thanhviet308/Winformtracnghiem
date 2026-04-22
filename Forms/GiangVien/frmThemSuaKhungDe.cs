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
        private Dictionary<long, int> _availableQuestionsByChuong = new Dictionary<long, int>();

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
            SetupCauTrucGrid();
            LoadChuongToGrid();

            if (_isEdit)
            {
                lblTitle.Text = "✏️ SỬA KHUNG ĐỀ THI";
                LoadKhungDe();
                LoadCauTrucDe();
            }
        }

        private void SetupCauTrucGrid()
        {
            if (dgvCauTruc == null) return;

            dgvCauTruc.Columns.Clear();
            dgvCauTruc.AutoGenerateColumns = false;

            var colChuong = new DataGridViewComboBoxColumn
            {
                Name = "colChuong",
                HeaderText = "Chương",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                FlatStyle = FlatStyle.Flat,
                FillWeight = 70
            };

            var colSoCau = new DataGridViewTextBoxColumn
            {
                Name = "colSoCau",
                HeaderText = "Số câu",
                FillWeight = 20
            };

            var colHienCo = new DataGridViewTextBoxColumn
            {
                Name = "colHienCo",
                HeaderText = "Hiện có",
                FillWeight = 15,
                ReadOnly = true
            };

            var colXoa = new DataGridViewButtonColumn
            {
                Name = "colXoa",
                HeaderText = "Xóa",
                Text = "Xóa",
                UseColumnTextForButtonValue = true,
                FillWeight = 10,
                FlatStyle = FlatStyle.Flat
            };

            dgvCauTruc.Columns.AddRange(colChuong, colSoCau, colHienCo, colXoa);

            dgvCauTruc.AllowUserToAddRows = true;
            dgvCauTruc.AllowUserToDeleteRows = true;
            dgvCauTruc.ReadOnly = false;

            dgvCauTruc.CellContentClick -= dgvCauTruc_CellContentClick;
            dgvCauTruc.CellContentClick += dgvCauTruc_CellContentClick;

            dgvCauTruc.CellValidating -= dgvCauTruc_CellValidating;
            dgvCauTruc.CellValidating += dgvCauTruc_CellValidating;

            dgvCauTruc.CurrentCellDirtyStateChanged -= dgvCauTruc_CurrentCellDirtyStateChanged;
            dgvCauTruc.CurrentCellDirtyStateChanged += dgvCauTruc_CurrentCellDirtyStateChanged;

            dgvCauTruc.CellValueChanged -= dgvCauTruc_CellValueChanged;
            dgvCauTruc.CellValueChanged += dgvCauTruc_CellValueChanged;

            dgvCauTruc.DataError -= dgvCauTruc_DataError;
            dgvCauTruc.DataError += dgvCauTruc_DataError;
        }

        private void dgvCauTruc_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Ignore combo binding errors to avoid annoying dialogs
            e.ThrowException = false;
        }

        private void dgvCauTruc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvCauTruc.Columns[e.ColumnIndex].Name != "colSoCau") return;

            var value = (e.FormattedValue ?? string.Empty).ToString().Trim();
            if (string.IsNullOrEmpty(value)) return;

            if (!int.TryParse(value, out var soCau) || soCau < 0)
            {
                e.Cancel = true;
                MessageBox.Show("Số câu phải là số nguyên không âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate against available questions of selected chapter in this row
            if (dgvCauTruc.Rows[e.RowIndex].Cells["colChuong"].Value is long maChuong)
            {
                var available = _availableQuestionsByChuong.TryGetValue(maChuong, out var v) ? v : 0;
                if (soCau > available)
                {
                    e.Cancel = true;
                    var tenChuong = _context.ChuongMonHoc
                        .Where(c => c.Id == maChuong)
                        .Select(c => c.TenChuong)
                        .FirstOrDefault() ?? $"ID={maChuong}";

                    MessageBox.Show(
                        $"Chương '{tenChuong}' hiện có {available} câu hỏi. Bạn đang nhập {soCau} câu nên bị vượt.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }

        private void dgvCauTruc_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCauTruc == null) return;
            if (dgvCauTruc.IsCurrentCellDirty)
            {
                dgvCauTruc.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvCauTruc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCauTruc.Columns[e.ColumnIndex].Name != "colChuong") return;
            UpdateRowAvailability(e.RowIndex);
        }

        private void UpdateRowAvailability(int rowIndex)
        {
            if (dgvCauTruc == null) return;
            if (rowIndex < 0 || rowIndex >= dgvCauTruc.Rows.Count) return;
            var row = dgvCauTruc.Rows[rowIndex];
            if (row.IsNewRow) return;

            var maChuongObj = row.Cells["colChuong"].Value;
            if (maChuongObj == null)
            {
                row.Cells["colHienCo"].Value = null;
                row.Cells["colSoCau"].ToolTipText = string.Empty;
                return;
            }

            if (!long.TryParse(maChuongObj.ToString(), out var maChuong))
            {
                row.Cells["colHienCo"].Value = null;
                row.Cells["colSoCau"].ToolTipText = string.Empty;
                return;
            }

            var available = _availableQuestionsByChuong.TryGetValue(maChuong, out var v) ? v : 0;
            row.Cells["colHienCo"].Value = available;
            row.Cells["colSoCau"].ToolTipText = $"Chương này hiện có {available} câu hỏi.";
        }

        private void dgvCauTruc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCauTruc.Columns[e.ColumnIndex].Name != "colXoa") return;
            if (dgvCauTruc.Rows[e.RowIndex].IsNewRow) return;
            dgvCauTruc.Rows.RemoveAt(e.RowIndex);
        }

        private void LoadMonHoc()
        {
            cboMonHoc.Items.Clear();

            List<MonHoc> monHocs;

            // Giảng viên chỉ được chọn các môn đã phân công
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
            }

            foreach (var mh in monHocs)
            {
                cboMonHoc.Items.Add(mh);
            }
            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "Id";

            // Nếu đang sửa và môn hiện tại không nằm trong danh sách phân công,
            // vẫn hiển thị để người dùng nhìn thấy dữ liệu hiện hữu.
            if (_isEdit && _nganHangDe != null)
            {
                var currentMon = _context.MonHoc.FirstOrDefault(m => m.Id == _nganHangDe.MaMon);
                if (currentMon != null)
                {
                    var existsInCombo = cboMonHoc.Items.Cast<object>().OfType<MonHoc>().Any(m => m.Id == currentMon.Id);
                    if (!existsInCombo)
                    {
                        cboMonHoc.Items.Insert(0, currentMon);
                    }
                }
            }

            if (cboMonHoc.Items.Count > 0)
            {
                cboMonHoc.SelectedIndex = 0;
            }

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
            LoadChuongToGrid();
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

        private void LoadChuongToGrid()
        {
            if (dgvCauTruc == null) return;
            if (cboMonHoc?.SelectedItem is not MonHoc monHoc) return;

            var chuongs = _context.ChuongMonHoc
                .Where(c => c.MaMon == monHoc.Id)
                .OrderBy(c => c.Id)
                .ToList();

            if (dgvCauTruc.Columns["colChuong"] is DataGridViewComboBoxColumn col)
            {
                col.DataSource = chuongs;
                col.DisplayMember = "TenChuong";
                col.ValueMember = "Id";
            }

            // Pre-compute availability by chapter for UX + validation
            _availableQuestionsByChuong = _context.CauHoiThi
                .Where(c => c.TrangThai && c.MaMon == monHoc.Id && c.MaChuong != null)
                .GroupBy(c => c.MaChuong!.Value)
                .Select(g => new { MaChuong = g.Key, Count = g.Count() })
                .ToDictionary(x => x.MaChuong, x => x.Count);

            // Refresh availability column for existing rows
            foreach (DataGridViewRow row in dgvCauTruc.Rows)
            {
                if (row.IsNewRow) continue;
                UpdateRowAvailability(row.Index);
            }
        }

        private void LoadCauTrucDe()
        {
            if (!_isEdit || _nganHangDe == null) return;
            if (dgvCauTruc == null) return;

            var cauTrucs = _context.CauTrucDe
                .Where(c => c.MaNganHangDe == _nganHangDe.Id && c.MaChuong != null)
                .OrderBy(c => c.Id)
                .ToList();

            dgvCauTruc.Rows.Clear();
            foreach (var ct in cauTrucs)
            {
                int idx = dgvCauTruc.Rows.Add();
                dgvCauTruc.Rows[idx].Cells["colChuong"].Value = ct.MaChuong;
                dgvCauTruc.Rows[idx].Cells["colSoCau"].Value = ct.SoCau;
                UpdateRowAvailability(idx);
            }
        }

        private List<CauTrucDe> GetCauTrucFromGrid(MonHoc monHoc)
        {
            var result = new List<CauTrucDe>();
            if (dgvCauTruc == null) return result;

            foreach (DataGridViewRow row in dgvCauTruc.Rows)
            {
                if (row.IsNewRow) continue;

                var maChuongObj = row.Cells["colChuong"].Value;
                var soCauObj = row.Cells["colSoCau"].Value;

                if (maChuongObj == null) continue;
                if (!long.TryParse(maChuongObj.ToString(), out var maChuong)) continue;

                int soCau = 0;
                if (soCauObj != null)
                {
                    int.TryParse(soCauObj.ToString(), out soCau);
                }
                if (soCau <= 0) continue;

                result.Add(new CauTrucDe
                {
                    MaMon = monHoc?.Id,
                    MaChuong = maChuong,
                    SoCau = soCau
                });
            }

            return result;
        }

        private bool ValidateInput()
        {
            if (cboMonHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMonHoc.Focus();
                return false;
            }

            if (_nguoiDung != null && _nguoiDung.MaVaiTro == 2)
            {
                if (cboMonHoc.SelectedItem is not MonHoc monHocSelected)
                {
                    MessageBox.Show("Vui lòng chọn môn học hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                var isAssigned = _context.PhanCongGiangDay.Any(p =>
                    p.MaGiangVien == _nguoiDung.Id && p.MaMon == monHocSelected.Id);

                if (!isAssigned)
                {
                    MessageBox.Show("Bạn chưa được phân công dạy môn này nên không thể tạo/sửa khung đề.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
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

            var cauTrucs = GetCauTrucFromGrid(monHoc);
            if (cauTrucs.Count > 0)
            {
                int tong = cauTrucs.Sum(c => c.SoCau);
                if (tong != (int)numTongSoCau.Value)
                {
                    MessageBox.Show($"Tổng số câu theo chương ({tong}) phải bằng Số câu hỏi ({(int)numTongSoCau.Value}).",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // validate per-chapter availability
                var requestedByChuong = cauTrucs
                    .GroupBy(c => c.MaChuong!.Value)
                    .Select(g => new { MaChuong = g.Key, Requested = g.Sum(x => x.SoCau) })
                    .ToList();

                foreach (var g in requestedByChuong)
                {
                    var available = _availableQuestionsByChuong.TryGetValue(g.MaChuong, out var v)
                        ? v
                        : _context.CauHoiThi.Count(c => c.TrangThai && c.MaMon == monHoc.Id && c.MaChuong == g.MaChuong);

                    if (g.Requested > available)
                    {
                        var tenChuong = _context.ChuongMonHoc
                            .Where(c => c.Id == g.MaChuong)
                            .Select(c => c.TenChuong)
                            .FirstOrDefault() ?? $"ID={g.MaChuong}";

                        MessageBox.Show(
                            $"Chương '{tenChuong}' hiện có {available} câu hỏi, không đủ để lấy {g.Requested} câu.",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return false;
                    }
                }
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

                    var cauTrucs = GetCauTrucFromGrid(monHoc);

                    if (_nganHangDeService.UpdateWithCauTruc(_nganHangDe, cauTrucs))
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

                    var cauTrucs = GetCauTrucFromGrid(monHoc);

                    if (_nganHangDeService.AddWithCauTruc(nganHangDe, cauTrucs))
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
