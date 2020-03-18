using System;
using System.Collections.Generic;
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
        private readonly ICalculateService calculateService;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public BasketService(IContextService contextService,
            ICalculateService calculateService,
            IProductRepository productRepository,
            IMapper mapper)
        {
            this.contextService = contextService;
            this.calculateService = calculateService;
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<List<OrderDetailViewModel>> GetOrdersAsync()
        {
            var orders = contextService.GetOrders();

            foreach (var order in orders)
            {
                var product = await productRepository.GetAsync(order.ProductId);

                if (product != null)
                {
                    order.Product = mapper.Map<ProductViewModel>(product);
                    calculateService.CalculateTotal(order);
                }
            }

            return orders;
        }

        public void AddOrder(OrderDetailViewModel order)
        {
            var orders = contextService.GetOrders();
            var sameOrder = orders.Find(x => x.ProductId == order.ProductId && x.Weight == order.Weight);

            if (sameOrder != null)
            {
                orders.Remove(sameOrder);
                order.Quantity += sameOrder.Quantity;
            }

            orders.Add(order);
            contextService.PutOrders(orders);
        }

        public void RewriteOrders(List<OrderDetailViewModel> orders) => contextService.PutOrders(orders);

        public void DeleteOrder(Guid id, int weight)
        {
            var orders = contextService.GetOrders();
            var order = orders.Find(x => x.ProductId == id && x.Weight == weight);

            if (order != null)
            {
                orders.Remove(order);
                contextService.PutOrders(orders);
            }
        }

        public void DeleteOrders() => contextService.PutOrders(new List<OrderDetailViewModel>());
    }
}
