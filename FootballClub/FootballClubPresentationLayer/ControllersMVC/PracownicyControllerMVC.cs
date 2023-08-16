using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.ControllersMVC
{
    public class PracownicyControllerMVC : Controller
    {
        private readonly IPracownikService pracownikService;

        public PracownicyControllerMVC(IPracownikService pracownikService)
        {
            this.pracownikService = pracownikService;
        }

        public IActionResult Index()
        {
            return DajPracownikiw();
        }

        public IActionResult DajPracownikiw()
        {
            var pracownicy = this.pracownikService.DajPracownikow().Result.ToList();
            ViewBag.Pracownicy = pracownicy;
            return View(pracownicy);
        }
    }
}
