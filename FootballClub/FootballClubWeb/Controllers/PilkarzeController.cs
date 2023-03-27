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
    public class PilkarzeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PilkarzeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pilkarze
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pilkarze.Include(p => p.Klub);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pilkarze/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Pilkarze == null)
            {
                return NotFound();
            }

            var pilkarz = await _context.Pilkarze
                .Include(p => p.Klub)
                .FirstOrDefaultAsync(m => m.IdPilkarz == id);
            if (pilkarz == null)
            {
                return NotFound();
            }

            return View(pilkarz);
        }

        // GET: Pilkarze/Create
        public IActionResult Create()
        {
            ViewData["IdKlubu"] = new SelectList(_context.Kluby, "IdKlub", "IdKlub");
            return View();
        }

        // POST: Pilkarze/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPilkarz,Pozycja,Wynagrodzenie,IdKlubu")] Pilkarz pilkarz)
        {
            if (ModelState.IsValid)
            {
                pilkarz.IdPilkarz = Guid.NewGuid();
                _context.Add(pilkarz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlubu"] = new SelectList(_context.Kluby, "IdKlub", "IdKlub", pilkarz.IdKlubu);
            return View(pilkarz);
        }

        // GET: Pilkarze/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Pilkarze == null)
            {
                return NotFound();
            }

            var pilkarz = await _context.Pilkarze.FindAsync(id);
            if (pilkarz == null)
            {
                return NotFound();
            }
            ViewData["IdKlubu"] = new SelectList(_context.Kluby, "IdKlub", "IdKlub", pilkarz.IdKlubu);
            return View(pilkarz);
        }

        // POST: Pilkarze/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdPilkarz,Pozycja,Wynagrodzenie,IdKlubu")] Pilkarz pilkarz)
        {
            if (id != pilkarz.IdPilkarz)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pilkarz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PilkarzExists(pilkarz.IdPilkarz))
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
            ViewData["IdKlubu"] = new SelectList(_context.Kluby, "IdKlub", "IdKlub", pilkarz.IdKlubu);
            return View(pilkarz);
        }

        // GET: Pilkarze/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Pilkarze == null)
            {
                return NotFound();
            }

            var pilkarz = await _context.Pilkarze
                .Include(p => p.Klub)
                .FirstOrDefaultAsync(m => m.IdPilkarz == id);
            if (pilkarz == null)
            {
                return NotFound();
            }

            return View(pilkarz);
        }

        // POST: Pilkarze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Pilkarze == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pilkarze'  is null.");
            }
            var pilkarz = await _context.Pilkarze.FindAsync(id);
            if (pilkarz != null)
            {
                _context.Pilkarze.Remove(pilkarz);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PilkarzExists(Guid id)
        {
          return (_context.Pilkarze?.Any(e => e.IdPilkarz == id)).GetValueOrDefault();
        }
    }
}
