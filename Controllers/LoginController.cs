using Integrador.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOil.DTOs;
using TechOil.Helper;
using TechOil.Infrastructure;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

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
        [ProducesResponseType(typeof(ApiSuccessResponse<LoginDTO>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 401)]
        public async Task<IActionResult> Login(AutenticacionDTO dto)
        {
            var userCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(dto);

            if (userCredentials is null) return Unauthorized();

            var token = _tokenJwtHelper.GenerateToken(userCredentials);

            var user = new LoginDTO()
            {
                Email = userCredentials.Email,
                Name = userCredentials.Name,
                UserType = userCredentials.UserType,
                Dni = userCredentials.Dni,
                Token = token
            };

            return ResponseFactory.CreateSuccessResponse(200, user);

        }
    }
}
