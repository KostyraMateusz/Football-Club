using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.Controllers
{
    [Route("/api/statystyka")]
    public class StatystykiController : Controller
    {
        private readonly IStatystykaService statystykaService;

        public StatystykiController(IStatystykaService statystykaService)
        {
            this.statystykaService = statystykaService;
        }


        [HttpGet("/DajStatystykeMeczu")]
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
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpGet("/DajStatystkiZoltejKartki")]
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
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpGet("/DajStatystykiCzerwonychKartek")]
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
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpGet("/DajStatystykeNajdluzszePrzebiegnieteDystanse")]
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
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
