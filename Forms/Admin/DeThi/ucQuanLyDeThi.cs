using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.DeThi
{
    public partial class ucQuanLyDeThi : UserControl
    {
        private readonly AppDbContext _context;
        private readonly NganHangDeService _nganHangDeService;

        public ucQuanLyDeThi()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            _context = new AppDbContext();
            _nganHangDeService = new NganHangDeService();
        }

        private void ucQuanLyDeThi_Load(object sender, EventArgs e)
        {
            LoadDeThi();
        }

        private void LoadDeThi()
        {
            try
            {
                var list = _context.NganHangDe
                    .Select(n => new
                    {
                        n.Id,
                        n.TenDe,
                        TenMon = n.MonHoc != null ? n.MonHoc.TenMon : "",
                        n.TongSoCau,
                        n.NgayTao
                    })
                    .ToList();

                dgvDeThi.DataSource = list;

                if (dgvDeThi.Columns.Count > 0)
                {
                    if (dgvDeThi.Columns.Contains("Id"))
                        dgvDeThi.Columns["Id"].HeaderText = "ID";
                    if (dgvDeThi.Columns.Contains("TenDe"))
                        dgvDeThi.Columns["TenDe"].HeaderText = "Tên đề";
                    if (dgvDeThi.Columns.Contains("TenMon"))
                        dgvDeThi.Columns["TenMon"].HeaderText = "Môn học";
                    if (dgvDeThi.Columns.Contains("TongSoCau"))
                        dgvDeThi.Columns["TongSoCau"].HeaderText = "Tổng số câu";
                    if (dgvDeThi.Columns.Contains("NgayTao"))
                        dgvDeThi.Columns["NgayTao"].HeaderText = "Ngày tạo";

                    // Di chuyển cột thao tác về cuối
                    if (dgvDeThi.Columns.Contains("colSua"))
                        dgvDeThi.Columns["colSua"].DisplayIndex = dgvDeThi.Columns.Count - 2;
                    if (dgvDeThi.Columns.Contains("colXoa"))
                        dgvDeThi.Columns["colXoa"].DisplayIndex = dgvDeThi.Columns.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đề thi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadDeThi();
                return;
            }

            try
            {
                var list = _context.NganHangDe
                    .Where(n => n.TenDe.ToLower().Contains(keyword))
                    .Select(n => new
                    {
                        n.Id,
                        n.TenDe,
                        TenMon = n.MonHoc != null ? n.MonHoc.TenMon : "",
                        n.TongSoCau,
                        n.NgayTao
                    })
                    .ToList();

                dgvDeThi.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng thêm đề thi đang được phát triển.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvDeThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            long id = Convert.ToInt64(dgvDeThi.Rows[e.RowIndex].Cells["Id"].Value);

            if (dgvDeThi.Columns[e.ColumnIndex].Name == "colXoa")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa đề thi này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (_nganHangDeService.Delete(id))
                        {
                            LoadDeThi();
                            MessageBox.Show("Xóa thành công!", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa đề thi!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
