using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    public partial class frmThemSuaKyThi : Form
    {
        private readonly KyThiService _kyThiService;
        private readonly NganHangDeService _nganHangDeService;
        private readonly LopHocService _lopHocService;
        private readonly AppDbContext _context;
        private NguoiDung _nguoiDung;
        private KyThi _kyThi;
        private bool _isEdit = false;

        public frmThemSuaKyThi(NguoiDung nguoiDung, KyThi kyThi = null)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            _kyThiService = new KyThiService();
            _nganHangDeService = new NganHangDeService();
            _lopHocService = new LopHocService();
            _context = new AppDbContext();
            _nguoiDung = nguoiDung;
            _kyThi = kyThi;
            _isEdit = kyThi != null;

            // Không cho chọn ngày đã qua
            dtpNgayBatDau.MinDate = DateTime.Today;

            // Đổ dữ liệu combobox giờ & phút
            LoadGioPhut();
            LoadComboBoxes();

            // Đổi khung đề → lọc lại danh sách lớp theo phân công + môn
            cboKhungDe.SelectedIndexChanged += (s, e) => LoadLopHocTheoKhungDe();

            if (_isEdit)
            {
                lblTitle.Text = "✏️ SỬA KỲ THI";
                LoadKyThi();
            }
            else
            {
                dtpNgayBatDau.Value = DateTime.Now.AddDays(1);
                cboGio.SelectedIndex = 8;   // 08 giờ
                numPhut.Value = 0;  // 00 phút
            }

            // Khi đổi ngày → cập nhật lại danh sách giờ hợp lệ
            dtpNgayBatDau.ValueChanged += (s, e) => UpdateGioPhutMinDate();
        }

        private void LoadLopHocTheoKhungDe()
        {
            cboLopHoc.Items.Clear();

            // Mặc định: với giảng viên thì chỉ hiển thị lớp đã được phân công.
            // Nếu khung đề có môn học → lọc theo đúng môn đó.
            List<LopHoc> lopHocs;
            if (_nguoiDung?.MaVaiTro == 2)
            {
                if (cboKhungDe.SelectedItem is NganHangDe nhd && nhd.MaMon != null)
                    lopHocs = _lopHocService.GetLopHocDuocPhanCong(_nguoiDung.Id, nhd.MaMon.Value);
                else
                    lopHocs = _lopHocService.GetLopHocDuocPhanCong(_nguoiDung.Id);
            }
            else
            {
                // Không phải giảng viên (ví dụ admin) → giữ hành vi cũ
                lopHocs = _lopHocService.GetAll();
            }

            foreach (var lh in lopHocs)
                cboLopHoc.Items.Add(lh);

            // Nếu đang sửa kỳ thi cũ mà lớp không còn trong danh sách lọc,
            // vẫn add vào để form không bị trống / không load được.
            if (_isEdit && _kyThi?.MaLop != null)
            {
                var maLopEdit = _kyThi.MaLop.Value;
                bool exists = lopHocs.Any(l => l.Id == maLopEdit);
                if (!exists)
                {
                    var lopEdit = _context.LopHoc.FirstOrDefault(l => l.Id == maLopEdit);
                    if (lopEdit != null)
                        cboLopHoc.Items.Add(lopEdit);
                }
            }

            cboLopHoc.DisplayMember = "TenLop";
            cboLopHoc.ValueMember = "Id";

            if (cboLopHoc.Items.Count > 0)
                cboLopHoc.SelectedIndex = 0;
        }

        private void LoadGioPhut()
        {
            // Giờ: 0 → 23
            cboGio.Items.Clear();
            for (int h = 0; h < 24; h++)
                cboGio.Items.Add(h.ToString("D2"));
            cboGio.DisplayMember = null;
            cboGio.ValueMember = null;

            // Phút: numPhut đã cài min=0, max=59 trong Designer
        }

        /// <summary>
        /// Nếu ngày chọn là hôm nay → loại bỏ các giờ đã qua
        /// </summary>
        private void UpdateGioPhutMinDate()
        {
            if (dtpNgayBatDau.Value.Date == DateTime.Today)
            {
                int currentHour = DateTime.Now.Hour;
                // Nếu giờ đang chọn đã qua → chọn giờ tiếp theo
                if (cboGio.SelectedIndex >= 0 && cboGio.SelectedIndex < currentHour)
                {
                    if (currentHour < 24)
                        cboGio.SelectedIndex = currentHour;
                }
            }
        }

        private void LoadComboBoxes()
        {
            cboKhungDe.Items.Clear();
            var nganHangDes = _nganHangDeService.GetByNguoiTao(_nguoiDung.Id);
            foreach (var nhd in nganHangDes)
                cboKhungDe.Items.Add(nhd);
            cboKhungDe.DisplayMember = "TenDe";
            cboKhungDe.ValueMember = "Id";

            if (nganHangDes.Count > 0)
                cboKhungDe.SelectedIndex = 0;

            // Lớp học sẽ được load theo khung đề + phân công
            LoadLopHocTheoKhungDe();
        }

        private void LoadKyThi()
        {
            if (_kyThi == null) return;

            txtTenKyThi.Text = _kyThi.TenKyThi;
            numThoiLuong.Value = _kyThi.ThoiLuongPhut;
            numTongDiem.Value = _kyThi.TongDiem ?? 100;
            dtpNgayBatDau.Value = _kyThi.ThoiGianBatDau.Date;

            // Chọn giờ
            int gio = _kyThi.ThoiGianBatDau.Hour;
            if (gio >= 0 && gio < cboGio.Items.Count)
                cboGio.SelectedIndex = gio;

            // Chọn phút
            numPhut.Value = _kyThi.ThoiGianBatDau.Minute;

            chkTronCauHoi.Checked = _kyThi.TronCauHoi;
            chkTronDapAn.Checked = _kyThi.TronDapAn;

            for (int i = 0; i < cboKhungDe.Items.Count; i++)
            {
                if (cboKhungDe.Items[i] is NganHangDe nhd && nhd.Id == _kyThi.MaNganHangDe)
                { cboKhungDe.SelectedIndex = i; break; }
            }
            for (int i = 0; i < cboLopHoc.Items.Count; i++)
            {
                if (cboLopHoc.Items[i] is LopHoc lh && lh.Id == _kyThi.MaLop)
                { cboLopHoc.SelectedIndex = i; break; }
            }
        }

        // ===== Helper =====
        private DateTime GetThoiGianBatDau()
        {
            int gio = cboGio.SelectedIndex >= 0 ? cboGio.SelectedIndex : 8;
            int phut = (int)numPhut.Value;
            return dtpNgayBatDau.Value.Date.AddHours(gio).AddMinutes(phut);
        }

        private DateTime GetThoiGianKetThuc()
        {
            return GetThoiGianBatDau().AddMinutes((double)numThoiLuong.Value);
        }

        // ===== Validation =====
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenKyThi.Text))
            {
                MessageBox.Show("Vui lòng nhập tên kỳ thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKyThi.Focus();
                return false;
            }
            if (cboKhungDe.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn khung đề!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboLopHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn lớp học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Chặn tạo kỳ thi cho lớp chưa được phân công (áp dụng cho giảng viên)
            if (_nguoiDung?.MaVaiTro == 2)
            {
                var khungDe = (NganHangDe)cboKhungDe.SelectedItem;
                var lopHoc = (LopHoc)cboLopHoc.SelectedItem;

                if (khungDe.MaMon == null)
                {
                    MessageBox.Show("Khung đề chưa gắn môn học nên không thể kiểm tra phân công.\nVui lòng cập nhật khung đề (chọn môn học).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!_lopHocService.IsGiangVienDuocPhanCong(_nguoiDung.Id, lopHoc.Id, khungDe.MaMon.Value))
                {
                    MessageBox.Show("Bạn chưa được phân công giảng dạy môn này cho lớp đã chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (cboGio.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giờ bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!_isEdit && GetThoiGianBatDau() <= DateTime.Now)
            {
                MessageBox.Show("Thời gian bắt đầu không được là thời gian đã qua!\nVui lòng chọn giờ/phút trong tương lai.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numThoiLuong.Value < 5)
            {
                MessageBox.Show("Thời lượng thi phải ít nhất 5 phút!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numThoiLuong.Focus();
                return false;
            }
            return true;
        }

        // ===== Save =====
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                var khungDe = (NganHangDe)cboKhungDe.SelectedItem;
                var lopHoc = (LopHoc)cboLopHoc.SelectedItem;

                if (_isEdit)
                {
                    _kyThi.TenKyThi = txtTenKyThi.Text.Trim();
                    _kyThi.MaNganHangDe = khungDe.Id;
                    _kyThi.MaLop = lopHoc.Id;
                    _kyThi.ThoiGianBatDau = GetThoiGianBatDau();
                    _kyThi.ThoiGianKetThuc = GetThoiGianKetThuc();
                    _kyThi.ThoiLuongPhut = (int)numThoiLuong.Value;
                    _kyThi.TongDiem = (int)numTongDiem.Value;
                    _kyThi.TronCauHoi = chkTronCauHoi.Checked;
                    _kyThi.TronDapAn = chkTronDapAn.Checked;

                    if (_kyThiService.Update(_kyThi))
                    {
                        MessageBox.Show("Cập nhật kỳ thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                        MessageBox.Show("Không thể cập nhật kỳ thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var kyThi = new KyThi
                    {
                        TenKyThi = txtTenKyThi.Text.Trim(),
                        MaNganHangDe = khungDe.Id,
                        MaLop = lopHoc.Id,
                        ThoiGianBatDau = GetThoiGianBatDau(),
                        ThoiGianKetThuc = GetThoiGianKetThuc(),
                        ThoiLuongPhut = (int)numThoiLuong.Value,
                        TongDiem = (int)numTongDiem.Value,
                        TronCauHoi = chkTronCauHoi.Checked,
                        TronDapAn = chkTronDapAn.Checked,
                        NgayTao = DateTime.Now
                    };

                    if (_kyThiService.Add(kyThi))
                    {
                        CreateBaiThiForStudents(kyThi.Id, lopHoc.Id);
                        MessageBox.Show("Tạo kỳ thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                        MessageBox.Show("Không thể tạo kỳ thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateBaiThiForStudents(long kyThiId, long lopHocId)
        {
            var sinhViens = _context.LopHocSinhVien
                .Where(l => l.MaLop == lopHocId)
                .Select(l => l.MaSinhVien)
                .ToList();

            foreach (var svId in sinhViens)
            {
                _context.BaiThi.Add(new BaiThi
                {
                    MaKyThi = kyThiId,
                    MaSinhVien = svId,
                    TrangThai = "chua_thi"
                });
            }
            _context.SaveChanges();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
