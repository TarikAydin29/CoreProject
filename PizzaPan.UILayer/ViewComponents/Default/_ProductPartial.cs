using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;

namespace PizzaPan.UILayer.ViewComponents.Default
{
    public class _ProductPartial:ViewComponent
    {
        private readonly IProductService productService;

        public _ProductPartial(IProductService productService)
        {
            this.productService = productService;
        }
     public IViewComponentResult Invoke()
        {
            var values = productService.TGetList();
            return View(values);
        }   
    }
}
