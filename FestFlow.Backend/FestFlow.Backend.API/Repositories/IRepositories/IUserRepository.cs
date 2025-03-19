using FestFlow.Backend.API.Responses;

namespace FestFlow.Backend.API.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserInGridResponse>> GetUsersList(Guid userId);
    }
}
