using FestFlow.Backend.API.DTO;
using FestFlow.Backend.API.Responses;

namespace FestFlow.Backend.API.Services.IServices
{
    public interface IJwtService
    {
        Task<string> GenerateJwtToken(UserResponse user);
    }
}
