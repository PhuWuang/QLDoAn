using System;
using System.Collections.Generic;
using System.Linq;
using QLBanDoAnNhanh.BLL.DTOs;
using QLBanDoAnNhanh.BLL.Mappers;
using QLBanDoAnNhanh.BLL.Security;
using QLBanDoAnNhanh.DAL;
using QLBanDoAnNhanh.DAL.Repositories;

namespace QLBanDoAnNhanh.BLL
{
    // Đổi namespace thành .Services nếu bạn muốn
    public class EmployeeService
    {
        // Kết quả trả về cho UI khi đăng nhập
        public class LoginResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public EmployeeDto Employee { get; set; }
        }

        // 1. Dùng cho frmLogin
        public LoginResult ValidateLogin(string email, string password)
        {
            using (var uow = new UnitOfWork(DataContextFactory.CreateWithIncludes()))
            {
                var empDal = uow.Employees.GetByEmail(email);

                if (empDal == null)
                {
                    return new LoginResult { Success = false, Message = "Email không tồn tại." };
                }

                // Lấy hash/salt từ DB (đã là NVARCHAR)
                string storedHash = empDal.PasswordHash;
                string storedSalt = empDal.PasswordSalt;

                if (CryptoHelper.VerifyPassword(password, storedHash, storedSalt))
                {
                    var empDto = empDal.ToDto();
                    return new LoginResult { Success = true, Employee = empDto };
                }
                else
                {
                    return new LoginResult { Success = false, Message = "Mật khẩu không chính xác." };
                }
            }
        }

        // 2. Dùng cho frmChangePass
        public string ChangePassword(int employeeId, string oldPassword, string newPassword)
        {
            using (var uow = new UnitOfWork(DataContextFactory.Create()))
            {
                var empDal = uow.Employees.GetById(employeeId);

                if (empDal == null) return "Không tìm thấy người dùng.";

                if (!CryptoHelper.VerifyPassword(oldPassword, empDal.PasswordHash, empDal.PasswordSalt))
                {
                    return "Mật khẩu cũ không đúng.";
                }

                (string hash, string salt) = CryptoHelper.HashPassword(newPassword);
                empDal.PasswordHash = hash;
                empDal.PasswordSalt = salt;

                uow.Commit();
                return "Đổi mật khẩu thành công.";
            }
        }

        // 3. Dùng cho frmItemDetail, frmMain
        public EmployeeDto GetEmployeeById(int id)
        {
            using (var uow = new UnitOfWork(DataContextFactory.CreateWithIncludes()))
            {
                return uow.Employees.GetById(id).ToDto();
            }
        }

        // 4. Dùng cho Form Quản lý Nhân viên (sau này)
        public List<EmployeeDto> GetAllActiveEmployees()
        {
            using (var uow = new UnitOfWork(DataContextFactory.CreateWithIncludes()))
            {
                return uow.Employees.GetAllActive()
                          .Select(emp => emp.ToDto())
                          .ToList();
            }
        }
        public string CreateEmployee(string name, string email, string password, int roleId, bool isActive)
        {
            using (var uow = new UnitOfWork(DataContextFactory.Create()))
            {
                // 1. Kiểm tra email trùng
                var existing = uow.Employees.GetByEmail(email);
                if (existing != null)
                {
                    return "Email đã tồn tại, vui lòng dùng email khác.";
                }

                // 2. Hash mật khẩu (tùy anh đang dùng class nào)
                var (hash, salt) = CryptoHelper.HashPassword(password);
                // ví dụ: trả về Hash + Salt, anh dùng đúng class hiện có trong BLL.Sercurity

                var emp = new Employee
                {
                    NameEmployee = name,
                    Email = email,
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    IdRole = roleId,
                    IsActive = isActive,
                    CreatedAt = DateTime.Now
                };

                uow.Employees.Insert(emp);
                uow.Commit();

                return "Tạo tài khoản nhân viên thành công.";
            }
        }
        public List<RoleDto> GetAllRoles()
        {
            using (var uow = new UnitOfWork(DataContextFactory.Create()))
            {
                return uow.Db.Roles
                             .OrderBy(r => r.IdRole)
                             .Select(r => new RoleDto
                             {
                                 IdRole = r.IdRole,
                                 NameRole = r.NameRole
                             })
                             .ToList();
            }
        }


    }
}