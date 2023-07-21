using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PizzaPan.EntityLayer.Concrete;
using PizzaPan.UILayer.Models;
using System;
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
            Random rnd = new Random();
            int x = rnd.Next(100000, 1000000);
            if (vm.Password == null || vm.ConfirmPassword == null)
            {
                return View();
            }
            AppUser user = new AppUser()
            {
                Name = vm.Name,
                Surname = vm.Surname,
                Email = vm.Email,
                UserName = vm.Username,
                ConfirmCode = x
            };
            if (vm.Password == vm.ConfirmPassword)
            {
                var result = await userManager.CreateAsync(user, vm.Password);
                if (result.Succeeded)
                {
                    SendMail(vm, x);
                    TempData["Username"] = user.UserName;
                    return RedirectToAction("Index", "ConfirmEmail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View();
        }

        private static void SendMail(RegisterVM vm, int code)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "demoprojemail@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", vm.Email);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Kayıt işlemi için onay kodunuz : " + code + ".";
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Kayıt Onay Kodu";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("demoprojemail@gmail.com", "lpcrysgsrzoeepzt");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
        }
    }
}
