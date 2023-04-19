using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.Controllers
{
    public class KlubyController : Controller
    {
        private readonly IKlubService klubService;

        public KlubyController(IKlubService klubService)
        {
            this.klubService = klubService;
        }

        public async Task<ActionResult> Index()
        {
            var kluby = await this.klubService.DajKluby();
            return View(kluby);
        }

        [HttpGet]
        [Route("api/[controller]/DajArchiwalnegoPilkarza")]
        public async Task<ActionResult> DajArchiwalnegoPilkarza([FromBody] Guid IdKlubu, [FromBody] Guid IdPilkarza)
        {
            try
            {
                var result = await this.klubService.DajArchiwalnegoPilkarza(IdKlubu, IdPilkarza);
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
        [Route("api/[controller]/DajArchiwalnychPilkarzy")]
        public async Task<ActionResult> DajArchiwalnychPilkarzy([FromBody] Guid IdKlubu)
        {
            try
            {
                var result = await this.klubService.DajArchiwalnychPilkarzy(IdKlubu);
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
        [Route("api/[controller]/DajObecnegoPilkarza")]
        public async Task<ActionResult> DajObecnegoPilkarza([FromBody] Guid IdKlubu, [FromBody] Guid IdPilkarza)
        {
            try
            {
                var result = await this.klubService.DajObecnegoPilkarza(IdKlubu, IdPilkarza);
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
        [Route("api/[controller]/DajObecnychPilkarzy")]
        public async Task<ActionResult> DajObecnychPilkarzy([FromBody] Guid IdKlubu)
        {
            try
            {
                var result = await this.klubService.DajObecnychPilkarzy(IdKlubu);
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

        [HttpPost]
        [Route("api/[controller]/DodajPilkarzaDoObecnych")]
        public async Task<ActionResult> DodajPilkarzaDoObecnych([FromBody] Guid IdPilkarza, [FromBody] Guid IdKlubu)
        {
            try
            {
                if (IdPilkarza.Equals(null) || IdKlubu.Equals(null))
                {
                    throw new Exception("");
                }
                await this.klubService.DodajPilkarzaDoObecnych(IdPilkarza, IdKlubu);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/[controller]/UsunPilkarzaZObecnych")]
        public async Task<ActionResult> UsunPilkarzaZObecnych([FromBody] Guid IdPilkarza, [FromBody] Guid IdKlubu)
        {
            try
            {
                if (IdPilkarza.Equals(null) || IdKlubu.Equals(null))
                {
                    throw new Exception("");
                }
                await this.klubService.UsunPilkarzaZObecnych(IdPilkarza, IdKlubu);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
