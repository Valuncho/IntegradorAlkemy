using AutoMapper;
using Integrador.DTOs;
using Integrador.Models;
using Integrador.Services;
using Microsoft.AspNetCore.Mvc;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<JobDTO>>> GetAllTrabajos()
        {
            IEnumerable<Job> trabajosList = await _unitOfWork.JobRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<JobDTO>>(trabajosList));
        }


        /*[HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TrabajoDTO>> PostTrabajo([FromBody] TrabajoDTO trabajoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (trabajoDto == null)
            {
                return BadRequest(trabajoDto);
            }

            Trabajo trabajoModel = _mapper.Map<Trabajo>(trabajoDto);
            await _unitOfWork.TrabajoRepository.Insert(trabajoModel);

            return CreatedAtRoute("GetTrabajoById", new { id = trabajoDto.IdTrabajo }, trabajoDto);
        }*/

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JobDTO>> PostTrabajo([FromBody] JobDTO trabajoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (trabajoDto == null)
            {
                return BadRequest(trabajoDto);
            }

            Job trabajoModel = _mapper.Map<Job>(trabajoDto);
            await _unitOfWork.JobRepository.Insert(trabajoModel);

            // Devolver una respuesta HTTP 201 (Created) sin especificar una ruta
            return StatusCode(StatusCodes.Status201Created, trabajoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutJob(int id, [FromBody] JobDTO jobDto)
        {
            if (jobDto == null || id != jobDto.JobId)
            {
                return BadRequest();
            }

            Job trabajoModel = _mapper.Map<Job>(jobDto);
            await _unitOfWork.JobRepository.Update(trabajoModel);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteJob(int JobId)
        {
            if (JobId == 0)
            {
                return BadRequest();
            }
            else
            {
                await _unitOfWork.JobRepository.Delete(JobId);
                return NoContent();
            }
        }
    }
}

