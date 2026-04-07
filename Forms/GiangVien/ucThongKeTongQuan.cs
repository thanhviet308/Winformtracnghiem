using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Forms;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    public partial class ucThongKeTongQuan : UserControl
    {
        private readonly ThongKeService _thongKeService;
        private readonly AppDbContext _context;
        private NguoiDung _nguoiDung;

        public ucThongKeTongQuan()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);

            ApplyWhiteDataGridViewStyle(dgvKyThiGanDay);
            ApplyWhiteDataGridViewStyle(dgvThongKeCauHoi);

            _thongKeService = new ThongKeService();
            _context = new AppDbContext();
        }

        private static void ApplyWhiteDataGridViewStyle(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.GridColor = Color.FromArgb(229, 231, 235);
            dgv.RowHeadersVisible = false;

            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.White,
                ForeColor = ThemeHelper.TextPrimary,
                Font = ThemeHelper.FontButton,
                SelectionBackColor = Color.White,
                SelectionForeColor = ThemeHelper.TextPrimary
            };

            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.White,
                ForeColor = ThemeHelper.TextPrimary,
                Font = ThemeHelper.FontSmall,
                SelectionBackColor = Color.White,
                SelectionForeColor = ThemeHelper.TextPrimary
            };
        }

        public void SetNguoiDung(NguoiDung nguoiDung)
        {
            _nguoiDung = nguoiDung;
            LoadThongKe();
        }

        private void LoadThongKe()
        {
            try
            {
                var thongKe = _thongKeService.GetThongKeTongQuan(_nguoiDung.Id);
                if (thongKe == null) return;

                // Thống kê tổng quan
                lblSoCauHoi.Text = thongKe.TongSoCauHoi.ToString();
                lblSoKhungDe.Text = thongKe.TongSoKhungDe.ToString();
                lblSoKyThi.Text = thongKe.TongSoKyThi.ToString();
                lblSoBaiThi.Text = thongKe.TongSoBaiThi.ToString();

                // Load danh sách kỳ thi gần đây
                LoadKyThiGanDay();

                // Load thống kê câu hỏi theo môn
                LoadThongKeCauHoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadKyThiGanDay()
        {
            dgvKyThiGanDay.Rows.Clear();

            var nganHangDeIds = _context.NganHangDe
                .Where(n => n.NguoiTao == _nguoiDung.Id)
                .Select(n => n.Id)
                .ToList();

            var kyThis = _context.KyThi
                .Where(k => nganHangDeIds.Contains(k.MaNganHangDe ?? 0))
                .OrderByDescending(k => k.ThoiGianBatDau)
                .Take(5)
                .ToList();

            foreach (var kt in kyThis)
            {
                var nganHangDe = _context.NganHangDe.FirstOrDefault(n => n.Id == kt.MaNganHangDe);
                var soBaiThi = _context.BaiThi.Count(b => b.MaKyThi == kt.Id);
                var soDaNop = _context.BaiThi.Count(b => b.MaKyThi == kt.Id && b.TrangThai == "da_nop");

                int index = dgvKyThiGanDay.Rows.Add();
                dgvKyThiGanDay.Rows[index].Cells["colTenKT"].Value = kt.TenKyThi;
                dgvKyThiGanDay.Rows[index].Cells["colNgayThi"].Value = kt.ThoiGianBatDau.ToString("dd/MM/yyyy");
                dgvKyThiGanDay.Rows[index].Cells["colSoLuong"].Value = $"{soDaNop}/{soBaiThi}";

                // Trạng thái
                string trangThai;
                var now = DateTime.Now;
                if (kt.ThoiGianBatDau > now)
                    trangThai = "⏳ Sắp tới";
                else if (kt.ThoiGianKetThuc < now)
                    trangThai = "✅ Đã xong";
                else
                    trangThai = "🔴 Đang thi";
                dgvKyThiGanDay.Rows[index].Cells["colTrangThaiKT"].Value = trangThai;
            }

            ClearGridSelection(dgvKyThiGanDay);
        }

        private void LoadThongKeCauHoi()
        {
            dgvThongKeCauHoi.Rows.Clear();

            var thongKeCauHoi = _thongKeService.GetThongKeCauHoiTheoMon(_nguoiDung.Id);

            foreach (var item in thongKeCauHoi)
            {
                int index = dgvThongKeCauHoi.Rows.Add();
                dgvThongKeCauHoi.Rows[index].Cells["colMonHoc"].Value = item.TenMonHoc;
                dgvThongKeCauHoi.Rows[index].Cells["colSoCauHoi"].Value = item.SoCauHoi;
            }

            ClearGridSelection(dgvThongKeCauHoi);
        }

        private static void ClearGridSelection(DataGridView dgv)
        {
            try
            {
                dgv.ClearSelection();
                dgv.CurrentCell = null;
            }
            catch
            {
                // ignore
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadThongKe();
            MessageBox.Show("Đã cập nhật thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
