using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    public partial class ucKetQuaThi : UserControl
    {
        private readonly AppDbContext _context;
        private NguoiDung _nguoiDung;
        private List<KyThi> _kyThiList;

        public ucKetQuaThi()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            _context = new AppDbContext();
        }

        public void SetNguoiDung(NguoiDung nguoiDung)
        {
            _nguoiDung = nguoiDung;
            LoadKyThiFilter();
            LoadData();
        }

        private void LoadKyThiFilter()
        {
            try
            {
                // Lấy các kỳ thi thuộc ngân hàng đề của giáo viên
                var nganHangDeIds = _context.NganHangDe
                    .Where(n => n.NguoiTao == _nguoiDung.Id)
                    .Select(n => n.Id)
                    .ToList();

                _kyThiList = _context.KyThi
                    .Include(k => k.LopHoc)
                    .Include(k => k.NganHangDe)
                        .ThenInclude(n => n.MonHoc)
                    .Where(k => nganHangDeIds.Contains(k.MaNganHangDe ?? 0))
                    .OrderByDescending(k => k.NgayTao)
                    .ToList();

                cboKyThi.Items.Clear();
                cboKyThi.Items.Add("-- Tất cả kỳ thi --");
                foreach (var kt in _kyThiList)
                {
                    string tenLop = kt.LopHoc?.TenLop ?? "";
                    cboKyThi.Items.Add($"{kt.TenKyThi} - {tenLop}");
                }
                cboKyThi.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách kỳ thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                dgvKetQua.Rows.Clear();

                // Lấy danh sách kỳ thi của giáo viên
                var nganHangDeIds = _context.NganHangDe
                    .Where(n => n.NguoiTao == _nguoiDung.Id)
                    .Select(n => n.Id)
                    .ToList();

                var kyThiIds = _context.KyThi
                    .Where(k => nganHangDeIds.Contains(k.MaNganHangDe ?? 0))
                    .Select(k => k.Id)
                    .ToList();

                // Lọc theo kỳ thi được chọn
                if (cboKyThi.SelectedIndex > 0)
                {
                    var selectedKyThi = _kyThiList[cboKyThi.SelectedIndex - 1];
                    kyThiIds = new List<long> { selectedKyThi.Id };
                }

                // Lấy tất cả bài thi đã nộp
                var baiThiList = _context.BaiThi
                    .Include(b => b.SinhVien)
                    .Include(b => b.KyThi)
                        .ThenInclude(k => k.LopHoc)
                    .Include(b => b.KyThi)
                        .ThenInclude(k => k.NganHangDe)
                            .ThenInclude(n => n.MonHoc)
                    .Where(b => kyThiIds.Contains(b.MaKyThi ?? 0)
                                && (b.TrangThai == "da_nop" || b.TrangThai == "cham_diem"))
                    .OrderByDescending(b => b.ThoiGianNopBai)
                    .ToList();

                // Lọc theo từ khóa
                string keyword = txtTimKiem.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(keyword))
                {
                    baiThiList = baiThiList.Where(b =>
                        (b.SinhVien?.HoTen?.ToLower().Contains(keyword) ?? false) ||
                        (b.SinhVien?.Email?.ToLower().Contains(keyword) ?? false) ||
                        (b.KyThi?.TenKyThi?.ToLower().Contains(keyword) ?? false)
                    ).ToList();
                }

                int stt = 1;
                foreach (var bt in baiThiList)
                {
                    int index = dgvKetQua.Rows.Add();
                    dgvKetQua.Rows[index].Cells["colSTT"].Value = stt++;
                    dgvKetQua.Rows[index].Cells["colHoTen"].Value = bt.SinhVien?.HoTen ?? "N/A";
                    dgvKetQua.Rows[index].Cells["colEmail"].Value = bt.SinhVien?.Email ?? "N/A";
                    dgvKetQua.Rows[index].Cells["colKyThi"].Value = bt.KyThi?.TenKyThi ?? "N/A";
                    dgvKetQua.Rows[index].Cells["colLopHoc"].Value = bt.KyThi?.LopHoc?.TenLop ?? "N/A";
                    dgvKetQua.Rows[index].Cells["colMonHoc"].Value = bt.KyThi?.NganHangDe?.MonHoc?.TenMon ?? "N/A";
                    dgvKetQua.Rows[index].Cells["colDiem"].Value = bt.DiemSo?.ToString() ?? "—";
                    dgvKetQua.Rows[index].Cells["colThoiGianNop"].Value = bt.ThoiGianNopBai?.ToString("dd/MM/yyyy HH:mm") ?? "—";

                    // Kết quả: hiển thị điểm
                    string trangThai;
                    if (bt.DiemSo == null)
                        trangThai = "⏳ Chưa chấm";
                    else
                        trangThai = $"{bt.DiemSo}/10";
                    dgvKetQua.Rows[index].Cells["colTrangThai"].Value = trangThai;

                    // Đếm vi phạm - tìm theo bài thi ID hoặc theo sinh viên + kỳ thi
                    int tongViPham = _context.NhatKyViPham
                        .Where(v => v.MaBaiThi == bt.Id)
                        .Sum(v => (int?)v.SoLanViPham) ?? 0;
                    dgvKetQua.Rows[index].Cells["colViPham"].Value = tongViPham > 0 ? $"⚠ {tongViPham}" : "0";

                    // Tô màu hàng theo kết quả
                    if (bt.DiemSo != null && bt.DiemSo < 5)
                        dgvKetQua.Rows[index].DefaultCellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                    if (tongViPham > 0)
                        dgvKetQua.Rows[index].Cells["colViPham"].Style.ForeColor = Color.FromArgb(255, 152, 0);
                }

                lblTongSo.Text = $"Tổng số: {baiThiList.Count} bài thi";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu kết quả thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboKyThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
