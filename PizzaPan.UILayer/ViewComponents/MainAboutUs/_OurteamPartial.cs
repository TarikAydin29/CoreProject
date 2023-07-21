using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;

namespace PizzaPan.UILayer.ViewComponents.MainAboutUs
{
    public class _OurteamPartial : ViewComponent
    {
        private readonly IOurTeamService ourTeamService;

        public _OurteamPartial(IOurTeamService ourTeamService)
        {
            this.ourTeamService = ourTeamService;
        }
        public IViewComponentResult Invoke()
        {
            var teams = ourTeamService.TGetList();
            return View("OurTeam",teams);
        }
    }
}
