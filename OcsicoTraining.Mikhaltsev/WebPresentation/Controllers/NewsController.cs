using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace WebPresentation.Controllers
{
    public class NewsController : Controller
    {
        private readonly IHttpClientFactory factory;

        public NewsController(IHttpClientFactory factory)
        {
            this.factory = factory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Post()
        {
            var article = new ArticleViewModel { Title = "NewPie", Text = "Very tasty" };
                var json = JsonSerializer.Serialize(article);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

            var client = factory.CreateClient();
            var url = "http://kawaii.local/news/index";

            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            return Content(result);
        }

        public string Test() => "ok";
    }
}
