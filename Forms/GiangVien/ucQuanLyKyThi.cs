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
    public partial class ucQuanLyKyThi : UserControl
    {
        private readonly KyThiService _kyThiService;
        private readonly NganHangDeService _nganHangDeService;
        private readonly AppDbContext _context;
        private NguoiDung _nguoiDung;
        private List<KyThi> _allKyThi;

        public ucQuanLyKyThi()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            _kyThiService = new KyThiService();
            _nganHangDeService = new NganHangDeService();
            _context = new AppDbContext();
        }

        public void SetNguoiDung(NguoiDung nguoiDung)
        {
            _nguoiDung = nguoiDung;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Lấy tất cả kỳ thi từ ngân hàng đề của giáo viên
                var nganHangDeIds = _context.NganHangDe
                    .Where(n => n.NguoiTao == _nguoiDung.Id)
                    .Select(n => n.Id)
                    .ToList();

                _allKyThi = _context.KyThi
                    .Where(k => nganHangDeIds.Contains(k.MaNganHangDe ?? 0))
                    .OrderBy(k => k.Id)
                    .ToList();

                // Load thêm thông tin liên quan
                foreach (var kt in _allKyThi)
                {
                    kt.NganHangDe = _context.NganHangDe.FirstOrDefault(n => n.Id == kt.MaNganHangDe);
                    kt.LopHoc = _context.LopHoc.FirstOrDefault(l => l.Id == kt.MaLop);
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
            dgvKyThi.Rows.Clear();
            var filtered = _allKyThi;

            // Lọc theo từ khóa
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(k => k.TenKyThi.ToLower().Contains(keyword)).ToList();
            }

            // Lọc theo trạng thái
            if (cboTrangThai.SelectedIndex > 0)
            {
                var now = DateTime.Now;
                switch (cboTrangThai.SelectedIndex)
                {
                    case 1: // Sắp diễn ra
                        filtered = filtered.Where(k => k.ThoiGianBatDau > now).ToList();
                        break;
                    case 2: // Đang diễn ra
                        filtered = filtered.Where(k => k.ThoiGianBatDau <= now && k.ThoiGianKetThuc >= now).ToList();
                        break;
                    case 3: // Đã kết thúc
                        filtered = filtered.Where(k => k.ThoiGianKetThuc < now).ToList();
                        break;
                }
            }

            filtered = filtered.OrderBy(k => k.Id).ToList();

            foreach (var item in filtered)
            {
                int index = dgvKyThi.Rows.Add();
                dgvKyThi.Rows[index].Cells["colId"].Value = item.Id;
                dgvKyThi.Rows[index].Cells["colTenKyThi"].Value = item.TenKyThi;
                dgvKyThi.Rows[index].Cells["colKhungDe"].Value = item.NganHangDe?.TenDe ?? "N/A";
                dgvKyThi.Rows[index].Cells["colLopHoc"].Value = item.LopHoc?.TenLop ?? "N/A";
                dgvKyThi.Rows[index].Cells["colThoiGianBD"].Value = item.ThoiGianBatDau.ToString("dd/MM/yyyy HH:mm");
                dgvKyThi.Rows[index].Cells["colThoiLuong"].Value = item.ThoiLuongPhut + " phút";

                // Trạng thái
                string trangThai;
                var now = DateTime.Now;
                if (item.ThoiGianBatDau > now)
                    trangThai = "⏳ Sắp tới";
                else if (item.ThoiGianKetThuc < now)
                    trangThai = "✅ Đã xong";
                else
                    trangThai = "🔴 Đang thi";
                dgvKyThi.Rows[index].Cells["colTrangThai"].Value = trangThai;
            }

            lblTongSo.Text = $"Tổng số: {filtered.Count} kỳ thi";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
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

            var frm = new frmThemSuaKyThi(_nguoiDung);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void dgvKyThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var columnName = dgvKyThi.Columns[e.ColumnIndex].Name;
            var id = Convert.ToInt64(dgvKyThi.Rows[e.RowIndex].Cells["colId"].Value);

            if (columnName == "colSua")
            {
                var kyThi = _kyThiService.GetById(id);
                if (kyThi != null)
                {
                    // Kiểm tra có sinh viên nào đã thi chưa
                    var hasBaiThi = _context.BaiThi.Any(b => b.MaKyThi == id && b.TrangThai != "chua_thi");
                    if (hasBaiThi)
                    {
                        MessageBox.Show("Không thể sửa kỳ thi đã có sinh viên làm bài!", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var frm = new frmThemSuaKyThi(_nguoiDung, kyThi);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else if (columnName == "colXoa")
            {
                // Kiểm tra có sinh viên nào đã thi chưa để cảnh báo
                var soBaiThi = _context.BaiThi.Count(b => b.MaKyThi == id && b.TrangThai != "chua_thi");

                string thongBao;
                if (soBaiThi > 0)
                    thongBao = $"Kỳ thi này đã có {soBaiThi} sinh viên làm bài!\nXóa sẽ mất toàn bộ dữ liệu bài thi, điểm và vi phạm.\n\nBạn có chắc chắn muốn xóa?";
                else
                    thongBao = "Bạn có chắc chắn muốn xóa kỳ thi này?";

                var result = MessageBox.Show(thongBao, "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (_kyThiService.Delete(id))
                    {
                        MessageBox.Show("Xóa kỳ thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa kỳ thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (columnName == "colThongKe")
            {
                var frm = new frmThongKeKyThi(id);
                frm.ShowDialog();
            }
        }
    }
}
