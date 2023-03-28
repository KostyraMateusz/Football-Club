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
    public class KlubyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KlubyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kluby
        public async Task<IActionResult> Index()
        {
            var kluby = await _context.Kluby.ToListAsync();
            return View(kluby);
        }

        // GET: Kluby/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Kluby == null)
            {
                return NotFound();
            }

            var klub = await _context.Kluby
                .FirstOrDefaultAsync(m => m.IdKlub == id);
            if (klub == null)
            {
                return NotFound();
            }

            return View(klub);
        }

        // GET: Kluby/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kluby/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKlub,Nazwa,Stadion,Trofea")] Klub klub)
        {
            if (ModelState.IsValid)
            {
                klub.IdKlub = Guid.NewGuid();
                _context.Add(klub);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klub);
        }

        // GET: Kluby/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Kluby == null)
            {
                return NotFound();
            }

            var klub = await _context.Kluby.FindAsync(id);
            if (klub == null)
            {
                return NotFound();
            }
            return View(klub);
        }

        // POST: Kluby/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdKlub,Nazwa,Stadion,Trofea")] Klub klub)
        {
            if (id != klub.IdKlub)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klub);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlubExists(klub.IdKlub))
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
            return View(klub);
        }

        // GET: Kluby/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Kluby == null)
            {
                return NotFound();
            }

            var klub = await _context.Kluby
                .FirstOrDefaultAsync(m => m.IdKlub == id);
            if (klub == null)
            {
                return NotFound();
            }

            return View(klub);
        }

        // POST: Kluby/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Kluby == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Kluby'  is null.");
            }
            var klub = await _context.Kluby.FindAsync(id);
            if (klub != null)
            {
                _context.Kluby.Remove(klub);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlubExists(Guid id)
        {
          return (_context.Kluby?.Any(e => e.IdKlub == id)).GetValueOrDefault();
        }
    }
}
