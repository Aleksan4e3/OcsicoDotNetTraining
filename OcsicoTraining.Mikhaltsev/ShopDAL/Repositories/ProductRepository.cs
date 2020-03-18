using ContractsDAL.Context;
using ContractsDAL.Repositories;
using EntityModels;

namespace ShopDAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
