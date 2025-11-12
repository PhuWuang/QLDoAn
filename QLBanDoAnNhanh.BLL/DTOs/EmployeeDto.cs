namespace QLBanDoAnNhanh.BLL.DTOs
{
    public class EmployeeDto
    {
        public int IdEmployee { get; set; }
        public string NameEmployee { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; } // tiện cho UI
        public bool IsActive { get; set; }
    }
}
