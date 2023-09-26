using AutoMapper;
using Integrador.DTOs;
using Integrador.Models;
using Integrador.Services;
using Microsoft.AspNetCore.Mvc;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServicioController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ServicioDTO>>> GetAllServicios()
        {
            IEnumerable<Servicio> serviciosList = await _unitOfWork.ServicioRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ServicioDTO>>(serviciosList));
        }


        /*[HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServicioDTO>> PostServicio([FromBody] ServicioDTO servicioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (servicioDto == null)
            {
                return BadRequest(servicioDto);
            }

            Servicio servicioModel = _mapper.Map<Servicio>(servicioDto);
            await _unitOfWork.ServicioRepository.Insert(servicioModel);

            return CreatedAtRoute("GetServicioById", new { id = servicioDto.IdServicio }, servicioDto);
        }*/

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServicioDTO>> PostServicio([FromBody] ServicioDTO servicioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (servicioDto == null)
            {
                return BadRequest(servicioDto);
            }

            Servicio servicioModel = _mapper.Map<Servicio>(servicioDto);
            await _unitOfWork.ServicioRepository.Insert(servicioModel);

            // Devolver una respuesta HTTP 201 (Created) sin especificar una ruta
            return StatusCode(StatusCodes.Status201Created, servicioDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutServicio(int id, [FromBody] ServicioDTO servicioDto)
        {
            if (servicioDto == null || id != servicioDto.IdServicio)
            {
                return BadRequest();
            }

            Servicio servicioModel = _mapper.Map<Servicio>(servicioDto);
            await _unitOfWork.ServicioRepository.Update(servicioModel);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteServicio(int IdServicio)
        {
            if (IdServicio == 0)
            {
                return BadRequest();
            }
            else
            {
                await _unitOfWork.ServicioRepository.Delete(IdServicio);
                return NoContent();
            }
        }
    }
}
