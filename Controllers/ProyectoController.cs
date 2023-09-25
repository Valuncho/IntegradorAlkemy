using AutoMapper;
using Integrador.DTOs;
using Integrador.Models;
using Integrador.Services;
using Microsoft.AspNetCore.Mvc;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProyectoController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProyectoDTO>>> GetAllProyectos()
        {
            IEnumerable<Proyecto> proyectosList = await _unitOfWork.ProyectoRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ProyectoDTO>>(proyectosList));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProyectoDTO>> PostProyecto([FromBody] ProyectoDTO proyectoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (proyectoDto == null)
            {
                return BadRequest(proyectoDto);
            }

            Proyecto proyectoModel = _mapper.Map<Proyecto>(proyectoDto);
            await _unitOfWork.ProyectoRepository.Insert(proyectoModel);

            return CreatedAtRoute("GetProyectoById", new { id = proyectoDto.IdProyecto }, proyectoDto);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProyecto(int id, [FromBody] ProyectoDTO proyectoDto)
        {
            if (proyectoDto == null || id != proyectoDto.IdProyecto)
            {
                return BadRequest();
            }

            Proyecto proyectoModel = _mapper.Map<Proyecto>(proyectoDto);
            await _unitOfWork.ProyectoRepository.Update(proyectoModel);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProyecto(int IdProyecto)
        {
            if (IdProyecto == 0)
            {
                return BadRequest();
            }
            else
            {
                await _unitOfWork.ProyectoRepository.Delete(IdProyecto);
                return NoContent();
            }
        }
    }
}
