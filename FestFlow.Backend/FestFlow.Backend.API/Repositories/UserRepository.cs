using Dapper;
using FestFlow.Backend.API.DTO;
using FestFlow.Backend.API.Repositories.IRepositories;
using FestFlow.Backend.API.Resources;
using FestFlow.Backend.API.Responses;
using System.Data;

namespace FestFlow.Backend.API.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserInGridResponse>> GetUsersList(Guid userId)
        {
            using (var connection = DbHelper.GetDbConnection(_configuration))
            {
                var result = await connection.QueryAsync<UserInGridResponse>("usp_GetUsersList", new { userId }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<bool> MarkUserAsAdmin(MarkUserAdminDTO dto)
        {
            using (var connection = DbHelper.GetDbConnection(_configuration))
            {
                var result = await connection.ExecuteAsync("UPDATE [Users] SET IsAdmin = @isAdmin WHERE ID = @userId",
                    new
                    {
                        userId = dto.UserId,
                        isAdmin = dto.IsAdmin
                    });

                return result > 0;
            }
        }

        public async Task<bool> MarkUserAsInactive(MarkUserInactiveDTO dto)
        {
            using (var connection = DbHelper.GetDbConnection(_configuration))
            {
                var result = await connection.ExecuteAsync("UPDATE [Users] SET IsDeleted = @isDeleted WHERE ID = @userId",
                    new
                    {
                        userId = dto.UserId,
                        isDeleted = dto.IsDeleted
                    });

                return result > 0;
            }
        }
    }
}
