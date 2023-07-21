using Microsoft.AspNetCore.Mvc;

namespace PizzaPan.UILayer.ViewComponents.Default
{
    public class _BlogPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Blog");
        }
    }
}
