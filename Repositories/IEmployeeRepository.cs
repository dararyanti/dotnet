using training.Models.Domain;
using training.Models.DTO;

namespace training.Repositories
{
    public interface IEmployeeRepository
    {
        Task<(IEnumerable<GetEmployeeDto> Data, int TotalCount)> GetEmployeeFiltered(
            int pageNumber,
            int pageSize,
            string sortColumn,
            string sortDirection,
            string? searchTerm);
        Task<GetEmployeeDto?> GetEmployeeById(Guid id);
        Task CallSpInsert(EmployeeDto employee);
        Task CallSpUpdate(EmployeeDto employee);
        Task DeleteAsync(Guid id);
    }
}
