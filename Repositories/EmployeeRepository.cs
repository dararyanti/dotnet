using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Linq.Expressions;
using training.Data;
using training.Models.Domain;
using training.Models.DTO;

namespace training.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;
        private readonly TrainingDBContext _context;

        public EmployeeRepository(IConfiguration configuration, TrainingDBContext context)
        {
            _connectionString = configuration.GetConnectionString("TrainingConnectionString");
            _context = context;
        }

        private NpgsqlConnection GetConnection() => new NpgsqlConnection(_connectionString);

        public async Task<(IEnumerable<GetEmployeeDto> Data, int TotalCount)> GetEmployeeFiltered(
            int pageNumber,
            int pageSize,
            string sortColumn,
            string sortDirection,
            string? searchTerm)
            {
            var allowedSortColumns = new Dictionary<string, Expression<Func<Employee, object>>>(StringComparer.OrdinalIgnoreCase)
                {
                    { "employee_id", e => e.EmployeeId },
                    { "first_name", e => e.FirstName },
                    { "last_name", e => e.LastName },
                    { "email", e => e.Email },
                    { "hire_date", e => e.HireDate },
                    { "department_id", e => e.DepartmentId },
                    { "create_date", e => e.CreateDate },
                    { "create_name", e => e.CreateName }
                };

            var query = _context.Employees
                .Include(e => e.Department)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var lowerSearch = searchTerm.ToLower();
                query = query.Where(e =>
                    e.FirstName.ToLower().Contains(lowerSearch) ||
                    e.LastName.ToLower().Contains(lowerSearch) ||
                    e.Email.ToLower().Contains(lowerSearch) ||
                    e.CreateName.ToLower().Contains(lowerSearch)
                );
            }

            var totalCount = await query.CountAsync();

            if (allowedSortColumns.TryGetValue(sortColumn ?? "", out var sortExpression))
            {
                query = sortDirection?.ToLower() == "desc"
                    ? query.OrderByDescending(sortExpression)
                    : query.OrderBy(sortExpression);
            }
            else
            {
                query = query.OrderBy(e => e.CreateDate);
            }

            var employees = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new GetEmployeeDto
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    HireDate = e.HireDate,
                    DepartmentId = e.DepartmentId ?? Guid.Empty,
                    DepartmentName = e.Department != null ? e.Department.Name : "",
                    CreateDate = e.CreateDate,
                    CreateName = e.CreateName
                })
                .ToListAsync();

            return (employees, totalCount);
        }

        public async Task<GetEmployeeDto?> GetEmployeeById(Guid id)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Where(e => e.EmployeeId == id)
                .Select(e => new GetEmployeeDto
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    HireDate = e.HireDate,
                    DepartmentId = e.DepartmentId ?? Guid.Empty,
                    DepartmentName = e.Department != null ? e.Department.Name : string.Empty,
                    CreateDate = e.CreateDate,
                    CreateName = e.CreateName
                })
                .FirstOrDefaultAsync();
        }

        public async Task CallSpInsert(EmployeeDto employee)
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            if (employee.EmployeeId == Guid.Empty)
            {
                employee.EmployeeId = Guid.NewGuid();
            }

            var parameters = new
            {
                i_employee_id = employee.EmployeeId,
                i_first_name = employee.FirstName,
                i_last_name = employee.LastName,
                i_email = employee.Email,
                i_hire_date = employee.HireDate,
                i_department_id = employee.DepartmentId,
                i_create_name = employee.CreateName
            };
            var sql = "CALL dara_sp_insert_employee" +
                "(@i_employee_id," +
                "@i_first_name, " +
                "@i_last_name, " +
                "@i_email, " +
                "@i_hire_date, " +
                "@i_department_id, " +
                "@i_create_name)";
            try
            {
                await conn.ExecuteAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing stored procedure: " + ex.Message);
                throw;
            }
        }

        public async Task CallSpUpdate(EmployeeDto employee)
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            var parameters = new
            {
                i_employee_id = employee.EmployeeId,
                i_first_name = employee.FirstName,
                i_last_name = employee.LastName,
                i_email = employee.Email,
                i_hire_date = employee.HireDate,
                i_department_id = employee.DepartmentId,
            };
            var sql = "CALL dara_sp_update_employee" +
                "(@i_employee_id, " +
                "@i_first_name, " +
                "@i_last_name, " +
                "@i_email, " +
                "@i_hire_date, " +
                "@i_department_id) ";
            try
            {
                await conn.ExecuteAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing stored procedure: " + ex.Message);
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using var conn = GetConnection();
            var sql = "DELETE FROM dara_employees WHERE employee_id = @Id";
            await conn.ExecuteAsync(sql, new { Id = id });
        }
    }

}
