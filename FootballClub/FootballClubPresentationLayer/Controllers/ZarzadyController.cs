using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.Controllers
{
    public class ZarzadyController : Controller
    {
        private readonly IZarzadService zarzadService;

        public ZarzadyController(IZarzadService zarzadService)
        {
            this.zarzadService = zarzadService;
        }

        // GET: Zarzady
        public async Task<ActionResult> Index()
        {
            var zarzady = await this.zarzadService.DajZarzady();

            return View(zarzady);
        }

        // GET: Zarzady/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var zarzady = await zarzadService.DajZarzady();
                var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);
                if (zarzad == null)
                {
                    return NotFound();
                }

                return View(zarzad);
            }
        }

        // GET: Zarzady/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zarzady/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZarzad")] Zarzad zarzad)
        {
            if (ModelState.IsValid)
            {
                zarzadService.DodajZarzad(zarzad);
                return RedirectToAction(nameof(Index));
            }
            return View(zarzad);
        }

        [HttpGet]
        [Route("api/[controller]/DajZarzady")]
        public async Task<ActionResult<Zarzad>> DajZarzady()
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
