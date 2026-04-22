using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem
{
    public partial class frmThi : Form
    {

        AppDbContext duLieu = new AppDbContext();

        List<Button> oCauHoi;
        List<GroupBox> luuBaiCham;
        List<RadioButton> layDapAnThi;

        private readonly ChiTietDeThiService danhMucCauHoiBAL;
        private readonly CauHoiService CauHoiService;
        private readonly BangDiemService BangDiemService;
        private readonly ChiTietKyThiService ChiTietKyThiService;
        private readonly GiangVienService GiangVienService;
        private readonly SinhVienService SinhVienService;
        private readonly NguoiDung nguoiDung;
        private readonly MonHoc monThi;
        private readonly KyThiService kiThiBAL;
        private readonly DateTime thoiGianBatDau;
        private readonly DateTime thoiGianKetThuc;
        private readonly List<CauHoiDTO> cauHoiMonThi = new List<CauHoiDTO>();
        private readonly long _maKyThi;
        private long _maBaiThi;
        private int _tongDiemKyThi = 10;


        public int TongThoiGian = 6;
        int iPhut = 0;
        int iGiay = 0;

        // ===== CHỐNG GIAN LẬN =====
        private int _soLanChuyenTab = 0;
        private int _soLanCopy = 0;
        private int _soLanPaste = 0;
        private const int MAX_VI_PHAM = 5; // Tự nộp bài khi vượt quá
        private Label lblCanhBaoViPham;
        private bool _dangHienDialog = false; // Cờ tạm tắt phát hiện gian lận khi hiện dialog
        private bool _isSubmitting = false;
        private bool _daNopTruocDo = false;
        private string _thongBaoChanVaoThi = "";
        private bool _timeUpHandled = false;

        private readonly ToolTip _toolTip = new ToolTip();



        public frmThi(NguoiDung nd, MonHoc mt, DateTime ThoiGianBatDauVaoThi, DateTime thoiGianKetThucThi, long maKyThi = 0)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);

            oCauHoi = new List<Button>();
            luuBaiCham = new List<GroupBox>();
            layDapAnThi = new List<RadioButton>();

            CauHoiService = new CauHoiService();
            BangDiemService = new BangDiemService();
            danhMucCauHoiBAL = new ChiTietDeThiService();
            ChiTietKyThiService = new ChiTietKyThiService();
            GiangVienService = new GiangVienService();
            SinhVienService = new SinhVienService();
            kiThiBAL = new KyThiService();
            thoiGianBatDau = ThoiGianBatDauVaoThi;
            thoiGianKetThuc = thoiGianKetThucThi;
            nguoiDung = nd;
            monThi = mt;
            _maKyThi = maKyThi;

            // Tạo bản ghi BaiThi khi bắt đầu thi
            TaoBaiThi();

            if (_daNopTruocDo)
            {
                this.Shown += (_, __) =>
                {
                    _dangHienDialog = true;
                    MessageBox.Show(_thongBaoChanVaoThi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _dangHienDialog = false;
                    this.Close();
                };
                return;
            }

            // Hiển thị thông tin sinh viên 
            lblTenSinhVien.Text = nguoiDung.HoTen.ToString() + "  ||  " + nguoiDung.Email.ToString();

            // Hiển thị môn thi
            lblMonThi.Text = monThi.TenMon;
            lblMonThi.Name = monThi.Id.ToString();

            // Gọi khung hiển thị câu hỏi trắc nghiệm
            flowLayoutPanel1.Enabled = true;
            flowLayoutPanel1_Paint();

            // Đồng bộ dark theme - text trắng trên nền tối
            lblTenSinhVien.ForeColor = Color.White;
            guna2HtmlLabel3.ForeColor = Color.White;
            lblMonThi.ForeColor = Color.White;
            guna2HtmlLabel1.ForeColor = Color.White;
            lblHienThi.ForeColor = Color.White;

            // ===== CHỐNG GIAN LẬN =====
            // Label cảnh báo vi phạm
            lblCanhBaoViPham = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 53, 69),
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(240, 10),
                Visible = false
            };
            pnlThi.Controls.Add(lblCanhBaoViPham);
            lblCanhBaoViPham.BringToFront();

            // Bắt sự kiện chuyển tab (mất focus cửa sổ)
            this.Deactivate += FrmThi_Deactivate;

            // Chặn copy/paste trong toàn form
            this.KeyPreview = true;
            this.KeyDown += FrmThi_KeyDown;

            this.FormClosing += FrmThi_FormClosing;

            // Cho phép kéo cửa sổ (borderless) bằng cách kéo vùng chính
            try
            {
                if (guna2DragControl1 != null)
                {
                    guna2DragControl1.TargetControl = pnlThi;
                }
            }
            catch
            {
                // ignore
            }
        }

        /// <summary>
        /// Tạo hoặc tìm bản ghi BaiThi khi sinh viên bắt đầu làm bài
        /// </summary>
        private void TaoBaiThi()
        {
            try
            {
                long kyThiId = _maKyThi;

                // Nếu chưa có maKyThi, tìm kỳ thi đang diễn ra
                if (kyThiId == 0)
                {
                    var kyThi = duLieu.Set<KyThi>()
                        .FirstOrDefault(k => DateTime.Now >= k.ThoiGianBatDau && DateTime.Now <= k.ThoiGianKetThuc);
                    if (kyThi != null)
                        kyThiId = kyThi.Id;
                }

                if (kyThiId > 0)
                {
                    // Nếu đã nộp/chấm điểm rồi thì không cho vào thi lại
                    var baiThiDaNop = duLieu.Set<BaiThi>()
                        .FirstOrDefault(b => b.MaKyThi == kyThiId
                                          && b.MaSinhVien == nguoiDung.Id
                                          && (b.TrangThai == "da_nop" || b.TrangThai == "cham_diem"));
                    if (baiThiDaNop != null)
                    {
                        _daNopTruocDo = true;
                        _thongBaoChanVaoThi = "Bạn đã nộp bài kỳ thi này rồi. Không thể vào thi lại.";
                        _maBaiThi = baiThiDaNop.Id;
                        return;
                    }

                    // Tìm bài thi đang thi hoặc chưa thi
                    var baiThiCu = duLieu.Set<BaiThi>()
                        .FirstOrDefault(b => b.MaKyThi == kyThiId
                                          && b.MaSinhVien == nguoiDung.Id
                                          && (b.TrangThai == "chua_thi" || b.TrangThai == "dang_thi"));

                    if (baiThiCu != null)
                    {
                        baiThiCu.TrangThai = "dang_thi";
                        baiThiCu.ThoiGianBatDau = DateTime.Now;
                        duLieu.SaveChanges();
                        _maBaiThi = baiThiCu.Id;
                    }
                    else
                    {
                        // Tạo mới bài thi (luôn tạo để đảm bảo có _maBaiThi)
                        var baiThiMoi = new BaiThi
                        {
                            MaKyThi = kyThiId,
                            MaSinhVien = nguoiDung.Id,
                            ThoiGianBatDau = DateTime.Now,
                            TrangThai = "dang_thi"
                        };
                        duLieu.Set<BaiThi>().Add(baiThiMoi);
                        duLieu.SaveChanges();
                        _maBaiThi = baiThiMoi.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi tạo bài thi: " + ex.Message);
            }
        }

        private void frmThi_Load(object sender, EventArgs e)
        {
            btnDemNguoc_Click(sender, e);

            layDapAnThi.Clear();
            for (int i = 0; i < cauHoiMonThi.Count; i++)
            {
                layDapAnThi.Add(null);
            }
        }

        private void flowLayoutPanel1_Paint()
        {
            // Tạo ô câu hỏi bên trái
            int x = 10, y = 105;
            cauHoiMonThi.Clear();
            LoadCauHoiTheoKyThi();

            for (int i = 0; i < cauHoiMonThi.Count; i++)
            {
                oCauHoi.Add(TaoNut((i + 1), ref x, ref y));

                x += 60;

                if ((i + 1) % 2 == 0)
                {
                    y += 40;
                    x = 10;
                }
                luuBaiCham.Add(TaoCauHoi(i));
            }

            // Tạo tất cả câu hỏi trong vùng chứa câu hỏi
            // Note: danhMucCauHoiBAL.GetCauHoi() không còn dùng nữa
        }

        private void LoadCauHoiTheoKyThi()
        {
            try
            {
                long kyThiId = _maKyThi;
                if (kyThiId == 0)
                {
                    var ktActive = duLieu.Set<KyThi>()
                        .FirstOrDefault(k => DateTime.Now >= k.ThoiGianBatDau && DateTime.Now <= k.ThoiGianKetThuc);
                    if (ktActive != null) kyThiId = ktActive.Id;
                }

                KyThi kyThi = null;
                if (kyThiId > 0)
                {
                    kyThi = duLieu.Set<KyThi>()
                        .Include(k => k.NganHangDe)
                            .ThenInclude(n => n.CauTrucDes)
                        .FirstOrDefault(k => k.Id == kyThiId);
                }

                _tongDiemKyThi = Math.Max(1, kyThi?.TongDiem ?? 10);

                int tongSoCau = 0;
                if (kyThi?.NganHangDe != null)
                {
                    tongSoCau = kyThi.NganHangDe.TongSoCau;
                }

                var baseQuery = duLieu.Set<CauHoiThi>()
                    .Include(c => c.LuaChonTracNghiems)
                    .Where(c => c.TrangThai && c.MaMon == monThi.Id);

                List<CauHoiThi> selectedQuestions;

                var cauTrucsChuong = kyThi?.NganHangDe?.CauTrucDes?
                    .Where(c => c.MaChuong != null && c.SoCau > 0)
                    .ToList() ?? new List<CauTrucDe>();

                if (cauTrucsChuong.Count > 0)
                {
                    selectedQuestions = new List<CauHoiThi>();

                    var grouped = cauTrucsChuong
                        .GroupBy(c => c.MaChuong!.Value)
                        .Select(g => new { MaChuong = g.Key, SoCau = g.Sum(x => x.SoCau) })
                        .ToList();

                    foreach (var g in grouped)
                    {
                        var pool = baseQuery
                            .Where(c => c.MaChuong == g.MaChuong)
                            .OrderBy(c => c.Id)
                            .ToList();

                        var picked = PickQuestions(pool, g.SoCau, kyThi?.TronCauHoi == true);
                        selectedQuestions.AddRange(picked);
                    }

                    // Nếu người dùng nhập cấu trúc nhưng tổng không khớp, fallback an toàn
                    if (tongSoCau > 0 && selectedQuestions.Count != tongSoCau)
                    {
                        // Không throw để tránh crash giữa ca thi; cứ lấy đúng tongSoCau theo pool tổng
                        var allPool = baseQuery.OrderBy(c => c.Id).ToList();
                        selectedQuestions = PickQuestions(allPool, tongSoCau, kyThi?.TronCauHoi == true);
                    }
                }
                else
                {
                    var pool = baseQuery.OrderBy(c => c.Id).ToList();
                    if (tongSoCau <= 0 || tongSoCau > pool.Count)
                    {
                        tongSoCau = pool.Count;
                    }
                    selectedQuestions = PickQuestions(pool, tongSoCau, kyThi?.TronCauHoi == true);
                }

                // Trộn lại toàn bộ danh sách sau khi đã chọn (để không bị gom theo chương)
                if (kyThi?.TronCauHoi == true)
                {
                    ShuffleInPlace(selectedQuestions);
                }

                // Map to DTO list used by UI
                foreach (var c in selectedQuestions)
                {
                    var dto = new CauHoiDTO
                    {
                        MaCauHoi = (int)c.Id,
                        NDCAUHOI = c.NoiDung,
                        MaMT = c.MaMon?.ToString() ?? monThi.Id.ToString(),
                        MaGiaoVien = c.NguoiTao?.ToString() ?? ""
                    };

                    var luaChons = (c.LuaChonTracNghiems ?? new List<LuaChonTracNghiem>())
                        .OrderBy(l => l.ThuTu)
                        .ToList();

                    if (kyThi?.TronDapAn == true)
                    {
                        ShuffleInPlace(luaChons);
                    }

                    if (luaChons.Count > 0) dto.DapAn1 = luaChons[0].NoiDung;
                    if (luaChons.Count > 1) dto.DapAn2 = luaChons[1].NoiDung;
                    if (luaChons.Count > 2) dto.DapAn3 = luaChons[2].NoiDung;
                    if (luaChons.Count > 3) dto.DapAn4 = luaChons[3].NoiDung;

                    var dung = luaChons.FirstOrDefault(l => l.LaDapAnDung);
                    if (dung != null) dto.DapAnDung = dung.NoiDung;

                    // Đảm bảo không add câu hỏi thiếu nội dung
                    if (!string.IsNullOrWhiteSpace(dto.NDCAUHOI))
                    {
                        cauHoiMonThi.Add(dto);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi load câu hỏi theo kỳ thi: " + ex.Message);
            }
        }

        private static List<CauHoiThi> PickQuestions(List<CauHoiThi> pool, int count, bool random)
        {
            if (pool == null) return new List<CauHoiThi>();
            if (count <= 0) return new List<CauHoiThi>();

            // Work on a copy to avoid surprising side-effects
            var list = pool.ToList();

            if (random)
            {
                ShuffleInPlace(list);
            }

            if (count >= list.Count) return list;
            return list.Take(count).ToList();
        }

        private static void ShuffleInPlace<T>(IList<T> list)
        {
            if (list == null) return;
            if (list.Count <= 1) return;

            // Fisher–Yates using shared RNG to avoid same-seed issues
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = Random.Shared.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        private GroupBox TaoCauHoi(int i)
        {
            // Tạo mỗi GroupBox chứa mỗi 1 câu hỏi
            GroupBox groupBox = new GroupBox();
            groupBox.Location = new Point();
            groupBox.Font = new Font("Be Vietnam Pro", 10, FontStyle.Bold);
            groupBox.Text = "Câu " + (i + 1);
            groupBox.Name = (i + 1).ToString();
            groupBox.Size = new System.Drawing.Size(1780, 320);
            flowLayoutPanel1.Controls.Add(groupBox);

            // Nội dung câu hỏi (cho phép bôi đen để copy)
            var rtb = new RichTextBox
            {
                Location = new Point(30, 30),
                Size = new Size(1600, 90),
                Name = "rtbQuestion_" + i,
                Font = new Font("Be Vietnam Pro", 10),
                Text = cauHoiMonThi[i].NDCAUHOI,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                ForeColor = Color.Black,
                DetectUrls = false,
                ScrollBars = RichTextBoxScrollBars.None,
                TabStop = false,
                ShortcutsEnabled = true,
                Cursor = Cursors.IBeam,
                Tag = i
            };

            rtb.Multiline = true;
            rtb.WordWrap = true;
            rtb.HideSelection = false;
            rtb.Select(0, 0);

            // Fit height roughly to content (cap to avoid huge boxes)
            try
            {
                var preferred = TextRenderer.MeasureText(rtb.Text, rtb.Font, new Size(rtb.Width, int.MaxValue),
                    TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
                int desiredHeight = Math.Min(140, Math.Max(70, preferred.Height + 10));
                rtb.Height = desiredHeight;
            }
            catch
            {
                // ignore
            }

            _toolTip.SetToolTip(rtb, "Bôi đen để copy (Ctrl+C)");
            groupBox.Controls.Add(rtb);

            int answerTop = rtb.Bottom + 35;
            int stepY = 60;

            for (int j = 0; j < 4; j++)
            {
                int baseX = (j == 1 || j == 3) ? 800 : 30;
                int row = (j == 1 || j == 3) ? (j - 1) : j;
                int y = answerTop + (row * stepY);

                string dapAn = j switch
                {
                    0 => cauHoiMonThi[i].DapAn1,
                    1 => cauHoiMonThi[i].DapAn2,
                    2 => cauHoiMonThi[i].DapAn3,
                    _ => cauHoiMonThi[i].DapAn4
                };

                var rdo = new RadioButton
                {
                    Location = new Point(baseX, y),
                    AutoSize = false,
                    Size = new Size(18, 18),
                    Name = "rdo" + j,
                    Font = new Font("Be Vietnam Pro", 10),
                    Text = string.Empty,
                    Tag = dapAn
                };

                var rtbAnswer = new RichTextBox
                {
                    Location = new Point(baseX + 22, y - 4),
                    Size = new Size(720, 26),
                    Name = $"rtbAnswer_{i}_{j}",
                    Font = new Font("Be Vietnam Pro", 10),
                    Text = dapAn,
                    ReadOnly = true,
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    DetectUrls = false,
                    ScrollBars = RichTextBoxScrollBars.None,
                    TabStop = false,
                    ShortcutsEnabled = true,
                    Cursor = Cursors.IBeam
                };
                rtbAnswer.Multiline = true;
                rtbAnswer.WordWrap = true;
                rtbAnswer.HideSelection = false;
                rtbAnswer.Select(0, 0);

                try
                {
                    var preferred = TextRenderer.MeasureText(rtbAnswer.Text, rtbAnswer.Font,
                        new Size(rtbAnswer.Width, int.MaxValue),
                        TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
                    int desiredHeight = Math.Min(50, Math.Max(22, preferred.Height + 6));
                    rtbAnswer.Height = desiredHeight;
                }
                catch
                {
                    // ignore
                }

                // Click on answer text should also select the radio
                rtbAnswer.MouseDown += (sender, args) =>
                {
                    if (args.Button != MouseButtons.Left) return;
                    rdo.Checked = true;
                    buttonNext_Click(rdo, EventArgs.Empty, groupBox.Name, rdo, (i + 1));
                };

                groupBox.Controls.Add(rdo);
                groupBox.Controls.Add(rtbAnswer);

                rdo.Click += (sender, EventArgs) => { buttonNext_Click(sender, EventArgs, groupBox.Name, rdo, (i + 1)); };
            }

            // Ensure groupbox tall enough for answers
            int lastRowY = answerTop + (2 * stepY);
            groupBox.Height = Math.Max(groupBox.Height, lastRowY + 110);

            return groupBox;
        }

        // Copy theo kiểu bôi đen: dùng RichTextBox (ReadOnly) nên không cần click-to-copy

        private void buttonNext_Click(object sender, EventArgs e, string index, RadioButton rdo, int traloi)
        {
            try
            {
                layDapAnThi[traloi - 1] = rdo;
                foreach (var item in oCauHoi)
                {
                    if (item.Name == index)
                    {
                        item.BackColor = Color.Yellow;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private System.EventHandler CauHoiRepositoryam(GroupBox a)
        {
            try
            {
                foreach (var item in oCauHoi)
                {
                    if (item.Name == a.Name)
                    {
                        item.BackColor = Color.Yellow;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private Button TaoNut(int i, ref int x, ref int y)
        {
            Button btn = new Button();
            btn.Location = new Point(x, y);
            btn.Font = new Font("Be Vietnam Pro", 10);
            btn.Text = i.ToString();
            btn.Name = i.ToString();
            btn.Tag = i;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Size = new Size(42, 36);
            btn.BackColor = Color.White;
            btn.Focus();

            btn.Click += BtnCauHoi_Click;

            panelMenu.Controls.Add(btn);
            btn.BringToFront();

            return btn;
        }

        private void BtnCauHoi_Click(object sender, EventArgs e)
        {
            if (sender is not Button btn) return;
            if (btn.Tag is not int soCau) return;
            ScrollToQuestionTop(soCau);
        }

        private void ScrollToQuestionTop(int questionNumber)
        {
            int index = questionNumber - 1;
            if (index < 0 || index >= luuBaiCham.Count) return;

            var target = luuBaiCham[index];
            if (target == null) return;

            flowLayoutPanel1.ScrollControlIntoView(target);

            // Force align to top
            int desiredY = Math.Max(0, target.Top - flowLayoutPanel1.Padding.Top);
            int max = Math.Max(flowLayoutPanel1.VerticalScroll.Minimum,
                flowLayoutPanel1.VerticalScroll.Maximum - flowLayoutPanel1.VerticalScroll.LargeChange + 1);
            int newValue = Math.Min(Math.Max(desiredY, flowLayoutPanel1.VerticalScroll.Minimum), max);
            flowLayoutPanel1.VerticalScroll.Value = newValue;
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel1.Invalidate();
            target.Focus();
        }

        private void FrmThi_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Nếu đã bị chặn vì đã nộp trước đó thì cho đóng luôn
                if (_daNopTruocDo) return;

                if (_isSubmitting) return;
                if (_maBaiThi <= 0) return;

                var baiThi = duLieu.Set<BaiThi>().Find(_maBaiThi);
                var rawTrangThai = (baiThi?.TrangThai ?? "").Trim().ToLowerInvariant();
                bool dangThi = rawTrangThai == "dang_thi";

                // Thoát khi đang thi => tự động nộp bài (không hiện màn nộp bài thành công)
                if (dangThi)
                {
                    SubmitBaiThi(showSuccessScreen: false);
                }
            }
            catch
            {
                // ignore: ưu tiên đóng form
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                flowLayoutPanel1.Controls.Add(new Button() { Text = "Cố lên" });
            }
            for (int i = 0; i < 100; i++)
            {
                flowLayoutPanel1.Controls.Add(new Button() { Text = "Mạnh mẽ lên" });
            }
        }

        private void menuThi_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        // NỘP BÀI
        private void NopBai_Click(object sender, EventArgs e)
        {
            _dangHienDialog = true;
            DialogResult result = MessageBox.Show("Bạn có muốn nộp bài không?", "Thông báo", MessageBoxButtons.YesNo);
            _dangHienDialog = false;

            if (result == DialogResult.No)
                return;
            NopBai_Click();
        }

        // TÍNH THỜI GIAN CÒN LẠI
        private void btnDemNguoc_Click(object sender, EventArgs e)
        {
            // Tính thời gian còn lại = thời gian kết thúc - hiện tại
            TimeSpan thoiGianConLai = thoiGianKetThuc - DateTime.Now;
            if (thoiGianConLai.TotalSeconds <= 0)
            {
                iPhut = 0;
                iGiay = 0;
            }
            else
            {
                iPhut = (int)thoiGianConLai.TotalMinutes;
                iGiay = thoiGianConLai.Seconds;
            }
            TongThoiGian = iPhut;
            this.timer1.Enabled = true;
            HienThiPhutGio();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_timeUpHandled) return;
            if (_daNopTruocDo) return;
            if (_isSubmitting) return;

            iGiay--;

            if (iGiay == 0)
            {
                if (iPhut > 0)
                {
                    iPhut--;
                    iGiay = 59;
                }
                else
                {
                    iPhut = 0;
                    iGiay = 0;
                }
            }

            if ((iPhut == 0) && (iGiay == 0))
            {
                HienThiPhutGio();
                this.timer1.Enabled = false;
                _timeUpHandled = true;

                // Nếu form thi đang bị ẩn/nằm sau màn hình khác thì không bật MessageBox gây khó chịu
                var shouldShowDialog = this.Visible && this.WindowState != FormWindowState.Minimized;
                if (shouldShowDialog)
                {
                    _dangHienDialog = true;
                    MessageBox.Show("Hết giờ làm bài!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _dangHienDialog = false;
                }

                SubmitBaiThi(showSuccessScreen: true);
            }
            else
            {
                HienThiPhutGio();
            }
        }

        private void NopBai_Click()
        {
            SubmitBaiThi(showSuccessScreen: true);
        }

        private void SubmitBaiThi(bool showSuccessScreen)
        {
            if (_isSubmitting) return;
            _isSubmitting = true;

            try
            {
                // Stop timer immediately to avoid duplicate submits
                try { this.timer1.Enabled = false; } catch { }
            }
            catch { }

            try
            {
                // Lấy thời gian kết thúc thi
                DateTime thoiGianThi = DateTime.Now;
                double diemMotCau;
                double diemThi = 0;
                int soCauHoi = cauHoiMonThi.Count;

                if (soCauHoi <= 0)
                {
                    _dangHienDialog = true;
                    MessageBox.Show("Không có câu hỏi để chấm điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _dangHienDialog = false;
                    return;
                }

                var tongDiem = Math.Max(1, _tongDiemKyThi);
                diemMotCau = (double)tongDiem / soCauHoi;
                for (int i = 0; i < soCauHoi; i++)
                {
                    if (layDapAnThi[i] != null)
                    {
                        var luaChon = GetSelectedAnswerText(layDapAnThi[i]);
                        if (String.Equals(luaChon, cauHoiMonThi[i].DapAnDung))
                        {
                            diemThi += diemMotCau;
                        }
                    }
                }
                diemThi = Math.Round(diemThi, 2, MidpointRounding.AwayFromZero);
                var diemThiLamTron = (int)Math.Round(diemThi, 0, MidpointRounding.AwayFromZero);
                if (diemThiLamTron < 0) diemThiLamTron = 0;
                if (diemThiLamTron > tongDiem) diemThiLamTron = tongDiem;

                try
                {
                    // Lưu dữ liệu: cập nhật bài thi đã tạo khi bắt đầu thi
                    if (_maBaiThi > 0)
                    {
                        var baiThi = duLieu.Set<BaiThi>().Find(_maBaiThi);
                        if (baiThi != null)
                        {
                            baiThi.ThoiGianNopBai = thoiGianThi;
                            baiThi.DiemSo = diemThiLamTron;
                            baiThi.TrangThai = "da_nop";
                            duLieu.SaveChanges();

                            LuuChiTietTraLoi(baiThi.Id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi cập nhật bài thi: " + ex.Message);
                }

                if (showSuccessScreen)
                {
                    // Hiển thị màn hình nộp bài thành công (không hiện điểm)
                    _dangHienDialog = true;
                    this.Deactivate -= FrmThi_Deactivate; // Gỡ sự kiện chống gian lận khi đã nộp bài
                    ThiTracNghiem thiTracNghiem = new ThiTracNghiem(nguoiDung);
                    thiTracNghiem.HienThiNopBaiThanhCong(DateTime.Now);
                    this.Hide();
                    thiTracNghiem.ShowDialog();
                    this.Close();
                }
            }
            finally
            {
                _isSubmitting = false;
            }
        }

        private void LuuChiTietTraLoi(long maBaiThi)
        {
            try
            {
                var existing = duLieu.Set<TraLoiBaiThi>()
                    .Where(t => t.MaBaiThi == maBaiThi)
                    .ToList();
                if (existing.Count > 0)
                {
                    duLieu.Set<TraLoiBaiThi>().RemoveRange(existing);
                }

                for (int i = 0; i < cauHoiMonThi.Count; i++)
                {
                    var dto = cauHoiMonThi[i];
                    long cauHoiId = dto.MaCauHoi;

                    string luaChonNoiDung = layDapAnThi.Count > i ? GetSelectedAnswerText(layDapAnThi[i]) : null;

                    LuaChonTracNghiem luaChon = null;
                    if (!string.IsNullOrWhiteSpace(luaChonNoiDung))
                    {
                        luaChon = duLieu.Set<LuaChonTracNghiem>()
                            .FirstOrDefault(l => l.MaCauHoi == cauHoiId && l.NoiDung == luaChonNoiDung);
                    }

                    bool? dungHaySai = null;
                    if (!string.IsNullOrWhiteSpace(luaChonNoiDung) && !string.IsNullOrWhiteSpace(dto.DapAnDung))
                    {
                        dungHaySai = string.Equals(luaChonNoiDung, dto.DapAnDung, StringComparison.Ordinal);
                    }

                    duLieu.Set<TraLoiBaiThi>().Add(new TraLoiBaiThi
                    {
                        MaBaiThi = maBaiThi,
                        MaCauHoi = cauHoiId,
                        MaLuaChon = luaChon?.Id,
                        DungHaySai = dungHaySai,
                        ThoiGianTraLoi = DateTime.Now
                    });
                }

                duLieu.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi lưu chi tiết trả lời: " + ex.Message);
            }
        }

        private static string GetSelectedAnswerText(RadioButton rdo)
        {
            if (rdo == null) return null;
            return (rdo.Tag as string) ?? rdo.Text;
        }

        private void HienThiPhutGio()
        {
            string sPhut = "";
            string sGiay = "";

            if (iPhut < 10)
                sPhut = "0" + iPhut.ToString();
            else
                sPhut = iPhut.ToString();

            if (iGiay < 10)
                sGiay = "0" + iGiay.ToString();
            else
                sGiay = iGiay.ToString();
            // Hiển thị thời gian
            this.lblHienThi.Text = sPhut + ":" + sGiay;
        }

        // ===== XỬ LÝ CHỐNG GIAN LẬN =====

        /// <summary>
        /// Phát hiện sinh viên chuyển tab / alt-tab ra khỏi form thi
        /// </summary>
        private void FrmThi_Deactivate(object sender, EventArgs e)
        {
            // Bỏ qua nếu đang hiện MessageBox của chính form (nộp bài, cảnh báo, hết giờ...)
            if (_dangHienDialog) return;

            _soLanChuyenTab++;
            XuLyViPham("chuyen_tab", _soLanChuyenTab, "⚠ Cảnh báo: Bạn đã chuyển tab " + _soLanChuyenTab + " lần!");
        }

        /// <summary>
        /// Phát hiện Ctrl+C (copy) và Ctrl+V (paste)
        /// </summary>
        private void FrmThi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                _soLanCopy++;

                bool isCopyExamText = IsCopyingExamText();

                // Copy câu hỏi: vẫn tính vi phạm + hiện cảnh báo, nhưng không chặn để người dùng copy được
                if (!isCopyExamText)
                {
                    e.SuppressKeyPress = true; // Chặn copy ở nơi khác
                }

                XuLyViPham("copy", _soLanCopy, "⚠ Cảnh báo: Bạn đã copy (" + _soLanCopy + " lần)");
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                _soLanPaste++;
                e.SuppressKeyPress = true; // Chặn paste
                XuLyViPham("paste", _soLanPaste, "⚠ Cảnh báo: Không được phép paste! (" + _soLanPaste + " lần)");
            }
        }

        private bool IsCopyingExamText()
        {
            var focused = GetDeepActiveControl(this);
            if (focused is RichTextBox rtb)
            {
                if (rtb.Name == null) return false;
                return rtb.Name.StartsWith("rtbQuestion_", StringComparison.Ordinal)
                    || rtb.Name.StartsWith("rtbAnswer_", StringComparison.Ordinal);
            }
            return false;
        }

        private static Control GetDeepActiveControl(Control control)
        {
            Control current = control;
            while (current is ContainerControl container && container.ActiveControl != null)
            {
                current = container.ActiveControl;
            }
            return current;
        }

        /// <summary>
        /// Xử lý khi phát hiện vi phạm: hiển thị cảnh báo, lưu DB, tự nộp bài nếu quá giới hạn
        /// </summary>
        private void XuLyViPham(string loaiViPham, int soLan, string thongBao)
        {
            // Hiển thị cảnh báo trên form
            lblCanhBaoViPham.Text = thongBao;
            lblCanhBaoViPham.Visible = true;

            int tongViPham = _soLanChuyenTab + _soLanCopy + _soLanPaste;

            // Lưu vi phạm vào database
            LuuViPhamVaoDb(loaiViPham, soLan);

            // Tự nộp bài nếu vượt quá giới hạn
            if (tongViPham >= MAX_VI_PHAM)
            {
                _dangHienDialog = true;
                MessageBox.Show(
                    "Bạn đã vi phạm " + tongViPham + " lần! Bài thi sẽ được tự động nộp.",
                    "Vi phạm quá nhiều",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                _dangHienDialog = false;
                NopBai_Click();
                return;
            }

            // Cảnh báo nếu gần đạt giới hạn
            int conLai = MAX_VI_PHAM - tongViPham;
            if (conLai <= 2)
            {
                _dangHienDialog = true;
                MessageBox.Show(
                    "Bạn còn " + conLai + " lần vi phạm nữa sẽ bị tự động nộp bài!\n" +
                    "Chuyển tab: " + _soLanChuyenTab + " | Copy: " + _soLanCopy + " | Paste: " + _soLanPaste,
                    "Cảnh báo vi phạm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _dangHienDialog = false;
            }
        }

        /// <summary>
        /// Lưu hoặc cập nhật vi phạm vào bảng NhatKyViPham
        /// </summary>
        private void LuuViPhamVaoDb(string loaiViPham, int soLan)
        {
            try
            {
                // Sử dụng _maBaiThi đã được tạo khi bắt đầu thi
                long? maBaiThi = _maBaiThi > 0 ? _maBaiThi : (long?)null;

                // Kiểm tra xem đã có nhật ký vi phạm loại này chưa
                var viPhamCu = duLieu.Set<NhatKyViPham>()
                    .FirstOrDefault(v => v.MaBaiThi == maBaiThi && v.LoaiViPham == loaiViPham);

                if (viPhamCu != null)
                {
                    // Cập nhật số lần vi phạm
                    viPhamCu.SoLanViPham = soLan;
                    viPhamCu.LanCuoiXayRa = DateTime.Now;
                }
                else
                {
                    // Tạo mới nhật ký vi phạm
                    var viPhamMoi = new NhatKyViPham
                    {
                        MaBaiThi = maBaiThi,
                        LoaiViPham = loaiViPham,
                        SoLanViPham = soLan,
                        LanCuoiXayRa = DateTime.Now,
                        NgayTao = DateTime.Now
                    };
                    duLieu.Set<NhatKyViPham>().Add(viPhamMoi);
                }

                duLieu.SaveChanges();
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nhưng không ảnh hưởng đến quá trình thi
                System.Diagnostics.Debug.WriteLine("Lỗi lưu vi phạm: " + ex.Message);
            }
        }

        private void pnlThi_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lblHienThi_TextChanged(object sender, EventArgs e)
        {
        }
    }
}