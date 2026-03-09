using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.SinhVien
{
    public class ucLichSuThi : UserControl
    {
        private NguoiDung _nguoiDung;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLichSu;
        private Label lblTitle;

        public ucLichSuThi(NguoiDung nguoiDung)
        {
            _nguoiDung = nguoiDung;
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
                Text = "Lịch sử thi",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            this.Controls.Add(lblTitle);

            // DataGridView
            dgvLichSu = new Guna.UI2.WinForms.Guna2DataGridView
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
            dgvLichSu.ThemeStyle.BackColor = Color.White;
            dgvLichSu.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(94, 148, 255);
            dgvLichSu.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvLichSu.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvLichSu.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLichSu.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvLichSu.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvLichSu.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10F);
            dgvLichSu.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(245, 248, 250);
            dgvLichSu.RowTemplate.Height = 40;

            // Columns
            dgvLichSu.Columns.Add("colSTT", "STT");
            dgvLichSu.Columns.Add("colKyThi", "Kỳ thi");
            dgvLichSu.Columns.Add("colNgayThi", "Ngày thi");
            dgvLichSu.Columns.Add("colDiem", "Điểm");
            dgvLichSu.Columns.Add("colTrangThai", "Trạng thái");

            dgvLichSu.Columns["colSTT"].FillWeight = 8;
            dgvLichSu.Columns["colKyThi"].FillWeight = 35;
            dgvLichSu.Columns["colNgayThi"].FillWeight = 22;
            dgvLichSu.Columns["colDiem"].FillWeight = 15;
            dgvLichSu.Columns["colTrangThai"].FillWeight = 20;

            dgvLichSu.Columns["colSTT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLichSu.Columns["colDiem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLichSu.Columns["colTrangThai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvLichSu.CellFormatting += DgvLichSu_CellFormatting;

            this.Controls.Add(dgvLichSu);
            this.Resize += (s, e) => LayoutControls();
        }

        private void LayoutControls()
        {
            dgvLichSu.Size = new Size(this.Width - 40, this.Height - 80);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LayoutControls();
        }

        private void LoadData()
        {
            dgvLichSu.Rows.Clear();

            using (var db = new AppDbContext())
            {
                var listBaiThi = db.BaiThi
                    .Where(bt => bt.MaSinhVien == _nguoiDung.Id)
                    .OrderByDescending(bt => bt.Id)
                    .ToList();

                int stt = 1;
                foreach (var bt in listBaiThi)
                {
                    string tenKyThi = "";
                    string ngayThi = "";

                    if (bt.KyThi != null)
                    {
                        tenKyThi = bt.KyThi.TenKyThi;
                        ngayThi = bt.KyThi.ThoiGianBatDau.ToString("dd/MM/yyyy HH:mm");
                    }

                    string trangThai = (bt.DiemSo ?? 0) >= 5 ? "Đạt" : "Không đạt";

                    int idx = dgvLichSu.Rows.Add(
                        stt++,
                        tenKyThi,
                        ngayThi,
                        (bt.DiemSo ?? 0).ToString(),
                        trangThai
                    );
                }
            }

            if (dgvLichSu.Rows.Count == 0)
            {
                // Thêm dòng trống thông báo
            }
        }

        private void DgvLichSu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSu.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
            {
                if (e.Value.ToString() == "Đạt")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69);
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }

            if (dgvLichSu.Columns[e.ColumnIndex].Name == "colDiem" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int diem))
                {
                    e.CellStyle.ForeColor = diem >= 5 ? Color.FromArgb(40, 167, 69) : Color.FromArgb(220, 53, 69);
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
        }
    }
}
