using PhanMemThiTracNghiem.Data;
using ExcelDataReader;
using OfficeOpenXml;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using PhanMemThiTracNghiem.Forms.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;


using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    public partial class frmGiangVien : Form
    {
        private readonly MonHocService MonHocService;
        private readonly CauHoiService CauHoiService;
        AppDbContext context = new AppDbContext();
        private NguoiDung nguoiDung;
        
        public frmGiangVien(NguoiDung nd)
        {
            nguoiDung = nd;
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            CauHoiService = new CauHoiService();
            MonHocService = new MonHocService();        
        }

     

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            dgvCauHoi.DataSource = CauHoiService.GetCAUHOIs();
            txtMaGV.Text = nguoiDung.Email;
            txtTenGV.Text = nguoiDung.HoTen;
            txtPassword.Text = "********"; // Không hiển thị mật khẩu thật
            
            // Ẩn panel ngày sinh (không còn trong NguoiDung)
            panel3.Visible = false;
            // Di chuyển panel mật khẩu lên
            panel4.Location = panel3.Location;

            cbDanhMucMT.Items.Clear();
            foreach (var item in MonHocService.GetThongTinMonThi())
            {
                cbDanhMucMT.Items.Add(item.TenMon);
            }
            cbDanhMucMT.SelectedIndex = -1;

        }





        DataTableCollection tableCollection;
        private void btnNhap_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook| *.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // txtFileName.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cboSheet.Items.Add(table.TableName); //add sheet to combobox
                        }
                    }
                }
            }
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];

            if (dt != null)
            {
                List<CauHoiDTO> listcauHoi = new List<CauHoiDTO>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CauHoiDTO cauHoi = new CauHoiDTO();
                    cauHoi.STT = int.Parse(dt.Rows[i]["STT"].ToString());
                    cauHoi.MaCauHoi = int.Parse(dt.Rows[i]["IDCAUHOI"].ToString());
                    cauHoi.NDCAUHOI = dt.Rows[i]["NDCAUHOI"].ToString();
                    cauHoi.DapAn1 = dt.Rows[i]["DAPAN1"].ToString();
                    cauHoi.DapAn2 = dt.Rows[i]["DAPAN2"].ToString();
                    cauHoi.DapAn3 = dt.Rows[i]["DAPAN3"].ToString();
                    cauHoi.DapAn4 = dt.Rows[i]["DAPAN4"].ToString();
                    cauHoi.DapAnDung = dt.Rows[i]["DAPANDUNG"].ToString();
                    listcauHoi.Add(cauHoi);
                }
                dgvCauHoi.DataSource = listcauHoi;
            }
        }

        private void dgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                dgvCauHoi.CurrentRow.Selected = true;
                txtMaCauHoi.Text = dgvCauHoi.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
                txtNoiDungCauHoi.Text = dgvCauHoi.Rows[e.RowIndex].Cells["NoiDung"].FormattedValue.ToString();
                
                // TODO: Cập nhật logic hiển thị đáp án cho model mới
                // Với model mới, đáp án nằm trong bảng LuaChonTracNghiem riêng
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (tableCollection == null || cboSheet.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn file Excel và sheet trước!");
                    return;
                }

                DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
                string tenMon = cbDanhMucMT.Text;

                if (string.IsNullOrEmpty(tenMon))
                {
                    MessageBox.Show("Vui lòng chọn môn học!");
                    return;
                }

                // Tìm môn học
                var monHoc = context.MonHoc.FirstOrDefault(m => m.TenMon == tenMon);
                if (monHoc == null)
                {
                    MessageBox.Show("Không tìm thấy môn học!");
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // Tạo câu hỏi mới
                    var cauHoi = new CauHoiThi
                    {
                        NoiDung = dt.Rows[i]["NDCAUHOI"].ToString(),
                        MaMon = monHoc.Id,
                        NguoiTao = nguoiDung.Id,
                        NgayTao = DateTime.Now,
                        TrangThai = true
                    };
                    context.CauHoiThi.Add(cauHoi);
                    context.SaveChanges();

                    // Tạo các lựa chọn
                    var luaChons = new List<LuaChonTracNghiem>
                    {
                        new LuaChonTracNghiem { MaCauHoi = cauHoi.Id, NoiDung = dt.Rows[i]["DAPAN1"].ToString(), ThuTu = 1, LaDapAnDung = dt.Rows[i]["DAPANDUNG"].ToString() == dt.Rows[i]["DAPAN1"].ToString() },
                        new LuaChonTracNghiem { MaCauHoi = cauHoi.Id, NoiDung = dt.Rows[i]["DAPAN2"].ToString(), ThuTu = 2, LaDapAnDung = dt.Rows[i]["DAPANDUNG"].ToString() == dt.Rows[i]["DAPAN2"].ToString() },
                        new LuaChonTracNghiem { MaCauHoi = cauHoi.Id, NoiDung = dt.Rows[i]["DAPAN3"].ToString(), ThuTu = 3, LaDapAnDung = dt.Rows[i]["DAPANDUNG"].ToString() == dt.Rows[i]["DAPAN3"].ToString() },
                        new LuaChonTracNghiem { MaCauHoi = cauHoi.Id, NoiDung = dt.Rows[i]["DAPAN4"].ToString(), ThuTu = 4, LaDapAnDung = dt.Rows[i]["DAPANDUNG"].ToString() == dt.Rows[i]["DAPAN4"].ToString() }
                    };
                    context.LuaChonTracNghiem.AddRange(luaChons);
                    context.SaveChanges();
                }

                MessageBox.Show("Lưu thành công!");
                frmGiangVien_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                long maCauHoi = long.Parse(txtMaCauHoi.Text);
                var cauHoi = CauHoiService.GetById(maCauHoi);
                if (cauHoi != null)
                {
                    cauHoi.NoiDung = txtNoiDungCauHoi.Text;
                    CauHoiService.Update(cauHoi);
                    MessageBox.Show("Cập nhật thành công!");
                    frmGiangVien_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenMon = cbDanhMucMT.Text;
                var monHoc = context.MonHoc.FirstOrDefault(m => m.TenMon == tenMon);

                if (monHoc == null)
                {
                    MessageBox.Show("Vui lòng chọn môn học!");
                    return;
                }

                var cauHoi = new CauHoiThi
                {
                    NoiDung = txtNoiDungCauHoi.Text,
                    MaMon = monHoc.Id,
                    NguoiTao = nguoiDung.Id,
                    NgayTao = DateTime.Now,
                    TrangThai = true
                };
                context.CauHoiThi.Add(cauHoi);
                context.SaveChanges();

                // Tạo các lựa chọn
                var dapAnDung = "";
                if (checkBoxA.Checked) dapAnDung = txtDapAnA.Text;
                else if (checkBoxB.Checked) dapAnDung = txtDapAnB.Text;
                else if (checkBoxC.Checked) dapAnDung = txtDapAnC.Text;
                else if (checkBoxD.Checked) dapAnDung = txtDapAnD.Text;

                var luaChons = new List<LuaChonTracNghiem>
                {
                    new LuaChonTracNghiem { MaCauHoi = cauHoi.Id, NoiDung = txtDapAnA.Text, ThuTu = 1, LaDapAnDung = checkBoxA.Checked },
                    new LuaChonTracNghiem { MaCauHoi = cauHoi.Id, NoiDung = txtDapAnB.Text, ThuTu = 2, LaDapAnDung = checkBoxB.Checked },
                    new LuaChonTracNghiem { MaCauHoi = cauHoi.Id, NoiDung = txtDapAnC.Text, ThuTu = 3, LaDapAnDung = checkBoxC.Checked },
                    new LuaChonTracNghiem { MaCauHoi = cauHoi.Id, NoiDung = txtDapAnD.Text, ThuTu = 4, LaDapAnDung = checkBoxD.Checked }
                };
                context.LuaChonTracNghiem.AddRange(luaChons);
                context.SaveChanges();

                MessageBox.Show("Thêm thành công!");
                frmGiangVien_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                dgvCauHoi.CurrentRow.Selected = true;
                long id = long.Parse(dgvCauHoi.SelectedRows[0].Cells["Id"].Value.ToString());
                CauHoiService.Delete(id);
                MessageBox.Show("Xóa thành công!!!");
                dgvCauHoi.DataSource = CauHoiService.GetCAUHOIs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

    

        private void btnAnHien_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DoiMKGiangVien doiMK = new DoiMKGiangVien((int)nguoiDung.Id);
            doiMK.ShowDialog();
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
