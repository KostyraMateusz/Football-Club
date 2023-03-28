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
    public class StatystykiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatystykiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Statystyki
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Statystyki.Include(s => s.Pilkarz);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Statystyki/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Statystyki == null)
            {
                return NotFound();
            }

            var statystyka = await _context.Statystyki
                .Include(s => s.Pilkarz)
                .FirstOrDefaultAsync(m => m.IdStatystyka == id);
            if (statystyka == null)
            {
                return NotFound();
            }

            return View(statystyka);
        }

        // GET: Statystyki/Create
        public IActionResult Create()
        {
            ViewData["IdPilkarz"] = new SelectList(_context.Pilkarze, "IdPilkarz", "IdPilkarz");
            return View();
        }

        // POST: Statystyki/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatystyka,Mecz,Gole,Asysty,ZolteKartki,CzerwoneKartki,PrzebiegnietyDystans,Ocena,IdPilkarz")] Statystyka statystyka)
        {
            if (ModelState.IsValid)
            {
                statystyka.IdStatystyka = Guid.NewGuid();
                _context.Add(statystyka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPilkarz"] = new SelectList(_context.Pilkarze, "IdPilkarz", "IdPilkarz", statystyka.IdPilkarz);
            return View(statystyka);
        }

        // GET: Statystyki/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Statystyki == null)
            {
                return NotFound();
            }

            var statystyka = await _context.Statystyki.FindAsync(id);
            if (statystyka == null)
            {
                return NotFound();
            }
            ViewData["IdPilkarz"] = new SelectList(_context.Pilkarze, "IdPilkarz", "IdPilkarz", statystyka.IdPilkarz);
            return View(statystyka);
        }

        // POST: Statystyki/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdStatystyka,Mecz,Gole,Asysty,ZolteKartki,CzerwoneKartki,PrzebiegnietyDystans,Ocena,IdPilkarz")] Statystyka statystyka)
        {
            if (id != statystyka.IdStatystyka)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statystyka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatystykaExists(statystyka.IdStatystyka))
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
            ViewData["IdPilkarz"] = new SelectList(_context.Pilkarze, "IdPilkarz", "IdPilkarz", statystyka.IdPilkarz);
            return View(statystyka);
        }

        // GET: Statystyki/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Statystyki == null)
            {
                return NotFound();
            }

            var statystyka = await _context.Statystyki
                .Include(s => s.Pilkarz)
                .FirstOrDefaultAsync(m => m.IdStatystyka == id);
            if (statystyka == null)
            {
                return NotFound();
            }

            return View(statystyka);
        }

        // POST: Statystyki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Statystyki == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Statystyki'  is null.");
            }
            var statystyka = await _context.Statystyki.FindAsync(id);
            if (statystyka != null)
            {
                _context.Statystyki.Remove(statystyka);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatystykaExists(Guid id)
        {
          return (_context.Statystyki?.Any(e => e.IdStatystyka == id)).GetValueOrDefault();
        }
    }
}
