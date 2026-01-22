using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.SinhVien
{
    public partial class frmSinhVien : Form
    {
        AppDbContext AppDbContext = new AppDbContext();

        KyThiService KyThiService;
        MonHocService MonHocService;
        BaiThiService BaiThiService;
        NguoiDung nguoiDung;
        MonHoc monHoc;
        KyThi kyThiHienTai;
        DateTime thoiGianThiGanNhat = DateTime.Now;
        DateTime thoiGianThi ;
        DateTime thoiGianKetThuc;

        public frmSinhVien(NguoiDung nd)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            KyThiService = new KyThiService();
            MonHocService = new MonHocService();
            BaiThiService = new BaiThiService();
            nguoiDung = nd;
        }
        public frmSinhVien(NguoiDung nd, int i)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            KyThiService = new KyThiService();
            nguoiDung = nd;
            btnVaoThi.Enabled = false;
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            btnXemDiem.Hide();
            
            // Ẩn trường Lớp (không còn trong NguoiDung)
            label2.Visible = false;
            lblLop.Visible = false;

            lblHoTen.Text = nguoiDung.HoTen;
            
            // Tìm kỳ thi đang diễn ra
            var kyThiDangDienRa = KyThiService.GetActiveExams();
            
            if (kyThiDangDienRa.Count > 0)
            {
                kyThiHienTai = kyThiDangDienRa.First();
                lblTenKyThi.Text = kyThiHienTai.TenKyThi.ToUpper();
                thoiGianThi = kyThiHienTai.ThoiGianBatDau;
                thoiGianKetThuc = kyThiHienTai.ThoiGianKetThuc;
                
                lblNgayThi.Text = kyThiHienTai.ThoiGianBatDau.ToString("dd/MM/yyyy");
                lblThoiGianBatDau.Text = kyThiHienTai.ThoiGianBatDau.ToString("HH:mm");
                lblThoiGianKetThuc.Text = kyThiHienTai.ThoiGianKetThuc.ToString("HH:mm");

                // Lấy môn học từ ngân hàng đề
                if (kyThiHienTai.NganHangDe != null && kyThiHienTai.NganHangDe.MonHoc != null)
                {
                    monHoc = kyThiHienTai.NganHangDe.MonHoc;
                    lblMonThi.Text = monHoc.TenMon;
                }
            }
            else
            {
                lblTenKyThi.Text = "Không có kỳ thi nào đang diễn ra";
                btnVaoThi.Enabled = false;
            }
        }

        // Bỏ kiểm tra trường hợp ngày thay đổi "Thi đêm"
        private bool KiemTraThoiGianVaoThi()
        {
            if (kyThiHienTai == null) return false;

            var now = DateTime.Now;
            return now >= thoiGianThi && now <= thoiGianKetThuc;
        }

        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            frmBangDiem frmBangDiem = new frmBangDiem(nguoiDung);
            this.Hide();
            frmBangDiem.ShowDialog();         
            this.Close();



        }
        private void btnVaoThi_Click(object sender, EventArgs e)
        {
            if (KiemTraThoiGianVaoThi() == true)
            {
                frmThi frmThi = new frmThi(nguoiDung, monHoc, DateTime.Now, thoiGianKetThuc);
                this.Hide();
                frmThi.WindowState = FormWindowState.Maximized;
                frmThi.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Chưa đến thời gian bắt đầu thi \nHiện tại là: " + DateTime.Now.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.ShowDialog();
            this.Close();
        }
    }
}
