using Microsoft.AspNetCore.Mvc;

namespace Mvc1.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
