using System.Collections.Generic;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace ShopBLL.Services
{
    public class CalculateService : ICalculateService
    {
        public void CalculateTotal(OrderDetailViewModel model)
        {
            model.TotalPrice = model.Weight * model.Quantity * model.Product.Price / 1000;
        }

        public void CalculateTotal(List<OrderDetailViewModel> orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                CalculateTotal(orderDetail);
            }
        }

        public void CalculateTotal(OrderViewModel model)
        {
            foreach (var detail in model.OrderDetails)
            {
                CalculateTotal(detail);
                model.FinalPrice += detail.TotalPrice;
            }
        }

        public void CalculateTotal(List<OrderViewModel> orders)
        {
            foreach (var order in orders)
            {
                CalculateTotal(order);
            }
        }
    }
}
