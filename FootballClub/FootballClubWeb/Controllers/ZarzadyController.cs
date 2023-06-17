using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballClubLibrary.Models;
using FootballClubLibrary.UnitOfWork;

namespace FootballClubWeb.Controllers
{
    public class ZarzadyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ZarzadyController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Zarzady
        public async Task<IActionResult> Index()
        {
            var zarzady = await this.unitOfWork.ZarzadRepository.GetZarzady();
            return View(zarzady);
        }

        // GET: Zarzady/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null || this.unitOfWork.ZarzadRepository == null)
            {
                return NotFound();
            }

            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(id);
            if (zarzad == null)
            {
                return NotFound();
            }

            return View(zarzad);
        }

        // GET: Zarzady/Create
        public IActionResult Create()
        {
            ViewData["IdKlubu"] = new SelectList(this.unitOfWork.KlubRepository.GetDbSetKluby(), "IdKlub", "IdKlub");
            return View();
        }

        // POST: Zarzady/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZarzad,Budzet,Cele,IdKlubu")] Zarzad zarzad)
        {
            if (ModelState.IsValid)
            {
                zarzad.IdZarzad = Guid.NewGuid();
                await this.unitOfWork.ZarzadRepository.CreateZarzad(zarzad);
                await this.unitOfWork.ZarzadRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlubu"] = new SelectList(this.unitOfWork.KlubRepository.GetDbSetKluby(), "IdKlub", "IdKlub", zarzad.IdKlubu);
            return View(zarzad);
        }

        // GET: Zarzady/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null || this.unitOfWork.ZarzadRepository == null)
            {
                return NotFound();
            }

            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(id);
            if (zarzad == null)
            {
                return NotFound();
            }
            ViewData["IdKlubu"] = new SelectList(this.unitOfWork.KlubRepository.GetDbSetKluby(), "IdKlub", "IdKlub", zarzad.IdKlubu);
            return View(zarzad);
        }

        // POST: Zarzady/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdZarzad,Budzet,Cele,IdKlubu")] Zarzad zarzad)
        {
            if (id != zarzad.IdZarzad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.unitOfWork.ZarzadRepository.UpdateZarzad(zarzad);
                    await this.unitOfWork.ZarzadRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZarzadExists(zarzad.IdZarzad))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlubu"] = new SelectList(this.unitOfWork.KlubRepository.GetDbSetKluby(), "IdKlub", "IdKlub", zarzad.IdKlubu);
            return View(zarzad);
        }

        // GET: Zarzady/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || this.unitOfWork.ZarzadRepository == null)
            {
                return NotFound();
            }

            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(id);
            if (zarzad == null)
            {
                return NotFound();
            }

            return View(zarzad);
        }

        // POST: Zarzady/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (this.unitOfWork.ZarzadRepository == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Zarzady'  is null.");
            }
            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(id);
            if (zarzad != null)
            {
                await this.unitOfWork.ZarzadRepository.DeleteZarzad(id);
            }
            
            await this.unitOfWork.ZarzadRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ZarzadExists(Guid id)
        {
          return this.unitOfWork.ZarzadRepository.GetZarzadById(id) != null ? true : false;
        }
    }
}
