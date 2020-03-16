using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityModels.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace WebPresentation.Controllers
{
    public class BasketController : Controller
    {
        private readonly IUserService userService;
        private readonly IBasketService basketService;
        private readonly IOrderService orderService;
        private readonly IEmailService emailService;
        private readonly ICalculateService calculateService;

        public BasketController(IUserService userService,
            IBasketService basketService,
            IOrderService orderService,
            IEmailService emailService,
            ICalculateService calculateService)
        {
            this.userService = userService;
            this.basketService = basketService;
            this.orderService = orderService;
            this.emailService = emailService;
            this.calculateService = calculateService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await basketService.GetOrdersAsync();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id, int weight)
        {
            basketService.DeleteOrder(id, weight);

            var orders = await basketService.GetOrdersAsync();

            return PartialView("_ShoppingCart", orders);
        }

        [Authorize]
        [HttpPost]
        public IActionResult PostOrderDetails(List<OrderDetailViewModel> orderDetails)
        {
            if (orderDetails.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "Нет товаров для заказа");
            }

            if (!ModelState.IsValid)
            {
                return View("Index", orderDetails);
            }

            basketService.RewriteOrders(orderDetails);

            var userId = userService.GetUserId();
            var order = new OrderViewModel { UserId = userId };

            return View("Order", order);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostOrder(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Order", model);
            }

            model.OrderDetails = await basketService.GetOrdersAsync();
            model.Status = OrderStatus.Accepted;
            calculateService.CalculateTotal(model);

            await orderService.CreateAsync(model);
            basketService.DeleteOrders();

            var email = await userService.GetEmail();

            await emailService.SendEmailAsync(email, model);

            return RedirectToAction("Index", "PersonalInfo");
        }
    }
}
