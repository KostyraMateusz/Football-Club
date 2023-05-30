using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.ControllersMVC
{
    public class PilkarzeControllerMVC : Controller
    {
        private readonly IPilkarzService pilkarzService;

        public PilkarzeControllerMVC(IPilkarzService pilkarzService)
        {
            this.pilkarzService = pilkarzService;
        }

        public IActionResult DajPilkarzy()
        {
            var pilkarze = this.pilkarzService.DajPilkarzy().Result.ToList();
            ViewBag.Pilkarze = pilkarze;
            return View(pilkarze);
        }

        public IActionResult DajPilkarzyBezKlubu()
        {
            var pilkarze = this.pilkarzService.DajPilkarzyBezKlubu().Result.ToList();
            ViewBag.Pilkarze = pilkarze;
            return View(pilkarze);
        }

        public IActionResult DajStatystykiPilkarza(Pilkarz pilkarz)
        {
            var statystyki = this.pilkarzService.DajStatystykiPilkarza(pilkarz).Result.ToList();
            if(statystyki == null)
            {
                return NotFound();
            }
            ViewBag.Pilkarze = statystyki;
            return View(statystyki);
        }

        public IActionResult DajArchiwalneKlubyPilkarza(Pilkarz pilkarz)
        {
            var kluby = this.pilkarzService.DajArchiwalneKlubyPilkarza(pilkarz).Result.ToList();
            if (kluby == null)
            {
                return NotFound();
            }
            ViewBag.Pilkarze = kluby;
            return View(kluby);
        }
        
        public IActionResult ZmienPozycjePilkarza(Pilkarz pilkarz, string pozycja)
        {
            this.pilkarzService.ZmienPozycjePilkarza(pilkarz, pozycja);
            return View();
        }
    }
}
