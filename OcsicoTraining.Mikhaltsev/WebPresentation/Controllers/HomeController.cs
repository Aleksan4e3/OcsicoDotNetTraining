using Microsoft.AspNetCore.Mvc;

namespace WebPresentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
