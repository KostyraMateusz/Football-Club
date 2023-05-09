using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.Controllers
{
    public class PilkarzeController : Controller
    {
        private readonly IPilkarzService pilkarzService;

        public PilkarzeController(IPilkarzService pilkarzService)
        {
            this.pilkarzService = pilkarzService;
        }


        public async Task<ActionResult> Index()
        {
            var pilkarze = await this.pilkarzService.DajPilkarzy();
            return Ok(pilkarze);
        }


        [HttpGet]
        [Route("api/[controller]/DajArchiwalneKlubyPilkarza/{IdPilkarza}")]
        public async Task<ActionResult<IEnumerable<Klub>>> DajArchiwalneKlubyPilkarza([FromRoute] Guid IdPilkarza)
        {
            try
            {
                var result = await this.pilkarzService.DajArchiwalneKlubyPilkarza(IdPilkarza);
                if (result == null)
                {
                    throw new Exception("");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/[controller]/DajStatystykePilkarza/{IdStatystyka}, {IdPilkarza}")]
        public async Task<ActionResult<Statystyka>> DajStatystykePilkarza([FromRoute] Guid IdStatystyka, [FromRoute] Guid IdPilkarza)
        {
            try
            {
                var result = await this.pilkarzService.DajStatystykePilkarza(IdStatystyka, IdPilkarza);
                if (result == null)
                {
                    throw new Exception("");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/[controller]/DajStatystykiPilkarza/{IdPilkarza}")]
        public async Task<ActionResult<IEnumerable<Statystyka>>> DajStatystykiPilkarza([FromRoute] Guid IdPilkarza)
        {
            try
            {
                var result = await this.pilkarzService.DajStatystykiPilkarza(IdPilkarza);
                if (result == null)
                {
                    throw new Exception("");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/[controller]/DajNajlepszeStatystykiPilkarza/{IdPilkarza}")]
        public async Task<ActionResult<IEnumerable<Statystyka>>> DajNajlepszeStatystykiPilkarza([FromRoute] Guid IdPilkarza)
        {
            try
            {
                var result = await this.pilkarzService.DajNajlepszeStatystykiPilkarza(IdPilkarza);
                if (result == null)
                {
                    throw new Exception("");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/[controller]/DajPilkarzyBezKlubu")]
        public async Task<ActionResult<IEnumerable<Pilkarz>>> DajPilkarzyBezKlubu()
        {
            try
            {
                var result = await this.pilkarzService.DajPilkarzyBezKlubu();
                if (result == null)
                {
                    throw new Exception("");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
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
