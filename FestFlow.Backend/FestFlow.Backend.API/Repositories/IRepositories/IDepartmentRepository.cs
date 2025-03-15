using FestFlow.Backend.API.Responses;

namespace FestFlow.Backend.API.Repositories.IRepositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentResponse>> GetDepartments();
    }
}
