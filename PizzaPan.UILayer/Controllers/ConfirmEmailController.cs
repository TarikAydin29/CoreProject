using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaPan.DataAccessLayer.Migrations;
using PizzaPan.EntityLayer.Concrete;
using PizzaPan.UILayer.Models;
using System.Threading.Tasks;

namespace PizzaPan.UILayer.Controllers
{
    public class ConfirmEmailController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public ConfirmEmailController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.username = TempData["Username"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ConfirmEmailVM vm)
        {
            var user = await userManager.FindByNameAsync(vm.Username);
            if (user.ConfirmCode == vm.ConfirmEmailCode)
            {
                user.EmailConfirmed = true;
                await userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
