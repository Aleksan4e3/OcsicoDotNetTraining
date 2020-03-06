using Microsoft.AspNetCore.Mvc;

namespace WebPresentation.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
