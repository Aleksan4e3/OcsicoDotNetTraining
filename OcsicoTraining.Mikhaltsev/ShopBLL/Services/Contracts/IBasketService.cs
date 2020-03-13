using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace ShopBLL.Services.Contracts
{
    public interface IBasketService
    {
        Task<List<OrderDetailViewModel>> GetOrdersAsync();
        void AddOrder(OrderDetailViewModel order);
        void RewriteOrders(List<OrderDetailViewModel> orders);
        void DeleteOrder(Guid id, int weight);
        void DeleteOrders();
    }
}
