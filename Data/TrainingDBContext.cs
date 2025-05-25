using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Cryptography;
using training.Models.Domain;

namespace training.Data
{
    public class TrainingDBContext : DbContext
    {
        public TrainingDBContext(DbContextOptions<TrainingDBContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Department>().HasData(
                new Department { 
                    DepartmentId = Guid.Parse("d4e5c630-ecaa-4f6b-a8c7-1d47c7a5f91a"), 
                    Name = "Human Resources" },
                new Department { 
                    DepartmentId = Guid.Parse("7b7f2a1b-dc3e-4c7c-b514-92fcf015cb57"), 
                    Name = "Software Development" },
                new Department { 
                    DepartmentId = Guid.Parse("32c61738-f1e5-4b8e-9c42-5cb78a16012a"), 
                    Name = "Quality Assurance" },
                new Department { 
                    DepartmentId = Guid.Parse("1e21aa4d-35db-43c0-a2e0-d5e155582cb5"), 
                    Name = "IT Support" },
                new Department { 
                    DepartmentId = Guid.Parse("47cc9f6a-6a0f-4c12-9b96-82a1c57f9b71"), 
                    Name = "DevOps" },
                new Department { 
                    DepartmentId = Guid.Parse("6e420738-b23c-41c4-82f3-fd6d0a6a5f58"), 
                    Name = "Product Management" },
                new Department { 
                    DepartmentId = Guid.Parse("64b63eec-bb98-4121-bdf8-940ee1de9150"), 
                    Name = "Sales and Marketing" },
                new Department { 
                    DepartmentId = Guid.Parse("9400ed2a-2ae6-453f-9130-14e46e10553a"), 
                    Name = "Finance and Accounting" },
                new Department { 
                    DepartmentId = Guid.Parse("adf08c7e-7c09-4ef3-bb9c-f4993a2b41aa"), 
                    Name = "UI/UX Design" },
                new Department { 
                    DepartmentId = Guid.Parse("ec7e2c46-166a-43a4-8c03-1b206a35f159"), 
                    Name = "Cybersecurity" }
            );
        }
    }
}
