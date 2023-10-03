using AutoMapper;
using Integrador.DTOs;
using Integrador.Models;
using Integrador.Services;
using Microsoft.AspNetCore.Mvc;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetAllServicios()
        {
            IEnumerable<Service> serviciosList = await _unitOfWork.ServiceRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ServiceDTO>>(serviciosList));
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
        public async Task<ActionResult<ServiceDTO>> PostServicio([FromBody] ServiceDTO servicioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (servicioDto == null)
            {
                return BadRequest(servicioDto);
            }

            Service servicioModel = _mapper.Map<Service>(servicioDto);
            await _unitOfWork.ServiceRepository.Insert(servicioModel);

            // Devolver una respuesta HTTP 201 (Created) sin especificar una ruta
            return StatusCode(StatusCodes.Status201Created, servicioDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutServicio(int id, [FromBody] ServiceDTO serviceDto)
        {
            if (serviceDto == null || id != serviceDto.ServiceId)
            {
                return BadRequest();
            }

            Service servicioModel = _mapper.Map<Service>(serviceDto);
            await _unitOfWork.ServiceRepository.Update(servicioModel);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteServicio(int ServiceId)
        {
            if (ServiceId == 0)
            {
                return BadRequest();
            }
            else
            {
                await _unitOfWork.ServiceRepository.Delete(ServiceId);
                return NoContent();
            }
        }
    }
}
