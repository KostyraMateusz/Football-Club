using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.Controllers
{
    [ApiController]
    public class PracownicyController : ControllerBase
    {
        private readonly IPracownikService pracownikService;

        public PracownicyController(IPracownikService pracownikService)
        {
            this.pracownikService = pracownikService;
        }

        [HttpPost]
        [Route("api/Pracownicy/DodajPracownika")]
        public async Task<ActionResult> UtworzPracownika([FromBody] Pracownik pracownik)
        {
            try
            {
                if (pracownik == null)
                {
                    throw new Exception("");
                }
                await this.pracownikService.DodajPracownika(pracownik);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/Pracownicy/UsunPracownika/{IdPracownika}")]
        public async Task<ActionResult> UsunPracownika([FromRoute] Guid IdPracownika)
        {
            try
            {
                var pracownicy = await this.pracownikService.DajPracownikow();
                var pracownik = pracownicy.First(k => k.IdPracownik == IdPracownika);
                if (pracownik == null)
                {
                    throw new Exception("");
                }
                await this.pracownikService.UsunPracownika(IdPracownika);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/Pracownicy/EdytujPracownika/{id}")]
        public async Task<ActionResult> EdytujPracownika([FromBody] Pracownik pracownik)
        {
            try
            {
                if (pracownik == null)
                {
                    throw new Exception("");
                }
                await this.pracownikService.EdytujPracownika(pracownik);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/[controller]/DajPracownikow")]
        public async Task<ActionResult<IEnumerable<Pracownik>>> DajPracownikow()
        {
            try
            {
                var result = await this.pracownikService.DajPracownikow();
                if (result.Equals(null))
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
        [Route("api/[controller]/ZmienWynagrodzeniePracownika/{IdPracownik}")]
        public async Task<ActionResult> ZmienWynagrodzenie([FromRoute] Guid IdPracownik, [FromBody]decimal wynagrodzenie)
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