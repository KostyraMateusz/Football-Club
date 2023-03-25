using FootballClubLibrary.Models;
using FootballClubLibrary.Unit_of_Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubAPI.Controllers
{
    [ApiController]
    public class PracownicyController : ControllerBase
    {
        private UnitOfWork unitOfWork;

        public PracownicyController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> DajPracownicy()
        {
            var pracownicy = this.unitOfWork.PracownikRepository.GetAll().ToList();
            if (pracownicy == null)
            {
                return NotFound();
            }
            return Ok(await Task.FromResult(pracownicy));
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DajPracownkPoId(Guid id)
        {
            var pracownik = this.unitOfWork.PracownikRepository.GetById(id);
            if (pracownik == null)
            {
                return NotFound();
            }
            return Ok(await Task.FromResult(pracownik));
        }

        [HttpPost]
        [Route("api/[controller]/stworzPracownika")]
        public async Task<IActionResult> StworzPracownika(Pracownik pracownik)
        {
            try
            {
                if (pracownik == null)
                {
                    throw new Exception();
                }
                this.unitOfWork.PracownikRepository.Add(pracownik);
                this.unitOfWork.Save();
                return Ok("Pracownik został stworzony");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/[controller]/usunPracownika")]
        public async Task<IActionResult> UsunPracownika(Guid id)
        {
            try
            {
                var pracownik = this.unitOfWork.PracownikRepository.GetById(id);
                if (pracownik == null)
                {
                    throw new Exception();
                }
                this.unitOfWork.PracownikRepository.Delete(id);
                this.unitOfWork.Save();
                return Ok($"Pracownik o id {id} został usunięty");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("api/[controller]/edytujPracownika")]
        public async Task<IActionResult> EdytujPracownika(Guid id, Pracownik _pracownik)
        {
            try
            {
                var pracownik = this.unitOfWork.PracownikRepository.GetById(id);
                if (pracownik == null)
                {
                    throw new Exception();
                }
                pracownik.Imie = _pracownik.Imie;
                pracownik.Nazwisko = _pracownik.Nazwisko;
                pracownik.PESEL = _pracownik.PESEL;
                pracownik.Wiek = _pracownik.Wiek;
                pracownik.WykonywanaFunkcja = _pracownik.WykonywanaFunkcja;
                pracownik.IdZarzadu = _pracownik.IdZarzadu; //?????????????
                pracownik.Zarzad = _pracownik.Zarzad; //?????????????
                this.unitOfWork.PracownikRepository.Update(pracownik);
                this.unitOfWork.Save();
                return Ok($"Pracownik o id {id} został edytowany");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
