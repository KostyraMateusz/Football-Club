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


        [HttpPut("/ZmienFunkcjePracownika")]
        public async Task<ActionResult> ZmienFunkcjePracownika([FromBody] Guid IdPracownik, string funkcja)
        {
            try
            {
                if (IdPracownik.Equals(null) || funkcja.Equals(null))
                {
                    throw new Exception();
                }
                await this.pracownikService.ZmienFunkcjePracownika(IdPracownik, funkcja);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpPut("/ZmienWynagrodzenie")]
        public async Task<ActionResult> ZmienWynagrodzenie([FromBody] Guid IdPracownik, decimal wynagrodzenie)
        {
            try
            {
                if (IdPracownik.Equals(null) || wynagrodzenie.Equals(null))
                {
                    throw new Exception();
                }
                await this.pracownikService.ZmienWynagrodzenie(IdPracownik, wynagrodzenie);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpPut("/ZmienWiekPracownika")]
        public async Task<ActionResult> ZmienWiekPracownika([FromBody] Guid IdPracownik, int wiek)
        {
            try
            {
                if (IdPracownik.Equals(null) || wiek.Equals(null))
                {
                    throw new Exception();
                }
                await this.pracownikService.ZmienWiekPracownika(IdPracownik, wiek);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}