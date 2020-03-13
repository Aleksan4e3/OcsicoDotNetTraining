using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace WebPresentation.Controllers
{
    public class NewsController : Controller
    {
        private readonly IHttpClientFactory factory;
        private readonly IArticleService articleService;

        public NewsController(IHttpClientFactory factory,
            IArticleService articleService)
        {
            this.factory = factory;
            this.articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAsync();

            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Post(Guid id)
        {
            var article = await articleService.GetAsync(id);
            var json = JsonSerializer.Serialize(article);
            var content = new StringContent(json, Encoding.Unicode, "application/json");

            var client = factory.CreateClient();
            var url = "http://kawaii.local/news/index";

            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            return Content(result);
        }
    }
}
