using ContractsDAL.Context;
using ContractsDAL.Repositories;
using EntityModels;

namespace ShopDAL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
