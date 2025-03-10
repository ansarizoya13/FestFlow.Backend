using Dapper;
using FestFlow.Backend.API.DTO;
using FestFlow.Backend.API.Repositories.IRepositories;
using FestFlow.Backend.API.Resources;
using FestFlow.Backend.API.Responses;
using System.Data;

namespace FestFlow.Backend.API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;

        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserResponse> Login(LoginUserDTO loginUserDTO)
        {
            using(var connection = DbHelper.GetDbConnection(_configuration))
            {
                var result = await connection.QuerySingleOrDefaultAsync<UserResponse>("usp_GetUser", new { email = loginUserDTO.Email }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<bool> Register(RegisterUserDTO registerUserDTO)
        {
            using (var connection = DbHelper.GetDbConnection(_configuration))
            {
                int affectedRows = await connection.ExecuteAsync("usp_InsertUser", registerUserDTO, commandType : CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }
    }
}
