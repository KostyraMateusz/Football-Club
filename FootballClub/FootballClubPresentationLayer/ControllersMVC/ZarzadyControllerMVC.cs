using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.ControllersMVC
{
    public class ZarzadyControllerMVC : Controller
    {
        private readonly IZarzadService zarzadService;

        public ZarzadyControllerMVC(IZarzadService zarzadService)
        {
            this.zarzadService = zarzadService;
        }

        public IActionResult DajZarzady()
        {
            var zarzady = this.zarzadService.DajZarzady().Result.ToList();
            ViewBag.Zarzad = zarzady;
            return View(zarzady);
        }

        public IActionResult DajWynikFinansowy(Zarzad zarzad)
        {
            var wynikFinansowy = this.zarzadService.DajWynikFinansowyZarzadu(zarzad.IdZarzad);
            ViewBag.Zarzad = wynikFinansowy;
            return View(wynikFinansowy);
        }

        public IActionResult DodajCelZarzadu(Zarzad zarzad, string cel)
        {
            this.zarzadService.DodajCelZarzadu(zarzad.IdZarzad, cel);
            return View();
        }

        public IActionResult DodajCzlonkaZarzadu(Zarzad zarzad, Pracownik pracownik)
        {
            this.zarzadService.DodajCzlonkaZarzadu(zarzad.IdZarzad, pracownik.IdPracownik);
            return View();
        }

        public IActionResult ZmienBudzetZarzadu(Zarzad zarzad, decimal budzet)
        {
            this.zarzadService.ZmienBudzetZarzadu(zarzad.IdZarzad, budzet);
            return View();
        }
    }
}
