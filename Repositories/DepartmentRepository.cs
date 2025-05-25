using Microsoft.EntityFrameworkCore;
using training.Data;
using training.Models.DTO;

namespace training.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly TrainingDBContext _context;

        public DepartmentRepository(TrainingDBContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentDto>> GetDepartment()
        {
            return await _context.Departments
                .Select(e => new DepartmentDto
                {
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.Name
                })
                .ToListAsync();
        }
    }
}
