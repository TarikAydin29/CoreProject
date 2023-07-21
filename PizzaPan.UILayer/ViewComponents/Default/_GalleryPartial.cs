using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using System.Linq;

namespace PizzaPan.UILayer.ViewComponents.Default
{
    public class _GalleryPartial : ViewComponent
    {
        private readonly IProductImageService productImageService;

        public _GalleryPartial(IProductImageService productImageService)
        {
            this.productImageService = productImageService;
        }
        public IViewComponentResult Invoke()
        {
            var values = productImageService.TGetList();
            ViewBag.list = values.Select(x=>x.ImageUrl).ToList();
            return View(values);
        }
    }
}
