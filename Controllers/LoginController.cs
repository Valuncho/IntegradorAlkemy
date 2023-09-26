using Integrador.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOil.DTOs;
using TechOil.Helper;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class LoginController : ControllerBase
    {
        //Token para realizar las operaciones de la API
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AutenticacionDTO dto)
        {
            var userCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(dto);
            if (userCredentials is null) return Unauthorized();

            var token = _tokenJwtHelper.GenerateToken(userCredentials);

            var user = new LoginDTO()
            {
                Email = userCredentials.Email,
                Nombre = userCredentials.Nombre,
                Dni = userCredentials.Dni,
                Token = token
            };

            return Ok(user);

        }
    }
}
