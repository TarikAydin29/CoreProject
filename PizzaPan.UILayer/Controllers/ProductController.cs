using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.EntityLayer.Concrete;
using System.Collections.Generic;

namespace PizzaPan.UILayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
           List<Product> p= productService.TGetList();
            return View(p);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product p)
        {
            productService.TInsert(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
           Product p= productService.TGetByID(id);
            productService.TDelete(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product p= productService.TGetByID(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            productService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
