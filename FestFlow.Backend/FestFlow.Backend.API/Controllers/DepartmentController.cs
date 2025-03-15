using FestFlow.Backend.API.Repositories.IRepositories;
using FestFlow.Backend.API.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FestFlow.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        [Route("GetDepartments")]
        public async Task<ActionResult<IEnumerable<DepartmentResponse>>> GetDepartments()
        {
            var result = await _departmentRepository.GetDepartments();
            return Ok(result);
        }
    }
}
