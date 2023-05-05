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

        public async Task<IActionResult> Index()
        {
            var kluby = await this.klubService.DajKluby();
            return Ok(kluby);
        }

        [HttpGet]
        [Route("api/[controller]/DajArchiwalnegoPilkarza/{IdKlubu}, {IdPilkarza}")]
        public async Task<ActionResult<Pilkarz>> DajArchiwalnegoPilkarza([FromRoute] Guid IdKlubu, [FromRoute] Guid IdPilkarza)
        {
            try
            {
                var result = await this.klubService.DajArchiwalnegoPilkarza(IdKlubu, IdPilkarza);
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
        [Route("api/[controller]/DajArchiwalnychPilkarzy/{IdKlubu}")]
        public async Task<ActionResult<IEnumerable<Pilkarz>>> DajArchiwalnychPilkarzy([FromRoute] Guid IdKlubu)
        {
            try
            {
                var result = await this.klubService.DajArchiwalnychPilkarzy(IdKlubu);
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
        [Route("api/[controller]/DajObecnegoPilkarza/{IdKlubu}, {IdPilkarza}")]
        public async Task<ActionResult<Pilkarz>> DajObecnegoPilkarza([FromRoute] Guid IdKlubu, [FromRoute] Guid IdPilkarza)
        {
            try
            {
                var result = await this.klubService.DajObecnegoPilkarza(IdKlubu, IdPilkarza);
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
        [Route("api/[controller]/DajObecnychPilkarzy/{IdKlubu}")]
        public async Task<ActionResult<IEnumerable<Pilkarz>>> DajObecnychPilkarzy([FromRoute] Guid IdKlubu)
        {
            try
            {
                var result = await this.klubService.DajObecnychPilkarzy(IdKlubu);
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
        [Route("api/[controller]/DodajPilkarzaDoObecnych/{IdPilkarza}, {IdKlubu}")]
        public async Task<ActionResult> DodajPilkarzaDoObecnych([FromRoute] Guid IdPilkarza, [FromRoute] Guid IdKlubu)
        {
            try
            {
                if (IdPilkarza.Equals(null) || IdKlubu.Equals(null))
                {
                    throw new Exception("");
                }
                await this.klubService.DodajPilkarzaDoObecnych(IdPilkarza, IdKlubu);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/[controller]/UsunPilkarzaZObecnych/{IdPilkarza}, {IdKlubu}")]
        public async Task<ActionResult> UsunPilkarzaZObecnych([FromRoute] Guid IdPilkarza, [FromRoute] Guid IdKlubu)
        {
            try
            {
                if (IdPilkarza.Equals(null) || IdKlubu.Equals(null))
                {
                    throw new Exception("");
                }
                await this.klubService.UsunPilkarzaZObecnych(IdPilkarza, IdKlubu);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/[controller]/DajTrofeaKlubu/{IdKlubu}")]
        public async Task<ActionResult<string>> DajTrofeaKlubu([FromRoute] Guid IdKlubu)
        {
            try
            {
                var result = await this.klubService.DajTrofeaKlubu(IdKlubu);
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
        [Route("api/[controller]/DajStadionKlubu/{IdKlubu}")]
        public async Task<ActionResult<string>> DajStadionKlubu([FromRoute] Guid IdKlubu)
        {
            try
            {
                var result = await this.klubService.DajStadionKlubu(IdKlubu);
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
    }
}
