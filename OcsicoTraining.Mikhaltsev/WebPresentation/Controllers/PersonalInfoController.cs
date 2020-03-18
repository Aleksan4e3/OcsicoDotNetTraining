using System;
using System.Threading.Tasks;
using EntityModels.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopBLL.Services.Contracts;

namespace WebPresentation.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly IUserService userService;
        private readonly IOrderService orderService;
        private readonly IEmailService emailService;

        public PersonalInfoController(IUserService userService,
            IOrderService orderService,
            IEmailService emailService)
        {
            this.userService = userService;
            this.orderService = orderService;
            this.emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await orderService.GetAsync();

            if (User.IsInRole(Roles.Admin))
            {
                return View(orders);
            }

            var userId = userService.GetUserId();
            var userOrders = await orderService.GetAsync(userId);

            return View(userOrders);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public async Task<IActionResult> Change(Guid id)
        {
            var order = await orderService.EditAsync(id);

            await emailService.SendEmailChangeStatusAsync(order.User.Email, order);

            var orders = await orderService.GetAsync();

            return PartialView("_Orders", orders);
        }
    }
}
