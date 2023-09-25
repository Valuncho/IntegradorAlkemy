using AutoMapper;
using Integrador.DTOs;
using Integrador.Models;
using Integrador.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAllUsers()
        {
            IEnumerable<Usuario> usuariosList = await _unitOfWork.UsuarioRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<UsuarioDTO>>(usuariosList));
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UsuarioDTO>> PostUser([FromBody] UsuarioDTO usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (usuarioDto == null)
            {
                return BadRequest(usuarioDto);
            }

            Usuario userModel = _mapper.Map<Usuario>(usuarioDto);
            await _unitOfWork.UsuarioRepository.Insert(userModel);

            return CreatedAtRoute("GetUserById", new { id = usuarioDto.IdUsuario }, usuarioDto);
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutUser(int id, [FromBody] UsuarioDTO usuarioDto)
        {
            if (usuarioDto == null || id != usuarioDto.IdUsuario)
            {
                return BadRequest();
            }

            Usuario usuarioModel = _mapper.Map<Usuario>(usuarioDto);
            await _unitOfWork.UsuarioRepository.Update(usuarioModel);

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUsuario(int IdUsuario)
        {
            if (IdUsuario == 0)
            {
                return BadRequest();
            } else
                {
                    await _unitOfWork.UsuarioRepository.Delete(IdUsuario);
                    return NoContent();
                }
        }
    }
}
