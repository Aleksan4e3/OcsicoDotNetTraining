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

        public PersonalInfoController(IUserService userService,
            IOrderService orderService)
        {
            this.userService = userService;
            this.orderService = orderService;
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
            await orderService.EditAsync(id);

            var orders = await orderService.GetAsync();

            return PartialView("_Orders", orders);
        }
    }
}
