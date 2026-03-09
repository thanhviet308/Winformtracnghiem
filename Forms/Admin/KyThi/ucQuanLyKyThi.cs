using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.KyThi
{
    public partial class ucQuanLyKyThi : UserControl
    {
        private readonly AppDbContext _context;
        private readonly KyThiService _kyThiService;

        public ucQuanLyKyThi()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            _context = new AppDbContext();
            _kyThiService = new KyThiService();
        }

        private void ucQuanLyKyThi_Load(object sender, EventArgs e)
        {
            LoadKyThi();
        }

        private void LoadKyThi()
        {
            try
            {
                var list = _context.KyThi
                    .Select(k => new
                    {
                        k.Id,
                        k.TenKyThi,
                        TenLop = k.LopHoc != null ? k.LopHoc.TenLop : "",
                        TenDe = k.NganHangDe != null ? k.NganHangDe.TenDe : "",
                        k.ThoiGianBatDau,
                        k.ThoiGianKetThuc,
                        k.ThoiLuongPhut,
                        k.NgayTao
                    })
                    .ToList();

                dgvKyThi.DataSource = list;

                if (dgvKyThi.Columns.Count > 0)
                {
                    if (dgvKyThi.Columns.Contains("Id"))
                        dgvKyThi.Columns["Id"].HeaderText = "ID";
                    if (dgvKyThi.Columns.Contains("TenKyThi"))
                        dgvKyThi.Columns["TenKyThi"].HeaderText = "Tên kỳ thi";
                    if (dgvKyThi.Columns.Contains("TenLop"))
                        dgvKyThi.Columns["TenLop"].HeaderText = "Lớp";
                    if (dgvKyThi.Columns.Contains("TenDe"))
                        dgvKyThi.Columns["TenDe"].HeaderText = "Đề thi";
                    if (dgvKyThi.Columns.Contains("ThoiGianBatDau"))
                        dgvKyThi.Columns["ThoiGianBatDau"].HeaderText = "Thời gian bắt đầu";
                    if (dgvKyThi.Columns.Contains("ThoiGianKetThuc"))
                        dgvKyThi.Columns["ThoiGianKetThuc"].HeaderText = "Thời gian kết thúc";
                    if (dgvKyThi.Columns.Contains("ThoiLuongPhut"))
                        dgvKyThi.Columns["ThoiLuongPhut"].HeaderText = "Thời lượng (phút)";
                    if (dgvKyThi.Columns.Contains("NgayTao"))
                        dgvKyThi.Columns["NgayTao"].HeaderText = "Ngày tạo";

                    // Di chuyển cột thao tác về cuối
                    if (dgvKyThi.Columns.Contains("colSua"))
                        dgvKyThi.Columns["colSua"].DisplayIndex = dgvKyThi.Columns.Count - 2;
                    if (dgvKyThi.Columns.Contains("colXoa"))
                        dgvKyThi.Columns["colXoa"].DisplayIndex = dgvKyThi.Columns.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách kỳ thi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadKyThi();
                return;
            }

            try
            {
                var list = _context.KyThi
                    .Where(k => k.TenKyThi.ToLower().Contains(keyword))
                    .Select(k => new
                    {
                        k.Id,
                        k.TenKyThi,
                        TenLop = k.LopHoc != null ? k.LopHoc.TenLop : "",
                        TenDe = k.NganHangDe != null ? k.NganHangDe.TenDe : "",
                        k.ThoiGianBatDau,
                        k.ThoiGianKetThuc,
                        k.ThoiLuongPhut,
                        k.NgayTao
                    })
                    .ToList();

                dgvKyThi.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng thêm kỳ thi đang được phát triển.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvKyThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            long id = Convert.ToInt64(dgvKyThi.Rows[e.RowIndex].Cells["Id"].Value);

            if (dgvKyThi.Columns[e.ColumnIndex].Name == "colXoa")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa kỳ thi này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (_kyThiService.Delete(id))
                        {
                            LoadKyThi();
                            MessageBox.Show("Xóa thành công!", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa kỳ thi!", "Lỗi",
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
