using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.Controllers
{
    [Route("/api/klub")]
    public class KlubyController : Controller
    {
        private readonly IKlubService klubService;

        public KlubyController(IKlubService klubService)
        {
            this.klubService = klubService;
        }

        public ActionResult Index()
        {
            var kluby = this.klubService.DajKluby();
            ViewData["Kluby"] = kluby;
            return View(kluby);
        }

        [HttpGet("/DajArchiwalnegoPilkarza")]
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
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("/DajArchiwalnychPilkarzy")]
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
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpGet("/DajObecnegoPilkarza")]
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
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpGet("/DajObecnychPilkarzy")]
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
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("/DodajPilkarzaDoObecnych")]
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
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("/UsunPilkarzaZObecnych")]
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
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
