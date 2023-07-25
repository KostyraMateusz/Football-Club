using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.Controllers
{
    [ApiController]
    public class StatystykiController : ControllerBase
    {
        private readonly IStatystykaService statystykaService;

        public StatystykiController(IStatystykaService statystykaService)
        {
            this.statystykaService = statystykaService;
        }

        [HttpPost]
        [Route("api/Statystyki/DodajStatystke")]
        public async Task<ActionResult> UtworzStatystyka([FromBody] Statystyka statystyka)
        {
            try
            {
                if (statystyka == null)
                {
                    throw new Exception("");
                }
                if (statystyka.ZolteKartki == 2 && statystyka.CzerwoneKartki == 0)
                {
                    statystyka.CzerwoneKartki = 1;
                }
                await this.statystykaService.DodajStatystyke(statystyka);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/Statystyki/UsunStatystyke/{IdStatystyka}")]
        public async Task<ActionResult> UsunStatystyke([FromRoute] Guid IdStatystyka)
        {
            try
            {
                var statystyki = await this.statystykaService.DajStatystyki();
                var statystyka = statystyki.First(s => s.IdStatystyka == IdStatystyka);
                if (statystyka == null)
                {
                    throw new Exception("");
                }
                await this.statystykaService.UsunStatystyke(IdStatystyka);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/Statystyki/EdytujStatystyke/{id}")]
        public async Task<ActionResult> EdytujStatystyke([FromBody] Statystyka statystyka)
        {
            try
            {
                if (statystyka == null)
                {
                    throw new Exception("");
                }
                await this.statystykaService.EdytujStatystyke(statystyka);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/[controller]/DajStatystyke/{IdStatystyki}")]
        public async Task<ActionResult<IEnumerable<Statystyka>>> DajStatystyki([FromRoute] Guid IdStatystyki)
        {
            try
            {
                var result = await this.statystykaService.DajStatystyki();
                var statystyka = result.First(s => s.IdStatystyka == IdStatystyki);
                if (statystyka == null)
                {
                    throw new Exception("");
                }
                return Ok(statystyka);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/[controller]/DajStatystyki")]
        public async Task<ActionResult<IEnumerable<Statystyka>>> DajStatystyki()
        {
            try
            {
                var result = await this.statystykaService.DajStatystyki();
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
        [Route("api/[controller]/DajStatystykeMeczu/{mecz}")]
        public async Task<ActionResult<Statystyka>> DajStatystykeMeczu(string mecz)
        {
            try
            {
                var result = await this.statystykaService.DajStatystykeMeczu(mecz);
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
        [Route("api/[controller]/DajStatystkiZoltejKartki")]
        public async Task<ActionResult<IEnumerable<Statystyka>>> DajStatystkiZoltejKartki()
        {
            try
            {
                var result = await this.statystykaService.DajStatystkiZoltejKartki();
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
        [Route("api/[controller]/DajStatystykiCzerwonychKartek")]
        public async Task<ActionResult<IEnumerable<Statystyka>>> DajStatystykiCzerwonychKartek()
        {
            try
            {
                var result = await this.statystykaService.DajStatystykiCzerwonychKartek();
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
        [Route("api/[controller]/DajStatystykiNajlepszaOcena")]
        public async Task<ActionResult<IEnumerable<Statystyka>>> DajStatystykiNajlepszaOcena()
        {
            try
            {
                var result = await this.statystykaService.DajStatystykeNajlepszaOcena();
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
