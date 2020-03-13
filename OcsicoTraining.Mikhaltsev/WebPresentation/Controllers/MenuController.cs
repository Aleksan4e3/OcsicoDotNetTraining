using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace WebPresentation.Controllers
{
    public class MenuController : Controller
    {
        private readonly IProductService productService;
        private readonly IBasketService basketService;

        public MenuController(IProductService productService,
            IBasketService basketService)
        {
            this.productService = productService;
            this.basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetForMenuAsync();

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

            basketService.AddOrder(model);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await productService.GetAsync(id);
            product.ParentProductId = id;

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm]ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
