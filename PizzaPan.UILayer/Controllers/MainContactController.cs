using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.EntityLayer.Concrete;

namespace PizzaPan.UILayer.Controllers
{
    public class MainContactController : Controller
    {
        private readonly IContactService contactService;

        public MainContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact c)
        {
            contactService.TInsert(c);
            return RedirectToAction("Index","Default");
        }
    }
}
