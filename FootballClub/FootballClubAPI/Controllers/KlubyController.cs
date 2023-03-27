using FootballClubLibrary.Intefaces;
using FootballClubLibrary.Models;
using FootballClubLibrary.Repositories;
using FootballClubLibrary.Unit_of_Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubAPI.Controllers
{
    [ApiController]
    public class KlubyController : ControllerBase
    {
        private UnitOfWork unitOfWork;

        public KlubyController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> DajKluby()
        {
            var kluby = this.unitOfWork.KlubRepository.GetAll().ToList();
            if(kluby == null)
            {
                return NotFound();
            }
            return Ok(await Task.FromResult(kluby));
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult>DajKlubPoId(Guid id)
        {
            var klub = this.unitOfWork.KlubRepository.GetById(id);
            if(klub == null)
            {
                return NotFound();
            }
            return Ok(await Task.FromResult(klub));
        }

        [HttpPost]
        [Route("api/[controller]/stworzKlub")]
        public async Task<IActionResult> StworzKlub(Klub klub)
        {
            try
            {
                if (klub == null)
                {
                    throw new Exception();
                }
                this.unitOfWork.KlubRepository.Add(klub);
                this.unitOfWork.Save();
                return Ok("Klub został stworzony");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/[controller]/usunKlub")]
        public async Task<IActionResult>UsunKlub(Guid id)
        {  
            try
            {
                var klub = this.unitOfWork.KlubRepository.GetById(id);
                if (klub == null)
                {
                    throw new Exception();
                }
                this.unitOfWork.KlubRepository.Delete(id);
                this.unitOfWork.Save();
                return Ok($"Klub o id {id} został usunięty");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("api/[controller]/edytujKlub")]
        public async Task<IActionResult>EdytujKlub(Guid id, Klub _klub)
        {
            try
            {
                var klub = this.unitOfWork.KlubRepository.GetById(id);
                if (klub == null)
                {
                    throw new Exception();
                }
                klub.Stadion = _klub.Stadion;
                klub.Trofea = _klub.Trofea;
                klub.ArchwilaniPilkarze = _klub.ArchwilaniPilkarze;
                klub.ObecniPilkarze = _klub.ObecniPilkarze;
                klub.Zarzad = _klub.Zarzad;
                this.unitOfWork.KlubRepository.Update(klub);
                this.unitOfWork.Save();
                return Ok($"Klub o id {id} został edytowany");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
