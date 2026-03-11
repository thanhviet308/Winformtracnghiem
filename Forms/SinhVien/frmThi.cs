using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Forms;
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
            for (int i = 0; i < CauHoiService.GetThongTinCauHoi().Count(); i++)
            {
                layDapAnThi.Add(null);
           
            }
        }

        private void flowLayoutPanel1_Paint()
        {
            // Tạo ô câu hỏi bên trái
            int x = 10, y = 105;
            int soCauHoi = 0;
            foreach (var item in CauHoiService.GetThongTinCauHoi())
            {
                if(item.MaMT == monThi.Id.ToString())
                {
                    soCauHoi++;
                    cauHoiMonThi.Add(item);
                }          
            }
            for (int i = 0; i < cauHoiMonThi.Count; i++)
            {
                oCauHoi.Add(TaoNut((i + 1), ref x, ref y));

                x += 60;

                if ((i + 1) % 2 == 0)
                {
                    y += 40;
                    x = 10;
                }
                luuBaiCham.Add(TaoCauHoi( i));
            }
            
            // Tạo tất cả câu hỏi trong vùng chứa câu hỏi
            // Note: danhMucCauHoiBAL.GetCauHoi() không còn dùng nữa
        }

        private GroupBox TaoCauHoi(int i)
        {
            // Tạo mỗi GroupBox chứa mỗi 1 câu hỏi
            GroupBox groupBox = new GroupBox();
            groupBox.Location = new Point();
            groupBox.Font = new Font("Be Vietnam Pro", 10, FontStyle.Bold);
            groupBox.Text = "Câu " + (i+1);
            groupBox.Name = (i+1).ToString();
            groupBox.Size = new System.Drawing.Size(1780, 300);
            flowLayoutPanel1.Controls.Add(groupBox);

            // Tiếp theo ta tạo câu hỏi
            Label label = new Label();
            label.Location = new Point(30, 30);
            label.Size = new Size(1600, 50);
            label.Name = i.ToString();
            label.Font = new Font("Be Vietnam Pro", 10);
            
            label.Text = cauHoiMonThi[i].NDCAUHOI;
            groupBox.Controls.Add(label);

            for (int j = 0; j < 4; j++)
            {
                RadioButton rdo = new RadioButton();
                if (j == 1 || j == 3)
                {
                    rdo.Location = new Point(800, 150 + ((j - 1) * 30));
                }
                else
                {
                    rdo.Location = new Point(30, 150 + (j * 30));
                }
                rdo.Size = new Size(450, 30);
                rdo.Name = "rdo" + j.ToString();
                rdo.Font = new Font("Be Vietnam Pro", 10);

                // Lấy 4 đáp án
                if (j == 0)
                {
                    rdo.Text = cauHoiMonThi[i].DapAn1;
                }
                if (j == 1)
                {
                    rdo.Text = cauHoiMonThi[i].DapAn2;
                }
                if (j == 2)
                {
                    rdo.Text = cauHoiMonThi[i].DapAn3;
                }
                if (j == 3)
                {
                    rdo.Text = cauHoiMonThi[i].DapAn4;
                }

                groupBox.Controls.Add(rdo);

                rdo.Click += (sender, EventArgs) => { buttonNext_Click(sender, EventArgs, groupBox.Name, rdo, (i + 1)) ; };
            }

            return groupBox;
        }

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
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Size = new Size(42, 36);
            btn.BackColor = Color.White;
            btn.Focus();

            panelMenu.Controls.Add(btn);
            btn.BringToFront();

            return btn;
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
                _dangHienDialog = true;
                MessageBox.Show("Hết giờ làm bài!!");
                _dangHienDialog = false;
                NopBai_Click();
            }
            else
            {
                HienThiPhutGio();
            }
        }

        private void NopBai_Click()
        {
            // Lấy thời gian kết thúc thi
            DateTime thoiGianThi = DateTime.Now;
            float diemMotCau;
            float diemThi = 0;
            int demSoCauDung = 0;
            int soCauHoi = CauHoiService.GetThongTinCauHoi().Count();
            diemMotCau = (float)10.0 / soCauHoi;
            List<int> luuBaiLam = new List<int>(soCauHoi);
            for (int i = 0; i < soCauHoi; i++)
            {
                luuBaiLam.Add(0);
            }

            for (int i = 0; i < soCauHoi; i++)
            {
                if (layDapAnThi[i] != null)
                {
                    if (String.Equals(layDapAnThi[i].Text.ToString(), CauHoiService.GetThongTinCauHoi()[i].DapAnDung))
                    {
                        diemThi += diemMotCau;
                        demSoCauDung++;
                        luuBaiLam[i] = 1;
                    }
                }
            }
            diemThi = (float)(Math.Round(diemThi, 2));

            // Lưu dữ liệu: cập nhật bài thi đã tạo khi bắt đầu thi
            if (_maBaiThi > 0)
            {
                try
                {
                    var baiThi = duLieu.Set<BaiThi>().Find(_maBaiThi);
                    if (baiThi != null)
                    {
                        baiThi.ThoiGianNopBai = thoiGianThi;
                        baiThi.DiemSo = (int)Math.Round(diemThi);
                        baiThi.TrangThai = "da_nop";
                        duLieu.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi cập nhật bài thi: " + ex.Message);
                }
            }

            // Hiển thị màn hình nộp bài thành công (không hiện điểm)
            // Điểm sẽ được xem ở lịch sử thi sau khi kỳ thi kết thúc
            _dangHienDialog = true;
            this.Deactivate -= FrmThi_Deactivate; // Gỡ sự kiện chống gian lận khi đã nộp bài
            ThiTracNghiem thiTracNghiem = new ThiTracNghiem(nguoiDung);
            thiTracNghiem.HienThiNopBaiThanhCong(DateTime.Now);
            this.Hide();
            thiTracNghiem.ShowDialog();
            this.Close();
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
                e.SuppressKeyPress = true; // Chặn copy
                XuLyViPham("copy", _soLanCopy, "⚠ Cảnh báo: Không được phép copy! (" + _soLanCopy + " lần)");
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                _soLanPaste++;
                e.SuppressKeyPress = true; // Chặn paste
                XuLyViPham("paste", _soLanPaste, "⚠ Cảnh báo: Không được phép paste! (" + _soLanPaste + " lần)");
            }
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