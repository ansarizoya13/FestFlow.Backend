using FestFlow.Backend.API.DTO;
using FestFlow.Backend.API.Repositories.IRepositories;
using FestFlow.Backend.API.Responses;
using FestFlow.Backend.API.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Bcrypt = BCrypt.Net.BCrypt;

namespace FestFlow.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;
        public static readonly HashSet<string> _revokedTokens = new();

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

        [HttpPost]
        [Route("Logout")]
        [Authorize]
        public IActionResult Logout()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var userId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;

                if (!string.IsNullOrEmpty(userId))
                {
                    _revokedTokens.Add(token);  // Add the token to the revoked list
                    return Ok(new { message = $"Logout successful for User ID: {userId}" });
                }

                return Unauthorized(new { message = "Invalid token or user not identified." });
            }

            return BadRequest(new { message = "Authorization token is missing." });

        }
    }
}
