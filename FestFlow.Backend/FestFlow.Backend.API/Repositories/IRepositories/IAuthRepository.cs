using FestFlow.Backend.API.DTO;
using FestFlow.Backend.API.Responses;

namespace FestFlow.Backend.API.Repositories.IRepositories
{
    public interface IAuthRepository
    {
        Task<bool> Register(RegisterUserDTO registerUserDTO);
        Task<UserResponse> Login(LoginUserDTO loginUserDTO);
    }
}
