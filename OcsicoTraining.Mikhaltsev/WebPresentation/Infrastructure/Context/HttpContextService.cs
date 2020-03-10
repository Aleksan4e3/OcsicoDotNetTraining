using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using ShopBLL.Services.Contracts;
using ViewModels;
using WebPresentation.Infrastructure.Utilities;

namespace WebPresentation.Infrastructure.Context
{
    public class HttpContextService : IContextService
    {
        private const string OrdersSessionKey = "BASKET_ORDERS";
        private readonly IHttpContextAccessor httpContextAccessor;

        public HttpContextService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public List<OrderDetailViewModel> GetOrders()
        {
            var httpContext = httpContextAccessor.HttpContext;
            var orders = httpContext.Session.Get<List<OrderDetailViewModel>>(OrdersSessionKey);

            return orders ?? new List<OrderDetailViewModel>();
        }

        public void PutOrders(List<OrderDetailViewModel> orders)
        {
            var httpContext = httpContextAccessor.HttpContext;

            httpContext.Session.Set(OrdersSessionKey, orders);
        }
    }
}
