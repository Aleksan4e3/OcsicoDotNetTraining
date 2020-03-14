using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContractsDAL.Context;
using ContractsDAL.Repositories;
using EntityModels;
using EntityModels.Enums;
using Microsoft.EntityFrameworkCore;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace ShopBLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICalculateService calculateService;
        private readonly IDataContext dataContext;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository orderRepository,
            ICalculateService calculateService,
            IDataContext dataContext,
            IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.calculateService = calculateService;
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

        public async Task<List<OrderViewModel>> GetAsync()
        {
            var orders = await orderRepository.GetQuery().ToListAsync();
            var orderModels = mapper.Map<List<OrderViewModel>>(orders);

            calculateService.CalculateTotal(orderModels);

            return orderModels;
        }

        public async Task<List<OrderViewModel>> GetAsync(Guid userId)
        {
            var orders = await orderRepository
                .GetQuery()
                .Where(x => x.UserId == userId)
                .ToListAsync();

            var orderModels = mapper.Map<List<OrderViewModel>>(orders);

            calculateService.CalculateTotal(orderModels);

            return orderModels;
        }

        public async Task EditAsync(Guid id)
        {
            var order = await orderRepository.GetAsync(id);

            ChangeStatus(order);
            orderRepository.Update(order);
            await dataContext.SaveChangesAsync();
        }

        private void ChangeStatus(Order order)
        {
            switch (order.Status)
            {
                case OrderStatus.Accepted:
                    order.Status = OrderStatus.Sent;
                    break;
                case OrderStatus.Sent:
                    order.Status = OrderStatus.Delivered;
                    break;
            }
        }
    }
}
