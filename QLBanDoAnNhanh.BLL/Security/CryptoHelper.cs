using System;
using System.Security.Cryptography;

namespace QLBanDoAnNhanh.BLL.Security
{
    // Lớp này xử lý mã hóa và xác thực mật khẩu bằng PBKDF2
    public static class CryptoHelper
    {
        // Cấu hình độ mạnh (càng cao càng an toàn nhưng càng chậm)
        private const int SaltSize = 16; // 128 bit
        private const int HashSize = 20; // 160 bit (SHA-1)
        private const int Iterations = 10000;

        // Tạo Hash từ mật khẩu (dùng khi Đăng ký hoặc Đổi mật khẩu)
        // Trả về chuỗi Base64 để lưu vào DB (NVARCHAR)
        public static (string hash, string salt) HashPassword(string password)
        {
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations))
            {
                byte[] hashBytes = pbkdf2.GetBytes(HashSize);
                return (Convert.ToBase64String(hashBytes), Convert.ToBase64String(saltBytes));
            }
        }

        // Xác thực mật khẩu (dùng khi Đăng nhập)
        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            try
            {
                byte[] saltBytes = Convert.FromBase64String(storedSalt);
                byte[] hashBytes = Convert.FromBase64String(storedHash);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations))
                {
                    byte[] testHash = pbkdf2.GetBytes(HashSize);

                    // So sánh 2 mảng byte một cách an toàn
                    uint diff = (uint)hashBytes.Length ^ (uint)testHash.Length;
                    for (int i = 0; i < hashBytes.Length && i < testHash.Length; i++)
                    {
                        diff |= (uint)(hashBytes[i] ^ testHash[i]);
                    }
                    return diff == 0;
                }
            }
            catch (Exception)
            {
                // Lỗi (ví dụ: salt/hash không đúng định dạng Base64) -> trả về false
                return false;
            }
        }
    }
}