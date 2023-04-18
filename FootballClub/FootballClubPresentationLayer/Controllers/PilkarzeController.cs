using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.Controllers
{
    [Route("/api/pilkarz")]
    public class PilkarzeController : Controller
    {
        private readonly IPilkarzService pilkarzService;

        public PilkarzeController (IPilkarzService pilkarzService)
        {
            this.pilkarzService = pilkarzService;
        }


        public async Task<ActionResult> Index()
        {
            var pilkarze = await this.pilkarzService.DajPilkarzy();
            return View(pilkarze);
        }


        [HttpGet("/DajArchiwalneKlubyPilkarza")]
        public async Task<ActionResult> DajArchiwalneKlubyPilkarza([FromBody] Guid IdPilkarza)
        {
            try
            {
                var result = await this.pilkarzService.DajArchiwalneKlubyPilkarza(IdPilkarza);
                if (result == null)
                {
                    throw new Exception("");
                }
                return View(result);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


        [HttpGet("/DajStatystykePilkarza")]
        public async Task<ActionResult> DajStatystykePilkarza([FromBody] Guid IdStatystyka, [FromBody] Guid IdPilkarza)
        {
            try
            {
                var result = await this.pilkarzService.DajStatystykePilkarza(IdStatystyka, IdPilkarza);
                if (result == null)
                {
                    throw new Exception("");
                }
                return View(result);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


        [HttpGet("/DajStatystykiPilkarza")]
        public async Task<ActionResult> DajStatystykiPilkarza([FromBody] Guid IdPilkarza)
        {
            try
            {
                var result = await this.pilkarzService.DajStatystykiPilkarza(IdPilkarza);
                if (result == null)
                {
                    throw new Exception("");
                }
                return View(result);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


        [HttpPut("/ZmienPozycjePilkarza")]
        public async Task<ActionResult> ZmienPozycjePilkarza([FromBody] Guid IdPilkarza, string pozycja)
        {
            try
            {
                if (IdPilkarza.Equals(null) || pozycja.Equals(null))
                {
                    throw new Exception();
                }
                await this.pilkarzService.ZmienPozycjePilkarza(IdPilkarza, pozycja);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


        [HttpGet("/DajNajlepszeStatystykiPilkarza")]
        public async Task<ActionResult> DajNajlepszeStatystykiPilkarza([FromBody] Guid IdPilkarza)
        {
            try
            {
                var result = await this.pilkarzService.DajNajlepszeStatystykiPilkarza(IdPilkarza);
                if (result == null)
                {
                    throw new Exception("");
                }
                return View(result);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet("/DajPilkarzyBezKlubu")]
        public async Task<ActionResult> DajPilkarzyBezKlubu()
        {
            try
            {
                var result = await this.pilkarzService.DajPilkarzyBezKlubu();
                if (result == null)
                {
                    throw new Exception("");
                }
                return View(result);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
