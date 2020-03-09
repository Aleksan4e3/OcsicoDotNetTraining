using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EntityModels;
using Microsoft.AspNetCore.Mvc;
using ShopBLL.Services.Contracts;
using ViewModels;
using WebPresentation.Session;

namespace WebPresentation.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public BasketController(IProductService productService,
            IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var keys = HttpContext.Session.Keys;
            var collection = new List<OrderDetailViewModel>();

            foreach (var key in keys)
            {
                var item = HttpContext.Session.Get<OrderDetailViewModel>(key);
                var product = await productService.GetAsync(Guid.Parse(key));
                item.Product = product;
                item.CalculateTotal();

                collection.Add(item);
            }

            return View(collection);
        }

        [HttpPost]
        public IActionResult PostOrder([Bind(Prefix = "item")]List<OrderDetail> orders)
        {
            return new EmptyResult();
        }
    }
}
