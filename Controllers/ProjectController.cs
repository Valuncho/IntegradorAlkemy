using AutoMapper;
using Integrador.DTOs;
using Integrador.Models;
using Integrador.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetProjectId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProjectDTO>> GetProject(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var project = await _unitOfWork.ProjectRepository.GetById(p => p.ProjectId == id);
            if (project != null)
            {
                return Ok(_mapper.Map<ProjectDTO>(project));
            }

            return NotFound();
        }

        [HttpGet("GetProjectsByState/{state}")]
        public async Task<ActionResult> GetProjectsByState([FromRoute] int state, int? itemsPerPage)
        {
            try
            {
                var projectsStateList = await _unitOfWork.ProjectRepository.GetAllStateProjects(state);
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                return Created(url, projectsStateList);
            }

            catch
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAllProyectos()
        {
            IEnumerable<Project> projectList = await _unitOfWork.ProjectRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ProjectDTO>>(projectList));
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
        public async Task<ActionResult<ProjectDTO>> PostProject([FromBody] ProjectDTO proyectoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (proyectoDto == null)
            {
                return BadRequest(proyectoDto);
            }

            Project proyectoModel = _mapper.Map<Project>(proyectoDto);
            await _unitOfWork.ProjectRepository.Insert(proyectoModel);

            // Construye manualmente la respuesta HTTP 201 (Created)
            var locationUri = new Uri($"{Request.Scheme}://{Request.Host.ToUriComponent()}/api/proyectos/{proyectoModel.ProjectId}");
            return Created(locationUri, proyectoDto);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProject(int id, [FromBody] ProjectDTO projectDto)
        {
            if (projectDto == null || id != projectDto.ProyectId)
            {
                return BadRequest();
            }

            Project proyectoModel = _mapper.Map<Project>(projectDto);
            await _unitOfWork.ProjectRepository.Update(proyectoModel);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProject(int ProjectId)
        {
            if (ProjectId == 0)
            {
                return BadRequest();
            }
            else
            {
                await _unitOfWork.ProjectRepository.Delete(ProjectId);
                return NoContent();
            }
        }
    }
}
