using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.SinhVien
{
    public class ucDanhSachKyThi : UserControl
    {
        private NguoiDung _nguoiDung;
        private KyThiService _kyThiService;
        private Guna.UI2.WinForms.Guna2DataGridView dgvKyThi;
        private Label lblTitle;

        public ucDanhSachKyThi(NguoiDung nguoiDung)
        {
            _nguoiDung = nguoiDung;
            _kyThiService = new KyThiService();
            InitializeComponents();
            ThemeHelper.ApplyVietnameseFont(this);
            LoadData();
        }

        private void InitializeComponents()
        {
            this.BackColor = Color.FromArgb(245, 248, 250);

            // Title
            lblTitle = new Label
            {
                Text = "Danh sách kỳ thi",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            this.Controls.Add(lblTitle);

            // DataGridView
            dgvKyThi = new Guna.UI2.WinForms.Guna2DataGridView
            {
                Location = new Point(20, 60),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BorderStyle = BorderStyle.None,
                BackgroundColor = Color.White,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ColumnHeadersHeight = 45,
            };

            // Theme style
            dgvKyThi.ThemeStyle.BackColor = Color.White;
            dgvKyThi.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(94, 148, 255);
            dgvKyThi.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvKyThi.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvKyThi.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvKyThi.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvKyThi.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvKyThi.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10F);
            dgvKyThi.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(245, 248, 250);
            dgvKyThi.RowTemplate.Height = 40;

            // Columns
            dgvKyThi.Columns.Add("colTenKyThi", "Tên kỳ thi");
            dgvKyThi.Columns.Add("colMonHoc", "Môn học");
            dgvKyThi.Columns.Add("colThoiGianBatDau", "Thời gian bắt đầu");
            dgvKyThi.Columns.Add("colThoiGianKetThuc", "Thời gian kết thúc");
            dgvKyThi.Columns.Add("colThoiLuong", "Thời lượng");
            dgvKyThi.Columns.Add("colTrangThai", "Trạng thái");

            dgvKyThi.Columns["colTenKyThi"].FillWeight = 25;
            dgvKyThi.Columns["colMonHoc"].FillWeight = 15;
            dgvKyThi.Columns["colThoiGianBatDau"].FillWeight = 18;
            dgvKyThi.Columns["colThoiGianKetThuc"].FillWeight = 18;
            dgvKyThi.Columns["colThoiLuong"].FillWeight = 10;
            dgvKyThi.Columns["colTrangThai"].FillWeight = 14;

            // Nút Vào thi
            var colThaoTac = new DataGridViewButtonColumn
            {
                Name = "colThaoTac",
                HeaderText = "Thao tác",
                Text = "Vào thi",
                UseColumnTextForButtonValue = true,
                FillWeight = 12,
                FlatStyle = FlatStyle.Flat
            };
            dgvKyThi.Columns.Add(colThaoTac);

            dgvKyThi.CellClick += DgvKyThi_CellClick;
            dgvKyThi.CellFormatting += DgvKyThi_CellFormatting;

            this.Controls.Add(dgvKyThi);
            this.Resize += (s, e) => LayoutControls();
        }

        private void LayoutControls()
        {
            dgvKyThi.Size = new Size(this.Width - 40, this.Height - 80);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LayoutControls();
        }

        private void LoadData()
        {
            dgvKyThi.Rows.Clear();

            // Lấy tất cả kỳ thi
            var listKyThi = _kyThiService.GetAll();

            foreach (var kt in listKyThi)
            {
                var now = DateTime.Now;
                string trangThai;
                if (now < kt.ThoiGianBatDau)
                    trangThai = "Sắp diễn ra";
                else if (now >= kt.ThoiGianBatDau && now <= kt.ThoiGianKetThuc)
                    trangThai = "Đang diễn ra";
                else
                    trangThai = "Đã kết thúc";

                string monHoc = kt.NganHangDe?.MonHoc?.TenMon ?? "";

                int idx = dgvKyThi.Rows.Add(
                    kt.TenKyThi,
                    monHoc,
                    kt.ThoiGianBatDau.ToString("dd/MM/yyyy HH:mm"),
                    kt.ThoiGianKetThuc.ToString("dd/MM/yyyy HH:mm"),
                    kt.ThoiLuongPhut + " phút",
                    trangThai
                );
                dgvKyThi.Rows[idx].Tag = kt;
            }
        }

        private void DgvKyThi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Tô màu trạng thái
            if (dgvKyThi.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
            {
                string val = e.Value.ToString();
                if (val == "Đang diễn ra")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69);
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                else if (val == "Sắp diễn ra")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(255, 193, 7);
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Gray;
                }
            }

            // Style nút Vào thi
            if (dgvKyThi.Columns[e.ColumnIndex].Name == "colThaoTac")
            {
                var row = dgvKyThi.Rows[e.RowIndex];
                var kt = row.Tag as KyThi;
                if (kt != null)
                {
                    var now = DateTime.Now;
                    bool dangDienRa = now >= kt.ThoiGianBatDau && now <= kt.ThoiGianKetThuc;
                    if (dangDienRa)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(94, 148, 255);
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.Gray;
                    }
                }
            }
        }

        private void DgvKyThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvKyThi.Columns[e.ColumnIndex].Name != "colThaoTac") return;

            var kt = dgvKyThi.Rows[e.RowIndex].Tag as KyThi;
            if (kt == null) return;

            var now = DateTime.Now;
            if (now < kt.ThoiGianBatDau)
            {
                MessageBox.Show($"Chưa đến thời gian thi!\nBắt đầu lúc: {kt.ThoiGianBatDau:dd/MM/yyyy HH:mm}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (now > kt.ThoiGianKetThuc)
            {
                MessageBox.Show("Kỳ thi đã kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra sinh viên đã nộp bài chưa
            using (var db = new AppDbContext())
            {
                var daNopBai = db.BaiThi
                    .Any(b => b.MaKyThi == kt.Id
                              && b.MaSinhVien == _nguoiDung.Id
                              && b.TrangThai == "da_nop");
                if (daNopBai)
                {
                    MessageBox.Show("Bạn đã nộp bài cho kỳ thi này rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Lấy môn học
            MonHoc monHoc = kt.NganHangDe?.MonHoc;
            if (monHoc == null)
            {
                MessageBox.Show("Không tìm thấy môn học cho kỳ thi này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mở form thi
            var parentForm = this.FindForm();
            frmThi frmThi = new frmThi(_nguoiDung, monHoc, DateTime.Now, kt.ThoiGianKetThuc, kt.Id);
            parentForm.Hide();
            frmThi.WindowState = FormWindowState.Maximized;
            frmThi.ShowDialog();
            parentForm.Close();
        }
    }
}
