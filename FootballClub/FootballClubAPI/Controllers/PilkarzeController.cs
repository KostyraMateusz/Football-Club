using FootballClubLibrary.Models;
using FootballClubLibrary.Unit_of_Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubAPI.Controllers
{
    [ApiController]
    public class PilkarzeController : ControllerBase
    {
        private UnitOfWork unitOfWork;

        public PilkarzeController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> DajPilkarzy()
        {
            var pilkarze = this.unitOfWork.PilkarzRepository.GetAll().ToList();
            if (pilkarze == null)
            {
                return NotFound();
            }
            return Ok(await Task.FromResult(pilkarze));
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DajPilkarzaPoId(Guid id)
        {
            var pilkarz = this.unitOfWork.PilkarzRepository.GetById(id);
            if (pilkarz == null)
            {
                return NotFound();
            }
            return Ok(await Task.FromResult(pilkarz));
        }

        [HttpPost]
        [Route("api/[controller]/stworzPilkarza")]
        public async Task<IActionResult> StworzPilkarza(Pilkarz pilkarz)
        {
            try
            {
                if (pilkarz == null)
                {
                    throw new Exception();
                }
                this.unitOfWork.PilkarzRepository.Add(pilkarz);
                this.unitOfWork.Save();
                return Ok("Pilkarz został stworzony");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/[controller]/usunPilkarza")]
        public async Task<IActionResult> UsunPilkarza(Guid id)
        {
            try
            {
                var pilkarz = this.unitOfWork.PilkarzRepository.GetById(id);
                if (pilkarz == null)
                {
                    throw new Exception();
                }
                this.unitOfWork.PilkarzRepository.Delete(id);
                this.unitOfWork.Save();
                return Ok($"Pilkarz o id {id} został usunięty");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("api/[controller]/edytujPilkarza")]
        public async Task<IActionResult> EdytujPilkarza(Guid id, Pilkarz _pilkarz)
        {
            try
            {
                var pilkarz = this.unitOfWork.PilkarzRepository.GetById(id);
                if (pilkarz == null)
                {
                    throw new Exception();
                }
                pilkarz.Pozycja = _pilkarz.Pozycja;
                pilkarz.Statystyki = _pilkarz.Statystyki;
                pilkarz.ArchiwalneKluby = _pilkarz.ArchiwalneKluby;
                pilkarz.Wynagrodzenie = _pilkarz.Wynagrodzenie;
                pilkarz.IdKlubu = _pilkarz.IdKlubu;
                pilkarz.Klub = _pilkarz.Klub;
                this.unitOfWork.PilkarzRepository.Update(pilkarz);
                this.unitOfWork.Save();
                return Ok($"Pilkarz o id {id} został edytowany");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
