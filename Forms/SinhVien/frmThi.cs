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


        public int TongThoiGian = 6;
        int iPhut = 0;
        int iGiay = 0;



        public frmThi(NguoiDung nd, MonHoc mt, DateTime ThoiGianBatDauVaoThi, DateTime thoiGianKetThucThi)
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

            // Hiển thị thông tin sinh viên 
            lblTenSinhVien.Text = nguoiDung.HoTen.ToString() + "  ||  " + nguoiDung.Email.ToString();

            // Hiển thị môn thi
            lblMonThi.Text = monThi.TenMon;
            lblMonThi.Name = monThi.Id.ToString();

            // Gọi khung hiển thị câu hỏi trắc nghiệm
            flowLayoutPanel1.Enabled = true;
            flowLayoutPanel1_Paint();
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
            DialogResult result = MessageBox.Show("Bạn có muốn nộp bài không?", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;
            NopBai_Click();
        }

        // TÍNH THỜI GIAN CÒN LẠI
        private void btnDemNguoc_Click(object sender, EventArgs e)
        {
            TongThoiGian = (thoiGianKetThuc.Hour - DateTime.Now.Hour) * 60 + (60 - thoiGianBatDau.Minute) + thoiGianKetThuc.Minute;
            iPhut = TongThoiGian - 1;
            iGiay = 59;
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
                MessageBox.Show("Hết giờ làm bài!!");
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

            // Lưu dữ liệu vào Chi Tiết Kỳ Thi và Lưu Điểm
            // Tìm thời gian khớp diễn ra kỳ thi để thêm cập nhật điểm, thời gian kết thúc thi và thời gian thi
            foreach (var item in kiThiBAL.GetThongTinKyThi())
            {
                if (DateTime.Now >= item.ThoiGianBatDau && DateTime.Now <= item.ThoiGianKetThuc)
                {
                    foreach (var i in ChiTietKyThiService.GetThongTinChiTietKyThi())
                    {
                        ChiTietKyThiService.LuuChiTietKyThi(nguoiDung, item.Id.ToString(), monThi, diemThi, thoiGianBatDau, thoiGianThi, (thoiGianThi.Hour * 60 + thoiGianThi.Minute) - (thoiGianBatDau.Hour * 60 + thoiGianBatDau.Minute));
                        break;
                    }
                }
            }

            // Hiển thị điểm
            ThiTracNghiem thiTracNghiem = new ThiTracNghiem(nguoiDung);
            thiTracNghiem.HienThi(diemThi, demSoCauDung, luuBaiLam);
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

        private void pnlThi_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lblHienThi_TextChanged(object sender, EventArgs e)
        {
        }
    }
}