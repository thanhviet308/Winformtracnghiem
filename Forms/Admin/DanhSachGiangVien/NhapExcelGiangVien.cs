using PhanMemThiTracNghiem.Data;
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
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Repositories;
using System.Collections.ObjectModel;
using PhanMemThiTracNghiem.Services;

namespace PhanMemThiTracNghiem.Forms.Admin.DanhSachGiangVien
{
    public partial class NhapExcelGiangVien : Form
    {
        AppDbContext AppDbContext = new AppDbContext();
        List<NGUOIDUNG> listGV = new List<NGUOIDUNG>();
        frmAdmin frmAdmin = new frmAdmin();
        private readonly GiangVienService GiangVienService;
        private readonly NguoiDungService NguoiDungService;
        public NhapExcelGiangVien(frmAdmin _frmAdmin)
        {
            InitializeComponent();
            GiangVienService = new GiangVienService();
            NguoiDungService = new NguoiDungService();
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
                listGV.Clear(); // Clear danh sách cu tru?c khi thêm m?i
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NGUOIDUNG giangvien = new NGUOIDUNG();
                    giangvien.EMAIL = dt.Rows[i]["EMAIL"]?.ToString() ?? "";
                    giangvien.HOTEN = dt.Rows[i]["TENGV"]?.ToString() ?? "";
                    giangvien.MATKHAU = PhanMemThiTracNghiem.Helpers.PasswordHelper.HashPassword(dt.Rows[i]["MATKHAU"]?.ToString() ?? "123456");
                    giangvien.MAROLE = 2; // Role GiangVien
                    listGV.Add(giangvien);
                }
            }
            // Ch? hi?n th? các c?t c?n thi?t
            var displayList = listGV.Select(x => new { Email = x.EMAIL, HoTen = x.HOTEN }).ToList();
            dgvThemExcelSinhVien.DataSource = null;
            dgvThemExcelSinhVien.DataSource = displayList;
        }

        private void btnLuuDL_Click(object sender, EventArgs e)
        {
            if (tableCollection == null || cboSheet.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng ch?n file Excel và sheet tru?c!");
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
                            MATKHAU = PhanMemThiTracNghiem.Helpers.PasswordHelper.HashPassword(dt.Rows[i]["MATKHAU"].ToString()),
                            MAROLE = 2 // Role GiangVien
                        };
                        list.Add(giangvien);
                    }
                    foreach (var giangvien in list)
                    {
                        NguoiDungService.Add(giangvien);
                    frmAdmin.frmAdmin_Load(sender, e);
                    }
                MessageBox.Show("Luu thành công");
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
                saveFileDialog.Title = "Luu file m?u";

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
                            
                            // D? li?u m?u
                            worksheet.Cells[2, 1].Value = "giangvien1@gmail.com";
                            worksheet.Cells[2, 2].Value = "Nguy?n Van Gi?ng";
                            worksheet.Cells[2, 3].Value = "123456";
                            
                            worksheet.Cells[3, 1].Value = "giangvien2@gmail.com";
                            worksheet.Cells[3, 2].Value = "Tr?n Th? Viên";
                            worksheet.Cells[3, 3].Value = "123456";
                            
                            // Auto fit columns
                            worksheet.Cells.AutoFitColumns();
                            
                            // Save file
                            FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                            package.SaveAs(fileInfo);
                            
                            MessageBox.Show("Ðã t?i file m?u thành công!\n\nHu?ng d?n:\n- EMAIL: Email dang nh?p\n- TENGV: H? và tên gi?ng viên\n- MATKHAU: M?t kh?u dang nh?p", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("L?i: " + ex.Message);
                    }
                }
            }
        }
    }
}
