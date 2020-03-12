using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            var orders = await orderService.GetAsync();

            if (User.IsInRole("Admin"))
            {
                return View(orders);
            }

            var userId = userService.GetUserId();
            var userOrders = await orderService.GetAsync(userId);

            return View(userOrders);
        }
    }
}
