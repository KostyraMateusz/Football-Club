using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.Controllers
{
    public class StatystykiController : Controller
    {
        private readonly IStatystykaService statystykaService;

        public StatystykiController(IStatystykaService statystykaService)
        {
            this.statystykaService = statystykaService;
        }

        public async Task<ActionResult> Index()
        {
            var statystyki = await this.statystykaService.DajStatystyki();
            return Ok(statystyki);
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
        [Route("api/[controller]/DajStatystykeNajdluzszePrzebiegnieteDystanse")]
        public async Task<ActionResult<IEnumerable<Statystyka>>> DajStatystykiNajdluzszePrzebiegnieteDystanse()
        {
            try
            {
                var result = await this.statystykaService.DajStatystykeNajdluzszePrzebiegnieteDystanse();
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
