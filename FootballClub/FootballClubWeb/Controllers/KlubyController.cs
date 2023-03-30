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
    public class KlubyController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public KlubyController()
        {
            this.unitOfWork = new UnitOfWork();
        }


        // GET: Kluby
        public async Task<IActionResult> Index()
        {
            var kluby = await this.unitOfWork.KlubRepository.GetKluby();
            return View(kluby);
        }

        // GET: Kluby/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null || this.unitOfWork.KlubRepository == null)
            {
                return NotFound();
            }

            var klub = await this.unitOfWork.KlubRepository.GetKlubById(id);
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
                await this.unitOfWork.KlubRepository.CreateKlub(klub);
                await this.unitOfWork.KlubRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(klub);
        }

        // GET: Kluby/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null || this.unitOfWork.KlubRepository == null)
            {
                return NotFound();
            }

            var klub = await this.unitOfWork.KlubRepository.GetKlubById(id);
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
                    await this.unitOfWork.KlubRepository.UpdateKlub(klub);
                    await this.unitOfWork.KlubRepository.Save();
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
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || this.unitOfWork.KlubRepository == null)
            {
                return NotFound();
            }

            var klub = await this.unitOfWork.KlubRepository.GetKlubById(id);
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
            if (this.unitOfWork.KlubRepository == null)
            {
                return Problem("Entity set 'unitOfWork.KlubRepository'  is null.");
            }
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(id);
            if (klub != null)
            {
                await this.unitOfWork.KlubRepository.DeleteKlub(id);
            }

            await this.unitOfWork.KlubRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool KlubExists(Guid id)
        {
          return this.unitOfWork.KlubRepository.GetKlubById(id) != null ? true : false;
        }
    }
}
