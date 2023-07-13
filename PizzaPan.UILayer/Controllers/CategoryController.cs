using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.EntityLayer.Concrete;

namespace PizzaPan.UILayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = categoryService.TGetList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            categoryService.TInsert(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category c = categoryService.TGetByID(id);
            categoryService.TDelete(c);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Category c = categoryService.TGetByID(id);
            return View(c);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            categoryService.TUpdate(category);
            return RedirectToAction("Index");
        }
    }
}
