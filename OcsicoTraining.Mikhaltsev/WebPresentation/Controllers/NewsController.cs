using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntityModels.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopBLL.Services.Contracts;

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

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public async Task<IActionResult> Publish(Guid id)
        {
            var article = await articleService.GetAsync(id);

            var json = JsonConvert.SerializeObject(article);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://httpbin.org/post";
            var client = factory.CreateClient();

            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            return Content(result);
        }
    }
}
