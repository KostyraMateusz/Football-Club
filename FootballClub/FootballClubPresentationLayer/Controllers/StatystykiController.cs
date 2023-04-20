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
            return View(statystyki);
        }

        [HttpGet]
        [Route("api/[controller]/DajStatystykeMeczu/{mecz}")]
        public async Task<ActionResult> DajStatystykeMeczu(string mecz)
        {
            try
            {
                var result = await this.statystykaService.DajStatystykeMeczu(mecz);
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
        [Route("api/[controller]/DajStatystkiZoltejKartki")]
        public async Task<ActionResult> DajStatystkiZoltejKartki()
        {
            try
            {
                var result = await this.statystykaService.DajStatystkiZoltejKartki();
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
        [Route("api/[controller]/DajStatystykiCzerwonychKartek")]
        public async Task<ActionResult> DajStatystykiCzerwonychKartek()
        {
            try
            {
                var result = await this.statystykaService.DajStatystykiCzerwonychKartek();
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
        [Route("api/[controller]/DajStatystykeNajdluzszePrzebiegnieteDystanse")]
        public async Task<ActionResult> DajStatystykeNajdluzszePrzebiegnieteDystanse()
        {
            try
            {
                var result = await this.statystykaService.DajStatystykeNajdluzszePrzebiegnieteDystanse();
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
    }
}
