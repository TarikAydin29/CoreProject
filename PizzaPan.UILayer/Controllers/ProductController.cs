using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.DataAccessLayer.Concrete;
using PizzaPan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PizzaPan.UILayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, IWebHostEnvironment webHostEnvironment,ICategoryService categoryService)
        {
            this.productService = productService;
            _webHostEnvironment = webHostEnvironment;
            this.categoryService = categoryService;
        }
        const string SessionPhoto = "photo";

        public IActionResult Index()
        {
            List<Product> p = productService.TGetProductsWithCategory();
            return View(p);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var categories = categoryService.TGetList();
            ViewBag.categorySelect = new SelectList(categories, "CategoryID", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product p, IFormFile image)
        {
            ResimKontrolleri(image);
            p.ImageUrl = ResimYukle(image);
            productService.TInsert(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product p = productService.TGetByID(id);
            productService.TDelete(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product p = productService.TGetByID(id);
            if (p.ImageUrl != null)
            {
                HttpContext.Session.SetString(SessionPhoto, p.ImageUrl);
            }

            return View(p);
        }
        [HttpPost]
        public IActionResult Edit(Product p, IFormFile image)
        {
            if (image != null)
            {
                ResimKontrolleri(image);
                p.ImageUrl = ResimYukle(image);
            }
            else
            {
                p.ImageUrl = HttpContext.Session.GetString(SessionPhoto);
            }

            productService.TUpdate(p);
            return RedirectToAction("Index");
        }

        


        private string ResimYukle(IFormFile image)
        {
            string ext = Path.GetExtension(image.FileName);
            string resimAd = Guid.NewGuid() + ext;
            string dosyaYolu = Path.Combine(_webHostEnvironment.WebRootPath, "images", "uploads", resimAd);
            using (var stream = new FileStream(dosyaYolu, FileMode.Create))
            {
                image.CopyTo(stream);
            }
            return resimAd;
        }

        private void ResimKontrolleri(IFormFile image)
        {
            string[] izinVerilenler = { ".jpg", ".png", ".jpeg" };
            if (image != null)
            {
                string ext = Path.GetExtension(image.FileName);
                if (!izinVerilenler.Contains(ext))
                {
                    ModelState.AddModelError("image", "İzin verilen dosya uzantıları jpeg,jpg,png");
                }
                else if (image.Length > 1000 * 5000 * 1) // 5 MB tekabül ediyor
                {
                    ModelState.AddModelError("image", "İzin verilen resim boyutu 5 MB");
                }
            }
            else
            {
                ModelState.AddModelError("image", "Resim Zorunlu");
            }
        }
    }
}
