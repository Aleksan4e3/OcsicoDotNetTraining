using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace WebPresentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(CreateProduct());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await productService.CreateAsync(model);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        //todo
        [NonAction]
        private CreateProductViewModel CreateProduct()
        {
            return new CreateProductViewModel { ProductParents = new List<SelectListItem>() };
        }
    }
}
