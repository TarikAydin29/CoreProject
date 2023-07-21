using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.BusinessLayer.ValidationRules.OurTeamValidator;
using PizzaPan.EntityLayer.Concrete;

namespace PizzaPan.UILayer.Controllers
{
    public class OurTeamController : Controller
    {
        private readonly IOurTeamService ourTeamService;

        public OurTeamController(IOurTeamService ourTeamService)
        {
            this.ourTeamService = ourTeamService;
        }
        public IActionResult Index()
        {
            return View(ourTeamService.TGetList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(OurTeam ourTeam)
        {
            CreateOurTeamValidator createOurTeamValidator = new CreateOurTeamValidator();
            ValidationResult result = createOurTeamValidator.Validate(ourTeam);
            if (result.IsValid)
            {
                ourTeamService.TInsert(ourTeam);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
