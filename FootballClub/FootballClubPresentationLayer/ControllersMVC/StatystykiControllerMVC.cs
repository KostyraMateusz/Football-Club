using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.ControllersMVC
{
    public class StatystykiControllerMVC : Controller
    {
        private readonly IStatystykaService statystykaService;

        public StatystykiControllerMVC(IStatystykaService statystykaService)
        {
            this.statystykaService = statystykaService;
        }

        public IActionResult Index()
        {
            return DajStatystyki();
        }

        public IActionResult DajStatystyki()
        {
            var statystyki = this.statystykaService.DajStatystyki().Result.ToList();
            ViewBag.Statystyki = statystyki;
            return View(statystyki);
        }
    }
}
