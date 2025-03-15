using Dapper;
using FestFlow.Backend.API.Repositories.IRepositories;
using FestFlow.Backend.API.Resources;
using FestFlow.Backend.API.Responses;
using System.Data;

namespace FestFlow.Backend.API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IConfiguration _configuration;

        public DepartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<DepartmentResponse>> GetDepartments()
        {
            using (var connection = DbHelper.GetDbConnection(_configuration))
            {
                var result = await connection.QueryAsync<DepartmentResponse>("usp_GetDepartments", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
