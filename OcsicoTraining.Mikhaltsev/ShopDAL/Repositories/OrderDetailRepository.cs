using ContractsDAL.Context;
using ContractsDAL.Repositories;
using EntityModels;

namespace ShopDAL.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
