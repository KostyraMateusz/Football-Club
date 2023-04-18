using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace FootballClubPresentationLayer.Controllers
{
    [Route("/api/Zarzad")]
    public class ZarzadyController : Controller
    {
        private readonly IZarzadService _zarzadService;

        public ZarzadyController(IZarzadService zarzadService)
        {
            _zarzadService = zarzadService;
        }

        public async Task<ActionResult> Index()
        {
            var zarzady = await this._zarzadService.DajZarzady();
            return View(zarzady);
        }

        [HttpGet("/DajWynikFinansowy")]
        public async Task<ActionResult>DajWynikFinansowy([FromBody]Guid IdZarzadu)
        {
            try
            {
                var result = await this._zarzadService.DajWynikFinansowyZarzadu(IdZarzadu);
                if(result.Equals(null))
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

        [HttpPost("/DodajCelZarzadu")]
        public async Task<ActionResult> DodajCelZarzadu([FromBody]Guid IdZarzadu, string cel)
        {
            try
            {
                if(IdZarzadu.Equals(null) || cel.Equals(null) || cel.Equals(""))
                {
                    throw new Exception("Pusty cel");
                }
                await this._zarzadService.DodajCelZarzadu(IdZarzadu, cel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost("/DodajCzlonkaZarzadu")]
        public async Task<ActionResult> DodajCzlonkaZarzadu([FromBody]Guid IdZarzadu, [FromBody]Guid IdPracownik)
        {
            try
            {
                if (IdZarzadu.Equals(null) || IdPracownik.Equals(null))
                {
                    throw new Exception();
                }
                await this._zarzadService.DodajCzlonkaZarzadu(IdZarzadu, IdPracownik);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPut("/ZmienBudzetZarzadu")]
        public async Task<ActionResult> ZmienBudzetZarzadu([FromBody]Guid IdZarzadu, decimal budzet)
        {
            try
            {
                if (IdZarzadu.Equals(null) || budzet.Equals(null) || budzet <= 0)
                {
                    throw new Exception();
                }
                await this._zarzadService.ZmienBudzetZarzadu(IdZarzadu, budzet);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
