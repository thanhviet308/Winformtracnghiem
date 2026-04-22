using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Forms;
using ExcelDataReader;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    public partial class frmImportCauHoi : Form
    {
        private readonly MonHocService _monHocService;
        private readonly AppDbContext _context;
        private NguoiDung _nguoiDung;
        private string _filePath;
        private DataTableCollection _tableCollection;
        private List<CauHoiImportDTO> _previewData;
        private readonly ToolTip _chuongToolTip = new ToolTip();

        // Constructor mới - không cần file path
        public frmImportCauHoi(NguoiDung nguoiDung)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            _monHocService = new MonHocService();
            _context = new AppDbContext();
            _nguoiDung = nguoiDung;

            // Không cho gõ tự do chương (tránh tự tạo chương ngoài ý muốn)
            if (cboChuong != null)
                cboChuong.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadMonHoc();
            cboMonHoc.SelectedIndexChanged += (s, e) =>
            {
                LoadChuongByMonHoc();
                UpdateUI();
            };
            cboChuong.SelectedIndexChanged += (s, e) => UpdateChuongToolTip();
            LoadChuongByMonHoc();
            ApplyChuongComboUx();
            UpdateUI();
        }

        // Constructor cũ - tương thích ngược
        public frmImportCauHoi(NguoiDung nguoiDung, string filePath) : this(nguoiDung)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                _filePath = filePath;
                LoadExcelFile();
                UpdateUI();
            }
        }

        private void LoadMonHoc()
        {
            cboMonHoc.Items.Clear();

            // Bắt buộc chọn môn rõ ràng, không auto chọn môn đầu tiên
            cboMonHoc.Items.Add("-- Chọn môn học --");
            var monHocs = _monHocService.GetThongTinMonThi();
            foreach (var mh in monHocs)
            {
                cboMonHoc.Items.Add(mh);
            }
            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "Id";

            cboMonHoc.SelectedIndex = 0;
        }

        private void LoadChuongByMonHoc()
        {
            if (cboChuong == null) return;
            cboChuong.Items.Clear();

            cboChuong.Items.Add("-- Chọn chương --");
            if (cboMonHoc == null || cboMonHoc.SelectedIndex <= 0 || cboMonHoc.SelectedItem is not MonHoc monHoc)
            {
                cboChuong.DisplayMember = "TenChuong";
                cboChuong.ValueMember = "Id";
                cboChuong.SelectedIndex = 0;
                return;
            }

            var chuongs = _context.ChuongMonHoc
                .Where(c => c.MaMon == monHoc.Id)
                .OrderBy(c => c.Id)
                .ToList();

            foreach (var c in chuongs)
            {
                cboChuong.Items.Add(c);
            }

            cboChuong.DisplayMember = "TenChuong";
            cboChuong.ValueMember = "Id";

            // Mặc định vẫn bắt buộc người dùng chọn chương rõ ràng
            cboChuong.SelectedIndex = 0;

            ApplyChuongComboUx();
        }

        private void ApplyChuongComboUx()
        {
            if (cboChuong == null) return;

            AutoSizeComboDropDownWidth(
                cboChuong,
                item => item is ChuongMonHoc c ? c.TenChuong : item?.ToString() ?? string.Empty,
                maxWidth: 800
            );

            UpdateChuongToolTip();
        }

        private void UpdateChuongToolTip()
        {
            if (cboChuong == null) return;
            _chuongToolTip.SetToolTip(cboChuong, cboChuong.Text);
        }

        private static void AutoSizeComboDropDownWidth(ComboBox combo, Func<object, string> getItemText, int maxWidth)
        {
            if (combo == null) return;

            var current = combo.DropDownWidth;
            var widest = current;

            foreach (var raw in combo.Items)
            {
                var text = getItemText?.Invoke(raw) ?? raw?.ToString() ?? string.Empty;
                var w = TextRenderer.MeasureText(text, combo.Font).Width;
                if (w > widest) widest = w;
            }

            widest += SystemInformation.VerticalScrollBarWidth + 30;
            if (widest < current) widest = current;
            if (widest > maxWidth) widest = maxWidth;

            combo.DropDownWidth = widest;
        }

        private void UpdateUI()
        {
            bool hasFile = !string.IsNullOrEmpty(_filePath);
            panelGuide.Visible = !hasFile;
            panelConfig.Visible = hasFile;
            panelPreview.Visible = hasFile;

            bool hasPreview = _previewData != null && _previewData.Count > 0;
            bool hasMonHocSelected = cboMonHoc != null && cboMonHoc.SelectedIndex > 0;
            btnImport.Enabled = hasFile && hasPreview && hasMonHocSelected;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls";
                openFileDialog.Title = "Chọn file Excel chứa câu hỏi";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _filePath = openFileDialog.FileName;
                    LoadExcelFile();
                    UpdateUI();
                }
            }
        }

        private void btnTaiFileMau_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                saveFileDialog.FileName = "MauImportCauHoi.xlsx";
                saveFileDialog.Title = "Lưu file mẫu import câu hỏi";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        using (var package = new ExcelPackage())
                        {
                            var ws = package.Workbook.Worksheets.Add("CauHoi");

                            // Header row
                            ws.Cells[1, 1].Value = "NDCAUHOI";
                            ws.Cells[1, 2].Value = "DAPAN1";
                            ws.Cells[1, 3].Value = "DAPAN2";
                            ws.Cells[1, 4].Value = "DAPAN3";
                            ws.Cells[1, 5].Value = "DAPAN4";
                            ws.Cells[1, 6].Value = "DAPANDUNG";
                            ws.Cells[1, 7].Value = "CHUONG";

                            // Style header
                            using (var headerRange = ws.Cells[1, 1, 1, 7])
                            {
                                headerRange.Style.Font.Bold = true;
                                headerRange.Style.Font.Size = 12;
                                headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(94, 148, 255));
                                headerRange.Style.Font.Color.SetColor(System.Drawing.Color.White);
                                headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            }

                            // Sample data
                            ws.Cells[2, 1].Value = "Thủ đô của Việt Nam là gì?";
                            ws.Cells[2, 2].Value = "Hà Nội";
                            ws.Cells[2, 3].Value = "TP. Hồ Chí Minh";
                            ws.Cells[2, 4].Value = "Đà Nẵng";
                            ws.Cells[2, 5].Value = "Huế";
                            ws.Cells[2, 6].Value = "A";
                            ws.Cells[2, 7].Value = "Chương 1";

                            ws.Cells[3, 1].Value = "1 + 1 = ?";
                            ws.Cells[3, 2].Value = "1";
                            ws.Cells[3, 3].Value = "2";
                            ws.Cells[3, 4].Value = "3";
                            ws.Cells[3, 5].Value = "4";
                            ws.Cells[3, 6].Value = "B";
                            ws.Cells[3, 7].Value = "Chương 1";

                            ws.Cells[4, 1].Value = "Ngôn ngữ lập trình nào được dùng cho .NET?";
                            ws.Cells[4, 2].Value = "Java";
                            ws.Cells[4, 3].Value = "Python";
                            ws.Cells[4, 4].Value = "C#";
                            ws.Cells[4, 5].Value = "JavaScript";
                            ws.Cells[4, 6].Value = "C";
                            ws.Cells[4, 7].Value = "Chương 2";

                            // Instruction sheet
                            var wsGuide = package.Workbook.Worksheets.Add("HuongDan");
                            wsGuide.Cells[1, 1].Value = "HƯỚNG DẪN IMPORT CÂU HỎI";
                            wsGuide.Cells[1, 1].Style.Font.Bold = true;
                            wsGuide.Cells[1, 1].Style.Font.Size = 16;

                            wsGuide.Cells[3, 1].Value = "Cột";
                            wsGuide.Cells[3, 2].Value = "Mô tả";
                            wsGuide.Cells[3, 3].Value = "Bắt buộc";
                            using (var hr = wsGuide.Cells[3, 1, 3, 3])
                            {
                                hr.Style.Font.Bold = true;
                                hr.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                hr.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(94, 148, 255));
                                hr.Style.Font.Color.SetColor(System.Drawing.Color.White);
                            }

                            wsGuide.Cells[4, 1].Value = "NDCAUHOI";
                            wsGuide.Cells[4, 2].Value = "Nội dung câu hỏi";
                            wsGuide.Cells[4, 3].Value = "Có";
                            wsGuide.Cells[5, 1].Value = "DAPAN1";
                            wsGuide.Cells[5, 2].Value = "Đáp án A";
                            wsGuide.Cells[5, 3].Value = "Có";
                            wsGuide.Cells[6, 1].Value = "DAPAN2";
                            wsGuide.Cells[6, 2].Value = "Đáp án B";
                            wsGuide.Cells[6, 3].Value = "Có";
                            wsGuide.Cells[7, 1].Value = "DAPAN3";
                            wsGuide.Cells[7, 2].Value = "Đáp án C";
                            wsGuide.Cells[7, 3].Value = "Có";
                            wsGuide.Cells[8, 1].Value = "DAPAN4";
                            wsGuide.Cells[8, 2].Value = "Đáp án D";
                            wsGuide.Cells[8, 3].Value = "Có";
                            wsGuide.Cells[9, 1].Value = "DAPANDUNG";
                            wsGuide.Cells[9, 2].Value = "Đáp án đúng (A, B, C hoặc D)";
                            wsGuide.Cells[9, 3].Value = "Có";

                            wsGuide.Cells[10, 1].Value = "CHUONG";
                            wsGuide.Cells[10, 2].Value = "Tên chương (phải tồn tại trong hệ thống). Nếu để trống, hãy chọn Chương ở màn Import.";
                            wsGuide.Cells[10, 3].Value = "Không";

                            wsGuide.Cells[12, 1].Value = "LƯU Ý:";
                            wsGuide.Cells[12, 1].Style.Font.Bold = true;
                            wsGuide.Cells[12, 1].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                            wsGuide.Cells[13, 1].Value = "1. Dữ liệu bắt đầu từ dòng 2 (dòng 1 là tiêu đề).";
                            wsGuide.Cells[14, 1].Value = "2. Cột DAPANDUNG nhập A, B, C hoặc D (viết hoa).";
                            wsGuide.Cells[15, 1].Value = "3. Cột CHUONG nếu nhập thì phải khớp chương đã có trong hệ thống (đúng môn).";
                            wsGuide.Cells[16, 1].Value = "4. Nếu CHUONG để trống, hãy chọn Chương ở màn Import để áp dụng cho các dòng trống.";
                            wsGuide.Cells[17, 1].Value = "5. Không được để trống nội dung câu hỏi.";
                            wsGuide.Cells[18, 1].Value = "6. Mỗi câu hỏi phải có ít nhất 2 đáp án.";
                            wsGuide.Cells[19, 1].Value = "7. Nhập dữ liệu vào sheet \"CauHoi\".";

                            ws.Cells.AutoFitColumns();
                            wsGuide.Cells.AutoFitColumns();
                            wsGuide.Column(2).Width = 35;

                            package.SaveAs(new FileInfo(saveFileDialog.FileName));
                        }

                        var result = MessageBox.Show(
                            "Đã tạo file mẫu thành công!\nBạn có muốn mở file không?",
                            "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveFileDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tạo file mẫu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadExcelFile()
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var stream = File.Open(_filePath, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });
                        _tableCollection = result.Tables;

                        cboSheet.Items.Clear();
                        foreach (DataTable table in _tableCollection)
                        {
                            cboSheet.Items.Add(table.TableName);
                        }

                        if (cboSheet.Items.Count > 0)
                            cboSheet.SelectedIndex = 0;
                    }
                }

                lblFilePath.Text = "📄 " + Path.GetFileName(_filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPreviewData();
        }

        private void LoadPreviewData()
        {
            if (_tableCollection == null || cboSheet.SelectedItem == null) return;

            try
            {
                DataTable dt = _tableCollection[cboSheet.SelectedItem.ToString()];
                _previewData = new List<CauHoiImportDTO>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var row = dt.Rows[i];
                    var cauHoi = new CauHoiImportDTO
                    {
                        STT = i + 1,
                        NoiDung = GetValue(row, "NDCAUHOI") ?? GetValue(row, "NoiDung") ?? GetValue(row, "CauHoi") ?? "",
                        DapAn1 = GetValue(row, "DAPAN1") ?? GetValue(row, "DapAnA") ?? "",
                        DapAn2 = GetValue(row, "DAPAN2") ?? GetValue(row, "DapAnB") ?? "",
                        DapAn3 = GetValue(row, "DAPAN3") ?? GetValue(row, "DapAnC") ?? "",
                        DapAn4 = GetValue(row, "DAPAN4") ?? GetValue(row, "DapAnD") ?? "",
                        DapAnDung = GetValue(row, "DAPANDUNG") ?? GetValue(row, "DapAnDung") ?? "",
                        Chuong = GetValue(row, "CHUONG") ?? GetValue(row, "Chuong") ?? GetValue(row, "TenChuong") ?? ""
                    };

                    if (!string.IsNullOrWhiteSpace(cauHoi.NoiDung))
                    {
                        _previewData.Add(cauHoi);
                    }
                }

                dgvPreview.Rows.Clear();
                foreach (var item in _previewData)
                {
                    int index = dgvPreview.Rows.Add();
                    dgvPreview.Rows[index].Cells["colSTT"].Value = item.STT;
                    dgvPreview.Rows[index].Cells["colNoiDung"].Value = item.NoiDung.Length > 50
                        ? item.NoiDung.Substring(0, 50) + "..."
                        : item.NoiDung;
                    dgvPreview.Rows[index].Cells["colDapAn1"].Value = item.DapAn1;
                    dgvPreview.Rows[index].Cells["colDapAn2"].Value = item.DapAn2;
                    dgvPreview.Rows[index].Cells["colDapAn3"].Value = item.DapAn3;
                    dgvPreview.Rows[index].Cells["colDapAn4"].Value = item.DapAn4;
                    dgvPreview.Rows[index].Cells["colDapAnDung"].Value = item.DapAnDung;
                }

                lblTongSo.Text = $"✅ Tổng số: {_previewData.Count} câu hỏi hợp lệ";
                btnImport.Enabled = _previewData.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetValue(DataRow row, string columnName)
        {
            if (row.Table.Columns.Contains(columnName))
            {
                return row[columnName]?.ToString();
            }
            return null;
        }

        private static string NormalizeQuestionText(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            // Normalize: trim + collapse whitespace + lowercase (invariant)
            var trimmed = input.Trim();
            var parts = trimmed
                .Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", parts).ToLowerInvariant();
        }

        private static string BuildQuestionKey(long maMon, long maChuong, string noiDung)
        {
            return $"{maMon}|{maChuong}|{NormalizeQuestionText(noiDung)}";
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (cboMonHoc == null || cboMonHoc.SelectedIndex <= 0 || cboMonHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn môn học trước khi import!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_previewData == null || _previewData.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để import!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var monHoc = (MonHoc)cboMonHoc.SelectedItem;

                // Siết nghiệp vụ: môn phải có ít nhất 1 chương trước khi import
                bool hasAnyChuong = _context.ChuongMonHoc.Any(c => c.MaMon == monHoc.Id);
                if (!hasAnyChuong)
                {
                    MessageBox.Show("Môn học này chưa có chương.\nVui lòng tạo chương trước khi import câu hỏi!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Nếu dòng nào không có CHUONG thì bắt buộc phải chọn chương trên form
                bool anyRowMissingChuong = _previewData.Any(p => string.IsNullOrWhiteSpace(p.Chuong));
                var defaultChuong = (cboChuong != null && cboChuong.SelectedIndex > 0) ? cboChuong.SelectedItem as ChuongMonHoc : null;
                if (anyRowMissingChuong && defaultChuong == null)
                {
                    MessageBox.Show("File Excel có dòng thiếu CHUONG.\nVui lòng chọn 'Chương' trên màn hình để áp dụng cho các dòng thiếu CHUONG.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int successCount = 0;
                int failCount = 0;
                int duplicateCount = 0;

                // Cache chương theo tên (không tự tạo chương mới)
                var chuongCache = new Dictionary<string, long?>(StringComparer.OrdinalIgnoreCase);
                long? ResolveExistingChuongId(string tenChuongInput)
                {
                    var tenChuong = (tenChuongInput ?? string.Empty).Trim();
                    if (string.IsNullOrWhiteSpace(tenChuong)) return null;
                    if (tenChuong.Length > 150) tenChuong = tenChuong.Substring(0, 150);

                    if (chuongCache.TryGetValue(tenChuong, out var cachedId)) return cachedId;

                    var keyLower = tenChuong.ToLower();
                    var existing = _context.ChuongMonHoc
                        .FirstOrDefault(c => c.MaMon == monHoc.Id && c.TenChuong.ToLower() == keyLower);

                    var id = existing?.Id;
                    chuongCache[tenChuong] = id;
                    return id;
                }

                // Preload key câu hỏi đã có trong DB cho môn này (TrangThai=true)
                // Key = (MaMon|MaChuong|NoiDungNormalized)
                var existingKeys = new HashSet<string>();
                var existingRows = _context.CauHoiThi
                    .Where(c => c.TrangThai && c.MaMon == monHoc.Id && c.MaChuong != null)
                    .Select(c => new { c.MaMon, c.MaChuong, c.NoiDung })
                    .ToList();

                foreach (var r in existingRows)
                {
                    if (r.MaMon == null || r.MaChuong == null) continue;
                    existingKeys.Add(BuildQuestionKey(r.MaMon.Value, r.MaChuong.Value, r.NoiDung));
                }

                // Duplicates ngay trong chính file import (hoặc trong batch hiện tại)
                var batchKeys = new HashSet<string>();

                progressBar.Maximum = _previewData.Count;
                progressBar.Value = 0;

                foreach (var item in _previewData)
                {
                    try
                    {
                        long? maChuong = null;
                        if (!string.IsNullOrWhiteSpace(item.Chuong))
                        {
                            maChuong = ResolveExistingChuongId(item.Chuong);
                            if (maChuong == null)
                            {
                                // Chương không tồn tại → đánh fail dòng này
                                failCount++;
                                progressBar.Value++;
                                Application.DoEvents();
                                continue;
                            }
                        }
                        else
                        {
                            maChuong = defaultChuong?.Id;
                            if (maChuong == null)
                            {
                                failCount++;
                                progressBar.Value++;
                                Application.DoEvents();
                                continue;
                            }
                        }

                        // Check trùng: theo môn + chương + nội dung
                        var key = BuildQuestionKey(monHoc.Id, maChuong.Value, item.NoiDung);
                        if (batchKeys.Contains(key) || existingKeys.Contains(key))
                        {
                            duplicateCount++;
                            progressBar.Value++;
                            Application.DoEvents();
                            continue;
                        }

                        batchKeys.Add(key);

                        var cauHoi = new CauHoiThi
                        {
                            NoiDung = item.NoiDung,
                            MaMon = monHoc.Id,
                            MaChuong = maChuong,
                            NguoiTao = _nguoiDung.Id,
                            NgayTao = DateTime.Now,
                            TrangThai = true
                        };

                        _context.CauHoiThi.Add(cauHoi);
                        _context.SaveChanges();

                        var luaChons = new List<LuaChonTracNghiem>();
                        int thuTu = 1;

                        if (!string.IsNullOrWhiteSpace(item.DapAn1))
                        {
                            luaChons.Add(new LuaChonTracNghiem
                            {
                                MaCauHoi = cauHoi.Id,
                                NoiDung = item.DapAn1,
                                ThuTu = thuTu++,
                                LaDapAnDung = item.DapAnDung.Trim().Equals(item.DapAn1.Trim(), StringComparison.OrdinalIgnoreCase)
                                    || item.DapAnDung.Trim().ToUpper() == "A"
                            });
                        }

                        if (!string.IsNullOrWhiteSpace(item.DapAn2))
                        {
                            luaChons.Add(new LuaChonTracNghiem
                            {
                                MaCauHoi = cauHoi.Id,
                                NoiDung = item.DapAn2,
                                ThuTu = thuTu++,
                                LaDapAnDung = item.DapAnDung.Trim().Equals(item.DapAn2.Trim(), StringComparison.OrdinalIgnoreCase)
                                    || item.DapAnDung.Trim().ToUpper() == "B"
                            });
                        }

                        if (!string.IsNullOrWhiteSpace(item.DapAn3))
                        {
                            luaChons.Add(new LuaChonTracNghiem
                            {
                                MaCauHoi = cauHoi.Id,
                                NoiDung = item.DapAn3,
                                ThuTu = thuTu++,
                                LaDapAnDung = item.DapAnDung.Trim().Equals(item.DapAn3.Trim(), StringComparison.OrdinalIgnoreCase)
                                    || item.DapAnDung.Trim().ToUpper() == "C"
                            });
                        }

                        if (!string.IsNullOrWhiteSpace(item.DapAn4))
                        {
                            luaChons.Add(new LuaChonTracNghiem
                            {
                                MaCauHoi = cauHoi.Id,
                                NoiDung = item.DapAn4,
                                ThuTu = thuTu++,
                                LaDapAnDung = item.DapAnDung.Trim().Equals(item.DapAn4.Trim(), StringComparison.OrdinalIgnoreCase)
                                    || item.DapAnDung.Trim().ToUpper() == "D"
                            });
                        }

                        _context.LuaChonTracNghiem.AddRange(luaChons);
                        _context.SaveChanges();

                        // Add vào existingKeys để các dòng sau (trong batch) không bị import trùng lại
                        existingKeys.Add(key);

                        successCount++;
                    }
                    catch
                    {
                        failCount++;
                    }

                    progressBar.Value++;
                    Application.DoEvents();
                }

                MessageBox.Show($"Import hoàn tất!\n✅ Thành công: {successCount}\n⚠️ Trùng (bỏ qua): {duplicateCount}\n❌ Thất bại: {failCount}",
                    "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (successCount > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnChonFileLai_Click(object sender, EventArgs e)
        {
            btnChonFile_Click(sender, e);
        }
    }

    public class CauHoiImportDTO
    {
        public int STT { get; set; }
        public string NoiDung { get; set; }
        public string DapAn1 { get; set; }
        public string DapAn2 { get; set; }
        public string DapAn3 { get; set; }
        public string DapAn4 { get; set; }
        public string DapAnDung { get; set; }
        public string Chuong { get; set; }
    }
}
