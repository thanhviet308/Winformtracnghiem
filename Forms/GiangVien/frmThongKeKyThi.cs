using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    public partial class frmThongKeKyThi : Form
    {
        private readonly ThongKeService _thongKeService;
        private readonly AppDbContext _context;
        private long _kyThiId;

        public frmThongKeKyThi(long kyThiId)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            _thongKeService = new ThongKeService();
            _context = new AppDbContext();
            _kyThiId = kyThiId;

            InitUi();

            LoadThongKe();
        }

        private void InitUi()
        {
            ApplyWhiteDataGridViewStyle(dgvChiTiet);

            panelHeader.Resize += (_, __) => LayoutHeader();
            panelStats.Resize += (_, __) => LayoutStatPanels();
            LayoutHeader();
            LayoutStatPanels();
        }

        private void LayoutHeader()
        {
            // Keep time label neatly right-aligned
            lblThoiGian.AutoSize = true;
            lblThoiGian.Top = 15;
            lblThoiGian.Left = Math.Max(15, panelHeader.ClientSize.Width - lblThoiGian.Width - 15);
        }

        private void LayoutStatPanels()
        {
            const int gap = 15;
            int available = panelStats.ClientSize.Width - (gap * 4);
            if (available <= 0) return;

            int w = available / 3;
            int y = 15;
            int h = panelSoLieu.Height;

            panelSoLieu.SetBounds(gap, y, w, h);
            panelProgress.SetBounds(panelSoLieu.Right + gap, y, w, h);
            panelDiem.SetBounds(panelProgress.Right + gap, y, w, h);
        }

        private static void ApplyWhiteDataGridViewStyle(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = SystemColors.ControlLight;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersHeight = 38;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 68);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(45, 45, 68);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = SystemColors.ControlLight;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control;
            dgv.RowTemplate.Height = 32;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;

            // Column alignment for readability
            if (dgv.Columns.Contains("colSTT")) dgv.Columns["colSTT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgv.Columns.Contains("colBatDau")) dgv.Columns["colBatDau"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgv.Columns.Contains("colNopBai")) dgv.Columns["colNopBai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgv.Columns.Contains("colDiem")) dgv.Columns["colDiem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgv.Columns.Contains("colTrangThai")) dgv.Columns["colTrangThai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LoadThongKe()
        {
            try
            {
                var thongKe = _thongKeService.GetThongKeKyThi(_kyThiId);
                if (thongKe == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin kỳ thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Hiển thị thông tin kỳ thi
                lblTenKyThi.Text = thongKe.TenKyThi;
                lblThoiGian.Text = $"{thongKe.ThoiGianBatDau:dd/MM/yyyy HH:mm} - {thongKe.ThoiGianKetThuc:dd/MM/yyyy HH:mm}";

                // Hiển thị thống kê tổng quan
                lblTongSoSV.Text = thongKe.TongSoSinhVien.ToString();
                lblDaThi.Text = thongKe.SoDaThi.ToString();
                lblChuaThi.Text = thongKe.SoChuaThi.ToString();
                lblDiemTB.Text = thongKe.DiemTrungBinh.ToString("F2");
                lblDiemCaoNhat.Text = thongKe.DiemCaoNhat.ToString("F2");
                lblDiemThapNhat.Text = thongKe.DiemThapNhat.ToString("F2");

                // Tính phần trăm
                double phanTramDaThi = thongKe.TongSoSinhVien > 0
                    ? (thongKe.SoDaThi * 100.0 / thongKe.TongSoSinhVien)
                    : 0;
                progressDaThi.Value = (int)Math.Min(phanTramDaThi, 100);
                lblPhanTramDaThi.Text = $"{phanTramDaThi:F1}%";

                // Load chi tiết bài thi
                LoadChiTietBaiThi(thongKe);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTietBaiThi(ThongKeKyThiDTO thongKe)
        {
            dgvChiTiet.Rows.Clear();

            if (thongKe.ChiTietBaiThis == null) return;

            foreach (var baiThi in thongKe.ChiTietBaiThis.OrderByDescending(b => b.DiemSo))
            {
                int index = dgvChiTiet.Rows.Add();
                dgvChiTiet.Rows[index].Cells["colSTT"].Value = index + 1;
                dgvChiTiet.Rows[index].Cells["colMSSV"].Value = baiThi.MaSV;
                dgvChiTiet.Rows[index].Cells["colTenSV"].Value = baiThi.TenSV;
                dgvChiTiet.Rows[index].Cells["colBatDau"].Value = baiThi.ThoiGianBatDau?.ToString("HH:mm:ss") ?? "-";
                dgvChiTiet.Rows[index].Cells["colNopBai"].Value = baiThi.ThoiGianNopBai?.ToString("HH:mm:ss") ?? "-";
                dgvChiTiet.Rows[index].Cells["colDiem"].Value = baiThi.DiemSo?.ToString("F2") ?? "-";

                // Trạng thái với màu sắc
                string trangThai;
                switch (baiThi.TrangThai)
                {
                    case "da_nop":
                        trangThai = "✅ Đã nộp";
                        break;
                    case "dang_thi":
                        trangThai = "🔴 Đang thi";
                        break;
                    default:
                        trangThai = "⏳ Chưa thi";
                        break;
                }
                dgvChiTiet.Rows[index].Cells["colTrangThai"].Value = trangThai;
            }

            dgvChiTiet.ClearSelection();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files|*.xlsx";
                    sfd.FileName = $"ThongKe_{lblTenKyThi.Text}_{DateTime.Now:yyyyMMdd}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // TODO: Implement Excel export using EPPlus or similar library
                        MessageBox.Show("Chức năng xuất Excel đang được phát triển!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
