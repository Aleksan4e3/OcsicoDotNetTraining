using EntityModels;
using ShopDAL.Context;
using ShopDAL.Repositories.Contracts;

namespace ShopDAL.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
