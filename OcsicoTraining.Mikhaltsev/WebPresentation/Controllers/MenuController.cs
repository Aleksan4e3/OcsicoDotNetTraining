using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopBLL.Services.Contracts;
using ViewModels;
using WebPresentation.Session;

namespace WebPresentation.Controllers
{
    public class MenuController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderDetailService orderDetailService;

        public MenuController(IProductService productService,
            IOrderDetailService orderDetailService)
        {
            this.productService = productService;
            this.orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAsync();

            return View(products);
        }

        [HttpPost]
        public IActionResult Add([Bind(Prefix = "item")]OrderDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //todo
                return new EmptyResult();
            }

            HttpContext.Session.Set(model.ProductId.ToString(), model);

            return Ok();
        }
    }
}
