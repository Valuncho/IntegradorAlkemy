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

        [HttpGet("{id}", Name = "GetProjectId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProyectoDTO>> GetProyecto(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var proyecto = await _unitOfWork.ProyectoRepository.GetById(p => p.IdProyecto == id);
            if (proyecto != null)
            {
                return Ok(_mapper.Map<ProyectoDTO>(proyecto));
            }

            return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProyectoDTO>>> GetAllProyectos()
        {
            IEnumerable<Proyecto> proyectosList = await _unitOfWork.ProyectoRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ProyectoDTO>>(proyectosList));
        }


        /*[HttpPost]
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
        }*/

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

            // Construye manualmente la respuesta HTTP 201 (Created)
            var locationUri = new Uri($"{Request.Scheme}://{Request.Host.ToUriComponent()}/api/proyectos/{proyectoModel.IdProyecto}");
            return Created(locationUri, proyectoDto);
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
