using FootballClubLibrary.Models;
using FootballClubLibrary.Unit_of_Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubAPI.Controllers
{
    [ApiController]
    public class StatystykaController : ControllerBase
    {
        private UnitOfWork unitOfWork;

        public StatystykaController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> DajStatystyki()
        {
            var statystyki = this.unitOfWork.StatystykaRepository.GetAll().ToList();
            if (statystyki == null)
            {
                return NotFound();
            }
            return Ok(await Task.FromResult(statystyki));
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DajStatystykaPoId(Guid id)
        {
            var statystyka = this.unitOfWork.StatystykaRepository.GetById(id);
            if (statystyka == null)
            {
                return NotFound();
            }
            return Ok(await Task.FromResult(statystyka));
        }

        [HttpPost]
        [Route("api/[controller]/stworzStatystyke")]
        public async Task<IActionResult> StworzStatystyke(Statystyka statystyka)
        {
            try
            {
                if (statystyka == null)
                {
                    throw new Exception();
                }
                this.unitOfWork.StatystykaRepository.Add(statystyka);
                this.unitOfWork.Save();
                return Ok("Statystyka została stworzona");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/[controller]/usunStatystyke")]
        public async Task<IActionResult> UsunStatystyke(Guid id)
        {
            try
            {
                var statystyka = this.unitOfWork.StatystykaRepository.GetById(id);
                if (statystyka == null)
                {
                    throw new Exception();
                }
                this.unitOfWork.StatystykaRepository.Delete(id);
                this.unitOfWork.Save();
                return Ok($"Statystyka o id {id} została usunięta");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("api/[controller]/edytujStatystyke")]
        public async Task<IActionResult> EdytujStatystyke(Guid id, Statystyka _statystyka)
        {
            try
            {
                var statystyka = this.unitOfWork.StatystykaRepository.GetById(id);
                if (statystyka == null)
                {
                    throw new Exception();
                }
                statystyka.Gole = _statystyka.Gole;
                statystyka.Asysty = _statystyka.Asysty;
                statystyka.Kartki = _statystyka.Kartki;
                statystyka.PrzebiegnietyDystans = _statystyka.PrzebiegnietyDystans;
                statystyka.Ocena = statystyka.Ocena;
                statystyka.IdPilkarz = _statystyka.IdPilkarz; //?????????????
                statystyka.Pilkarz = _statystyka.Pilkarz; //?????????????
                this.unitOfWork.StatystykaRepository.Update(statystyka);
                this.unitOfWork.Save();
                return Ok($"Statystyka o id {id} została edytowana");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
