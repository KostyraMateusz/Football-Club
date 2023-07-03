using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballClubPresentationLayer.ControllersMVC
{
    public class ZarzadyControllerMVC : Controller
    {
        private readonly IZarzadService zarzadService;
        private readonly IKlubService klubService;
        private readonly IPracownikService pracownikService;

        public ZarzadyControllerMVC(IZarzadService zarzadService, IKlubService klubService, IPracownikService pracownikService)
        {
            this.zarzadService = zarzadService;
            this.klubService = klubService;
            this.pracownikService = pracownikService;
        }


        public IActionResult Index()
        {
            var zarzady = this.zarzadService.DajZarzady().Result.ToList();
            ViewBag.Zarzad = zarzady;
            return View(zarzady);
        }


        //Do poprawy
        public async Task<IActionResult> Details(Guid? id)
        {
            var zarzady = await zarzadService.DajZarzady();
            if (id == Guid.Empty && zarzady == null)
            {
                return NotFound();
            }
            else
            {
                var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);
                var pracownicy = pracownikService.DajPracownikow().Result.ToList();
                ViewBag.Pracownicy = pracownicy.Where(p => p.IdZarzadu == zarzad.IdZarzad);
                if (zarzad == null)
                {
                    return NotFound();
                }

                return View(zarzad);
            }
        }


        public IActionResult Create()
        {
            ViewData["IdKlubu"] = new SelectList(klubService.DajKluby().Result.ToList(), "IdKlub", "Nazwa");
            ViewBag.Pracownicy = pracownikService.DajPracownikow().Result.ToList();

            return View();
        }

        //Do poprawy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKlubu, Pracownicy, Budzet, Cele")] Zarzad zarzad)
        {
            if (ModelState.IsValid)
            {
                zarzad.IdZarzad = Guid.NewGuid();
                zarzadService.DodajZarzad(zarzad);
                return RedirectToAction(nameof(Index));
            }
            return View(zarzad);
        }


        public async Task<IActionResult> Edit(Guid? id)
        {
            var zarzady = await zarzadService.DajZarzady();
            if (id == Guid.Empty && zarzady == null)
            {
                return NotFound();
            }
            else
            {
                var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);
                ViewData["IdKlubu"] = new SelectList(klubService.DajKluby().Result.ToList(), "IdKlub", "Nazwa");
                var pracownicy = pracownikService.DajPracownikow().Result.ToList();
                ViewBag.PracownicyZarzadu = pracownicy.Where(p => p.IdZarzadu == zarzad.IdZarzad);
                ViewBag.PracownicyInni = pracownicy.Where(p => p.IdZarzadu != zarzad.IdZarzad && p.IdZarzadu == null);
                if (zarzad == null)
                {
                    return NotFound();
                }

                return View(zarzad);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdZarzad,IdKlubu,Budzet,Cele")] Zarzad zarzad)
        {
            if (id != zarzad.IdZarzad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                zarzadService.EdytujZarzad(zarzad);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdKlubu"] = new SelectList(_context.Kluby, "IdKlub", "Trofea", zarzad.IdKlubu);
            return View(zarzad);
        }


        public async Task<IActionResult> Delete(Guid? id)
        {
            var zarzady = await zarzadService.DajZarzady();
            if (id == Guid.Empty && zarzady == null)
            {
                return NotFound();
            }
            var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);
            if (zarzad == null)
            {
                return NotFound();
            }

            return View(zarzad);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var zarzady = await zarzadService.DajZarzady();
            if (zarzady == null)
            {
                return Problem("Entity set 'DbFootballClub.Zarzad' is null");
            }

            var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);
            if (zarzad != null)
            {
                zarzadService.UsunZarzad(zarzad.IdZarzad);
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ZmienBudzetZarzadu(Guid? id)
        {
            var zarzady = await zarzadService.DajZarzady();
            if (id == Guid.Empty && zarzady == null)
            {
                return NotFound();
            }
            var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);
            if (zarzad == null)
            {
                return NotFound();
            }

            return View(zarzad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ZmienBudzetZarzadu(Guid id, [Bind("Budzet")] decimal budzet)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var zarzady = await zarzadService.DajZarzady();
            var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);

            if (zarzad == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await zarzadService.ZmienBudzetZarzadu(zarzad.IdZarzad, budzet);
                return RedirectToAction(nameof(Index));
            }

            return View(zarzad);
        }


        public async Task<IActionResult> DodajCelZarzadu(Guid? id)
        {
            var zarzady = await zarzadService.DajZarzady();
            if (id == Guid.Empty && zarzady == null)
            {
                return NotFound();
            }
            var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);
            if (zarzad == null)
            {
                return NotFound();
            }

            return View(zarzad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DodajCelZarzadu(Guid id, [Bind("cele")] string cele)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var zarzady = await zarzadService.DajZarzady();
            var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);

            if (zarzad == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await zarzadService.DodajCelZarzadu(zarzad.IdZarzad, cele);
                return RedirectToAction(nameof(Index));
            }

            return View(zarzad);
        }


        public async Task<IActionResult> DodajCzlonkaZarzadu(Guid? id)
        {
            var zarzady = await zarzadService.DajZarzady();
            if (id == Guid.Empty && zarzady == null)
            {
                return NotFound();
            }
            var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);
            var pracownicy = pracownikService.DajPracownikow().Result.ToList();
            ViewBag.Pracownicy = pracownicy.Where(p => p.IdZarzadu != zarzad.IdZarzad).ToList();
            if (zarzad == null)
            {
                return NotFound();
            }

            return View(zarzad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DodajCzlonkaZarzadu(Guid id, string wybranypracownik)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            
            var zarzady = await zarzadService.DajZarzady();
            var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);

            Pracownik pracownik = await pracownikService.DajPracownika(Guid.Parse(wybranypracownik));

            if (zarzad == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await zarzadService.DodajCzlonkaZarzadu(zarzad.IdZarzad, pracownik.IdPracownik);
                return RedirectToAction(nameof(Index));
            }

            return View(zarzad);
        }
    }
}
