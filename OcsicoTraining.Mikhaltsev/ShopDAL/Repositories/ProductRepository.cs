using EntityModels;
using ShopDAL.Context;
using ShopDAL.Repositories.Contracts;

namespace ShopDAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
