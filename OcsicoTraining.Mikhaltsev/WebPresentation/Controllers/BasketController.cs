using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EntityModels;
using Microsoft.AspNetCore.Mvc;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace WebPresentation.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        private readonly IBasketService basketService;

        public BasketController(IProductService productService,
            IMapper mapper,
            IBasketService basketService)
        {
            this.productService = productService;
            this.mapper = mapper;
            this.basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await basketService.GetOrdersAsync();
            return View(orders);
        }

        [HttpPost]
        public IActionResult PostOrder(List<OrderDetailViewModel> orders)
        {
            return Json(orders);
        }
    }
}
