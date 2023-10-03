using AutoMapper;
using Integrador.DTOs;
using Integrador.Models;
using Integrador.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOil.DTOs;
using TechOil.Helper;
using TechOil.Infrastructure;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var user = await _unitOfWork.UserRepository.GetById(u => u.UserId == id);
            if (user != null)
            {
                return Ok(_mapper.Map<UserDTO>(user));
            }

            return NotFound();
        }


        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ApiSuccessResponseList<User>), 200)]
        [ProducesResponseType(typeof(PaginateDataDto<User>), 201)]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize = 10)
        {
            var users = await _unitOfWork.UserRepository.GetAll();

            if (page > 0)
            {
                if (pageSize < 1) return ResponseFactory.CreateErrorResponse(409, "'pageSize' debe ser un número mayor o igual a 1.");
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                var paginateUsers = PaginateHelper.Paginate(users, page, url, pageSize);
                return ResponseFactory.CreateSuccessResponse(201, paginateUsers);
            }

            return ResponseFactory.CreateSuccessResponse(200, users);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> PostUser([FromBody] UserDTO usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (usuarioDto == null)
            {
                return BadRequest(usuarioDto);
            }

            User usuarioModel = _mapper.Map<User>(usuarioDto);
            await _unitOfWork.UserRepository.Insert(usuarioModel);

            // Construye manualmente la respuesta HTTP 201 (Created)
            var locationUri = new Uri($"{Request.Scheme}://{Request.Host.ToUriComponent()}/api/usuarios/{usuarioModel.UserId}");
            return Created(locationUri, usuarioDto);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutUser(int id, [FromBody] UserDTO usuarioDto)
        {
            if (usuarioDto == null || id != usuarioDto.UserId)
            {
                return BadRequest();
            }

            User usuarioModel = _mapper.Map<User>(usuarioDto);
            await _unitOfWork.UserRepository.Update(usuarioModel);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            if (UserId == 0)
            {
                return BadRequest();
            } else
                {
                    await _unitOfWork.UserRepository.Delete(UserId);
                    return NoContent();
                }
        }
    }
}
