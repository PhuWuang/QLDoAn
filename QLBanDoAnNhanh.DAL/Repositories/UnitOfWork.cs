namespace QLBanDoAnNhanh.DAL.Repositories
{
    public class UnitOfWork : System.IDisposable
    {
        public PosFastFoodsDataContext Db { get; }
        public ProductRepository Products { get; }
        public OrderRepository Orders { get; }
        public TypeProductRepository Types { get; }
        public EmployeeRepository Employees { get; }

        public UnitOfWork(PosFastFoodsDataContext db)
        {
            Db = db;
            Products = new ProductRepository(db);
            Orders = new OrderRepository(db);
            Types = new TypeProductRepository(db);
            Employees = new EmployeeRepository(db);
        }

        public void Commit() => Db.SubmitChanges();
        public void Dispose() => Db.Dispose();
    }
}
