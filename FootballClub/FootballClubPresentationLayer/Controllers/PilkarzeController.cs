using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FootballClubPresentationLayer.Controllers
{
    [ApiController]
    public class PilkarzeController : ControllerBase
    {
        private readonly IPilkarzService pilkarzService;

        public PilkarzeController(IPilkarzService pilkarzService)
        {
            this.pilkarzService = pilkarzService;
        }

        [HttpPost]
        [Route("api/Pilkarze/DodajPracownika")]
        public async Task<ActionResult> UtworzPilkarz([FromBody] Pilkarz pilkarz)
        {
            try
            {
                if (pilkarz == null)
                {
                    throw new Exception("");
                }
                await this.pilkarzService.DodajPilkarza(pilkarz);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/Pilkarze/UsunPilkarza/{IdPilkarza}")]
        public async Task<ActionResult> UsunPracownika([FromRoute] Guid IdPilkarza)
        {
            try
            {
                var pilkarze = await this.pilkarzService.DajPilkarzy();
                var pracownik = pilkarze.First(k => k.IdPilkarz == IdPilkarza);
                if (pracownik == null)
                {
                    throw new Exception("");
                }
                await this.pilkarzService.UsunPilkarza(IdPilkarza);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/Pilkarze/EdytujPilkarza/{id}")]
        public async Task<ActionResult> EdytujPracownika([FromBody] Pilkarz pilkarz)
        {
            try
            {
                if (pilkarz == null)
                {
                    throw new Exception("");
                }
                await this.pilkarzService.EdytujPilkarza(pilkarz);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/[controller]/DajPilkarzy")]
        public async Task<ActionResult<IEnumerable<Pilkarz>>> DajPilkarzy()
        {
            try
            {
                var result = await this.pilkarzService.DajPilkarzy();
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
        [Route("api/[controller]/DajArchiwalneKlubyPilkarza/{IdPilkarza}")]
        public async Task<ActionResult<IEnumerable<Klub>>> DajArchiwalneKlubyPilkarza([FromRoute] Guid IdPilkarza)
        {
            try
            {
                var pilkarze = await this.pilkarzService.DajPilkarzy();
                var pilkarz = pilkarze.First(p => p.IdPilkarz == IdPilkarza);
                var result = await this.pilkarzService.DajArchiwalneKlubyPilkarza(pilkarz);
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
        [Route("api/[controller]/DajStatystykePilkarza/{IdStatystyka}, {IdPilkarza}")]
        public async Task<ActionResult<Statystyka>> DajStatystykePilkarza([FromRoute] Guid IdStatystyka, [FromRoute] Guid IdPilkarza)
        {
            try
            {
                var pilkarze = await this.pilkarzService.DajPilkarzy();
                var pilkarz = pilkarze.First(p => p.IdPilkarz == IdPilkarza);
                var result = await this.pilkarzService.DajStatystykePilkarza(pilkarz, IdStatystyka);
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
        [Route("api/[controller]/DajStatystykiPilkarza/{IdPilkarza}")]
        public async Task<ActionResult<IEnumerable<Statystyka>>> DajStatystykiPilkarza([FromRoute] Guid IdPilkarza)
        {
            try
            {
                var pilkarze = await this.pilkarzService.DajPilkarzy();
                var pilkarz = pilkarze.First(p => p.IdPilkarz == IdPilkarza);
                var result = await this.pilkarzService.DajStatystykiPilkarza(pilkarz);
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
        [Route("api/[controller]/DajNajlepszeStatystykiPilkarza/{IdPilkarza}")]
        public async Task<ActionResult<IEnumerable<Statystyka>>> DajNajlepszeStatystykiPilkarza([FromRoute] Guid IdPilkarza)
        {
            try
            {
                var pilkarze = await this.pilkarzService.DajPilkarzy();
                var pilkarz = pilkarze.First(p => p.IdPilkarz == IdPilkarza);
                var result = await this.pilkarzService.DajNajlepszeStatystykiPilkarza(pilkarz);
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
        [Route("api/[controller]/DajPilkarzyBezKlubu")]
        public async Task<ActionResult<IEnumerable<Pilkarz>>> DajPilkarzyBezKlubu()
        {
            try
            {
                var result = await this.pilkarzService.DajPilkarzyBezKlubu();
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

        [HttpPut]
        [Route("api/[controller]/ZmienPozycjePilkarza")]
        public async Task<ActionResult> ZmienPozycjePilkarza([FromRoute] Guid IdPilkarza, string pozycja)
        {
            try
            {
                var pilkarze = await this.pilkarzService.DajPilkarzy();
                var pilkarz = pilkarze.First(p => p.IdPilkarz == IdPilkarza);
                if (IdPilkarza.Equals(null) || pozycja.Equals(null))
                {
                    throw new Exception();
                }
                await this.pilkarzService.ZmienPozycjePilkarza(pilkarz, pozycja);
                return Ok("Index");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
