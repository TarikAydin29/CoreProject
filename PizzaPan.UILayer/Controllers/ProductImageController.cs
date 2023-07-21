using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.EntityLayer.Concrete;
using PizzaPan.UILayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PizzaPan.UILayer.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly IProductImageService productImageService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductImageController(IProductImageService productImageService, IWebHostEnvironment webHostEnvironment)
        {
            this.productImageService = productImageService;
            _webHostEnvironment = webHostEnvironment;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ImageFileVM vm)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(vm.Image.FileName);
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = resource + "/wwwroot/Images/" + imageName;
            var stream = new FileStream(saveLocation, FileMode.Create);
            vm.Image.CopyTo(stream);

            ProductImage productImage = new ProductImage();
            productImage.ImageUrl = imageName;

            productImageService.TInsert(productImage);

            return RedirectToAction("ImageList");
        }

        public IActionResult ImageList()
        {            
            return View(productImageService.TGetList());
        }
    }
}
