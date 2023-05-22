using BusinessLogicLayer.Interfaces;
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
            var pilkarze = this.pilkarzService.DajPilkarzy();
            return View(pilkarze);
        }

        public IActionResult DajStatystykiPilkarza(Guid IdPilkarz)
        {
            var statystyki = this.pilkarzService.DajStatystykiPilkarza(IdPilkarz);
            if(statystyki == null)
            {
                return NotFound();
            }
            return View(statystyki);
        }

        public IActionResult ZmienPozycjePilkarza(Guid idPilkarz, string pozycja)
        {
            this.pilkarzService.ZmienPozycjePilkarza(idPilkarz, pozycja);
            return View();
        }
    }
}
