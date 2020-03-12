using System.Threading.Tasks;
using AutoMapper;
using ContractsDAL.Context;
using ContractsDAL.Repositories;
using EntityModels;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace ShopBLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IDataContext dataContext;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository orderRepository,
            IDataContext dataContext,
            IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<OrderViewModel> CreateAsync(OrderViewModel model)
        {
            var order = mapper.Map<OrderViewModel, Order>(model);

            await orderRepository.AddAsync(order);
            await dataContext.SaveChangesAsync();

            return model;
        }
    }
}
