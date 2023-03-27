using FootballClubLibrary.Models;
using FootballClubLibrary.Unit_of_Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubAPI.Controllers
{
    [ApiController]
    public class ZarzadyController : ControllerBase
    {
        private UnitOfWork unitOfWork;

        public ZarzadyController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> DajZarzady()
        {
            var zarzady = this.unitOfWork.ZarzadRepository.GetAll().ToList();
            if(zarzady == null)
            {
                return NotFound();
            }
            return Ok(await Task.FromResult(zarzady));
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DajZarzadPoId(Guid id)
        {
            var zarzad = this.unitOfWork.ZarzadRepository.GetById(id);
            if (zarzad == null)
            {
                return NotFound();
            }
            return Ok(await Task.FromResult(zarzad));
        }

        [HttpPost]
        [Route("api/[controller]/stworzZarzad")]
        public async Task<IActionResult> StworzZarzad(Zarzad zarzad)
        {
            try
            {
                if (zarzad == null)
                {
                    throw new Exception();
                }
                this.unitOfWork.ZarzadRepository.Add(zarzad);
                this.unitOfWork.Save();
                return Ok("Zarzad został stworzony");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/[controller]/usunZarzad")]
        public async Task<IActionResult> UsunZarzad(Guid id)
        {
            try
            {
                var zarzad = this.unitOfWork.ZarzadRepository.GetById(id);
                if (zarzad == null)
                {
                    throw new Exception();
                }
                this.unitOfWork.ZarzadRepository.Delete(id);
                this.unitOfWork.Save();
                return Ok($"Zarzad o id {id} został usunięty");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("api/[controller]/edytujZarzad")]
        public async Task<IActionResult> EdytujZarzad(Guid id, Zarzad _zarzad)
        {
            try
            {
                var zarzad = this.unitOfWork.ZarzadRepository.GetById(id);
                if (zarzad == null)
                {
                    throw new Exception();
                }
                zarzad.Pracownicy = _zarzad.Pracownicy;
                zarzad.Budzet = _zarzad.Budzet;
                zarzad.Cele = _zarzad.Cele;
                zarzad.Klub = _zarzad.Klub; //?????????????
                zarzad.IdKlubu = _zarzad.IdKlubu; //?????????????
                this.unitOfWork.ZarzadRepository.Update(zarzad);
                this.unitOfWork.Save();
                return Ok($"Zarzad o id {id} został edytowany");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
