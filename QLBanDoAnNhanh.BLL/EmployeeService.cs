using QLBanDoAnNhanh.DAL; // Để sử dụng EmployeeDAL
using QLBanDoAnNhanh.Models; // Để sử dụng model Employee
using BCrypt.Net; // Thư viện mã hóa vừa cài

namespace QLBanDoAnNhanh.BLL
{
    public class EmployeeService
    {
        private EmployeeDAL _employeeDAL;

        public EmployeeService()
        {
            _employeeDAL = new EmployeeDAL();
        }

        // Hàm này sẽ trả về đối tượng Employee nếu đăng nhập thành công
        // và trả về null nếu thất bại.
        public Employee ValidateLogin(string email, string plainPassword)
        {
            // 1. Gọi xuống DAL để lấy thông tin user từ CSDL
            var user = _employeeDAL.GetByEmail(email);

            // 2. Nếu không tìm thấy user với email này, trả về null ngay lập tức
            if (user == null)
            {
                return null;
            }

            // 3. Nếu tìm thấy user, tiến hành xác thực mật khẩu
            //    BCrypt.Verify sẽ so sánh mật khẩu người dùng nhập (plainPassword)
            //    với mật khẩu đã được mã hóa trong CSDL (user.Password)
            if (BCrypt.Net.BCrypt.Verify(plainPassword, user.Password))
            {
                // Nếu mật khẩu khớp, trả về toàn bộ thông tin của user
                return user;
            }

            // 4. Nếu mật khẩu không khớp, trả về null
            return null;
        }

        // Hàm này dùng để tạo mật khẩu mã hóa cho user mới
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        // HÀM MỚI: Xử lý nghiệp vụ đổi mật khẩu
        public bool ChangePassword(int employeeId, string oldPassword, string newPassword)
        {
            // 1. Lấy thông tin nhân viên hiện tại từ DAL
            var employee = _employeeDAL.GetById(employeeId);
            if (employee == null)
            {
                return false; // Không tìm thấy nhân viên
            }

            // 2. Dùng BCrypt.Verify để xác thực mật khẩu cũ
            // Đây là cách so sánh chính xác giữa văn bản thường và chuỗi đã mã hóa
            if (!BCrypt.Net.BCrypt.Verify(oldPassword, employee.Password))
            {
                return false; // Mật khẩu cũ không đúng
            }

            // 3. Nếu mật khẩu cũ đúng, mã hóa mật khẩu mới
            string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

            // 4. Cập nhật mật khẩu đã mã hóa mới cho nhân viên
            employee.Password = newHashedPassword;

            // 5. Gọi xuống DAL để lưu thay đổi
            return _employeeDAL.UpdateEmployee(employee);
        }
        // HÀM MỚI BỔ SUNG: Lấy thông tin nhân viên theo ID thông qua DAL
        public Employee GetEmployeeById(int employeeId)
        {
            return _employeeDAL.GetById(employeeId);
        }
    }
}