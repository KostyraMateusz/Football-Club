using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.Controllers
{
    public class PracownicyController : Controller
    {
        private readonly IPracownikService pracownikService;

        public PracownicyController(IPracownikService pracownikService)
        {
            this.pracownikService = pracownikService;
        }

        public async Task<ActionResult> Index()
        {
            var pracownicy = await this.pracownikService.DajPracownikow();
            return Ok(pracownicy);
        }

        [HttpPut]
        [Route("api/[controller]/ZmienFunkcjePracownika")]
        public async Task<ActionResult> ZmienFunkcjePracownika([FromRoute] Guid IdPracownik, string funkcja)
        {
            try
            {
                if (IdPracownik.Equals(null) || funkcja.Equals(null))
                {
                    throw new Exception();
                }
                await this.pracownikService.ZmienFunkcjePracownika(IdPracownik, funkcja);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut]
        [Route("api/[controller]/ZmienWynagrodzenie")]
        public async Task<ActionResult> ZmienWynagrodzenie([FromRoute] Guid IdPracownik, decimal wynagrodzenie)
        {
            try
            {
                if (IdPracownik.Equals(null) || wynagrodzenie.Equals(null))
                {
                    throw new Exception();
                }
                await this.pracownikService.ZmienWynagrodzenie(IdPracownik, wynagrodzenie);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut]
        [Route("api/[controller]/ZmienWiekPracownika")]
        public async Task<ActionResult> ZmienWiekPracownika([FromRoute] Guid IdPracownik, int wiek)
        {
            try
            {
                if (IdPracownik.Equals(null) || wiek.Equals(null))
                {
                    throw new Exception();
                }
                await this.pracownikService.ZmienWiekPracownika(IdPracownik, wiek);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}