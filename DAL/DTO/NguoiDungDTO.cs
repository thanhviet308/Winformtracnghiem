namespace PhanMemThiTracNghiem.DAL.DTO
{
    /// <summary>
    /// DTO để hiển thị thông tin người dùng trên DataGridView
    /// </summary>
    public class NguoiDungDTO
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; }
    }
}
