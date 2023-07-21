using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.DataAccessLayer.Concrete;
using System.Linq;

namespace PizzaPan.UILayer.Controllers
{
    public class MainMenuController : Controller
    {
		private readonly IProductService productService;
        private readonly Context _context;

        public MainMenuController(IProductService productService, Context context)
        {
            this.productService = productService;
            _context = context;
        }
        public IActionResult Index()
        {
            //var values = productService.TGetProductsWithCategory();
            var values = _context.Categories.Include(x => x.Products).ToList();
            return View(values);
        }
    }
}
