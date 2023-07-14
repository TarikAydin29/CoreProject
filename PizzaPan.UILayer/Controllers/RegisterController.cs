using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaPan.EntityLayer.Concrete;
using PizzaPan.UILayer.Models;
using System.Threading.Tasks;

namespace PizzaPan.UILayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Name = vm.Name,
                    Surname = vm.Surname,
                    Email = vm.Email,
                    UserName = vm.Username
                };
                await userManager.CreateAsync(user, vm.Password);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
    }
}
