using Microsoft.AspNetCore.Mvc;

namespace PizzaPan.UILayer.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
