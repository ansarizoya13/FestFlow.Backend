using FestFlow.Backend.API.DTO;
using FestFlow.Backend.API.Repositories.IRepositories;
using FestFlow.Backend.API.Responses;
using FestFlow.Backend.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bcrypt = BCrypt.Net.BCrypt;

namespace FestFlow.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public AuthController(IAuthRepository authRepository, IJwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<bool>> Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            if (registerUserDTO is null)
            {
                return BadRequest("Invalid arguments passed");
            }
            else
            {
                registerUserDTO.Password = Bcrypt.HashPassword(registerUserDTO.Password);
                var result = await _authRepository.Register(registerUserDTO);
                return Ok(result);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            if (loginUserDTO is null)
            {
                return BadRequest("Invalid arguments passed");
            }

            var response = await _authRepository.Login(loginUserDTO);

            if (response is null || !Bcrypt.Verify(loginUserDTO.Password, response.PasswordHash))
            {
                return Unauthorized("Invalid Email or Password");
            }

            var token = await _jwtService.GenerateJwtToken(response);
            return Ok(new { token });
        }
    }
}
