using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace WebPresentation.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductService productService;
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IBasketService basketService;

        public BasketController(IProductService productService,
            IUserService userService,
            IMapper mapper,
            IBasketService basketService)
        {
            this.productService = productService;
            this.userService = userService;
            this.mapper = mapper;
            this.basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await basketService.GetOrdersAsync();
            return View(orders);
        }

        [Authorize]
        [HttpPost]
        public IActionResult PostOrderDetails(List<OrderDetailViewModel> orderDetails)
        {
            basketService.RewriteOrders(orderDetails);

            var userId = userService.GetUserId();
            var order = new OrderViewModel { UserId = userId };

            return View("Order", order);
        }

        [Authorize]
        [HttpPost]
        public IActionResult PostOrder(OrderViewModel model)
        {
            return Json(model);
        }
    }
}
