using QLBanDoAnNhanh.Models;
using System.Linq;

namespace QLBanDoAnNhanh.DAL
{
    public class EmployeeDAL
    {
        // Khởi tạo đối tượng DbContext để làm việc với CSDL
        private PosFastFood _context;

        public EmployeeDAL()
        {
            _context = new PosFastFood();
        }

        // Hàm này chỉ có một nhiệm vụ: tìm kiếm Employee dựa trên email
        public Employee GetByEmail(string email)
        {
            // Sử dụng LINQ để truy vấn CSDL
            // FirstOrDefault sẽ trả về Employee đầu tiên tìm thấy, hoặc null nếu không có
            return _context.Employees.FirstOrDefault(e => e.Email == email);
        }
        // HÀM MỚI: Lấy thông tin nhân viên theo ID
        public Employee GetById(int employeeId)
        {
            return _context.Employees.Find(employeeId);
        }

        // HÀM MỚI: Cập nhật thông tin nhân viên
        public bool UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}