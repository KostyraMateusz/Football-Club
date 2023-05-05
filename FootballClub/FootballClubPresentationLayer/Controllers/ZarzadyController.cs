﻿using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace FootballClubPresentationLayer.Controllers
{
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
            return Ok(zarzady);
        }

        [HttpGet]
        [Route("api/[controller]/DajWynikFinansowy/{IdZarzadu}")]
        public async Task<ActionResult<decimal>> DajWynikFinansowy([FromRoute] Guid IdZarzadu)
        {
            try
            {
                var result = await this._zarzadService.DajWynikFinansowyZarzadu(IdZarzadu);
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

        [HttpPost]
        [Route("api/[controller]/DodajCelZarzadu")]
        public async Task<ActionResult> DodajCelZarzadu([FromRoute] Guid IdZarzadu, string cel)
        {
            try
            {
                if (IdZarzadu.Equals(null) || cel.Equals(null) || cel.Equals(""))
                {
                    throw new Exception("Pusty cel");
                }
                await this._zarzadService.DodajCelZarzadu(IdZarzadu, cel);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/[controller]/DodajCzlonkaZarzadu")]
        public async Task<ActionResult> DodajCzlonkaZarzadu([FromRoute] Guid IdZarzadu, [FromRoute] Guid IdPracownik)
        {
            try
            {
                if (IdZarzadu.Equals(null) || IdPracownik.Equals(null))
                {
                    throw new Exception();
                }
                await this._zarzadService.DodajCzlonkaZarzadu(IdZarzadu, IdPracownik);
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
                await this._zarzadService.ZmienBudzetZarzadu(IdZarzadu, budzet);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
