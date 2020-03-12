using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContractsDAL.Context;
using ContractsDAL.Repositories;
using EntityModels;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<OrderViewModel>> GetAsync()
        {
            var orders = await orderRepository.GetQuery().ToListAsync();

            return mapper.Map<List<OrderViewModel>>(orders);
        }

        public async Task<List<OrderViewModel>> GetAsync(Guid userId)
        {
            var orders = await orderRepository
                .GetQuery()
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return mapper.Map<List<OrderViewModel>>(orders);
        }
    }
}
