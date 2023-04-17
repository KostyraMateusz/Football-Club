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


        public ActionResult Index()
        {
            var pilkarze = this.pilkarzService.DajPilkarzy();
            ViewData["Pilkarze"] = pilkarze;
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
            catch (Exception)
            {
                return NotFound();
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
            catch (Exception)
            {
                return NotFound();
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
            catch (Exception)
            {
                return NotFound();
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
            catch (Exception)
            {
                return NotFound();
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
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
