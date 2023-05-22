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

        public IActionResult DajKluby()
        {
            var kluby = this.klubService.DajKluby().Result.ToList();
            ViewBag.Kluby = kluby;
            return View(kluby);
        }

        public IActionResult DajTrofea(Guid id)
        {
            var troefa = this.klubService.DajTrofeaKlubu(id);
            if(troefa == null)
            {
                return NotFound();
            }
            return View(troefa);
        }

        public IActionResult DajObecnychPilkarzyKlubu(Guid id)
        {
            var pilkarze = this.klubService.DajObecnychPilkarzy(id);
            if(pilkarze == null)
            {
                return NotFound();
            }
            return View(pilkarze);
        }

        public IActionResult DodajPilkarzaDoObecnych(Guid id, Pilkarz pilkarz)
        {
            this.klubService.DodajPilkarzaDoObecnych(pilkarz, id);
            return View();
        }
    }
}
