using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopBLL.Services.Contracts;

namespace WebPresentation.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly IUserService userService;
        private readonly IOrderService orderService;
        private readonly ICalculateService calculateService;

        public PersonalInfoController(IUserService userService,
            IOrderService orderService,
            ICalculateService calculateService)
        {
            this.userService = userService;
            this.orderService = orderService;
            this.calculateService = calculateService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await orderService.GetAsync();

            if (User.IsInRole("Admin"))
            {
                calculateService.CalculateTotal(orders);

                return View(orders);
            }

            var userId = userService.GetUserId();
            var userOrders = await orderService.GetAsync(userId);

            calculateService.CalculateTotal(userOrders);

            return View(userOrders);
        }
    }
}
