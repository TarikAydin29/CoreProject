using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.BusinessLayer.Concrete;
using PizzaPan.EntityLayer.Concrete;
using System.Collections.Generic;

namespace PizzaPan.UILayer.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {

            _contactService = contactService;
        }
        public IActionResult Index()
        {
            var contacts = _contactService.TGetList();
            return View(contacts);
        }
        public IActionResult Delete(int id)
        {
            Contact c = _contactService.TGetByID(id);
            _contactService.TDelete(c);
            return RedirectToAction("Index");
        }
        public IActionResult GetMessageByTesekkur()
        {
            var values = _contactService.TGetContactBySubjectWithTesekkur();
            return View(values);
        }
    }
}
