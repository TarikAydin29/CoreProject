using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaPan.EntityLayer.Concrete;
using PizzaPan.UILayer.Models;
using System;
using System.Threading.Tasks;

namespace PizzaPan.UILayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public LoginController(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginVM vm)
        {
            var result = await signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, true);
            var user = await userManager.FindByNameAsync(vm.Username);

            if (result.Succeeded && user.EmailConfirmed==true)
            {
                return RedirectToAction("Index", "Admin");
            }
            else if(result.Succeeded && user.EmailConfirmed == false)
            {
                return RedirectToAction("Index", "ConfirmEmail");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("Index","Default");
        }
    }
}
