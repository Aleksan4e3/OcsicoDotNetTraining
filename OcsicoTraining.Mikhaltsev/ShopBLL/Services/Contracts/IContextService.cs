using System.Collections.Generic;
using ViewModels;

namespace ShopBLL.Services.Contracts
{
    public interface IContextService
    {
        List<OrderDetailViewModel> GetOrders();
        void PutOrders(List<OrderDetailViewModel> orders);
    }
}
