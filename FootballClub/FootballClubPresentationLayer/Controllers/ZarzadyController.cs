using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.Controllers
{
    [ApiController]
    public class ZarzadyController : ControllerBase
    {
        private readonly IZarzadService zarzadService;

        public ZarzadyController(IZarzadService zarzadService)
        {
            this.zarzadService = zarzadService;
        }

        [HttpGet]
        [Route("api/[controller]/DajZarzady")]
        public async Task<ActionResult<IEnumerable<Zarzad>>> DajZarzady()
        {
            try
            {
                var result = await this.zarzadService.DajZarzady();
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
        [Route("api/[controller]/DajWynikFinansowy/{IdZarzadu}")]
        public async Task<ActionResult<decimal>> DajWynikFinansowy([FromRoute] Guid IdZarzadu)
        {
            try
            {
                var result = await this.zarzadService.DajWynikFinansowyZarzadu(IdZarzadu);
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

        [HttpPost]
        [Route("api/[controller]/DodajCelZarzadu/{IdZarzadu}, {cel}")]
        public async Task<ActionResult> DodajCelZarzadu([FromRoute] Guid IdZarzadu, string cel)
        {
            try
            {
                if (IdZarzadu.Equals(null) || cel.Equals(null) || cel.Equals(""))
                {
                    throw new Exception("Pusty cel");
                }
                await this.zarzadService.DodajCelZarzadu(IdZarzadu, cel);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/[controller]/DodajCzlonkaZarzadu/{IdZarzadu}, {IdPracownik}")]
        public async Task<ActionResult> DodajCzlonkaZarzadu([FromRoute] Guid IdZarzadu, [FromRoute] Guid IdPracownik)
        {
            try
            {
                if (IdZarzadu.Equals(null) || IdPracownik.Equals(null))
                {
                    throw new Exception();
                }
                await this.zarzadService.DodajCzlonkaZarzadu(IdZarzadu, IdPracownik);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/[controller]/ZmienBudzetZarzadu")]
        public async Task<ActionResult> ZmienBudzetZarzadu([FromRoute] Guid IdZarzadu, decimal budzet)
        {
            try
            {
                if (IdZarzadu.Equals(null) || budzet.Equals(null) || budzet <= 0)
                {
                    throw new Exception();
                }
                await this.zarzadService.ZmienBudzetZarzadu(IdZarzadu, budzet);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
