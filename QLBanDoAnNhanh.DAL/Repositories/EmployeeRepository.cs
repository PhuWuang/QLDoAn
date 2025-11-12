using System.Linq;

namespace QLBanDoAnNhanh.DAL.Repositories
{
    public class EmployeeRepository
    {
        private readonly PosFastFoodsDataContext _db;
        public EmployeeRepository(PosFastFoodsDataContext db) => _db = db;

        public Employee GetByEmail(string email) =>
            _db.Employees.SingleOrDefault(e => e.Email == email && e.IsActive);

        public Employee GetById(int id) =>
            _db.Employees.SingleOrDefault(e => e.IdEmployee == id);

        public IQueryable<Employee> GetAllActive() =>
            _db.Employees.Where(e => e.IsActive);

        public void Insert(Employee e) => _db.Employees.InsertOnSubmit(e);
        // Update/ChangePassword sẽ thực hiện ở BLL với PBKDF2, repo chỉ lưu Hash/Salt đã tính sẵn.
    }
}
