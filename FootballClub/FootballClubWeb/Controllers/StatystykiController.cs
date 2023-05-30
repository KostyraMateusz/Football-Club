using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballClubLibrary.Data;
using FootballClubLibrary.Models;
using FootballClubLibrary.UnitOfWork;

namespace FootballClubWeb.Controllers
{
    public class StatystykiController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public StatystykiController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Statystyki
        public async Task<IActionResult> Index()
        {
            var statystyki = await this.unitOfWork.StatystykaRepository.GetStatystyki();
            return View(statystyki);
        }

        // GET: Statystyki/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null || this.unitOfWork.StatystykaRepository == null)
            {
                return NotFound();
            }

            var statystyka = await this.unitOfWork.StatystykaRepository.GetStatystykaById(id);
            if (statystyka == null)
            {
                return NotFound();
            }

            return View(statystyka);
        }

        // GET: Statystyki/Create
        public IActionResult Create()
        {
            ViewData["IdPilkarz"] = new SelectList(this.unitOfWork.PilkarzRepository.GetDbSetPilkarze(), "IdPilkarz", "IdPilkarz");
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
                await this.unitOfWork.StatystykaRepository.CreateStatystyka(statystyka);
                await this.unitOfWork.StatystykaRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPilkarz"] = new SelectList(this.unitOfWork.PilkarzRepository.GetDbSetPilkarze(), "IdPilkarz", "IdPilkarz", statystyka.IdPilkarz);
            return View(statystyka);
        }

        // GET: Statystyki/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null || this.unitOfWork.StatystykaRepository == null)
            {
                return NotFound();
            }

            var statystyka = await this.unitOfWork.StatystykaRepository.GetStatystykaById(id);
            if (statystyka == null)
            {
                return NotFound();
            }
            ViewData["IdPilkarz"] = new SelectList(this.unitOfWork.PilkarzRepository.GetDbSetPilkarze(), "IdPilkarz", "IdPilkarz", statystyka.IdPilkarz);
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
                    await this.unitOfWork.StatystykaRepository.UpdateStatystyka(statystyka);
                    await this.unitOfWork.StatystykaRepository.Save();
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
            ViewData["IdPilkarz"] = new SelectList(this.unitOfWork.PilkarzRepository.GetDbSetPilkarze(), "IdPilkarz", "IdPilkarz", statystyka.IdPilkarz);
            return View(statystyka);
        }

        // GET: Statystyki/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || this.unitOfWork.StatystykaRepository == null)
            {
                return NotFound();
            }

            var statystyka = await this.unitOfWork.StatystykaRepository.GetStatystykaById(id);
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
            if (this.unitOfWork.StatystykaRepository == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Statystyki'  is null.");
            }
            var statystyka = await this.unitOfWork.StatystykaRepository.GetStatystykaById(id);
            if (statystyka != null)
            {
                await this.unitOfWork.StatystykaRepository.DeleteStatystyka(id);
            }
            
            await this.unitOfWork.StatystykaRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool StatystykaExists(Guid id)
        {
            return this.unitOfWork.StatystykaRepository.GetStatystykaById(id) != null ? true : false ;
        }
    }
}
