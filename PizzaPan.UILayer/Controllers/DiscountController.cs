using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.EntityLayer.Concrete;
using System;

namespace PizzaPan.UILayer.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService discountService;

        public DiscountController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }
        public IActionResult Index()
        {
           var discounts= discountService.TGetList();
            return View(discounts);
        }
        public IActionResult CreateCode()
        {
            string[] symbols = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };
            int c1, c2, c3, c4;
            Random rnd = new Random();
            c1 = rnd.Next(0, symbols.Length);
            c2 = rnd.Next(0, symbols.Length);
            c3 = rnd.Next(0, symbols.Length);
            c4 = rnd.Next(0, symbols.Length);
            int c5 = rnd.Next(10, 100);
            ViewBag.v = symbols[c1] + symbols[c2] + symbols[c3] + symbols[c4] + c5;
            return View();
        }
        [HttpPost]
        public IActionResult CreateCode(Discount d)
        {
            d.CreatedDate = DateTime.Now;
            d.ExpireDate = d.CreatedDate.AddDays(3);
            discountService.TInsert(d);
            return RedirectToAction("Index");
        }
    }
}
