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
    public partial class ucViPhamSinhVien : UserControl
    {
        private readonly AppDbContext _context;
        private NguoiDung _nguoiDung;
        private List<KyThi> _kyThiList;

        public ucViPhamSinhVien()
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
                var nganHangDeIds = _context.NganHangDe
                    .Where(n => n.NguoiTao == _nguoiDung.Id)
                    .Select(n => n.Id)
                    .ToList();

                _kyThiList = _context.KyThi
                    .Include(k => k.LopHoc)
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
                dgvViPham.Rows.Clear();

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

                // Lấy tất cả vi phạm liên quan đến bài thi trong kỳ thi của giáo viên
                var viPhamList = _context.NhatKyViPham
                    .Include(v => v.BaiThi)
                        .ThenInclude(b => b.SinhVien)
                    .Include(v => v.BaiThi)
                        .ThenInclude(b => b.KyThi)
                            .ThenInclude(k => k.LopHoc)
                    .Where(v => v.BaiThi != null && kyThiIds.Contains(v.BaiThi.MaKyThi ?? 0))
                    .OrderByDescending(v => v.LanCuoiXayRa)
                    .ToList();

                // Lọc theo từ khóa
                string keyword = txtTimKiem.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(keyword))
                {
                    viPhamList = viPhamList.Where(v =>
                        (v.BaiThi?.SinhVien?.HoTen?.ToLower().Contains(keyword) ?? false) ||
                        (v.BaiThi?.SinhVien?.Email?.ToLower().Contains(keyword) ?? false) ||
                        (v.BaiThi?.KyThi?.TenKyThi?.ToLower().Contains(keyword) ?? false) ||
                        v.LoaiViPham.ToLower().Contains(keyword)
                    ).ToList();
                }

                // Nhóm theo sinh viên + bài thi để hiển thị tổng hợp
                var grouped = viPhamList
                    .GroupBy(v => new { MaBaiThi = v.MaBaiThi, MaSV = v.BaiThi?.MaSinhVien })
                    .Select(g => new
                    {
                        BaiThi = g.First().BaiThi,
                        ChuyenTab = g.Where(v => v.LoaiViPham == "chuyen_tab").Sum(v => v.SoLanViPham),
                        Copy = g.Where(v => v.LoaiViPham == "copy").Sum(v => v.SoLanViPham),
                        Paste = g.Where(v => v.LoaiViPham == "paste").Sum(v => v.SoLanViPham),
                        TongViPham = g.Sum(v => v.SoLanViPham),
                        LanCuoi = g.Max(v => v.LanCuoiXayRa)
                    })
                    .OrderByDescending(x => x.TongViPham)
                    .ToList();

                int stt = 1;
                foreach (var item in grouped)
                {
                    int index = dgvViPham.Rows.Add();
                    dgvViPham.Rows[index].Cells["colSTT"].Value = stt++;
                    dgvViPham.Rows[index].Cells["colHoTen"].Value = item.BaiThi?.SinhVien?.HoTen ?? "N/A";
                    dgvViPham.Rows[index].Cells["colEmail"].Value = item.BaiThi?.SinhVien?.Email ?? "N/A";
                    dgvViPham.Rows[index].Cells["colKyThi"].Value = item.BaiThi?.KyThi?.TenKyThi ?? "N/A";
                    dgvViPham.Rows[index].Cells["colLopHoc"].Value = item.BaiThi?.KyThi?.LopHoc?.TenLop ?? "N/A";
                    dgvViPham.Rows[index].Cells["colChuyenTab"].Value = item.ChuyenTab;
                    dgvViPham.Rows[index].Cells["colCopy"].Value = item.Copy;
                    dgvViPham.Rows[index].Cells["colPaste"].Value = item.Paste;
                    dgvViPham.Rows[index].Cells["colTongViPham"].Value = item.TongViPham;
                    dgvViPham.Rows[index].Cells["colLanCuoi"].Value = item.LanCuoi?.ToString("dd/MM/yyyy HH:mm") ?? "—";

                    // Mức độ vi phạm
                    string mucDo;
                    Color mauSac;
                    if (item.TongViPham >= 5)
                    {
                        mucDo = "🔴 Nghiêm trọng";
                        mauSac = Color.FromArgb(220, 53, 69);
                    }
                    else if (item.TongViPham >= 3)
                    {
                        mucDo = "🟡 Cảnh báo";
                        mauSac = Color.FromArgb(255, 152, 0);
                    }
                    else
                    {
                        mucDo = "🟢 Nhẹ";
                        mauSac = Color.FromArgb(40, 167, 69);
                    }
                    dgvViPham.Rows[index].Cells["colMucDo"].Value = mucDo;
                    dgvViPham.Rows[index].DefaultCellStyle.ForeColor = mauSac;
                }

                lblTongSo.Text = $"Tổng số: {grouped.Count} sinh viên vi phạm";

                // Cập nhật thống kê tổng
                int tongChuyenTab = grouped.Sum(x => x.ChuyenTab);
                int tongCopy = grouped.Sum(x => x.Copy);
                int tongPaste = grouped.Sum(x => x.Paste);
                lblThongKe.Text = $"Tổng vi phạm: Chuyển tab: {tongChuyenTab} | Copy: {tongCopy} | Paste: {tongPaste}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu vi phạm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
