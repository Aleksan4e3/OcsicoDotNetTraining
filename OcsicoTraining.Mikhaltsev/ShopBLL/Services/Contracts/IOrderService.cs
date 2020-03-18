using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace ShopBLL.Services.Contracts
{
    public interface IOrderService
    {
        Task<OrderViewModel> CreateAsync(OrderViewModel model);
        Task<List<OrderViewModel>> GetAsync();
        Task<List<OrderViewModel>> GetAsync(Guid userId);
        Task<OrderViewModel> EditAsync(Guid id);
    }
}
