using Microsoft.AspNetCore.Mvc;

namespace PizzaPan.UILayer.ViewComponents.Default
{
    public class _FeaturePartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.title1 = "Her Gün Pizza Yiyin";
            ViewBag.title2 = "Pizzaya Olan Sevginizi Paylaşın";
            return View();
        }
    }
}
