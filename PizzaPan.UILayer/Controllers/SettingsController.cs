using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaPan.EntityLayer.Concrete;
using PizzaPan.UILayer.Models;
using System.Threading.Tasks;

namespace PizzaPan.UILayer.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await userManager.FindByNameAsync(User.Identity.Name);
            UserEditVM vm = new UserEditVM();
            vm.Name = value.Name;
            vm.Surname = value.Surname;
            vm.Email = value.Email;
            vm.City = value.City;
            vm.Username = value.UserName;
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditVM vm)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            user.Name = vm.Name;
            user.Surname = vm.Surname;
            user.City = vm.City;
            user.Email = vm.Email;
            if (vm.Password != null)
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, vm.Password);
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
    }
}
