using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ViewModels;

namespace WebPresentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PostNews()
        {
            var model = new ArticleViewModel {Text = "Работает", Title = "localhost"};
            var client = new HttpClient();

            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(nameof(model.Text), model.Text),
                new KeyValuePair<string, string>(nameof(model.Title), model.Title)
            };

            var content = new FormUrlEncodedContent(postData);

            var response = await client.PostAsync("http://kawaii.local/News/Post", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            model = JsonConvert.DeserializeObject<ArticleViewModel>(responseContent);

            return Json(model);

        }
    }
}
