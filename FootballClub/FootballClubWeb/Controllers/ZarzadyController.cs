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
    public class ZarzadyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZarzadyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zarzady
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Zarzady.Include(z => z.Klub);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Zarzady/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Zarzady == null)
            {
                return NotFound();
            }

            var zarzad = await _context.Zarzady
                .Include(z => z.Klub)
                .FirstOrDefaultAsync(m => m.IdZarzad == id);
            if (zarzad == null)
            {
                return NotFound();
            }

            return View(zarzad);
        }

        // GET: Zarzady/Create
        public IActionResult Create()
        {
            ViewData["IdKlubu"] = new SelectList(_context.Kluby, "IdKlub", "IdKlub");
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
                _context.Add(zarzad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlubu"] = new SelectList(_context.Kluby, "IdKlub", "IdKlub", zarzad.IdKlubu);
            return View(zarzad);
        }

        // GET: Zarzady/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Zarzady == null)
            {
                return NotFound();
            }

            var zarzad = await _context.Zarzady.FindAsync(id);
            if (zarzad == null)
            {
                return NotFound();
            }
            ViewData["IdKlubu"] = new SelectList(_context.Kluby, "IdKlub", "IdKlub", zarzad.IdKlubu);
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
                    _context.Update(zarzad);
                    await _context.SaveChangesAsync();
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
            ViewData["IdKlubu"] = new SelectList(_context.Kluby, "IdKlub", "IdKlub", zarzad.IdKlubu);
            return View(zarzad);
        }

        // GET: Zarzady/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Zarzady == null)
            {
                return NotFound();
            }

            var zarzad = await _context.Zarzady
                .Include(z => z.Klub)
                .FirstOrDefaultAsync(m => m.IdZarzad == id);
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
            if (_context.Zarzady == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Zarzady'  is null.");
            }
            var zarzad = await _context.Zarzady.FindAsync(id);
            if (zarzad != null)
            {
                _context.Zarzady.Remove(zarzad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZarzadExists(Guid id)
        {
          return (_context.Zarzady?.Any(e => e.IdZarzad == id)).GetValueOrDefault();
        }
    }
}
