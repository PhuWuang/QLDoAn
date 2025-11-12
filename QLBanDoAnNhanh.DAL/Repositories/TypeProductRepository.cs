using System.Linq;

namespace QLBanDoAnNhanh.DAL.Repositories
{
    public class TypeProductRepository
    {
        private readonly PosFastFoodsDataContext _db;
        public TypeProductRepository(PosFastFoodsDataContext db) => _db = db;

        public IQueryable<TypeProduct> GetAllActiveOrdered() =>
            _db.TypeProducts.Where(t => t.IsActive).OrderBy(t => t.DisplayOrder);

        public TypeProduct GetById(int id) =>
            _db.TypeProducts.SingleOrDefault(t => t.IdTypeProduct == id);

        public void Insert(TypeProduct t) => _db.TypeProducts.InsertOnSubmit(t);

        public void Update(TypeProduct tExist, TypeProduct tNew)
        {
            tExist.NameType = tNew.NameType;
            tExist.DisplayOrder = tNew.DisplayOrder;
            tExist.IsActive = tNew.IsActive;
        }

        /// <summary>Xóa mềm danh mục (ẩn), không xóa cứng để tránh orphan product.</summary>
        public void SoftDelete(int id)
        {
            var t = _db.TypeProducts.SingleOrDefault(x => x.IdTypeProduct == id);
            if (t != null) t.IsActive = false;
        }
    }
}
