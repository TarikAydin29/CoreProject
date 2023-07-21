using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using System.Linq;

namespace PizzaPan.UILayer.ViewComponents.Default
{
    public class _TestimonialPartial : ViewComponent
    {
        private readonly ITestimonialService testimonialService;

        public _TestimonialPartial(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }
        public IViewComponentResult Invoke()
        {
            var values = testimonialService.TGetList();
            return View(values);
        }
    }
}
