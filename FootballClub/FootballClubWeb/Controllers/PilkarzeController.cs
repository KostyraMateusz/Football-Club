using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballClubLibrary.Data;
using FootballClubLibrary.Models;
using FootballClubLibrary.Unit_of_Work;

namespace FootballClubWeb.Controllers
{
    public class PilkarzeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public PilkarzeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Pilkarze
        public async Task<IActionResult> Index()
        {
            var pilkarze = await this.unitOfWork.PilkarzRepository.GetPilkarze();
            return View(pilkarze);
        }

        // GET: Pilkarze/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null || this.unitOfWork.PilkarzRepository == null)
            {
                return NotFound();
            }

            var pilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(id);
            if (pilkarz == null)
            {
                return NotFound();
            }

            return View(pilkarz);
        }

        // GET: Pilkarze/Create
        public IActionResult Create()
        {
            ViewData["IdKlubu"] = new SelectList(this.unitOfWork.KlubRepository.GetDbSetKluby(), "IdKlub", "IdKlub");
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
                await this.unitOfWork.PilkarzRepository.CreatePilkarz(pilkarz);
                await this.unitOfWork.PilkarzRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlubu"] = new SelectList(this.unitOfWork.KlubRepository.GetDbSetKluby(), "IdKlub", "IdKlub", pilkarz.IdKlubu);
            return View(pilkarz);
        }

        // GET: Pilkarze/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null || this.unitOfWork.KlubRepository == null)
            {
                return NotFound();
            }

            var pilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(id);
            if (pilkarz == null)
            {
                return NotFound();
            }
            ViewData["IdKlubu"] = new SelectList(this.unitOfWork.KlubRepository.GetDbSetKluby(), "IdKlub", "IdKlub", pilkarz.IdKlubu);
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
                    await this.unitOfWork.PilkarzRepository.UpdatePilkarz(pilkarz);
                    await this.unitOfWork.PilkarzRepository.Save();
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
            ViewData["IdKlubu"] = new SelectList(this.unitOfWork.KlubRepository.GetDbSetKluby(), "IdKlub", "IdKlub", pilkarz.IdKlubu);
            return View(pilkarz);
        }

        // GET: Pilkarze/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || this.unitOfWork.PilkarzRepository == null)
            {
                return NotFound();
            }

            var pilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(id);
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
            if (this.unitOfWork.PilkarzRepository == null)
            {
                return Problem("Entity set 'unitOfWork.PilkarzRepository'  is null.");
            }
            var pilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(id);
            if (pilkarz != null)
            {
                await this.unitOfWork.PilkarzRepository.DeletePilkarz(id);
            }

            await this.unitOfWork.PilkarzRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PilkarzExists(Guid id)
        {
          return this.unitOfWork.PilkarzRepository.GetPilkarzById(id) != null ? true : false;
        }
    }
}
