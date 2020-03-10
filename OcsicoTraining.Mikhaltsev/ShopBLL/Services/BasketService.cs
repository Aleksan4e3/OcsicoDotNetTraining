using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContractsDAL.Repositories;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace ShopBLL.Services
{
    public class BasketService : IBasketService
    {
        private readonly IContextService contextService;
        private readonly IOrderDetailService orderDetailService;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public BasketService(IContextService contextService,
            IOrderDetailService orderDetailService,
            IProductRepository productRepository,
            IMapper mapper)
        {
            this.contextService = contextService;
            this.orderDetailService = orderDetailService;
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<List<OrderDetailViewModel>> GetOrdersAsync()
        {
            var orders = contextService.GetOrders();

            // business logic
            foreach (var order in orders)
            {
                var product = await productRepository.GetAsync(order.ProductId);

                if (product != null)
                {
                    order.Product = mapper.Map<ProductViewModel>(product);
                    orderDetailService.CalculateTotal(order);
                }
            }

            return orders;
        }

        public void AddOrder(OrderDetailViewModel order)
        {
            var orders = contextService.GetOrders();

            // Business Logic
            orders.Add(order);

            contextService.PutOrders(orders);
        }
    }
}
