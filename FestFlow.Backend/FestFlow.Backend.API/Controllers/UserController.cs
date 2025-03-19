using FestFlow.Backend.API.DTO;
using FestFlow.Backend.API.Repositories.IRepositories;
using FestFlow.Backend.API.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FestFlow.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetUsersList")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserInGridResponse>> GetUsersList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            var result = await _userRepository.GetUsersList(new Guid(userId));
            return Ok(result);
        }

        [HttpPost]
        [Route("set-admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> MarkUserAsAdmin(MarkUserAdminDTO dto)
        {
            var result = await _userRepository.MarkUserAsAdmin(dto);
            return Ok(result);
        }

        [HttpPost]
        [Route("set-inactive")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> MarkUserAsInactive(MarkUserInactiveDTO dto)
        {
            var result = await _userRepository.MarkUserAsInactive(dto);
            return Ok(result);
        }
    }
}
