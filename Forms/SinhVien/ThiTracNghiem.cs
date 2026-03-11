using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using PhanMemThiTracNghiem.Forms.SinhVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PhanMemThiTracNghiem
{
    public partial class ThiTracNghiem : Form
    {
        private readonly NguoiDung nguoiDung;
        public ThiTracNghiem(NguoiDung nd)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            nguoiDung = nd;

            // Ẩn panel điểm và panel ô đúng sai
            panel1.Visible = false;
            pnlHienThiODungSai.Visible = false;
        }

        /// <summary>
        /// Hiển thị màn hình nộp bài thành công (không hiện điểm)
        /// Điểm sẽ được xem ở lịch sử thi sau khi kỳ thi kết thúc
        /// </summary>
        internal void HienThiNopBaiThanhCong(DateTime thoiGianNopBai)
        {
            // Ẩn các panel cũ
            panel1.Visible = false;
            pnlHienThiODungSai.Visible = false;

            // ===== ICON CHECK THÀNH CÔNG =====
            Panel pnlIcon = new Panel
            {
                Size = new Size(100, 100),
                BackColor = Color.Transparent
            };
            pnlIcon.Paint += (s, ev) =>
            {
                ev.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(Color.FromArgb(40, 167, 69)))
                {
                    ev.Graphics.FillEllipse(brush, 5, 5, 90, 90);
                }
                using (var pen = new Pen(Color.White, 5))
                {
                    ev.Graphics.DrawLine(pen, 28, 50, 43, 65);
                    ev.Graphics.DrawLine(pen, 43, 65, 72, 35);
                }
            };

            // ===== TIÊU ĐỀ =====
            Label lblThanhCong = new Label
            {
                Text = "Nộp bài thành công!",
                Font = new Font("Be Vietnam Pro", 22, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 167, 69),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // ===== THÔNG BÁO PHỤ =====
            Label lblThongBao = new Label
            {
                Text = "Điểm số sẽ được công bố sau khi kỳ thi kết thúc.\nBạn có thể xem điểm trong mục \"Lịch sử thi\".",
                Font = new Font("Be Vietnam Pro", 12),
                ForeColor = Color.FromArgb(200, 200, 200),
                AutoSize = true,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // ===== THỜI GIAN NỘP =====
            Label lblThoiGian = new Label
            {
                Text = "Thời gian nộp: " + thoiGianNopBai.ToString("HH:mm:ss  dd/MM/yyyy"),
                Font = new Font("Be Vietnam Pro", 11),
                ForeColor = Color.FromArgb(160, 160, 170),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // ===== NÚT QUAY LẠI =====
            var btnQuayLai = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Quay lại trang chính",
                Font = new Font("Be Vietnam Pro", 12, FontStyle.Bold),
                Size = new Size(260, 50),
                FillColor = Color.FromArgb(94, 148, 255),
                ForeColor = Color.White,
                BorderRadius = 10,
                Cursor = Cursors.Hand
            };
            btnQuayLai.Click += (s, ev) =>
            {
                int i = 1;
                frmSinhVienNew frmSV = new frmSinhVienNew(nguoiDung, i);
                this.Hide();
                frmSV.ShowDialog();
                this.Close();
            };

            // ===== BỐ TRÍ GIAO DIỆN =====
            // Tính toán vị trí giữa form
            int centerX = this.ClientSize.Width / 2;
            int startY = 80;

            pnlIcon.Location = new Point(centerX - pnlIcon.Width / 2, startY);
            this.Controls.Add(pnlIcon);
            pnlIcon.BringToFront();

            startY += pnlIcon.Height + 20;
            lblThanhCong.Location = new Point(centerX - lblThanhCong.PreferredWidth / 2, startY);
            this.Controls.Add(lblThanhCong);
            lblThanhCong.BringToFront();

            startY += lblThanhCong.PreferredHeight + 20;
            lblThongBao.Location = new Point(centerX - lblThongBao.PreferredWidth / 2, startY);
            this.Controls.Add(lblThongBao);
            lblThongBao.BringToFront();

            startY += lblThongBao.PreferredHeight + 25;
            lblThoiGian.Location = new Point(centerX - lblThoiGian.PreferredWidth / 2, startY);
            this.Controls.Add(lblThoiGian);
            lblThoiGian.BringToFront();

            startY += lblThoiGian.PreferredHeight + 35;
            btnQuayLai.Location = new Point(centerX - btnQuayLai.Width / 2, startY);
            this.Controls.Add(btnQuayLai);
            btnQuayLai.BringToFront();

            // Ẩn hình ngôi sao 2 bên (nếu có)
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void ThiTracNghiem_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int i = 1;
            frmSinhVienNew frmSV = new frmSinhVienNew(nguoiDung, i);
            this.Hide();
            frmSV.ShowDialog();
            this.Close();

        }
    }
}
