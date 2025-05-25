using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using training.Exceptions;
using training.Models.DTO;
using training.Repositories;

namespace training.Controllers
{
    [EnableCors("GatewayCors")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository, IHttpClientFactory httpClientFactory)
        {
            _repository = repository;
        }

        // GET: api/employees
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<IActionResult> GetAll(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortColumn = "hire_date",
            [FromQuery] string sortDirection = "asc",
            [FromQuery] string? searchTerm = null)
        {
            var result = await _repository.GetEmployeeFiltered(
                pageNumber, pageSize, sortColumn, sortDirection, searchTerm
            );

            return Ok(new
            {
                Data = result.Data,
                TotalCount = result.TotalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            });
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var employee = await _repository.GetEmployeeById(id);
            if (employee == null)
                throw new NotFoundException($"Employee with ID {id} not found.");

            return Ok(employee);
        }

        // POST: api/employees
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Create([FromBody] EmployeeDto dto)
        {
            dto.HireDate = DateTime.UtcNow;

            await _repository.CallSpInsert(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.EmployeeId }, dto);
        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] EmployeeDto dto)
        {
            var existing = await _repository.GetEmployeeById(id);
            if (existing == null) return NotFound();

            dto.EmployeeId = id;
            await _repository.CallSpUpdate(dto);
            return NoContent();
        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _repository.GetEmployeeById(id);
            if (existing == null)
                throw new NotFoundException($"Employee with ID {id} does not exist.");

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
