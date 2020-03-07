using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopBLL.Services.Contracts;

namespace WebPresentation.Controllers
{
    public class MenuController : Controller
    {
        private readonly IProductService productService;

        public MenuController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAsync();

            return View(products);
        }
    }
}
