using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.ControllersMVC
{
    public class KlubyControllerMVC : Controller
    {
        private readonly IKlubService klubService;

        public KlubyControllerMVC(IKlubService klubService)
        {
            this.klubService = klubService;
        }

        public IActionResult Index()
        {
            return DajKluby();
        }

        public IActionResult DajKluby()
        {
            var kluby = this.klubService.DajKluby().Result.ToList();
            ViewBag.Kluby = kluby;
            return View(kluby);
        }

        public IActionResult DajTrofea(Klub klub)
        {
            var troefa = this.klubService.DajTrofeaKlubu(klub).Result.ToString();
            ViewBag.Trofea = troefa;
            return View(troefa);
        }

        public IActionResult DajStadion(Klub klub)
        {
            var stadion = this.klubService.DajStadionKlubu(klub).Result.ToString();
            ViewBag.Stadion = stadion;
            return View(stadion);
        }

        public IActionResult DajObecnychPilkarzyKlubu(Klub klub)
        {
            var pilkarze = this.klubService.DajObecnychPilkarzy(klub).Result.ToList();
            if(pilkarze == null)
            {
                return NotFound();
            }
            ViewBag.Pilkarze = pilkarze;
            return View(pilkarze);
        }

        public IActionResult DodajPilkarzaDoObecnych(Klub klub, Pilkarz pilkarz)
        {
            this.klubService.DodajPilkarzaDoObecnych(pilkarz, klub);
            return View();
        }
    }
}
