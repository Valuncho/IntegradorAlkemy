using AutoMapper;
using Integrador.DTOs;
using Integrador.Models;
using Integrador.Services;
using Microsoft.AspNetCore.Mvc;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TrabajoController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TrabajoDTO>>> GetAllTrabajos()
        {
            IEnumerable<Trabajo> trabajosList = await _unitOfWork.TrabajoRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<TrabajoDTO>>(trabajosList));
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

            // Devolver una respuesta HTTP 201 (Created) sin especificar una ruta
            return StatusCode(StatusCodes.Status201Created, trabajoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTrabajo(int id, [FromBody] TrabajoDTO trabajoDto)
        {
            if (trabajoDto == null || id != trabajoDto.IdTrabajo)
            {
                return BadRequest();
            }

            Trabajo trabajoModel = _mapper.Map<Trabajo>(trabajoDto);
            await _unitOfWork.TrabajoRepository.Update(trabajoModel);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTrabajo(int IdTrabajo)
        {
            if (IdTrabajo == 0)
            {
                return BadRequest();
            }
            else
            {
                await _unitOfWork.TrabajoRepository.Delete(IdTrabajo);
                return NoContent();
            }
        }
    }
}

