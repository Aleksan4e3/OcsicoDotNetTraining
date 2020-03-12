using System.Collections.Generic;
using ViewModels;

namespace ShopBLL.Services.Contracts
{
    public interface ICalculateService
    {
        void CalculateTotal(OrderDetailViewModel model);
        void CalculateTotal(List<OrderDetailViewModel> orderDetails);
        void CalculateTotal(OrderViewModel model);
        void CalculateTotal(List<OrderViewModel> orders);
    }
}
