using Microsoft.EntityFrameworkCore;
using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.SinhVien
{
    public class frmChiTietKetQuaBaiThi : Form
    {
        private readonly long _baiThiId;

        private Label _lblTitle;
        private Label _lblInfo;
        private DataGridView _dgv;
        private Button _btnClose;

        public frmChiTietKetQuaBaiThi(long baiThiId)
        {
            _baiThiId = baiThiId;

            InitializeComponents();
            ThemeHelper.ApplyVietnameseFont(this);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadData();
        }

        private void InitializeComponents()
        {
            Text = "Kết quả chi tiết";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(1000, 650);
            BackColor = Color.FromArgb(245, 248, 250);

            _lblTitle = new Label
            {
                Text = "Kết quả chi tiết",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = ThemeHelper.TextPrimary,
                AutoSize = true,
                Location = new Point(20, 15)
            };

            _lblInfo = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = ThemeHelper.TextSecondary,
                AutoSize = true,
                Location = new Point(20, 50)
            };

            _dgv = new DataGridView
            {
                Location = new Point(20, 85),
                Size = new Size(ClientSize.Width - 40, ClientSize.Height - 155),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ColumnHeadersHeight = 40,
                EnableHeadersVisualStyles = false
            };

            _dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = ThemeHelper.TextPrimary,
                Font = ThemeHelper.FontButton,
                SelectionBackColor = Color.White,
                SelectionForeColor = ThemeHelper.TextPrimary,
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };

            _dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = ThemeHelper.TextPrimary,
                Font = ThemeHelper.FontSmall,
                SelectionBackColor = Color.White,
                SelectionForeColor = ThemeHelper.TextPrimary,
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };

            _dgv.Columns.Add("colSTT", "STT");
            _dgv.Columns.Add("colNoiDung", "Câu hỏi");
            _dgv.Columns.Add("colBanChon", "Bạn chọn");
            _dgv.Columns.Add("colDapAnDung", "Đáp án đúng");
            _dgv.Columns.Add("colKetQua", "Kết quả");

            _dgv.Columns["colSTT"].FillWeight = 8;
            _dgv.Columns["colNoiDung"].FillWeight = 42;
            _dgv.Columns["colBanChon"].FillWeight = 20;
            _dgv.Columns["colDapAnDung"].FillWeight = 20;
            _dgv.Columns["colKetQua"].FillWeight = 10;

            _btnClose = new Button
            {
                Text = "Đóng",
                Size = new Size(120, 36),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(ClientSize.Width - 140, ClientSize.Height - 55)
            };
            _btnClose.Click += (s, e) => Close();

            Controls.Add(_lblTitle);
            Controls.Add(_lblInfo);
            Controls.Add(_dgv);
            Controls.Add(_btnClose);

            Resize += (s, e) =>
            {
                _btnClose.Location = new Point(ClientSize.Width - 140, ClientSize.Height - 55);
            };
        }

        private void LoadData()
        {
            _dgv.Rows.Clear();

            using var db = new AppDbContext();
            var baiThi = db.BaiThi
                .Include(bt => bt.KyThi)
                .FirstOrDefault(bt => bt.Id == _baiThiId);

            if (baiThi == null)
            {
                MessageBox.Show("Không tìm thấy bài thi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            bool kyThiDaKetThuc = baiThi.KyThi != null && DateTime.Now >= baiThi.KyThi.ThoiGianKetThuc;
            _lblInfo.Text = baiThi.KyThi == null
                ? $"Bài thi #{_baiThiId}"
                : $"{baiThi.KyThi.TenKyThi} • Điểm: {(baiThi.DiemSo?.ToString() ?? "-")}";

            var traLois = db.TraLoiBaiThi
                .Include(t => t.CauHoiThi)
                .Include(t => t.LuaChonTracNghiem)
                .Where(t => t.MaBaiThi == _baiThiId)
                .OrderBy(t => t.Id)
                .ToList();

            if (traLois.Count == 0)
            {
                MessageBox.Show(
                    "Chưa có dữ liệu chi tiết cho bài thi này.\n(Nếu bài thi làm trước khi hệ thống lưu chi tiết được cập nhật thì sẽ không có dữ liệu)",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
                return;
            }

            var cauHoiIds = traLois
                .Select(t => t.MaCauHoi)
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .Distinct()
                .ToList();

            Dictionary<long, string> dapAnDungMap = new();
            if (kyThiDaKetThuc && cauHoiIds.Count > 0)
            {
                dapAnDungMap = db.LuaChonTracNghiem
                    .Where(l => l.MaCauHoi.HasValue && cauHoiIds.Contains(l.MaCauHoi.Value) && l.LaDapAnDung)
                    .ToDictionary(l => l.MaCauHoi!.Value, l => l.NoiDung);
            }

            _dgv.Columns["colDapAnDung"].Visible = kyThiDaKetThuc;

            int stt = 1;
            foreach (var tl in traLois)
            {
                string noiDung = tl.CauHoiThi?.NoiDung ?? "";
                string banChon = tl.LuaChonTracNghiem?.NoiDung ?? "";

                string ketQua;
                if (tl.DungHaySai == true) ketQua = "Đúng";
                else if (tl.DungHaySai == false) ketQua = "Sai";
                else ketQua = "Chưa trả lời";

                string dapAnDung = "";
                if (kyThiDaKetThuc && tl.MaCauHoi.HasValue && dapAnDungMap.TryGetValue(tl.MaCauHoi.Value, out var dapAn))
                {
                    dapAnDung = dapAn;
                }

                _dgv.Rows.Add(stt++, noiDung, banChon, dapAnDung, ketQua);
            }

            _dgv.ClearSelection();
            _dgv.CurrentCell = null;
        }
    }
}
