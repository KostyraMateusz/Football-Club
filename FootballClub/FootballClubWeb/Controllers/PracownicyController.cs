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
    public class PracownicyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;


        public PracownicyController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Pracownicy
        public async Task<IActionResult> Index()
        {
            var pracownicy = await this.unitOfWork.PracownikRepository.GetPracownicy();
            return View(pracownicy);
        }

        // GET: Pracownicy/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null ||  this.unitOfWork.PracownikRepository == null)
            {
                return NotFound();
            }

            var pracownik = await this.unitOfWork.PracownikRepository.GetPracownikById(id);
            if (pracownik == null)
            {
                return NotFound();
            }

            return View(pracownik);
        }

        // GET: Pracownicy/Create
        public IActionResult Create()
        {
            ViewData["IdZarzadu"] = new SelectList(this.unitOfWork.ZarzadRepository.GetDbSetZarzady(), "IdZarzad", "IdZarzad");
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
                await this.unitOfWork.PracownikRepository.CreatePracownik(pracownik);
                await this.unitOfWork.PracownikRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdZarzadu"] = new SelectList(this.unitOfWork.ZarzadRepository.GetDbSetZarzady(), "IdZarzad", "IdZarzad", pracownik.IdZarzadu);
            return View(pracownik);
        }

        // GET: Pracownicy/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null || this.unitOfWork.PracownikRepository == null)
            {
                return NotFound();
            }

            var pracownik = await this.unitOfWork.PracownikRepository.GetPracownikById(id);
            if (pracownik == null)
            {
                return NotFound();
            }
            ViewData["IdZarzadu"] = new SelectList(this.unitOfWork.ZarzadRepository.GetDbSetZarzady(), "IdZarzad", "IdZarzad", pracownik.IdZarzadu);
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
                    await this.unitOfWork.PracownikRepository.UpdatePracownik(pracownik);
                    await this.unitOfWork.PracownikRepository.Save();
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
            ViewData["IdZarzadu"] = new SelectList(this.unitOfWork.ZarzadRepository.GetDbSetZarzady(), "IdZarzad", "IdZarzad", pracownik.IdZarzadu);
            return View(pracownik);
        }

        // GET: Pracownicy/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || this.unitOfWork.PracownikRepository == null)
            {
                return NotFound();
            }

            var pracownik = await this.unitOfWork.PracownikRepository.GetPracownikById(id);
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
            if (this.unitOfWork.PracownikRepository == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pracownicy'  is null.");
            }
            var pracownik = await this.unitOfWork.PracownikRepository.GetPracownikById(id);
            if (pracownik != null)
            {
                await this.unitOfWork.PracownikRepository.DeletePracownik(id);
            }
            
            await this.unitOfWork.PracownikRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PracownikExists(Guid id)
        {
            return this.unitOfWork.PracownikRepository.GetPracownikById(id) != null ? true : false;
        }
    }
}
