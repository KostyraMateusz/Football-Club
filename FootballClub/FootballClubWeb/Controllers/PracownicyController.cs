using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballClubLibrary.Data;
using FootballClubLibrary.Models;

namespace FootballClubWeb.Controllers
{
    public class PracownicyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PracownicyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pracownicy
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pracownicy.Include(p => p.Zarzad);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pracownicy/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Pracownicy == null)
            {
                return NotFound();
            }

            var pracownik = await _context.Pracownicy
                .Include(p => p.Zarzad)
                .FirstOrDefaultAsync(m => m.IdPracownik == id);
            if (pracownik == null)
            {
                return NotFound();
            }

            return View(pracownik);
        }

        // GET: Pracownicy/Create
        public IActionResult Create()
        {
            ViewData["IdZarzadu"] = new SelectList(_context.Zarzady, "IdZarzad", "IdZarzad");
            return View();
        }

        // POST: Pracownicy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPracownik,Imie,Nazwisko,PESEL,Wiek,WykonywanaFunkcja,IdZarzadu,Wynagrodzenie")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                pracownik.IdPracownik = Guid.NewGuid();
                _context.Add(pracownik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdZarzadu"] = new SelectList(_context.Zarzady, "IdZarzad", "IdZarzad", pracownik.IdZarzadu);
            return View(pracownik);
        }

        // GET: Pracownicy/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Pracownicy == null)
            {
                return NotFound();
            }

            var pracownik = await _context.Pracownicy.FindAsync(id);
            if (pracownik == null)
            {
                return NotFound();
            }
            ViewData["IdZarzadu"] = new SelectList(_context.Zarzady, "IdZarzad", "IdZarzad", pracownik.IdZarzadu);
            return View(pracownik);
        }

        // POST: Pracownicy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdPracownik,Imie,Nazwisko,PESEL,Wiek,WykonywanaFunkcja,IdZarzadu,Wynagrodzenie")] Pracownik pracownik)
        {
            if (id != pracownik.IdPracownik)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pracownik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracownikExists(pracownik.IdPracownik))
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
            ViewData["IdZarzadu"] = new SelectList(_context.Zarzady, "IdZarzad", "IdZarzad", pracownik.IdZarzadu);
            return View(pracownik);
        }

        // GET: Pracownicy/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Pracownicy == null)
            {
                return NotFound();
            }

            var pracownik = await _context.Pracownicy
                .Include(p => p.Zarzad)
                .FirstOrDefaultAsync(m => m.IdPracownik == id);
            if (pracownik == null)
            {
                return NotFound();
            }

            return View(pracownik);
        }

        // POST: Pracownicy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Pracownicy == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pracownicy'  is null.");
            }
            var pracownik = await _context.Pracownicy.FindAsync(id);
            if (pracownik != null)
            {
                _context.Pracownicy.Remove(pracownik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PracownikExists(Guid id)
        {
          return (_context.Pracownicy?.Any(e => e.IdPracownik == id)).GetValueOrDefault();
        }
    }
}
