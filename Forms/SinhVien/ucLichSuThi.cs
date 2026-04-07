using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using Microsoft.EntityFrameworkCore;
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

            // Header alignment: avoid centered headers
            dgvLichSu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Columns
            dgvLichSu.Columns.Add("colSTT", "STT");
            dgvLichSu.Columns.Add("colKyThi", "Kỳ thi");
            dgvLichSu.Columns.Add("colNgayThi", "Ngày thi");
            dgvLichSu.Columns.Add("colDiem", "Điểm");

            var colChiTiet = new DataGridViewButtonColumn
            {
                Name = "colChiTiet",
                HeaderText = "Chi tiết",
                Text = "Xem",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            dgvLichSu.Columns.Add(colChiTiet);

            dgvLichSu.Columns.Add("colBaiThiId", "BaiThiId");

            dgvLichSu.Columns["colBaiThiId"].Visible = false;

            dgvLichSu.Columns["colSTT"].FillWeight = 8;
            dgvLichSu.Columns["colKyThi"].FillWeight = 40;
            dgvLichSu.Columns["colNgayThi"].FillWeight = 25;
            dgvLichSu.Columns["colDiem"].FillWeight = 15;
            dgvLichSu.Columns["colChiTiet"].FillWeight = 12;

            dgvLichSu.Columns["colSTT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLichSu.Columns["colDiem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLichSu.Columns["colChiTiet"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Text columns: left align for readability
            dgvLichSu.Columns["colKyThi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLichSu.Columns["colNgayThi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvLichSu.CellFormatting += DgvLichSu_CellFormatting;
            dgvLichSu.CellContentClick += DgvLichSu_CellContentClick;
            dgvLichSu.CellDoubleClick += DgvLichSu_CellDoubleClick;

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
                // Chỉ lấy bài thi có kỳ thi còn tồn tại
                var listBaiThi = db.BaiThi
                    .Include(bt => bt.KyThi)
                    // Lịch sử thi: chỉ hiển thị bài đã nộp / đã chấm điểm
                    // (bỏ các bản ghi tạo sẵn trạng thái "chua_thi" khi giảng viên tạo kỳ thi)
                    .Where(bt => bt.MaSinhVien == _nguoiDung.Id
                              && bt.KyThi != null
                              && (bt.TrangThai == "da_nop" || bt.TrangThai == "cham_diem"))
                    .OrderBy(bt => bt.Id)
                    .ToList();

                // Xóa bài thi mồ côi (kỳ thi đã bị xóa)
                var baiThiMoCoi = db.BaiThi
                    .Where(bt => bt.MaSinhVien == _nguoiDung.Id && bt.KyThi == null)
                    .ToList();
                if (baiThiMoCoi.Any())
                {
                    foreach (var bt in baiThiMoCoi)
                    {
                        var vpLienQuan = db.NhatKyViPham.Where(v => v.MaBaiThi == bt.Id).ToList();
                        db.NhatKyViPham.RemoveRange(vpLienQuan);
                    }
                    db.BaiThi.RemoveRange(baiThiMoCoi);
                    db.SaveChanges();
                }

                int stt = 1;
                foreach (var bt in listBaiThi)
                {
                    string tenKyThi = "";
                    string ngayThi = "";
                    bool kyThiDaKetThuc = false;

                    if (bt.KyThi != null)
                    {
                        tenKyThi = bt.KyThi.TenKyThi;
                        ngayThi = bt.KyThi.ThoiGianBatDau.ToString("dd/MM/yyyy HH:mm");
                        kyThiDaKetThuc = DateTime.Now >= bt.KyThi.ThoiGianKetThuc;
                    }

                    string diem;

                    var rawTrangThai = (bt.TrangThai ?? "").Trim().ToLowerInvariant();
                    bool daNop = rawTrangThai == "da_nop" || rawTrangThai == "cham_diem";
                    bool dangThi = rawTrangThai == "dang_thi";

                    if (daNop)
                    {
                        if (kyThiDaKetThuc)
                        {
                            diem = (bt.DiemSo ?? 0).ToString();
                        }
                        else
                        {
                            diem = "Chưa công bố";
                        }
                    }
                    else if (dangThi)
                    {
                        diem = "—";
                    }
                    else
                    {
                        diem = "—";
                    }

                    int idx = dgvLichSu.Rows.Add(
                        stt++,
                        tenKyThi,
                        ngayThi,
                        diem,
                        null,
                        bt.Id
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
            if (dgvLichSu.Columns[e.ColumnIndex].Name == "colDiem" && e.Value != null)
            {
                string diemText = e.Value.ToString();
                if (diemText == "Chưa công bố")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(160, 160, 170);
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                }
                else if (diemText == "—")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(160, 160, 170);
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                }
                else if (int.TryParse(diemText, out int diem))
                {
                    e.CellStyle.ForeColor = diem >= 5 ? Color.FromArgb(40, 167, 69) : Color.FromArgb(220, 53, 69);
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
        }

        private void DgvLichSu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvLichSu.Rows[e.RowIndex];
                if (row?.Cells["colBaiThiId"]?.Value == null) return;

                if (!long.TryParse(row.Cells["colBaiThiId"].Value.ToString(), out long baiThiId)) return;
                TryOpenChiTiet(baiThiId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở chi tiết bài thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvLichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvLichSu.Columns[e.ColumnIndex].Name != "colChiTiet") return;

            try
            {
                var row = dgvLichSu.Rows[e.RowIndex];
                if (row?.Cells["colBaiThiId"]?.Value == null) return;
                if (!long.TryParse(row.Cells["colBaiThiId"].Value.ToString(), out long baiThiId)) return;

                TryOpenChiTiet(baiThiId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở chi tiết bài thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TryOpenChiTiet(long baiThiId)
        {
            using (var db = new AppDbContext())
            {
                var baiThi = db.BaiThi
                    .Include(bt => bt.KyThi)
                    .FirstOrDefault(bt => bt.Id == baiThiId);

                if (baiThi?.KyThi == null)
                {
                    MessageBox.Show("Không tìm thấy kỳ thi của bài thi này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var rawTrangThai = (baiThi.TrangThai ?? "").Trim().ToLowerInvariant();
                bool daNop = rawTrangThai == "da_nop" || rawTrangThai == "cham_diem";
                if (!daNop)
                {
                    MessageBox.Show("Bạn chưa nộp bài nên chưa có kết quả chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                bool kyThiDaKetThuc = DateTime.Now >= baiThi.KyThi.ThoiGianKetThuc;
                if (!kyThiDaKetThuc)
                {
                    MessageBox.Show("Kết quả chi tiết sẽ được công bố sau khi kỳ thi kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            using (var frm = new frmChiTietKetQuaBaiThi(baiThiId))
            {
                frm.ShowDialog();
            }
        }
    }
}
