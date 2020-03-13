using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace WebPresentation.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService productService;
        private readonly IArticleService articleService;

        public AdminController(IProductService productService,
            IArticleService articleService)
        {
            this.productService = productService;
            this.articleService = articleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View(new CreateProductViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View(new CreateArticleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await articleService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
