using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.AspNetCore.Mvc;

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

        private async Task<IEnumerable<Pracownik>> DajPracownikow()
        {
            var pracownicy = await this.pracownikService.DajPracownikow();
            if (pracownicy == null)
            {
                return new List<Pracownik>();
            }
            return pracownicy;
        }

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
                if (zarzad == null)
                {
                    return NotFound();
                }

                return View(zarzad);
            }
        }

        public IActionResult Create()
        {
            ViewBag.Zarzady = zarzadService.DajZarzady().Result.ToList();
            ViewBag.Pracownicy = pracownikService.DajPracownikow().Result.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid id, Guid[] wybraniPracownicy, [Bind("Budzet")] decimal budzet, [Bind("cele")] string cele)
        {
            if (ModelState.IsValid)
            {
                var listapracownikow = new List<Pracownik>();

                for (int i = 0; i < wybraniPracownicy.Count(); i++)
                {
                    Pracownik pracownik = await pracownikService.DajPracownika(wybraniPracownicy[i]);
                    listapracownikow.Add(pracownik);
                }

                Zarzad nowyZarzad = new Zarzad()
                {
                    IdZarzad = Guid.NewGuid(),
                    Pracownicy = listapracownikow,
                    Budzet = budzet,
                    Cele = cele,
                    IdKlubu = id,
                };

                await this.zarzadService.DodajZarzad(nowyZarzad);
                return RedirectToAction(nameof(Details), new { id = nowyZarzad.IdZarzad });
            }
            return View();
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            var zarzady = await zarzadService.DajZarzady();
            if (id == Guid.Empty && zarzady == null)
            {
                return NotFound();
            }
            var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);
            var pracownicy = pracownikService.DajPracownikow().Result.ToList();
            ViewBag.PracownicyZarzadu = pracownicy.Where(p => p.IdZarzadu == zarzad.IdZarzad).ToList();
            ViewBag.Pracownicy = pracownicy.Where(p => p.IdZarzadu != zarzad.IdZarzad).ToList();
            if (zarzad == null)
            {
                return NotFound();
            }

            return View(zarzad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, string[] wybraniPracownicy, [Bind("Budzet")] decimal budzet, [Bind("cele")] string cele)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var zarzad = zarzadService.DajZarzad(id).Result;

            if (ModelState.IsValid)
            {
                List<Pracownik> listaPracownikow = new List<Pracownik>();

                for (int i = 0; i < wybraniPracownicy.Count(); i++)
                {
                    Pracownik pracownik = await pracownikService.DajPracownika(Guid.Parse(wybraniPracownicy[i]));
                    listaPracownikow.Add(pracownik);
                }

                zarzad.Pracownicy = listaPracownikow;
                zarzad.Budzet = budzet;
                zarzad.Cele = cele;

                await this.zarzadService.EdytujZarzad(zarzad);
                return RedirectToAction(nameof(Details), new { id = zarzad.IdZarzad });
            }
            return View(zarzad);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            var zarzady = await zarzadService.DajZarzady();
            if (zarzady == null)
            {
                return Problem("Entity set 'DbFootballClub.Zarzad' is null");
            }

            var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);
            if (zarzad != null)
            {
                await this.zarzadService.UsunZarzad(zarzad.IdZarzad);
            }

            return RedirectToAction(nameof(Index));
        }

        //Modyfikacja budżetu zarządu
        public async Task<IActionResult> ZmienBudzetZarzadu()
        {
            var zarzady = await zarzadService.DajZarzady();
            ViewBag.Zarzady = zarzady.ToList();

            if (zarzady == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DajBudzetZarzadu(Guid id)
        {
            var zarzad = zarzadService.DajZarzad(id).Result;

            if (zarzad != null)
            {
                return Json(zarzad.Budzet);
            }

            return Json("");
        }

        public async Task<IActionResult> ZmienBudzetZarzaduID(Guid? id)
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
        public async Task<IActionResult> ZmienBudzetZarzaduID(Guid id, [Bind("Budzet")] decimal budzet)
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
                return RedirectToAction(nameof(Details), new { id = zarzad.IdZarzad });
            }

            return View(zarzad);
        }


        //Modyfikacja celów do wykonania przez zarząd
        public async Task<IActionResult> DodajCelZarzadu()
        {
            var zarzady = await zarzadService.DajZarzady();
            ViewBag.Zarzady = zarzady.ToList();

            if (zarzady == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DajCeleZarzadu(Guid id)
        {
            var zarzad = zarzadService.DajZarzad(id).Result;

            if (zarzad != null)
            {
                return Json(zarzad.Cele);
            }

            return Json("");
        }

        public async Task<IActionResult> DodajCelZarzaduID(Guid? id)
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
        public async Task<IActionResult> DodajCelZarzaduID(Guid id, [Bind("cele")] string cele)
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
                return RedirectToAction(nameof(Details), new { id = zarzad.IdZarzad });
            }

            return View(zarzad);
        }


        //Dodanie pracowników do zarządu
        public async Task<IActionResult> DodajCzlonkaZarzadu()
        {
            var zarzady = await zarzadService.DajZarzady();
            ViewBag.Zarzady = zarzady.ToList();

            if (zarzady == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DajMozliwychPracownikow(Guid id)
        {
            var zarzady = await zarzadService.DajZarzady();
            var zarzad = zarzady.SingleOrDefault(m => m.IdZarzad == id);
            var pracownicy = (await pracownikService.DajPracownikow()).ToList();
            var mozliwiPracownicy = pracownicy.Where(p => p.IdZarzadu != zarzad.IdZarzad).ToList();

            if (mozliwiPracownicy != null)
            {
                return Json(mozliwiPracownicy);
            }

            return Json("");
        }

        public async Task<IActionResult> DodajCzlonkaZarzaduID(Guid? id)
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
        public async Task<IActionResult> DodajCzlonkaZarzaduID(Guid id, string wybranypracownik)
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
                return RedirectToAction(nameof(Details), new { id = zarzad.IdZarzad });
            }

            return View(zarzad);
        }


        //Usunięcie pracowników z zarządu
        public async Task<IActionResult> UsunCzlonkaZarzadu()
        {
            var zarzady = await zarzadService.DajZarzady();
            ViewBag.Zarzady = zarzady.ToList();

            if (zarzady == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DajPracownikowZarzadu(Guid id)
        {
            var zarzady = await zarzadService.DajZarzady();
            var zarzad = zarzady.SingleOrDefault(m => m.IdZarzad == id);
            var pracownicy = (await pracownikService.DajPracownikow()).ToList();
            var mozliwiPracownicy = pracownicy.Where(p => p.IdZarzadu == zarzad.IdZarzad).ToList();

            if (mozliwiPracownicy != null)
            {
                return Json(mozliwiPracownicy);
            }

            return Json("");
        }

        public async Task<IActionResult> UsunCzlonkaZarzaduID(Guid? id)
        {
            var zarzady = await zarzadService.DajZarzady();
            if (id == Guid.Empty && zarzady == null)
            {
                return NotFound();
            }
            var zarzad = zarzady.FirstOrDefault(m => m.IdZarzad == id);
            var pracownicy = pracownikService.DajPracownikow().Result.ToList();
            ViewBag.Pracownicy = pracownicy.Where(p => p.IdZarzadu == zarzad.IdZarzad).ToList();
            if (zarzad == null)
            {
                return NotFound();
            }

            return View(zarzad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UsunCzlonkaZarzaduID(Guid id, string wybranypracownik)
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
                await zarzadService.UsunCzlonkaZarzadu(zarzad.IdZarzad, pracownik.IdPracownik);
                return RedirectToAction(nameof(Details), new { id = zarzad.IdZarzad });
            }

            return View(zarzad);
        }
    }
}