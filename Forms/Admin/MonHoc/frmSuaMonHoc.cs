using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Data;
using System.Linq;
using System;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.MonHoc
{
    public partial class frmSuaMonHoc : Form
    {
        private readonly MonHocService MonHocService;
        private readonly Models.MonHoc _monHoc;
        private readonly AppDbContext _db;
        private long _selectedChuongId;

        public frmSuaMonHoc(Models.MonHoc monHoc)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            MonHocService = new MonHocService();
            _monHoc = monHoc;
            _db = new AppDbContext();

            // Load dữ liệu
            txtTenMon.Text = monHoc.TenMon;

            _selectedChuongId = 0;
            btnSuaChuong.Enabled = false;
            btnXoaChuong.Enabled = false;
            LoadChuong();
        }

        private void LoadChuong()
        {
            try
            {
                dgvChuong.Rows.Clear();

                var chapters = _db.ChuongMonHoc
                    .Where(c => c.MaMon == _monHoc.Id)
                    .OrderBy(c => c.Id)
                    .Select(c => new { c.Id, c.TenChuong })
                    .ToList();

                foreach (var chapter in chapters)
                {
                    int idx = dgvChuong.Rows.Add();
                    dgvChuong.Rows[idx].Cells["colChuongId"].Value = chapter.Id;
                    dgvChuong.Rows[idx].Cells["colTenChuong"].Value = chapter.TenChuong;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearChuongSelection()
        {
            _selectedChuongId = 0;
            txtTenChuong.Text = "";
            btnSuaChuong.Enabled = false;
            btnXoaChuong.Enabled = false;
            dgvChuong.ClearSelection();
        }

        private void dgvChuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var idObj = dgvChuong.Rows[e.RowIndex].Cells["colChuongId"].Value;
            if (idObj == null) return;

            _selectedChuongId = Convert.ToInt64(idObj);
            txtTenChuong.Text = dgvChuong.Rows[e.RowIndex].Cells["colTenChuong"].Value?.ToString() ?? "";
            btnSuaChuong.Enabled = _selectedChuongId > 0;
            btnXoaChuong.Enabled = _selectedChuongId > 0;
        }

        private void btnThemChuong_Click(object sender, EventArgs e)
        {
            try
            {
                var ten = (txtTenChuong.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(ten))
                {
                    MessageBox.Show("Vui lòng nhập tên chương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var exists = _db.ChuongMonHoc.Any(c => c.MaMon == _monHoc.Id && c.TenChuong.ToLower() == ten.ToLower());
                if (exists)
                {
                    MessageBox.Show("Chương này đã tồn tại trong môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var chapter = new Models.ChuongMonHoc
                {
                    MaMon = _monHoc.Id,
                    TenChuong = ten,
                    NgayTao = DateTime.Now
                };

                _db.ChuongMonHoc.Add(chapter);
                _db.SaveChanges();

                LoadChuong();
                ClearChuongSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm chương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaChuong_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedChuongId <= 0)
                {
                    MessageBox.Show("Vui lòng chọn chương cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var ten = (txtTenChuong.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(ten))
                {
                    MessageBox.Show("Vui lòng nhập tên chương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var exists = _db.ChuongMonHoc.Any(c => c.MaMon == _monHoc.Id && c.Id != _selectedChuongId && c.TenChuong.ToLower() == ten.ToLower());
                if (exists)
                {
                    MessageBox.Show("Tên chương bị trùng trong môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var chapter = _db.ChuongMonHoc.FirstOrDefault(c => c.Id == _selectedChuongId && c.MaMon == _monHoc.Id);
                if (chapter == null)
                {
                    MessageBox.Show("Không tìm thấy chương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                chapter.TenChuong = ten;
                _db.SaveChanges();

                LoadChuong();
                ClearChuongSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật chương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaChuong_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedChuongId <= 0)
                {
                    MessageBox.Show("Vui lòng chọn chương cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var used = _db.CauHoiThi.Any(q => q.MaChuong == _selectedChuongId);
                if (used)
                {
                    MessageBox.Show("Không thể xóa chương vì đang có câu hỏi thuộc chương này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Bạn có chắc muốn xóa chương này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                var chapter = _db.ChuongMonHoc.FirstOrDefault(c => c.Id == _selectedChuongId && c.MaMon == _monHoc.Id);
                if (chapter == null)
                {
                    MessageBox.Show("Không tìm thấy chương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _db.ChuongMonHoc.Remove(chapter);
                _db.SaveChanges();

                LoadChuong();
                ClearChuongSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa chương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenMon.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _monHoc.TenMon = txtTenMon.Text.Trim();

                if (MonHocService.Update(_monHoc))
                {
                    MessageBox.Show("Cập nhật môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
