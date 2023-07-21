using Microsoft.AspNetCore.Mvc;

namespace PizzaPan.UILayer.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
