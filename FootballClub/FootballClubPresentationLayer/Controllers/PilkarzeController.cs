using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.Controllers
{
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


        [HttpGet]
        [Route("api/[controller]/DajArchiwalneKlubyPilkarza")]
        public async Task<ActionResult> DajArchiwalneKlubyPilkarza([FromRoute] Guid IdPilkarza)
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


        [HttpGet]
        [Route("api/[controller]/DajStatystykePilkarza")]
        public async Task<ActionResult> DajStatystykePilkarza([FromRoute] Guid IdStatystyka, [FromRoute] Guid IdPilkarza)
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


        [HttpGet]
        [Route("api/[controller]/DajStatystykiPilkarza")]
        public async Task<ActionResult> DajStatystykiPilkarza([FromRoute] Guid IdPilkarza)
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

        [HttpGet]
        [Route("api/[controller]/DajNajlepszeStatystykiPilkarza")]
        public async Task<ActionResult> DajNajlepszeStatystykiPilkarza([FromRoute] Guid IdPilkarza)
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

        [HttpGet]
        [Route("api/[controller]/DajPilkarzyBezKlubu")]
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

        [HttpPut]
        [Route("api/[controller]/ZmienPozycjePilkarza")]
        public async Task<ActionResult> ZmienPozycjePilkarza([FromRoute] Guid IdPilkarza, string pozycja)
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
    }
}
