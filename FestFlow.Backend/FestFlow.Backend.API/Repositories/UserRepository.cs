using Dapper;
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
    }
}
