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
    public partial class frmThemSuaCauHoi : Form
    {
        private readonly MonHocService _monHocService;
        private readonly CauHoiService _cauHoiService;
        private readonly AppDbContext _context;
        private NguoiDung _nguoiDung;
        private CauHoiThi _cauHoi;
        private bool _isEdit = false;

        public frmThemSuaCauHoi(NguoiDung nguoiDung, CauHoiThi cauHoi = null)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            _monHocService = new MonHocService();
            _cauHoiService = new CauHoiService();
            _context = new AppDbContext();
            _nguoiDung = nguoiDung;
            _cauHoi = cauHoi;
            _isEdit = cauHoi != null;

            LoadMonHoc();

            if (_isEdit)
            {
                lblTitle.Text = "✏️ SỬA CÂU HỎI";
                LoadCauHoi();
            }
        }

        private void LoadMonHoc()
        {
            cboMonHoc.Items.Clear();
            var monHocs = _monHocService.GetThongTinMonThi();
            foreach (var mh in monHocs)
            {
                cboMonHoc.Items.Add(mh);
            }
            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "Id";
            
            if (monHocs.Count > 0)
                cboMonHoc.SelectedIndex = 0;
        }

        private void LoadCauHoi()
        {
            if (_cauHoi == null) return;

            // Load nội dung câu hỏi
            txtNoiDung.Text = _cauHoi.NoiDung;

            // Load môn học
            for (int i = 0; i < cboMonHoc.Items.Count; i++)
            {
                if (cboMonHoc.Items[i] is MonHoc mh && mh.Id == _cauHoi.MaMon)
                {
                    cboMonHoc.SelectedIndex = i;
                    break;
                }
            }

            // Load các lựa chọn
            var luaChons = _context.LuaChonTracNghiem
                .Where(l => l.MaCauHoi == _cauHoi.Id)
                .OrderBy(l => l.ThuTu)
                .ToList();

            if (luaChons.Count >= 1)
            {
                txtDapAnA.Text = luaChons[0].NoiDung;
                chkDapAnA.Checked = luaChons[0].LaDapAnDung;
            }
            if (luaChons.Count >= 2)
            {
                txtDapAnB.Text = luaChons[1].NoiDung;
                chkDapAnB.Checked = luaChons[1].LaDapAnDung;
            }
            if (luaChons.Count >= 3)
            {
                txtDapAnC.Text = luaChons[2].NoiDung;
                chkDapAnC.Checked = luaChons[2].LaDapAnDung;
            }
            if (luaChons.Count >= 4)
            {
                txtDapAnD.Text = luaChons[3].NoiDung;
                chkDapAnD.Checked = luaChons[3].LaDapAnDung;
            }
        }

        private bool ValidateInput()
        {
            if (cboMonHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMonHoc.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung câu hỏi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDung.Focus();
                return false;
            }

            // Kiểm tra ít nhất 2 đáp án
            int soDapAn = 0;
            if (!string.IsNullOrWhiteSpace(txtDapAnA.Text)) soDapAn++;
            if (!string.IsNullOrWhiteSpace(txtDapAnB.Text)) soDapAn++;
            if (!string.IsNullOrWhiteSpace(txtDapAnC.Text)) soDapAn++;
            if (!string.IsNullOrWhiteSpace(txtDapAnD.Text)) soDapAn++;

            if (soDapAn < 2)
            {
                MessageBox.Show("Vui lòng nhập ít nhất 2 đáp án!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra có ít nhất 1 đáp án đúng
            if (!chkDapAnA.Checked && !chkDapAnB.Checked && !chkDapAnC.Checked && !chkDapAnD.Checked)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 đáp án đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                var monHoc = (MonHoc)cboMonHoc.SelectedItem;

                if (_isEdit)
                {
                    // Cập nhật câu hỏi
                    _cauHoi.NoiDung = txtNoiDung.Text.Trim();
                    _cauHoi.MaMon = monHoc.Id;

                    _context.CauHoiThi.Update(_cauHoi);

                    // Xóa lựa chọn cũ
                    var oldLuaChons = _context.LuaChonTracNghiem.Where(l => l.MaCauHoi == _cauHoi.Id).ToList();
                    _context.LuaChonTracNghiem.RemoveRange(oldLuaChons);
                    _context.SaveChanges();

                    // Thêm lựa chọn mới
                    AddLuaChons(_cauHoi.Id);
                    
                    MessageBox.Show("Cập nhật câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Thêm câu hỏi mới
                    var cauHoi = new CauHoiThi
                    {
                        NoiDung = txtNoiDung.Text.Trim(),
                        MaMon = monHoc.Id,
                        NguoiTao = _nguoiDung.Id,
                        NgayTao = DateTime.Now,
                        TrangThai = true
                    };

                    _context.CauHoiThi.Add(cauHoi);
                    _context.SaveChanges();

                    // Thêm lựa chọn
                    AddLuaChons(cauHoi.Id);

                    MessageBox.Show("Thêm câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddLuaChons(long cauHoiId)
        {
            var luaChons = new List<LuaChonTracNghiem>();
            int thuTu = 1;

            if (!string.IsNullOrWhiteSpace(txtDapAnA.Text))
            {
                luaChons.Add(new LuaChonTracNghiem
                {
                    MaCauHoi = cauHoiId,
                    NoiDung = txtDapAnA.Text.Trim(),
                    ThuTu = thuTu++,
                    LaDapAnDung = chkDapAnA.Checked
                });
            }

            if (!string.IsNullOrWhiteSpace(txtDapAnB.Text))
            {
                luaChons.Add(new LuaChonTracNghiem
                {
                    MaCauHoi = cauHoiId,
                    NoiDung = txtDapAnB.Text.Trim(),
                    ThuTu = thuTu++,
                    LaDapAnDung = chkDapAnB.Checked
                });
            }

            if (!string.IsNullOrWhiteSpace(txtDapAnC.Text))
            {
                luaChons.Add(new LuaChonTracNghiem
                {
                    MaCauHoi = cauHoiId,
                    NoiDung = txtDapAnC.Text.Trim(),
                    ThuTu = thuTu++,
                    LaDapAnDung = chkDapAnC.Checked
                });
            }

            if (!string.IsNullOrWhiteSpace(txtDapAnD.Text))
            {
                luaChons.Add(new LuaChonTracNghiem
                {
                    MaCauHoi = cauHoiId,
                    NoiDung = txtDapAnD.Text.Trim(),
                    ThuTu = thuTu++,
                    LaDapAnDung = chkDapAnD.Checked
                });
            }

            _context.LuaChonTracNghiem.AddRange(luaChons);
            _context.SaveChanges();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
