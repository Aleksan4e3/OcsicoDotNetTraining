using System.Threading.Tasks;
using AutoMapper;
using ContractsDAL.Context;
using ContractsDAL.Repositories;
using EntityModels;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace ShopBLL.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IDataContext dataContext;
        private readonly IMapper mapper;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository,
            IDataContext dataContext,
            IMapper mapper)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task AddAsync(OrderDetailViewModel model)
        {
            var orderDetail = mapper.Map<OrderDetail>(model);

            await orderDetailRepository.AddAsync(orderDetail);
            await dataContext.SaveChangesAsync();
        }
    }
}
