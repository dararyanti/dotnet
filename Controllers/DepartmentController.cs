using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using training.Models.DTO;
using training.Repositories;

namespace training.Controllers
{
    [EnableCors("GatewayCors")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: api/department
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<ActionResult<List<DepartmentDto>>> GetDepartments()
        {
            var departments = await _departmentRepository.GetDepartment();
            return Ok(departments);
        }
    }
}
