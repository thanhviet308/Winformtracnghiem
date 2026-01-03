using ExcelDataReader;
using OfficeOpenXml;
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
using PhanMemThiTracNghiem.DAL.Model;
using PhanMemThiTracNghiem.DAL;
using System.Collections.ObjectModel;
using PhanMemThiTracNghiem.BAL;

namespace PhanMemThiTracNghiem.UI.Admin.DanhSachGiangVien
{
    public partial class NhapExcelGiangVien : Form
    {
        DuLieuDAL duLieuDAL = new DuLieuDAL();
        List<NGUOIDUNG> listGV = new List<NGUOIDUNG>();
        frmAdmin frmAdmin = new frmAdmin();
        private readonly GiangVienBAL giangVienBAL;
        private readonly NguoiDungBAL nguoiDungBAL;
        public NhapExcelGiangVien(frmAdmin _frmAdmin)
        {
            InitializeComponent();
            giangVienBAL = new GiangVienBAL();
            nguoiDungBAL = new NguoiDungBAL();
            frmAdmin = _frmAdmin;
        }

        DataTableCollection tableCollection;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook| *.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = openFileDialog.FileName;
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
            if (tableCollection == null || cboSheet.SelectedItem == null) return;
            
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            
            if (dt != null)
            {
                listGV.Clear(); // Clear danh sách cũ trước khi thêm mới
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NGUOIDUNG giangvien = new NGUOIDUNG();
                    giangvien.EMAIL = dt.Rows[i]["EMAIL"]?.ToString() ?? "";
                    giangvien.HOTEN = dt.Rows[i]["TENGV"]?.ToString() ?? "";
                    giangvien.MATKHAU = PhanMemThiTracNghiem.BAL.PasswordHelper.HashPassword(dt.Rows[i]["MATKHAU"]?.ToString() ?? "123456");
                    giangvien.MAROLE = 2; // Role GiangVien
                    listGV.Add(giangvien);
                }
            }
            // Chỉ hiển thị các cột cần thiết
            var displayList = listGV.Select(x => new { Email = x.EMAIL, HoTen = x.HOTEN }).ToList();
            dgvThemExcelSinhVien.DataSource = null;
            dgvThemExcelSinhVien.DataSource = displayList;
        }

        private void btnLuuDL_Click(object sender, EventArgs e)
        {
            if (tableCollection == null || cboSheet.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn file Excel và sheet trước!");
                return;
            }
            
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            List<NGUOIDUNG> list = new List<NGUOIDUNG>();   
         
            try
            {
               
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        NGUOIDUNG giangvien = new NGUOIDUNG()
                        {
                            EMAIL = dt.Rows[i]["EMAIL"].ToString(),
                            HOTEN = dt.Rows[i]["TENGV"].ToString(),
                            MATKHAU = PhanMemThiTracNghiem.BAL.PasswordHelper.HashPassword(dt.Rows[i]["MATKHAU"].ToString()),
                            MAROLE = 2 // Role GiangVien
                        };
                        list.Add(giangvien);
                    }
                    foreach (var giangvien in list)
                    {
                        nguoiDungBAL.Add(giangvien);
                    frmAdmin.frmAdmin_Load(sender, e);
                    }
                MessageBox.Show("Lưu thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTaiFileMau_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                saveFileDialog.FileName = "MauNhapGiangVien.xlsx";
                saveFileDialog.Title = "Lưu file mẫu";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("DanhSachGiangVien");
                            
                            // Header
                            worksheet.Cells[1, 1].Value = "EMAIL";
                            worksheet.Cells[1, 2].Value = "TENGV";
                            worksheet.Cells[1, 3].Value = "MATKHAU";
                            
                            // Style header
                            using (var range = worksheet.Cells[1, 1, 1, 3])
                            {
                                range.Style.Font.Bold = true;
                                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                            }
                            
                            // Dữ liệu mẫu
                            worksheet.Cells[2, 1].Value = "giangvien1@gmail.com";
                            worksheet.Cells[2, 2].Value = "Nguyễn Văn Giảng";
                            worksheet.Cells[2, 3].Value = "123456";
                            
                            worksheet.Cells[3, 1].Value = "giangvien2@gmail.com";
                            worksheet.Cells[3, 2].Value = "Trần Thị Viên";
                            worksheet.Cells[3, 3].Value = "123456";
                            
                            // Auto fit columns
                            worksheet.Cells.AutoFitColumns();
                            
                            // Save file
                            FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                            package.SaveAs(fileInfo);
                            
                            MessageBox.Show("Đã tải file mẫu thành công!\n\nHướng dẫn:\n- EMAIL: Email đăng nhập\n- TENGV: Họ và tên giảng viên\n- MATKHAU: Mật khẩu đăng nhập", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }
    }
}
