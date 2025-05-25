using training.Models.DTO;

namespace training.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentDto>> GetDepartment();
    }
}
