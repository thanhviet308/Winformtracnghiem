using System;
using System.Security.Cryptography;
using System.Text;

namespace PhanMemThiTracNghiem.BAL
{
    /// <summary>
    /// Helper class để mã hóa mật khẩu sử dụng SHA256
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// Mã hóa mật khẩu sử dụng SHA256
        /// </summary>
        /// <param name="password">Mật khẩu gốc</param>
        /// <returns>Mật khẩu đã được mã hóa dạng hex string</returns>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Kiểm tra mật khẩu có khớp với hash đã lưu không
        /// </summary>
        /// <param name="password">Mật khẩu người dùng nhập</param>
        /// <param name="hashedPassword">Mật khẩu đã hash trong database</param>
        /// <returns>True nếu khớp, False nếu không khớp</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
                return false;

            string hashOfInput = HashPassword(password);
            return string.Equals(hashOfInput, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
